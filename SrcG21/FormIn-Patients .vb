Imports System.Data
Imports System.Data.SqlClient

Public Class FormIn_Patients

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ===== helpers =====
    Private Function ColumnExists(cn As SqlConnection, tableOrView As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                     WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", tableOrView)
            cmd.Parameters.AddWithValue("@c", col)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    Private Function PickCol(cn As SqlConnection, tableOrView As String, ParamArray candidates() As String) As String
        For Each c In candidates
            If ColumnExists(cn, tableOrView, c) Then Return c
        Next
        Return ""
    End Function

    Private Sub FormIn_Patients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
    End Sub

    Private Sub LoadGrid(Optional keyword As String = "")
        Const viewName = "vw_InPatientStatus"

        Using cn = Conn()
            cn.Open()

            ' ---- ลองดึงจาก VIEW ก่อน (ถ้า VIEW มีชื่อผู้ป่วย) ----
            Dim idCol = PickCol(cn, viewName, "Inpatient_ID", "InpatientID", "InpatientId", "ID")
            Dim wardCol = PickCol(cn, viewName, "WardName", "Ward", "Ward_Name")
            Dim bedCol = PickCol(cn, viewName, "BedNumber", "Bed_No", "BedNo", "Bed", "Bed_ID", "Bed_Number")
            Dim dateCol = PickCol(cn, viewName, "DateInWard", "Date_In_Ward", "DateIn", "AdmitDate")
            Dim patientNameCol = PickCol(cn, viewName, "PatientName", "FullName", "Name")
            Dim firstColInView = PickCol(cn, viewName, "FirstName", "Firstname")
            Dim lastColInView = PickCol(cn, viewName, "LastName", "Lastname")

            Dim sql As String = ""

            If idCol <> "" AndAlso wardCol <> "" AndAlso bedCol <> "" AndAlso dateCol <> "" AndAlso
               (patientNameCol <> "" OrElse (firstColInView <> "" AndAlso lastColInView <> "")) Then

                ' CASE A: VIEW มีชื่อผู้ป่วย
                If patientNameCol <> "" Then
                    sql =
$"SELECT {idCol}   AS Inpatient_ID,
        {wardCol} AS WardName,
        {bedCol}  AS BedNumber,
        {dateCol} AS DateInWard,
        {patientNameCol} AS PatientName
   FROM dbo.{viewName}"
                Else
                    sql =
$"SELECT {idCol}   AS Inpatient_ID,
        {wardCol} AS WardName,
        {bedCol}  AS BedNumber,
        {dateCol} AS DateInWard,
        ({firstColInView} + ' ' + {lastColInView}) AS PatientName
   FROM dbo.{viewName}"
                End If

                If Not String.IsNullOrWhiteSpace(keyword) Then
                    sql &= $" WHERE {wardCol} LIKE @kw
                              OR CONVERT(varchar(10), {dateCol}, 120) LIKE @kw
                              OR CAST({bedCol} AS varchar(10)) LIKE @kw
                              OR {If(patientNameCol <> "", patientNameCol, firstColInView & " + ' ' + " & lastColInView)} LIKE @kw"
                End If

                sql &= $" ORDER BY {dateCol} DESC, {idCol} DESC"

            Else
                ' ---- CASE B: VIEW ไม่มีชื่อผู้ป่วย → Fallback: In_Patient JOIN Patient ----
                Dim ipTable = "In_Patient"
                Dim ipIdCol = PickCol(cn, ipTable, "Inpatient_ID", "InpatientID", "ID")
                Dim ipWardName = PickCol(cn, ipTable, "Ward_Required") ' เป็นชื่อวอร์ดอยู่แล้ว
                Dim ipBedCol = PickCol(cn, ipTable, "Bed_Number", "BedNumber", "BedNo")
                Dim ipDateCol = PickCol(cn, ipTable, "DateInWard", "Date_In_Ward", "AdmitDate")
                Dim ipPidCol = PickCol(cn, ipTable, "PatientID", "Patient_ID")

                If ipIdCol = "" OrElse ipWardName = "" OrElse ipBedCol = "" OrElse ipDateCol = "" OrElse ipPidCol = "" Then
                    MessageBox.Show("ไม่พบคอลัมน์ที่ต้องใช้ทั้งใน View และ In_Patient", "Schema mismatch",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Patient table columns
                Dim pFirst = PickCol(cn, "Patient", "FirstName", "Firstname")
                Dim pLast = PickCol(cn, "Patient", "LastName", "Lastname")
                Dim pId = PickCol(cn, "Patient", "Patient_ID", "PatientID")

                If pFirst = "" OrElse pLast = "" OrElse pId = "" Then
                    MessageBox.Show("ตาราง Patient ไม่มีคอลัมน์ที่ต้องใช้ (Patient_ID/FirstName/LastName)", "Schema mismatch",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                sql =
$"SELECT ip.{ipIdCol} AS Inpatient_ID,
        ip.{ipWardName} AS WardName,
        ip.{ipBedCol} AS BedNumber,
        ip.{ipDateCol} AS DateInWard,
        (p.{pFirst} + ' ' + p.{pLast}) AS PatientName
   FROM dbo.{ipTable} ip
   INNER JOIN dbo.Patient p ON p.{pId} = ip.{ipPidCol}"

                If Not String.IsNullOrWhiteSpace(keyword) Then
                    sql &= $" WHERE ip.{ipWardName} LIKE @kw
                              OR CONVERT(varchar(10), ip.{ipDateCol}, 120) LIKE @kw
                              OR CAST(ip.{ipBedCol} AS varchar(10)) LIKE @kw
                              OR (p.{pFirst} + ' ' + p.{pLast}) LIKE @kw"
                End If

                sql &= $" ORDER BY ip.{ipDateCol} DESC, ip.{ipIdCol} DESC"
            End If

            Using da As New SqlDataAdapter(sql, cn)
                If Not String.IsNullOrWhiteSpace(keyword) Then
                    da.SelectCommand.Parameters.AddWithValue("@kw", "%" & keyword.Trim() & "%")
                End If
                Dim dt As New DataTable()
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using

        ' ตั้งค่ากริด
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False

        ' จัดลำดับคอลัมน์สวย ๆ ถ้ามี
        If DataGridView1.Columns.Contains("PatientName") Then
            DataGridView1.Columns("PatientName").HeaderText = "Patient"
            DataGridView1.Columns("PatientName").DisplayIndex = 1
        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        LoadGrid(txtb_search.Text)
    End Sub

    Private Function SelectedInpatientId() As Integer
        If DataGridView1.CurrentRow Is Nothing Then Return 0
        Dim v = DataGridView1.CurrentRow.Cells("Inpatient_ID").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return CInt(v)
    End Function

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Using f As New FormAddIn_Patients()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_search.Text)
            End If
        End Using
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim id = SelectedInpatientId()
        If id = 0 Then
            MessageBox.Show("กรุณาเลือกแถวก่อน", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FormIn_Patients1()
            f.InpatientId = id
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_search.Text)
            End If
        End Using
    End Sub

End Class
