Imports System.Data
Imports System.Data.SqlClient

Public Class FromstaffAssingmentEdit

    ' รับค่า AssignmentID จากหน้ารายการ
    Public Property RowID As Integer

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ===== helpers =====
    Private Function ColumnExists(cn As SqlConnection, table As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                     WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", table)
            cmd.Parameters.AddWithValue("@c", col)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    Private Function PickCol(cn As SqlConnection, table As String, ParamArray cands() As String) As String
        For Each c In cands
            If ColumnExists(cn, table, c) Then Return c
        Next
        Return Nothing
    End Function

    Private _table As String = "StaffAssignment"
    Private _idCol As String = "AssignmentID"
    Private _staffCol As String = "StaffID"
    Private _wardCol As String = "WardNumber"
    Private _posCol As String = Nothing         ' (optional) ตำแหน่งใน StaffAssignment ถ้ามี
    Private _weekCol As String = "WeekID"
    Private _shiftIdCol As String = "ShiftID"   ' ใช้ ShiftID

    ' จำคอลัมน์ "ตำแหน่ง" ฝั่ง Staff ไว้เพื่อดึงมาโชว์อัตโนมัติ
    Private _posColInStaff As String = Nothing

    Private Sub DetectCols(cn As SqlConnection)
        ' PK
        For Each c In {"AssignmentID", "Assign_ID", "ID"}
            If ColumnExists(cn, _table, c) Then _idCol = c : Exit For
        Next
        ' Staff / Ward / Week / ShiftID / Position (ถ้ามี)
        _staffCol = PickCol(cn, _table, "StaffID", "Staff_ID")
        _wardCol = PickCol(cn, _table, "WardNumber", "Ward_No", "Ward_ID")
        _weekCol = PickCol(cn, _table, "WeekID", "Week", "WeekNo")
        _shiftIdCol = PickCol(cn, _table, "ShiftID")  ' ต้องมี
        _posCol = PickCol(cn, _table, "Position", "StaffPosition")

        ' ตำแหน่งใน Staff (ไว้ใช้ auto-fill)
        _posColInStaff = PickCol(cn, "Staff", "Position", "StaffPosition", "Role", "JobTitle")
    End Sub

    Private Sub FromstaffAssingmentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadShifts()  ' โหลดจากตาราง Shift
        LoadStaff()   ' โหลดรายชื่อพนักงาน (รวมคอลัมน์ตำแหน่ง)
        LoadWards()   ' โหลดวอร์ด

        Using cn = Conn()
            cn.Open()
            DetectCols(cn)

            ' ดึงค่าปัจจุบันของ Assignment นี้
            Dim sql As String =
$"SELECT {_idCol}                                         AS AssignmentID,
        {_staffCol}                                      AS Staff_ID,
        {_wardCol}                                       AS WardNumber,
        {If(String.IsNullOrEmpty(_posCol), "NULL", _posCol)} AS Position,
        {If(String.IsNullOrEmpty(_weekCol), "NULL", _weekCol)} AS WeekID,
        {_shiftIdCol}                                    AS ShiftID
   FROM dbo.{_table}
  WHERE {_idCol}=@id;"

            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", RowID)
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        ' ตั้งค่าจากแถวเดิม
                        If Not rd.IsDBNull(rd.GetOrdinal("Staff_ID")) Then ComboBox1SSASS.SelectedValue = CInt(rd("Staff_ID"))
                        If Not rd.IsDBNull(rd.GetOrdinal("WardNumber")) Then cmb_editstaffname.SelectedValue = CInt(rd("WardNumber"))
                        If Not rd.IsDBNull(rd.GetOrdinal("Position")) Then txtb_editstaffpos.Text = rd("Position").ToString() Else txtb_editstaffpos.Clear()
                        If Not rd.IsDBNull(rd.GetOrdinal("WeekID")) Then TextBox1.Text = rd("WeekID").ToString() Else TextBox1.Clear()
                        If Not rd.IsDBNull(rd.GetOrdinal("ShiftID")) Then cmb_editstaffshift.SelectedValue = CInt(rd("ShiftID")) Else cmb_editstaffshift.SelectedIndex = -1
                    End If
                End Using
            End Using

            ' หลังจากโหลดค่าเดิมแล้ว ให้เติมตำแหน่งจาก Staff อัตโนมัติอีกครั้งเพื่อให้ sync ตามคนที่เลือกปัจจุบัน
            UpdatePositionFromSelected()
        End Using
    End Sub

    Private Sub LoadShifts()
        ' โหลดจากตาราง Shift → Value = ShiftID, Display = Shift_Type
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("SELECT ShiftID, Shift_Type FROM dbo.[Shift] ORDER BY ShiftID", cn)
                da.Fill(dt)
            End Using
            cmb_editstaffshift.DisplayMember = "Shift_Type"
            cmb_editstaffshift.ValueMember = "ShiftID"
            cmb_editstaffshift.DataSource = dt
            cmb_editstaffshift.DropDownStyle = ComboBoxStyle.DropDownList
        End Using
    End Sub

    Private Sub LoadStaff()
        Using cn = Conn()
            cn.Open()
            ' รองรับทั้ง StaffID และ Staff_ID
            Dim staffIdCol = If(ColumnExists(cn, "Staff", "StaffID"), "StaffID", "Staff_ID")

            ' หา column "ตำแหน่ง" ในตาราง Staff แบบยืดหยุ่น
            _posColInStaff = PickCol(cn, "Staff", "Position", "StaffPosition", "Role", "JobTitle")

            Dim sql As String =
                $"SELECT {staffIdCol} AS Staff_ID,
                          LTRIM(RTRIM(ISNULL(FirstName,''))) +
                          CASE WHEN ISNULL(LastName,'')<>'' THEN ' ' + LastName ELSE '' END AS StaffName, " &
                If(_posColInStaff IsNot Nothing,
                   $"CAST({_posColInStaff} AS NVARCHAR(100)) AS Pos",
                   "CAST(NULL AS NVARCHAR(100)) AS Pos") &
                " FROM dbo.Staff
                  ORDER BY StaffName"

            Dim dt As New DataTable()
            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using

            ComboBox1SSASS.DisplayMember = "StaffName"
            ComboBox1SSASS.ValueMember = "Staff_ID"
            ComboBox1SSASS.DataSource = dt
            ComboBox1SSASS.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox1SSASS.AutoCompleteSource = AutoCompleteSource.ListItems
            ComboBox1SSASS.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            ' เซ็ตตำแหน่งเริ่มต้นตามรายการแรก (ถ้ามี)
            UpdatePositionFromSelected()
        End Using
    End Sub

    Private Sub ComboBox1SSASS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1SSASS.SelectedIndexChanged
        UpdatePositionFromSelected()
    End Sub

    Private Sub UpdatePositionFromSelected()
        ' เติม txtb_editstaffpos จากคอลัมน์ Pos ใน DataSource ของ ComboBox1SSASS
        Dim drv As DataRowView = TryCast(ComboBox1SSASS.SelectedItem, DataRowView)
        If drv IsNot Nothing AndAlso drv.DataView IsNot Nothing AndAlso
           drv.DataView.Table.Columns.Contains("Pos") Then
            txtb_editstaffpos.Text = If(drv("Pos") Is DBNull.Value, "", CStr(drv("Pos")))
        End If
    End Sub

    Private Sub LoadWards()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("SELECT WardNumber, WardName FROM dbo.Ward ORDER BY WardNumber", cn)
                da.Fill(dt)
            End Using
            If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
            For Each r As DataRow In dt.Rows
                r("Display") = $"{CInt(r("WardNumber")):00} — {CStr(r("WardName"))}"
            Next

            cmb_editstaffname.DisplayMember = "Display"
            cmb_editstaffname.ValueMember = "WardNumber"
            cmb_editstaffname.DataSource = dt
            cmb_editstaffname.DropDownStyle = ComboBoxStyle.DropDownList
            cmb_editstaffname.AutoCompleteSource = AutoCompleteSource.ListItems
            cmb_editstaffname.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    ' Save (UPDATE)
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If ComboBox1SSASS.SelectedItem Is Nothing OrElse
           cmb_editstaffname.SelectedItem Is Nothing OrElse
           cmb_editstaffshift.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Staff / Ward / Shift", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using cn = Conn()
                cn.Open()
                DetectCols(cn)

                Dim setList As New List(Of String) From {
                    $"{_staffCol}=@sid",
                    $"{_wardCol}=@ward",
                    $"{_shiftIdCol}=@shiftId"
                }
                If Not String.IsNullOrEmpty(_posCol) Then setList.Add($"{_posCol}=@pos")
                If Not String.IsNullOrEmpty(_weekCol) Then setList.Add($"{_weekCol}=@week")

                Dim sql = $"UPDATE dbo.{_table} SET {String.Join(","c, setList)} WHERE {_idCol}=@id"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = RowID
                    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = CInt(ComboBox1SSASS.SelectedValue)
                    cmd.Parameters.Add("@ward", SqlDbType.Int).Value = CInt(cmb_editstaffname.SelectedValue)
                    cmd.Parameters.Add("@shiftId", SqlDbType.Int).Value = CInt(cmb_editstaffshift.SelectedValue)

                    If sql.Contains("@pos") Then
                        ' ใช้ค่าที่ auto-fill ไว้ใน textbox
                        cmd.Parameters.Add("@pos", SqlDbType.NVarChar, 100).Value =
                            If(String.IsNullOrWhiteSpace(txtb_editstaffpos.Text), CType(DBNull.Value, Object), txtb_editstaffpos.Text.Trim())
                    End If
                    If sql.Contains("@week") Then
                        Dim wk As Integer
                        If Integer.TryParse(TextBox1.Text.Trim(), wk) Then
                            cmd.Parameters.Add("@week", SqlDbType.Int).Value = wk
                        Else
                            cmd.Parameters.Add("@week", SqlDbType.Int).Value = DBNull.Value
                        End If
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("บันทึกแล้ว", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Delete
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If MessageBox.Show("ต้องการลบรายการนี้หรือไม่?", "Confirm",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Using cn = Conn()
                cn.Open()
                DetectCols(cn)
                Using cmd As New SqlCommand($"DELETE FROM dbo.{_table} WHERE {_idCol}=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = RowID
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("ลบแล้ว", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
