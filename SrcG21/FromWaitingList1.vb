Imports System.Data
Imports System.Data.SqlClient

Public Class FromWaitingList1

    ' ===== ปรับให้ตรงเครื่องของคุณ =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    ' ====================================

    ' RowID จะถูกเซ็ตมาจากหน้ารายการ
    Public Property RowID As Integer = 0

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- Utils ----------
    Private Function ColumnExists(cn As SqlConnection, tableOrView As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", tableOrView)
            cmd.Parameters.AddWithValue("@c", col)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    ' หา PK column ของ Waiting_List
    Private Function DetectIdColumn(cn As SqlConnection) As String
        For Each colName As String In New String() {"Waiting_ID", "WaitingList_ID", "ID"}
            If ColumnExists(cn, "Waiting_List", colName) Then Return colName
        Next
        Return "Waiting_ID"
    End Function

    ' ---------- Load lookups ----------
    Private Sub LoadPatients()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter(
                    "SELECT CAST(Patient_ID AS int) AS Patient_ID,
                            (FirstName + ' ' + LastName) AS PatientName
                       FROM dbo.Patient
                   ORDER BY PatientName;", cn)
                    da.Fill(dt)
                End Using

                cmb_panid.DisplayMember = "PatientName"
                cmb_panid.ValueMember = "Patient_ID"
                cmb_panid.DataSource = dt
                cmb_panid.DropDownStyle = ComboBoxStyle.DropDownList
            End Using
        Catch ex As Exception
            cmb_panid.DataSource = Nothing
            MessageBox.Show("โหลดรายชื่อผู้ป่วยไม่ได้: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadWards()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter(
                    "SELECT WardNumber, WardName FROM dbo.Ward ORDER BY WardName;", cn)
                    da.Fill(dt)
                End Using

                ' แสดงทั้งชื่อและไอดีในดรอปดาวน์
                dt.Columns.Add("WardDisplay", GetType(String))
                For Each r As DataRow In dt.Rows
                    r("WardDisplay") = $"{r("WardName")} (#{r("WardNumber")})"
                Next

                cmb_ward.DisplayMember = "WardDisplay"
                cmb_ward.ValueMember = "WardNumber"
                cmb_ward.DataSource = dt
                cmb_ward.DropDownStyle = ComboBoxStyle.DropDownList
            End Using
        Catch ex As Exception
            cmb_ward.DataSource = Nothing
            MessageBox.Show("โหลดวอร์ดไม่ได้: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStatus()
        cmb_status.Items.Clear()
        cmb_status.Items.Add("Waiting")
        cmb_status.Items.Add("Bed Assigned")
        cmb_status.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' ---------- Load record ----------
    Private Sub LoadRecord()
        If RowID <= 0 Then Return

        Try
            Using cn = Conn()
                cn.Open()
                Dim idCol As String = DetectIdColumn(cn)

                ' ใช้ชื่อคอลัมน์จริง + ตั้ง ALIAS ให้เท่ากับที่ UI ใช้อยู่
                Dim sql As String =
$"SELECT wl.{idCol} AS RowID,
         CAST(wl.Patient_ID AS int) AS Patient_ID,
         wl.Date_Added  AS DateAdded,
         wl.WardNumber  AS WardRequired,
         wl.Status
    FROM dbo.Waiting_List wl
   WHERE wl.{idCol}=@id;"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", RowID)
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            ' patient
                            If Not rd("Patient_ID") Is DBNull.Value Then
                                cmb_panid.SelectedValue = CInt(rd("Patient_ID"))
                            End If
                            ' date
                            If Not rd("DateAdded") Is DBNull.Value Then
                                dtp_date.Value = CDate(rd("DateAdded"))
                            End If
                            ' ward (เก็บเป็นหมายเลขวจ.)
                            If Not rd("WardRequired") Is DBNull.Value Then
                                cmb_ward.SelectedValue = CInt(rd("WardRequired"))
                            End If
                            ' status
                            If Not rd("Status") Is DBNull.Value Then
                                Dim s As String = CStr(rd("Status"))
                                If cmb_status.Items.Contains(s) Then cmb_status.SelectedItem = s
                            End If
                        Else
                            MessageBox.Show("ไม่พบบันทึกรอเตียงนี้", "Info",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                            DialogResult = DialogResult.Cancel
                            Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("โหลดข้อมูลไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------- Save / Update ----------
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If cmb_panid.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือกผู้ป่วย", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If cmb_ward.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือกวอร์ด", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If cmb_status.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือกสถานะ", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If

        Try
            Using cn = Conn()
                cn.Open()
                Dim idCol As String = DetectIdColumn(cn)

                ' UPDATE ต้องใช้ชื่อคอลัมน์จริงใน DB
                Using cmd As New SqlCommand(
$"UPDATE dbo.Waiting_List
    SET Patient_ID = @pid,
        Date_Added  = @dateAdded,
        WardNumber  = @ward,
        Status      = @status
  WHERE {idCol} = @id;", cn)

                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = CInt(cmb_panid.SelectedValue)
                    cmd.Parameters.Add("@dateAdded", SqlDbType.Date).Value = dtp_date.Value.Date
                    cmd.Parameters.Add("@ward", SqlDbType.Int).Value = CInt(cmb_ward.SelectedValue)
                    cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = CStr(cmb_status.SelectedItem)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = RowID

                    Dim n = cmd.ExecuteNonQuery()
                    If n > 0 Then
                        MessageBox.Show("บันทึกเรียบร้อย", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DialogResult = DialogResult.OK
                        Close()
                    Else
                        MessageBox.Show("ไม่พบแถวให้แก้ไข", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------- Delete ----------
    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If RowID <= 0 Then Return
        If MessageBox.Show("ต้องการลบบันทึกนี้หรือไม่?", "Confirm Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using cn = Conn()
                cn.Open()
                Dim idCol As String = DetectIdColumn(cn)

                Using cmd As New SqlCommand($"DELETE FROM dbo.Waiting_List WHERE {idCol}=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", RowID)
                    Dim n = cmd.ExecuteNonQuery()
                    If n > 0 Then
                        MessageBox.Show("ลบเรียบร้อย", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DialogResult = DialogResult.OK
                        Close()
                    Else
                        MessageBox.Show("ไม่พบแถวให้ลบ", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------- Cancel ----------
    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    ' ---------- Form Load ----------
    Private Sub FromWaitingList1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatients()
        LoadWards()
        LoadStatus()
        If RowID > 0 Then LoadRecord()
    End Sub

End Class


