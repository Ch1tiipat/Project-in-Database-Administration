Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions

Partial Public Class FormPatientRegistration

    ' ===== ปรับให้ตรงเครื่องของคุณ =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    ' ====================================

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    Private Sub FormPatientRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridView1
            .AutoGenerateColumns = True
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With

        ' รองรับกด Enter เพื่อค้นหา
        AddHandler txtb_SearchPtnRegis.KeyDown, Sub(_s, ke)
                                                    If ke.KeyCode = Keys.Enter Then
                                                        ke.SuppressKeyPress = True
                                                        LoadPatients(txtb_SearchPtnRegis.Text)
                                                    End If
                                                End Sub

        ' เผื่อปุ่ม Search ตั้งชื่อแปลก
        Try
            Dim btn = TryCast(Me.Controls.Find("FormPatientRegistration", True).FirstOrDefault(), Button)
            If btn IsNot Nothing Then
                AddHandler btn.Click, Sub(_s, _e) LoadPatients(txtb_SearchPtnRegis.Text)
            End If
        Catch
        End Try

        ' ปุ่มที่มีอยู่บนฟอร์ม (ถ้ามี)
        Try
            AddHandler btn_SearchPtnRegis.Click, Sub(_s, _e) LoadPatients(txtb_SearchPtnRegis.Text)
        Catch
        End Try

        LoadPatients()
    End Sub

    Private Sub btn_AddPtnRegis_Click(sender As Object, e As EventArgs) Handles btn_AddPtnRegis.Click
        Using f As New FormAddPatientRegistration()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadPatients(txtb_SearchPtnRegis.Text)
            End If
        End Using
    End Sub

    Private Sub btn_EditPtnRegis_Click(sender As Object, e As EventArgs) Handles btn_EditPtnRegis.Click
        Dim pid As Integer = GetSelectedPatientId()
        If pid <= 0 Then
            MessageBox.Show("กรุณาเลือกผู้ป่วยจากตาราง", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FormEditPatientRegistration1()
            f.PatientId = pid
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadPatients(txtb_SearchPtnRegis.Text)
            End If
        End Using
    End Sub

    Private Function GetSelectedPatientId() As Integer
        If DataGridView1.CurrentRow Is Nothing Then Return 0
        Dim obj = DataGridView1.CurrentRow.Cells("Patient_ID").Value
        Dim pid As Integer
        If obj IsNot Nothing AndAlso Integer.TryParse(obj.ToString(), pid) Then Return pid
        Return 0
    End Function

    Private Function HasView(cn As SqlConnection, viewName As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@v"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@v", viewName)
            Return cmd.ExecuteScalar() IsNot Nothing
        End Using
    End Function

    ' ------- Helper: แยกคำค้นด้วย whitespace ทุกชนิด -------
    Private Function SplitTerms(q As String) As List(Of String)
        If String.IsNullOrWhiteSpace(q) Then Return New List(Of String)
        Dim parts = Regex.Split(q.Trim(), "\s+")
        Dim terms As New List(Of String)
        For Each p In parts
            If Not String.IsNullOrWhiteSpace(p) Then terms.Add(p.Trim())
        Next
        Return terms
    End Function

    Private Sub LoadPatients(Optional keyword As String = "")
        Dim dt As New DataTable()
        Using cn = Conn()
            cn.Open()

            Dim useView = HasView(cn, "vw_PatientRegistration")
            Dim terms = SplitTerms(keyword)

            Dim sb As New StringBuilder()

            If useView Then
                ' ===== กรณีมีวิว =====
                sb.AppendLine("SELECT Patient_ID, FirstName, LastName, Sex, BirthDate, P_Tel, Marital_Status, Date_Registered, NextOfKinName")
                sb.AppendLine("FROM dbo.vw_PatientRegistration")
                sb.AppendLine("WHERE 1=1")

                For i As Integer = 0 To terms.Count - 1
                    ' AND ระหว่างคำ, OR ระหว่างคอลัมน์
                    sb.AppendLine($"  AND (CAST(Patient_ID AS nvarchar(20)) LIKE @t{i}" &
                                  $" OR FirstName LIKE @t{i}" &
                                  $" OR LastName LIKE @t{i}" &
                                  $" OR P_Tel LIKE @t{i}" &
                                  $" OR NextOfKinName LIKE @t{i}" &
                                  $" OR Sex LIKE @t{i}" &
                                  $" OR Marital_Status LIKE @t{i}" &
                                  $" OR CONVERT(nvarchar(10), BirthDate, 120) LIKE @t{i}" &
                                  $" OR CONVERT(nvarchar(10), Date_Registered, 120) LIKE @t{i})")
                Next

                sb.AppendLine("ORDER BY Patient_ID")

            Else
                ' ===== กรณีไม่มีวิว: join ตารางโดยตรง =====
                sb.AppendLine("SELECT p.Patient_ID, p.FirstName, p.LastName, p.Sex, p.BirthDate, p.P_Tel, p.Marital_Status, p.Date_Registered,")
                sb.AppendLine("       (nk.FirstName + N' ' + nk.LastName) AS NextOfKinName")
                sb.AppendLine("FROM dbo.Patient p")
                sb.AppendLine("LEFT JOIN dbo.NextOfKin nk ON nk.NextOfKin_ID = p.NextOfKin_ID")
                sb.AppendLine("WHERE 1=1")

                For i As Integer = 0 To terms.Count - 1
                    sb.AppendLine($"  AND (CAST(p.Patient_ID AS nvarchar(20)) LIKE @t{i}" &
                                  $" OR p.FirstName LIKE @t{i}" &
                                  $" OR p.LastName LIKE @t{i}" &
                                  $" OR p.P_Tel LIKE @t{i}" &
                                  $" OR (nk.FirstName + N' ' + nk.LastName) LIKE @t{i}" &
                                  $" OR p.Sex LIKE @t{i}" &
                                  $" OR p.Marital_Status LIKE @t{i}" &
                                  $" OR CONVERT(nvarchar(10), p.BirthDate, 120) LIKE @t{i}" &
                                  $" OR CONVERT(nvarchar(10), p.Date_Registered, 120) LIKE @t{i})")
                Next

                sb.AppendLine("ORDER BY p.Patient_ID")
            End If

            Using da As New SqlDataAdapter(sb.ToString(), cn)
                ' ใส่พารามิเตอร์แบบกำหนดชนิด (เลี่ยง AddWithValue ที่เดา type/length)
                For i As Integer = 0 To terms.Count - 1
                    Dim p = da.SelectCommand.Parameters.Add($"@t{i}", SqlDbType.NVarChar, 100)
                    p.Value = $"%{terms(i)}%"
                Next

                da.Fill(dt)
            End Using
        End Using

        DataGridView1.DataSource = dt

        ' ตั้งชื่อหัวคอลัมน์ภาษาอ่านง่าย
        If DataGridView1.Columns.Contains("Patient_ID") Then DataGridView1.Columns("Patient_ID").HeaderText = "Patient ID"
        If DataGridView1.Columns.Contains("FirstName") Then DataGridView1.Columns("FirstName").HeaderText = "First Name"
        If DataGridView1.Columns.Contains("LastName") Then DataGridView1.Columns("LastName").HeaderText = "Last Name"
        If DataGridView1.Columns.Contains("Sex") Then DataGridView1.Columns("Sex").HeaderText = "Sex"
        If DataGridView1.Columns.Contains("BirthDate") Then DataGridView1.Columns("BirthDate").HeaderText = "Birth Date"
        If DataGridView1.Columns.Contains("P_Tel") Then DataGridView1.Columns("P_Tel").HeaderText = "Phone"
        If DataGridView1.Columns.Contains("Marital_Status") Then DataGridView1.Columns("Marital_Status").HeaderText = "Marital Status"
        If DataGridView1.Columns.Contains("Date_Registered") Then DataGridView1.Columns("Date_Registered").HeaderText = "Date Registered"
        If DataGridView1.Columns.Contains("NextOfKinName") Then DataGridView1.Columns("NextOfKinName").HeaderText = "Next of Kin"
    End Sub

End Class
