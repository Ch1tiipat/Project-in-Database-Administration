Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq

Public Class FormMedicalPatient1

    ' === SQL Server connection ===
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    ' รับมาจากหน้าค้นหา
    Public Property MedicationId As Integer

    ' === หา ComboBox ของ Drug Name จากหลายชื่อที่เป็นไปได้ ===
    Private ReadOnly Property cboDrug As ComboBox
        Get
            Dim candidates As String() = {
                "med_drugnumED", "med_drugnum", "med_drugnumEDIT",
                "cboDrug", "cboDrugName", "cmbDrug", "cmbDrugName",
                "DrugName", "DrugNameCombo", "ComboBox1", "ComboBox2"
            }
            For Each n In candidates
                Dim c = TryCast(Me.Controls.Find(n, True).FirstOrDefault(), ComboBox)
                If c IsNot Nothing Then Return c
            Next
            Return Nothing
        End Get
    End Property

    Private Sub FormMedicalPatient1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MedicationId <= 0 Then
            MessageBox.Show("ไม่พบรหัสรายการที่จะแก้ไข", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DialogResult = DialogResult.Cancel
            Close()
            Return
        End If

        With DateTimePicker11 : .Format = DateTimePickerFormat.Custom : .CustomFormat = "yyyy-MM-dd" : End With
        With DateTimePicker22 : .Format = DateTimePickerFormat.Custom : .CustomFormat = "yyyy-MM-dd" : End With

        med_PIDEDIT.DropDownStyle = ComboBoxStyle.DropDownList
        If cboDrug IsNot Nothing Then cboDrug.DropDownStyle = ComboBoxStyle.DropDownList
        med_CN_ID_EDIT.DropDownStyle = ComboBoxStyle.DropDownList

        AddHandler unitperEDIT.KeyPress, AddressOf OnlyDigits_KeyPress

        Me.AcceptButton = btn_AddFrPtnMed
        Me.CancelButton = btn_CancleFrPtnMed

        LoadPatients()
        LoadDrugs()
        LoadNurses()
        LoadCurrentMedication()
    End Sub

    Private Sub OnlyDigits_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    ' === Lists ===
    Private Sub LoadPatients()
        Dim sql As String =
"SELECT Patient_ID,
        (CAST(Patient_ID AS NVARCHAR(10)) + ' - ' + FirstName + ' ' + LastName) AS Label
 FROM dbo.Patient
 ORDER BY Patient_ID;"
        Using cn As New SqlConnection(ConnStr), da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable() : da.Fill(dt)
            med_PIDEDIT.DataSource = dt
            med_PIDEDIT.DisplayMember = "Label"
            med_PIDEDIT.ValueMember = "Patient_ID"
            med_PIDEDIT.SelectedIndex = If(dt.Rows.Count > 0, 0, -1)
        End Using
    End Sub

    Private Sub LoadDrugs()
        If cboDrug Is Nothing Then
            MessageBox.Show("ไม่พบคอมโบ Drug Name (ตั้งชื่อเป็น med_drugnumED หรือ med_drugnum)", "Control not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim sql As String =
"SELECT Drug_Number, DrugName
 FROM dbo.Pharmaceutical_Supplie
 ORDER BY DrugName;"

        Using cn As New SqlConnection(ConnStr), da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable() : da.Fill(dt)
            cboDrug.DataSource = dt
            cboDrug.DisplayMember = "DrugName"
            cboDrug.ValueMember = "Drug_Number"
            cboDrug.SelectedIndex = -1
            ' >>> ลำดับที่ถูกต้อง: Source ก่อน Mode <<<
            cboDrug.AutoCompleteSource = AutoCompleteSource.ListItems
            cboDrug.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    Private Sub LoadNurses()
        Dim sql As String =
"SELECT c.CN_ID, (s.FirstName + ' ' + s.LastName) AS NurseName
 FROM dbo.ChargeNurse c
 JOIN dbo.Staff s ON s.StaffID = c.StaffID
 ORDER BY s.FirstName, s.LastName;"
        Using cn As New SqlConnection(ConnStr), da As New SqlDataAdapter(sql, cn)
            Dim dt As New DataTable() : da.Fill(dt)
            med_CN_ID_EDIT.DataSource = dt
            med_CN_ID_EDIT.DisplayMember = "NurseName"
            med_CN_ID_EDIT.ValueMember = "CN_ID"
            med_CN_ID_EDIT.SelectedIndex = If(dt.Rows.Count > 0, 0, -1)
        End Using
    End Sub

    ' เติมยาเข้า DataSource ถ้าไม่เจอ แล้วเลือกให้ตรง
    Private Sub EnsureDrugInCombo(drugNum As Integer)
        If cboDrug Is Nothing Then Return
        Dim dt = TryCast(cboDrug.DataSource, DataTable)
        If dt Is Nothing Then Return

        Dim found = dt.AsEnumerable().Any(Function(r) Convert.ToInt32(r("Drug_Number")) = drugNum)
        If found Then
            cboDrug.SelectedValue = drugNum
            Return
        End If

        Using cn As New SqlConnection(ConnStr),
              cmd As New SqlCommand("SELECT Drug_Number, DrugName FROM dbo.Pharmaceutical_Supplie WHERE Drug_Number=@n", cn)
            cmd.Parameters.AddWithValue("@n", drugNum)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    Dim newRow = dt.NewRow()
                    newRow("Drug_Number") = Convert.ToInt32(rd("Drug_Number"))
                    newRow("DrugName") = rd("DrugName").ToString()
                    dt.Rows.Add(newRow)
                    dt.AcceptChanges()
                    cboDrug.SelectedValue = drugNum
                Else
                    cboDrug.SelectedIndex = -1 ' ถูกลบไปแล้ว
                End If
            End Using
        End Using
    End Sub

    ' === Load current row ===
    Private Sub LoadCurrentMedication()
        Dim sql As String =
"SELECT Patient_ID, Drug_Number, UnitPer, Method_of_admin,
        StartDate, FinishDate, CN_ID
 FROM dbo.PatientMedication
 WHERE Medication_ID = @id;"
        Using cn As New SqlConnection(ConnStr), cmd As New SqlCommand(sql, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = MedicationId
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    If Not rd.IsDBNull(0) Then med_PIDEDIT.SelectedValue = Convert.ToInt32(rd("Patient_ID"))
                    If cboDrug IsNot Nothing AndAlso Not rd.IsDBNull(1) Then
                        EnsureDrugInCombo(Convert.ToInt32(rd("Drug_Number"))) ' ให้แสดงชื่อยาเดิมแน่นอน
                    End If
                    unitperEDIT.Text = If(rd.IsDBNull(2), "", Convert.ToInt32(rd("UnitPer")).ToString())
                    med_moaEDIT.Text = If(rd.IsDBNull(3), "", rd("Method_of_admin").ToString())
                    If Not rd.IsDBNull(4) Then DateTimePicker11.Value = Convert.ToDateTime(rd("StartDate"))
                    If Not rd.IsDBNull(5) Then DateTimePicker22.Value = Convert.ToDateTime(rd("FinishDate"))
                    If Not rd.IsDBNull(6) Then med_CN_ID_EDIT.SelectedValue = Convert.ToInt32(rd("CN_ID"))
                Else
                    MessageBox.Show("ไม่พบรายการที่ต้องการแก้ไข", "Not found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        End Using
    End Sub

    Private Function ValidateForm() As String
        Dim sb As New Text.StringBuilder()
        If med_PIDEDIT.SelectedValue Is Nothing Then sb.AppendLine("กรุณาเลือก Patient")
        If cboDrug Is Nothing OrElse cboDrug.SelectedValue Is Nothing Then sb.AppendLine("กรุณาเลือก Drug")
        If String.IsNullOrWhiteSpace(unitperEDIT.Text) Then sb.AppendLine("กรุณากรอก UnitPer")
        If String.IsNullOrWhiteSpace(med_moaEDIT.Text) Then sb.AppendLine("กรุณากรอก Method_of_admin")
        If med_CN_ID_EDIT.SelectedValue Is Nothing Then sb.AppendLine("กรุณาเลือก Charge Nurse")
        If DateTimePicker22.Value.Date < DateTimePicker11.Value.Date Then sb.AppendLine("FinishDate ต้องไม่ก่อน StartDate")
        Return sb.ToString()
    End Function

    ' === Save (UPDATE) ===
    Private Sub btn_AddFrPtnMed_Click(sender As Object, e As EventArgs) Handles btn_AddFrPtnMed.Click
        Dim err = ValidateForm()
        Dim unitVal As Integer
        If err.Length = 0 AndAlso Not Integer.TryParse(unitperEDIT.Text, unitVal) Then
            err &= "UnitPer ต้องเป็นตัวเลข" & Environment.NewLine
        End If
        If err.Length > 0 Then
            MessageBox.Show(err, "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim sql As String =
"UPDATE dbo.PatientMedication
   SET Patient_ID      = @pid,
       Drug_Number     = @drugnum,
       UnitPer         = @unit,
       Method_of_admin = @method,
       StartDate       = @start,
       FinishDate      = @finish,
       CN_ID           = @cn
 WHERE Medication_ID   = @id;"

        Try
            Using cn As New SqlConnection(ConnStr), cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = CInt(med_PIDEDIT.SelectedValue)
                cmd.Parameters.Add("@drugnum", SqlDbType.Int).Value = CInt(cboDrug.SelectedValue)
                cmd.Parameters.Add("@unit", SqlDbType.Int).Value = unitVal
                cmd.Parameters.Add("@method", SqlDbType.NVarChar, 100).Value = med_moaEDIT.Text.Trim()
                cmd.Parameters.Add("@start", SqlDbType.Date).Value = DateTimePicker11.Value.Date
                cmd.Parameters.Add("@finish", SqlDbType.Date).Value = DateTimePicker22.Value.Date
                cmd.Parameters.Add("@cn", SqlDbType.Int).Value = CInt(med_CN_ID_EDIT.SelectedValue)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = MedicationId

                cn.Open()
                Dim n = cmd.ExecuteNonQuery()
                If n > 0 Then
                    MessageBox.Show("บันทึกการแก้ไขเรียบร้อย", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                Else
                    MessageBox.Show("ไม่พบข้อมูลให้แก้ไข", "No change",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As SqlException
            MessageBox.Show("อัปเดตไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === Delete ===
    Private Sub btn_DeleteFrPtnMed_Click(sender As Object, e As EventArgs) Handles btn_DeleteFrPtnMed.Click
        If MessageBox.Show("ยืนยันลบรายการนี้?", "Confirm Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return

        Dim sql As String = "DELETE FROM dbo.PatientMedication WHERE Medication_ID=@id;"
        Try
            Using cn As New SqlConnection(ConnStr), cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = MedicationId
                cn.Open()
                Dim n = cmd.ExecuteNonQuery()
                If n > 0 Then
                    MessageBox.Show("ลบเรียบร้อย", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("ไม่พบข้อมูลให้ลบ", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As SqlException
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_CancleFrPtnMed_Click(sender As Object, e As EventArgs) Handles btn_CancleFrPtnMed.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class





