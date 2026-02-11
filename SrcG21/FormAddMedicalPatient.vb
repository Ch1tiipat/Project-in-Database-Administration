Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddMedicalPatient

    ' ===== SQL Server Connection =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    ' =================================

    Private Sub FormAddMedicalPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งรูปแบบวันที่
        With DateTimePicker1 : .Format = DateTimePickerFormat.Custom : .CustomFormat = "yyyy-MM-dd" : End With
        With DateTimePicker2 : .Format = DateTimePickerFormat.Custom : .CustomFormat = "yyyy-MM-dd" : End With

        ' ตั้งค่า ComboBox
        med_PID.DropDownStyle = ComboBoxStyle.DropDownList
        med_drugnumED.DropDownStyle = ComboBoxStyle.DropDownList
        med_CN_ID.DropDownStyle = ComboBoxStyle.DropDownList

        ' โหลดข้อมูลลงคอมโบ
        LoadPatients()
        LoadDrugs()
        LoadNurses()

        ' ปุ่มลัดและกฎกรอกตัวเลข
        Me.AcceptButton = btn_Addmed
        Me.CancelButton = btn_canclemed
        AddHandler btn_unitper.KeyPress, AddressOf OnlyDigits_KeyPress   ' << TextBox ชื่อ btn_unitper
    End Sub

    Private Sub OnlyDigits_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    ' -------- โหลดข้อมูลใส่คอมโบ --------
    Private Sub LoadPatients()
        Dim sql As String =
"SELECT Patient_ID,
        (CAST(Patient_ID AS NVARCHAR(10)) + ' - ' + FirstName + ' ' + LastName) AS Label
 FROM dbo.Patient
 ORDER BY Patient_ID;"
        Using cn As New SqlConnection(ConnStr),
              da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            da.Fill(dt)
            med_PID.DataSource = dt
            med_PID.DisplayMember = "Label"
            med_PID.ValueMember = "Patient_ID"
            If dt.Rows.Count > 0 Then med_PID.SelectedIndex = 0
        End Using
    End Sub

    Private Sub LoadDrugs()
        Dim sql As String =
"SELECT Drug_Number, DrugName
 FROM dbo.Pharmaceutical_Supplie
 ORDER BY DrugName;"
        Using cn As New SqlConnection(ConnStr),
              da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            da.Fill(dt)
            med_drugnumED.DataSource = dt
            med_drugnumED.DisplayMember = "DrugName"
            med_drugnumED.ValueMember = "Drug_Number"
            If dt.Rows.Count > 0 Then med_drugnumED.SelectedIndex = 0
        End Using
    End Sub

    Private Sub LoadNurses()
        Dim sql As String =
"SELECT c.CN_ID,
        (s.FirstName + ' ' + s.LastName) AS NurseName
 FROM dbo.ChargeNurse c
 JOIN dbo.Staff s ON s.StaffID = c.StaffID
 ORDER BY s.FirstName, s.LastName;"
        Using cn As New SqlConnection(ConnStr),
              da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable()
            da.Fill(dt)
            med_CN_ID.DataSource = dt
            med_CN_ID.DisplayMember = "NurseName"
            med_CN_ID.ValueMember = "CN_ID"
            If dt.Rows.Count > 0 Then med_CN_ID.SelectedIndex = 0
        End Using
    End Sub
    ' -----------------------------------

    Private Function ValidateForm() As String
        Dim sb As New Text.StringBuilder()
        If med_PID.SelectedValue Is Nothing Then sb.AppendLine("กรุณาเลือก Patient")
        If med_drugnumED.SelectedValue Is Nothing Then sb.AppendLine("กรุณาเลือก Drug")
        If String.IsNullOrWhiteSpace(btn_unitper.Text) Then sb.AppendLine("กรุณากรอก UnitPer")
        If String.IsNullOrWhiteSpace(btn_med_moa.Text) Then sb.AppendLine("กรุณากรอก Method_of_admin")
        If med_CN_ID.SelectedValue Is Nothing Then sb.AppendLine("กรุณาเลือก Charge Nurse")
        If DateTimePicker2.Value.Date < DateTimePicker1.Value.Date Then sb.AppendLine("FinishDate ต้องไม่ก่อน StartDate")
        Return sb.ToString()
    End Function

    Private Sub btn_Addmed_Click(sender As Object, e As EventArgs) Handles btn_Addmed.Click
        Dim err = ValidateForm()
        Dim unitVal As Integer
        If err.Length = 0 AndAlso Not Integer.TryParse(btn_unitper.Text, unitVal) Then
            err &= "UnitPer ต้องเป็นตัวเลข" & Environment.NewLine
        End If
        If err.Length > 0 Then
            MessageBox.Show(err, "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim sql As String =
"INSERT INTO dbo.PatientMedication
 (Patient_ID, Drug_Number, UnitPer, Method_of_admin, StartDate, FinishDate, CN_ID)
 OUTPUT INSERTED.Medication_ID
 VALUES
 (@pid, @drugnum, @unit, @method, @start, @finish, @cn);"

        Try
            Dim newId As Integer
            Using cn As New SqlConnection(ConnStr), cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = CInt(med_PID.SelectedValue)
                cmd.Parameters.Add("@drugnum", SqlDbType.Int).Value = CInt(med_drugnumED.SelectedValue)
                cmd.Parameters.Add("@unit", SqlDbType.Int).Value = unitVal
                cmd.Parameters.Add("@method", SqlDbType.NVarChar, 100).Value = btn_med_moa.Text.Trim()
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.Add("@finish", SqlDbType.Date).Value = DateTimePicker2.Value.Date
                cmd.Parameters.Add("@cn", SqlDbType.Int).Value = CInt(med_CN_ID.SelectedValue)

                cn.Open()
                newId = CInt(cmd.ExecuteScalar())
            End Using

            MessageBox.Show($"บันทึกสำเร็จ (Medication_ID = {newId})",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            'Me.Close() ' ถ้าต้องการปิดฟอร์มทันทีให้เปิดบรรทัดนี้
        Catch ex As SqlException
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_canclemed_Click(sender As Object, e As EventArgs) Handles btn_canclemed.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class
