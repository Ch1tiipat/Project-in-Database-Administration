Imports System.Data
Imports System.Data.SqlClient

Public Class FromEditPatientAppointment1

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- schema helpers ----------
    Private Function ColumnExists(cn As SqlConnection, tableOrView As String, col As String) As Boolean
        Const sql As String = "
            SELECT 1
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", tableOrView)
            cmd.Parameters.AddWithValue("@c", col)
            Return cmd.ExecuteScalar() IsNot Nothing
        End Using
    End Function

    Private Function PickCol(cn As SqlConnection, tableOrView As String, ParamArray candidates() As String) As String
        For Each c In candidates
            If ColumnExists(cn, tableOrView, c) Then Return c
        Next
        Return Nothing
    End Function

    Private Sub FromEditPatientAppointment1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
    End Sub

    Private Sub LoadGrid(Optional keyword As String = "")
        Using cn = Conn()
            cn.Open()

            Dim v As String = "vw_PatientAppointments"

            ' columns ที่ต้องมี
            Dim idCol As String = PickCol(cn, v, "Appointment_ID", "Appt_ID", "ID")
            Dim nameCol As String = PickCol(cn, v, "PatientName", "Patient_Name", "Full_Name", "Name")
            Dim dateCol As String = PickCol(cn, v, "Appt_Date", "AppointmentDate", "Appointment_Date", "ApptDate")
            Dim roomCol As String = PickCol(cn, v, "ExaminationRoom", "ExamRoom", "Room")
            Dim statusCol As String = PickCol(cn, v, "Status", "ApptStatus", "Appointment_Status")

            If String.IsNullOrEmpty(idCol) Then Throw New Exception("dbo.vw_PatientAppointments: ไม่พบคอลัมน์รหัสนัด")
            If String.IsNullOrEmpty(dateCol) Then Throw New Exception("dbo.vw_PatientAppointments: ไม่พบคอลัมน์วันที่นัด")
            If String.IsNullOrEmpty(nameCol) Then Throw New Exception("dbo.vw_PatientAppointments: ไม่พบคอลัมน์ชื่อผู้ป่วย")

            ' ----- วอร์ด: แสดงเฉพาะ 'ชื่อวอร์ด' -----
            ' ----- วอร์ด: แสดงเฉพาะ "ชื่อวอร์ด" -----
            Dim wardNameCol As String = PickCol(cn, v, "WardName", "Ward_Name")
            Dim wardOneCol As String = PickCol(cn, v, "Ward")

            Dim wardSelect As String
            If Not String.IsNullOrEmpty(wardNameCol) Then
                wardSelect = $"CAST({wardNameCol} AS nvarchar(200)) AS Ward"
            ElseIf Not String.IsNullOrEmpty(wardOneCol) Then
                ' ปกติค่าจะเป็น "01 – Orthopaedic" หรือ "02 — Geriatric"
                ' แปลงทุกชนิดของ dash เป็น '-' แล้วตัดส่วนหลังขีด + Trim ซ้าย
                Dim norm = $"REPLACE(REPLACE({wardOneCol}, N'—', N'-'), N'–', N'-')" ' em-dash & en-dash → hyphen
                wardSelect =
        $"CAST(LTRIM(CASE " &
        $"WHEN CHARINDEX('-', {norm}) > 0 " &
        $"THEN SUBSTRING({norm}, CHARINDEX('-', {norm}) + 1, 400) " &
        $"ELSE {norm} END) AS nvarchar(200)) AS Ward"
            Else
                wardSelect = "NULL AS Ward"
            End If


            ' SELECT
            Dim sql As String =
$"SELECT {idCol} AS Appointment_ID,
         {nameCol} AS PatientName,
         {wardSelect},
         {dateCol} AS Appt_Date,
         {If(String.IsNullOrEmpty(roomCol), "NULL", roomCol)} AS ExaminationRoom,
         {If(String.IsNullOrEmpty(statusCol), "NULL", statusCol)} AS Status
  FROM dbo.{v}"

            ' ค้นหา
            If Not String.IsNullOrWhiteSpace(keyword) Then
                Dim likes As New List(Of String) From {$"{nameCol} LIKE @kw"}
                If Not String.IsNullOrEmpty(wardNameCol) Then likes.Add($"{wardNameCol} LIKE @kw")
                If Not String.IsNullOrEmpty(wardOneCol) Then likes.Add($"{wardOneCol} LIKE @kw")
                If Not String.IsNullOrEmpty(roomCol) Then likes.Add($"{roomCol} LIKE @kw")
                If Not String.IsNullOrEmpty(statusCol) Then likes.Add($"{statusCol} LIKE @kw")
                If likes.Count > 0 Then sql &= " WHERE " & String.Join(" OR ", likes)
            End If

            sql &= $" ORDER BY {dateCol} DESC, {idCol} DESC"

            Using da As New SqlDataAdapter(sql, cn)
                If Not String.IsNullOrWhiteSpace(keyword) Then
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" & keyword.Trim() & "%")
                End If
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
    End Sub

    Private Sub btn_SearchApoint_Click(sender As Object, e As EventArgs) Handles btn_SearchApoint.Click
        LoadGrid(txtb_SeacrhPtnApoint.Text)
    End Sub

    Private Sub btn_AddPtnApoint_Click(sender As Object, e As EventArgs) Handles btn_AddPtnApoint.Click
        Using f As New FormAddPatientAppointment()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_SeacrhPtnApoint.Text)
            End If
        End Using
    End Sub

    Private Function SelectedAppointmentId() As Integer
        If DataGridView1.CurrentRow Is Nothing Then Return 0
        Dim obj = DataGridView1.CurrentRow.Cells("Appointment_ID").Value
        If obj Is Nothing OrElse obj Is DBNull.Value Then Return 0
        Return CInt(obj)
    End Function

    Private Sub btn_EditPtnApoint_Click(sender As Object, e As EventArgs) Handles btn_EditPtnApoint.Click
        Dim apptId = SelectedAppointmentId()
        If apptId = 0 Then
            MessageBox.Show("กรุณาเลือกแถวที่จะแก้ไขก่อน", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FromEditPatientAppointment2()
            f.AppointmentId = apptId
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_SeacrhPtnApoint.Text)
            End If
        End Using
    End Sub

End Class
