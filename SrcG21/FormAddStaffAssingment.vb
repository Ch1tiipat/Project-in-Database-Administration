Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddStaffAssingment

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- helpers ----------
    Private Function ColumnExists(cn As SqlConnection, table As String, col As String) As Boolean
        Const sql = "SELECT 1
                     FROM INFORMATION_SCHEMA.COLUMNS
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

    ' ---------- load UI ----------
    Private Sub FormAddStaffAssingment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStaff()   ' ← ดึงทั้งชื่อ + ตำแหน่ง
        LoadWards()
        LoadShifts()

        ' (ออปชัน) ไม่อยากให้แก้ตำแหน่งด้วยมือ ก็ล็อกไว้:
        'txtb_pos.ReadOnly = True
    End Sub

    Private Sub LoadShifts()
        Using cn = Conn()
            cn.Open()
            Dim keyCol = If(ColumnExists(cn, "Shift", "ShiftID"), "ShiftID",
                        If(ColumnExists(cn, "Shift", "Shift_ID"), "Shift_ID", Nothing))
            If keyCol Is Nothing Then Throw New Exception("ไม่พบคอลัมน์ ID ในตาราง Shift (ShiftID/Shift_ID)")

            Dim dt As New DataTable()
            Using da As New SqlDataAdapter($"SELECT {keyCol} AS ShiftKey, Shift_Type FROM dbo.[Shift] ORDER BY {keyCol}", cn)
                da.Fill(dt)
            End Using
            cmb_shift.DisplayMember = "Shift_Type"
            cmb_shift.ValueMember = "ShiftKey"
            cmb_shift.DataSource = dt
            cmb_shift.DropDownStyle = ComboBoxStyle.DropDownList
            cmb_shift.AutoCompleteSource = AutoCompleteSource.ListItems
            cmb_shift.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    Private Sub LoadStaff()
        Using cn = Conn()
            cn.Open()
            Dim staffIdCol = If(ColumnExists(cn, "Staff", "StaffID"), "StaffID",
                            If(ColumnExists(cn, "Staff", "Staff_ID"), "Staff_ID", Nothing))
            If staffIdCol Is Nothing Then Throw New Exception("ไม่พบคอลัมน์ StaffID/Staff_ID ในตาราง Staff")

            ' หา column "ตำแหน่ง" ในตาราง Staff แบบยืดหยุ่น
            Dim posColInStaff = PickCol(cn, "Staff", "Position", "StaffPosition", "Role", "JobTitle")

            Dim sql As String =
                $"SELECT {staffIdCol} AS Staff_ID,
                          LTRIM(RTRIM(ISNULL(FirstName,''))) +
                          CASE WHEN ISNULL(LastName,'')<>'' THEN ' ' + LastName ELSE '' END AS StaffName, " &
                If(posColInStaff IsNot Nothing,
                   $"CAST({posColInStaff} AS NVARCHAR(100)) AS Pos",
                   "CAST(NULL AS NVARCHAR(100)) AS Pos") &
                " FROM dbo.Staff
                  ORDER BY StaffName"

            Dim dt As New DataTable()
            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using

            StaffIDAssAdd.DisplayMember = "StaffName"
            StaffIDAssAdd.ValueMember = "Staff_ID"
            StaffIDAssAdd.DataSource = dt
            StaffIDAssAdd.DropDownStyle = ComboBoxStyle.DropDownList
            StaffIDAssAdd.AutoCompleteSource = AutoCompleteSource.ListItems
            StaffIDAssAdd.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            ' เซ็ตตำแหน่งเริ่มต้นตามรายการแรก (ถ้ามี)
            UpdatePositionFromSelected()
        End Using
    End Sub

    ' เมื่อเลือกสตาฟ เปลี่ยนตำแหน่งอัตโนมัติ
    Private Sub StaffIDAssAdd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StaffIDAssAdd.SelectedIndexChanged
        UpdatePositionFromSelected()
    End Sub

    Private Sub UpdatePositionFromSelected()
        Dim drv As DataRowView = TryCast(StaffIDAssAdd.SelectedItem, DataRowView)
        If drv IsNot Nothing AndAlso drv.DataView IsNot Nothing AndAlso
           drv.DataView.Table.Columns.Contains("Pos") Then
            txtb_pos.Text = If(drv("Pos") Is DBNull.Value, "", CStr(drv("Pos")))
        Else
            txtb_pos.Text = "" ' ไม่มีคอลัมน์ตำแหน่งในตาราง Staff
        End If
    End Sub

    Private Sub LoadWards()
        Using cn = Conn()
            cn.Open()
            Dim keyCol = If(ColumnExists(cn, "Ward", "WardNumber"), "WardNumber",
                        If(ColumnExists(cn, "Ward", "Ward_No"), "Ward_No",
                        If(ColumnExists(cn, "Ward", "Ward_ID"), "Ward_ID",
                        If(ColumnExists(cn, "Ward", "CN_ID"), "CN_ID", Nothing))))
            If keyCol Is Nothing Then Throw New Exception("ไม่พบคีย์ในตาราง Ward")

            Dim dt As New DataTable()
            Using da As New SqlDataAdapter($"SELECT {keyCol} AS WardKey, WardName FROM dbo.Ward ORDER BY WardName", cn)
                da.Fill(dt)
            End Using
            If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
            For Each r As DataRow In dt.Rows
                r("Display") = $"{CStr(r("WardKey"))} — {CStr(r("WardName"))}"
            Next

            cmb_Wname.DisplayMember = "Display"
            cmb_Wname.ValueMember = "WardKey"
            cmb_Wname.DataSource = dt
            cmb_Wname.DropDownStyle = ComboBoxStyle.DropDownList
            cmb_Wname.AutoCompleteSource = AutoCompleteSource.ListItems
            cmb_Wname.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    ' ---------- add ----------
    Private Sub btn_addAss_Click(sender As Object, e As EventArgs) Handles btn_addAss.Click
        If StaffIDAssAdd.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Staff", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If cmb_Wname.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Ward", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If cmb_shift.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Shift", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If

        Try
            Using cn = Conn()
                cn.Open()

                Dim t = "StaffAssignment"
                Dim staffCol = PickCol(cn, t, "StaffID", "Staff_ID")
                Dim wardCol = PickCol(cn, t, "WardNumber", "Ward_No", "Ward_ID", "CN_ID")
                Dim posCol = PickCol(cn, t, "Position", "StaffPosition")   ' คอลัมน์ตำแหน่งใน StaffAssignment (ถ้ามี)
                Dim weekCol = PickCol(cn, t, "WeekID", "WeekNo", "Week")    ' ใช้ค่าที่ผู้ใช้กรอก (ไม่อิงตาราง Week)
                Dim shiftIdCol = PickCol(cn, t, "ShiftID", "Shift_ID")
                Dim roleInShiftCol = PickCol(cn, t, "Role_In_Shift")
                Dim shiftTxtCol = PickCol(cn, t, "Shift", "Shift_Type")

                If String.IsNullOrEmpty(staffCol) OrElse String.IsNullOrEmpty(wardCol) Then
                    Throw New Exception("ตาราง StaffAssignment ไม่พบคอลัมน์ Staff/Ward")
                End If
                If String.IsNullOrEmpty(weekCol) Then
                    Throw New Exception("ตาราง StaffAssignment ไม่พบคอลัมน์สัปดาห์ (WeekID/WeekNo/Week)")
                End If

                ' ใช้ค่าที่ผู้ใช้กรอกเป็นเลขสัปดาห์ตรง ๆ
                Dim weekVal As Object
                Dim wk As Integer
                If Integer.TryParse(TextBox1.Text.Trim(), wk) Then
                    weekVal = wk
                Else
                    weekVal = DBNull.Value
                End If

                Dim cols As New List(Of String) From {staffCol, wardCol, weekCol}
                Dim vals As New List(Of String) From {"@sid", "@ward", "@week"}

                ' เติมตำแหน่งอัตโนมัติลงตาราง (ถ้ามีคอลัมน์)
                If Not String.IsNullOrEmpty(posCol) Then cols.Add(posCol) : vals.Add("@pos")

                If Not String.IsNullOrEmpty(shiftIdCol) Then
                    cols.Add(shiftIdCol) : vals.Add("@shift_id")
                ElseIf Not String.IsNullOrEmpty(shiftTxtCol) Then
                    cols.Add(shiftTxtCol) : vals.Add("@shift_txt")
                ElseIf Not String.IsNullOrEmpty(roleInShiftCol) Then
                    cols.Add(roleInShiftCol) : vals.Add("@shift_id")
                Else
                    Throw New Exception("ไม่พบคอลัมน์สำหรับเก็บกะ (ShiftID/Shift_ID/Role_In_Shift/Shift)")
                End If

                Dim addRoleInShiftToo As Boolean =
                    (Not String.IsNullOrEmpty(shiftIdCol) AndAlso
                     Not String.IsNullOrEmpty(roleInShiftCol) AndAlso
                     Not cols.Contains(roleInShiftCol))
                If addRoleInShiftToo Then
                    cols.Add(roleInShiftCol) : vals.Add("@role_in_shift")
                End If

                Dim sql = $"INSERT INTO dbo.{t}({String.Join(",", cols)}) VALUES({String.Join(",", vals)});"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = CInt(StaffIDAssAdd.SelectedValue)
                    cmd.Parameters.Add("@ward", SqlDbType.Int).Value = CInt(cmb_Wname.SelectedValue)

                    Dim pWeek = cmd.Parameters.Add("@week", SqlDbType.Int)
                    pWeek.Value = weekVal

                    If vals.Contains("@pos") Then
                        ' ใช้ค่าจาก txtb_pos ที่ถูกเติมอัตโนมัติ
                        cmd.Parameters.Add("@pos", SqlDbType.NVarChar, 100).Value =
                            If(String.IsNullOrWhiteSpace(txtb_pos.Text), CType(DBNull.Value, Object), txtb_pos.Text.Trim())
                    End If

                    Dim selId As Integer = CInt(cmb_shift.SelectedValue)
                    Dim selText As String = cmb_shift.Text

                    If vals.Contains("@shift_id") Then
                        cmd.Parameters.Add("@shift_id", SqlDbType.Int).Value = selId
                    End If
                    If vals.Contains("@shift_txt") Then
                        cmd.Parameters.Add("@shift_txt", SqlDbType.NVarChar, 50).Value = selText
                    End If
                    If vals.Contains("@role_in_shift") Then
                        cmd.Parameters.Add("@role_in_shift", SqlDbType.Int).Value = selId
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("เพิ่ม Staff Assignment เรียบร้อย", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException
            If ex.Number = 2627 OrElse ex.Number = 2601 Then
                MessageBox.Show("รายการซ้ำ: ห้ามมีชุด (Staff, Week, Shift) ซ้ำ", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("บันทึกไม่สำเร็จ (SQL): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bnt_addCan_Click(sender As Object, e As EventArgs) Handles bnt_addCan.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class








