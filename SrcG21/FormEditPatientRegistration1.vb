Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Partial Public Class FormEditPatientRegistration1

    ' ===== ปรับให้ตรงเครื่องของคุณ =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    ' ====================================

    Public Property PatientId As Integer
    Private _nextOfKinId As Integer = 0
    Private _localDoctorId As Integer = 0

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- Helpers ----------
    Private Sub MakeDtpNullable(c As Control)
        If TypeOf c Is DateTimePicker Then
            Dim d = DirectCast(c, DateTimePicker)
            d.ShowCheckBox = True
        End If
        For Each ch As Control In c.Controls : MakeDtpNullable(ch) : Next
    End Sub

    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked,
                  CType(DBNull.Value, Object),
                  dtp.Value.Date)
    End Function

    Private Sub SetDtp(dtp As DateTimePicker, v As Object)
        If v Is DBNull.Value Then
            dtp.Checked = False
        Else
            dtp.Checked = True
            dtp.Value = CDate(v)
        End If
    End Sub

    Private Function ColumnExists(cn As SqlConnection, table As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", table)
            cmd.Parameters.AddWithValue("@c", col)
            Return cmd.ExecuteScalar() IsNot Nothing
        End Using
    End Function

    Private Function HasCol(r As IDataRecord, name As String) As Boolean
        For i = 0 To r.FieldCount - 1
            If String.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase) Then Return True
        Next
        Return False
    End Function

    ' คืนชื่อคอลัมน์แรกที่มีจริงในตาราง (ไว้รองรับสคีมาหลายแบบ)
    Private Function PickCol(cn As SqlConnection, table As String, ParamArray candidates() As String) As String
        For Each c In candidates
            If ColumnExists(cn, table, c) Then Return c
        Next
        Return Nothing
    End Function

    ' หา column เบอร์โทรตามสคีมาที่เจอจริง
    Private Function TelCol(cn As SqlConnection, table As String) As String
        If table.Equals("NextOfKin", StringComparison.OrdinalIgnoreCase) Then
            Return PickCol(cn, table, "NextOfKin_Tel", "Telephone", "TelNo", "Tel")
        ElseIf table.Equals("LocalDoctor", StringComparison.OrdinalIgnoreCase) Then
            Return PickCol(cn, table, "Tel_LD", "Telephone", "TelNo", "Tel")
        End If
        Return PickCol(cn, table, "Telephone", "TelNo", "Tel")
    End Function

    ' ========== LOAD ==========
    Private Sub FormEditPatientRegistration1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeDtpNullable(Me)
        LoadWards()
        LoadClinics() ' ★ ต้องเรียกเพื่อให้คอมโบมีรายการ
        If PatientId <= 0 Then
            MessageBox.Show("หน้านี้ใช้สำหรับแก้ไข ต้องเลือกผู้ป่วยจากรายการก่อน", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close() : Return
        End If
        LoadForEdit(PatientId)
    End Sub

    Private Sub LoadWards()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter("SELECT WardNumber, WardName FROM dbo.Ward ORDER BY WardNumber", cn)
                    da.Fill(dt)
                End Using
                ComboBox2.DisplayMember = "WardName"
                ComboBox2.ValueMember = "WardNumber"
                ComboBox2.DataSource = dt
                ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
            End Using
        Catch
            ComboBox2.DataSource = Nothing
        End Try
    End Sub

    ' ★ โหลดรายการ Clinic จากตาราง Clinic
    Private Sub LoadClinics()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter("
                    SELECT ClinicNumber, ClinicName
                    FROM dbo.Clinic
                    ORDER BY ClinicNumber", cn)
                    da.Fill(dt)
                End Using
                If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
                For Each r As DataRow In dt.Rows
                    r("Display") = $"{r("ClinicNumber")} — {r("ClinicName")}"
                Next
                cmb_ClinicNoLocalDoc.DisplayMember = "Display"
                cmb_ClinicNoLocalDoc.ValueMember = "ClinicNumber"
                cmb_ClinicNoLocalDoc.DataSource = dt
                cmb_ClinicNoLocalDoc.DropDownStyle = ComboBoxStyle.DropDownList
            End Using
        Catch
            cmb_ClinicNoLocalDoc.DataSource = Nothing
        End Try
    End Sub

    Private Sub LoadForEdit(pid As Integer)
        Using cn = Conn()
            cn.Open()

            ' ตรวจคอลัมน์ใน Patient ที่อาจไม่มีในฐานจริง
            Dim hasLocalDoctor As Boolean = ColumnExists(cn, "Patient", "LocalDoctor_ID")
            Dim hasWard As Boolean = ColumnExists(cn, "Patient", "WardRequested")
            Dim hasAdmission As Boolean = ColumnExists(cn, "Patient", "AdmissionDate")
            Dim hasActual As Boolean = ColumnExists(cn, "Patient", "ActualDischargeDate")
            Dim hasIssued As Boolean = ColumnExists(cn, "Patient", "DateOfRegistrationIssued")
            Dim hasEstimated As Boolean = ColumnExists(cn, "Patient", "EstimatedStayDuration")
            Dim hasExpected As Boolean = ColumnExists(cn, "Patient", "ExpectedDischargeDate")

            ' เลือกชื่อคอลัมน์ที่มีจริง
            Dim nkTelCol As String = TelCol(cn, "NextOfKin")
            Dim ldTelCol As String = TelCol(cn, "LocalDoctor")
            Dim ldClinicCol As String = PickCol(cn, "LocalDoctor", "Clinic_Number", "ClinicNo")
            Dim ldFirstCol As String = PickCol(cn, "LocalDoctor", "FirstName")
            Dim ldLastCol As String = PickCol(cn, "LocalDoctor", "LastName")
            Dim ldFullNameCol As String = PickCol(cn, "LocalDoctor", "Full_Name")

            Dim sb As New StringBuilder()
            sb.AppendLine("SELECT p.Patient_ID,")
            sb.AppendLine("       p.FirstName, p.LastName, p.Sex, p.BirthDate, p.Address, p.Marital_Status,")
            sb.AppendLine("       p.Date_Registered, p.P_Tel")
            If hasEstimated Then sb.AppendLine("     , p.EstimatedStayDuration")
            If hasExpected Then sb.AppendLine("     , p.ExpectedDischargeDate")
            If hasIssued Then sb.AppendLine("     , p.DateOfRegistrationIssued")
            If hasWard Then sb.AppendLine("     , p.WardRequested")
            If hasAdmission Then sb.AppendLine("     , p.AdmissionDate")
            If hasActual Then sb.AppendLine("     , p.ActualDischargeDate")
            sb.AppendLine("     , p.NextOfKin_ID")
            If hasLocalDoctor Then sb.AppendLine("     , p.LocalDoctor_ID")

            ' Next of Kin
            sb.AppendLine("     , nk.FirstName AS NK_First, nk.LastName AS NK_Last, nk.Address AS NK_Address, nk.Relationship AS NK_Rel,")
            sb.AppendLine("       " & If(String.IsNullOrEmpty(nkTelCol), "NULL", $"nk.{nkTelCol}") & " AS NK_Tel")

            ' Local Doctor (ถ้ามี) — เลือกคอลัมน์แบบยืดหยุ่น
            If hasLocalDoctor Then
                If Not String.IsNullOrEmpty(ldFullNameCol) Then
                    sb.AppendLine($"     , ld.{ldFullNameCol} AS LD_FullName, NULL AS LD_First, NULL AS LD_Last,")
                Else
                    sb.AppendLine($"     , NULL AS LD_FullName, ld.{ldFirstCol} AS LD_First, ld.{ldLastCol} AS LD_Last,")
                End If
                sb.AppendLine("       " & If(String.IsNullOrEmpty(ldClinicCol), "NULL", $"ld.{ldClinicCol}") & " AS LD_Clinic,")
                sb.AppendLine("       " & If(String.IsNullOrEmpty(ldTelCol), "NULL", $"ld.{ldTelCol}") & " AS LD_Tel")
            End If

            sb.AppendLine("FROM dbo.Patient p")
            sb.AppendLine("LEFT JOIN dbo.NextOfKin nk ON nk.NextOfKin_ID = p.NextOfKin_ID")
            If hasLocalDoctor Then
                ' JOIN ตามคีย์ปกติของตาราง LocalDoctor
                sb.AppendLine("LEFT JOIN dbo.LocalDoctor ld ON ld.LD_ID = p.LocalDoctor_ID")
            End If
            sb.AppendLine("WHERE p.Patient_ID = @id")

            Using cmd As New SqlCommand(sb.ToString(), cn)
                cmd.Parameters.AddWithValue("@id", pid)
                Using rd = cmd.ExecuteReader()
                    If Not rd.Read() Then
                        MessageBox.Show("ไม่พบข้อมูลผู้ป่วย", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Close() : Return
                    End If

                    ' Patient
                    txtb_FirstNameRegis.Text = If(rd("FirstName") Is DBNull.Value, "", CStr(rd("FirstName")))
                    txtb_LastNameRegis.Text = If(rd("LastName") Is DBNull.Value, "", CStr(rd("LastName")))
                    TextBox10.Text = If(rd("Sex") Is DBNull.Value, "", CStr(rd("Sex")))
                    txtb_AddressRegis.Text = If(rd("Address") Is DBNull.Value, "", CStr(rd("Address")))
                    TextBox11.Text = If(rd("Marital_Status") Is DBNull.Value, "", CStr(rd("Marital_Status")))
                    txtb_TeleRegis.Text = If(rd("P_Tel") Is DBNull.Value, "", CStr(rd("P_Tel")))
                    SetDtp(dtp_DateofBirthRegis, rd("BirthDate"))
                    SetDtp(dtp_RegisdateRegis, rd("Date_Registered"))
                    If hasEstimated AndAlso HasCol(rd, "EstimatedStayDuration") Then SetDtp(dtp_EstimatedRegis, rd("EstimatedStayDuration"))
                    If hasExpected AndAlso HasCol(rd, "ExpectedDischargeDate") Then SetDtp(dtp_ExpectedRegis, rd("ExpectedDischargeDate"))
                    If hasAdmission AndAlso HasCol(rd, "AdmissionDate") Then SetDtp(dtp_AdmissRegis, rd("AdmissionDate"))
                    If hasActual AndAlso HasCol(rd, "ActualDischargeDate") Then SetDtp(dtp_ActualRegis, rd("ActualDischargeDate"))
                    If hasIssued AndAlso HasCol(rd, "DateOfRegistrationIssued") Then SetDtp(DateTimePicker1, rd("DateOfRegistrationIssued")) Else DateTimePicker1.Checked = False

                    If hasWard AndAlso HasCol(rd, "WardRequested") AndAlso ComboBox2.DataSource IsNot Nothing Then
                        If Not rd("WardRequested") Is DBNull.Value Then
                            ComboBox2.SelectedValue = CInt(rd("WardRequested"))
                        Else
                            ComboBox2.SelectedIndex = -1
                        End If
                    Else
                        ComboBox2.SelectedIndex = -1
                    End If

                    _nextOfKinId = If(HasCol(rd, "NextOfKin_ID") AndAlso Not rd("NextOfKin_ID") Is DBNull.Value, CInt(rd("NextOfKin_ID")), 0)
                    _localDoctorId = If(hasLocalDoctor AndAlso HasCol(rd, "LocalDoctor_ID") AndAlso Not rd("LocalDoctor_ID") Is DBNull.Value, CInt(rd("LocalDoctor_ID")), 0)

                    ' Next of Kin
                    txtb_FirstNexkin.Text = If(HasCol(rd, "NK_First") AndAlso Not rd("NK_First") Is DBNull.Value, CStr(rd("NK_First")), "")
                    txtb_LastNexkin.Text = If(HasCol(rd, "NK_Last") AndAlso Not rd("NK_Last") Is DBNull.Value, CStr(rd("NK_Last")), "")
                    txtb_teleNexkin.Text = If(HasCol(rd, "NK_Tel") AndAlso Not rd("NK_Tel") Is DBNull.Value, CStr(rd("NK_Tel")), "")
                    txtb_AddressNexkin.Text = If(HasCol(rd, "NK_Address") AndAlso Not rd("NK_Address") Is DBNull.Value, CStr(rd("NK_Address")), "")
                    txtb_RelationNexkin.Text = If(HasCol(rd, "NK_Rel") AndAlso Not rd("NK_Rel") Is DBNull.Value, CStr(rd("NK_Rel")), "")

                    ' Local Doctor
                    If hasLocalDoctor Then
                        If HasCol(rd, "LD_FullName") AndAlso Not rd("LD_FullName") Is DBNull.Value Then
                            ' ถ้าเก็บชื่อรวมไว้คอลัมน์เดียว
                            txtb_FirstLocalDoc.Text = CStr(rd("LD_FullName"))
                            txtb_LastLocalDoc.Clear()
                        Else
                            txtb_FirstLocalDoc.Text = If(HasCol(rd, "LD_First") AndAlso Not rd("LD_First") Is DBNull.Value, CStr(rd("LD_First")), "")
                            txtb_LastLocalDoc.Text = If(HasCol(rd, "LD_Last") AndAlso Not rd("LD_Last") Is DBNull.Value, CStr(rd("LD_Last")), "")
                        End If

                        ' ★ เซ็ตค่า Clinic ลงคอมโบด้วย SelectedValue (ไม่ใช้ Text)
                        If cmb_ClinicNoLocalDoc.DataSource IsNot Nothing AndAlso HasCol(rd, "LD_Clinic") AndAlso Not rd("LD_Clinic") Is DBNull.Value Then
                            Dim clinicNum As Integer
                            If Integer.TryParse(CStr(rd("LD_Clinic")), clinicNum) Then
                                cmb_ClinicNoLocalDoc.SelectedValue = clinicNum
                            Else
                                cmb_ClinicNoLocalDoc.SelectedIndex = -1
                            End If
                        Else
                            cmb_ClinicNoLocalDoc.SelectedIndex = -1
                        End If

                        txtb_AddressLocalDoc.Text = If(HasCol(rd, "LD_Address") AndAlso Not rd("LD_Address") Is DBNull.Value, CStr(rd("LD_Address")), "")
                        txtb_teleLocalDoc.Text = If(HasCol(rd, "LD_Tel") AndAlso Not rd("LD_Tel") Is DBNull.Value, CStr(rd("LD_Tel")), "")
                    Else
                        txtb_FirstLocalDoc.Clear()
                        txtb_LastLocalDoc.Clear()
                        cmb_ClinicNoLocalDoc.SelectedIndex = -1
                        txtb_AddressLocalDoc.Clear()
                        txtb_teleLocalDoc.Clear()
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' ========== SAVE (UPDATE) ==========
    Private Sub btn_SavePtnRegis_Click(sender As Object, e As EventArgs) Handles btn_SavePtnRegis.Click
        If String.IsNullOrWhiteSpace(txtb_FirstNameRegis.Text) OrElse String.IsNullOrWhiteSpace(txtb_LastNameRegis.Text) Then
            MessageBox.Show("กรุณากรอก First/Last Name", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using cn = Conn()
                cn.Open()

                ' ตรวจคอลัมน์ก่อนสร้าง UPDATE
                Dim hasLocalDoctor As Boolean = ColumnExists(cn, "Patient", "LocalDoctor_ID")
                Dim hasWard As Boolean = ColumnExists(cn, "Patient", "WardRequested")
                Dim hasAdmission As Boolean = ColumnExists(cn, "Patient", "AdmissionDate")
                Dim hasActual As Boolean = ColumnExists(cn, "Patient", "ActualDischargeDate")
                Dim hasIssued As Boolean = ColumnExists(cn, "Patient", "DateOfRegistrationIssued")
                Dim hasEstimated As Boolean = ColumnExists(cn, "Patient", "EstimatedStayDuration")
                Dim hasExpected As Boolean = ColumnExists(cn, "Patient", "ExpectedDischargeDate")

                Using tx = cn.BeginTransaction()

                    ' ===== NextOfKin ===== (คงของเดิมคุณ ถ้าคอลัมน์เป็น NextOfKin_Tel ให้ปรับตามจริง)
                    If _nextOfKinId = 0 Then
                        Using cmd As New SqlCommand("
INSERT INTO dbo.NextOfKin(FirstName, LastName, Address, Relationship, NextOfKin_Tel)
VALUES(@fn,@ln,@addr,@rel,@tel);
SELECT CAST(SCOPE_IDENTITY() AS int);", cn, tx)
                            cmd.Parameters.AddWithValue("@fn", txtb_FirstNexkin.Text.Trim())
                            cmd.Parameters.AddWithValue("@ln", txtb_LastNexkin.Text.Trim())
                            cmd.Parameters.AddWithValue("@addr", If(String.IsNullOrWhiteSpace(txtb_AddressNexkin.Text), CType(DBNull.Value, Object), txtb_AddressNexkin.Text.Trim()))
                            cmd.Parameters.AddWithValue("@rel", If(String.IsNullOrWhiteSpace(txtb_RelationNexkin.Text), CType(DBNull.Value, Object), txtb_RelationNexkin.Text.Trim()))
                            cmd.Parameters.AddWithValue("@tel", If(String.IsNullOrWhiteSpace(txtb_teleNexkin.Text), CType(DBNull.Value, Object), txtb_teleNexkin.Text.Trim()))
                            _nextOfKinId = CInt(cmd.ExecuteScalar())
                        End Using
                    Else
                        Using cmd As New SqlCommand("
UPDATE dbo.NextOfKin
SET FirstName=@fn, LastName=@ln, Address=@addr, Relationship=@rel, NextOfKin_Tel=@tel
WHERE NextOfKin_ID=@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", _nextOfKinId)
                            cmd.Parameters.AddWithValue("@fn", txtb_FirstNexkin.Text.Trim())
                            cmd.Parameters.AddWithValue("@ln", txtb_LastNexkin.Text.Trim())
                            cmd.Parameters.AddWithValue("@addr", If(String.IsNullOrWhiteSpace(txtb_AddressNexkin.Text), CType(DBNull.Value, Object), txtb_AddressNexkin.Text.Trim()))
                            cmd.Parameters.AddWithValue("@rel", If(String.IsNullOrWhiteSpace(txtb_RelationNexkin.Text), CType(DBNull.Value, Object), txtb_RelationNexkin.Text.Trim()))
                            cmd.Parameters.AddWithValue("@tel", If(String.IsNullOrWhiteSpace(txtb_teleNexkin.Text), CType(DBNull.Value, Object), txtb_teleNexkin.Text.Trim()))
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' ===== Patient =====
                    Dim sb As New StringBuilder()
                    sb.AppendLine("UPDATE dbo.Patient SET")
                    sb.AppendLine(" FirstName=@fn, LastName=@ln, Sex=@sex, BirthDate=@birth, Address=@addr, Marital_Status=@marital,")
                    sb.AppendLine(" Date_Registered=@regdate, P_Tel=@tel")
                    If hasEstimated Then sb.AppendLine(" , EstimatedStayDuration=@estdur")
                    If hasExpected Then sb.AppendLine(" , ExpectedDischargeDate=@expectdisc")
                    If hasIssued Then sb.AppendLine(" , DateOfRegistrationIssued=@regissued")
                    If hasWard Then sb.AppendLine(" , WardRequested=@ward")
                    If hasAdmission Then sb.AppendLine(" , AdmissionDate=@admiss")
                    If hasActual Then sb.AppendLine(" , ActualDischargeDate=@actualdisc")
                    sb.AppendLine(" , NextOfKin_ID=@nk")
                    If hasLocalDoctor Then sb.AppendLine(" , LocalDoctor_ID=@ld")
                    sb.AppendLine(" WHERE Patient_ID=@id;")

                    Using cmd As New SqlCommand(sb.ToString(), cn, tx)
                        cmd.Parameters.AddWithValue("@id", PatientId)
                        cmd.Parameters.AddWithValue("@fn", txtb_FirstNameRegis.Text.Trim())
                        cmd.Parameters.AddWithValue("@ln", txtb_LastNameRegis.Text.Trim())
                        cmd.Parameters.AddWithValue("@sex", If(String.IsNullOrWhiteSpace(TextBox10.Text), CType(DBNull.Value, Object), TextBox10.Text.Trim()))
                        cmd.Parameters.AddWithValue("@birth", DtpOrNull(dtp_DateofBirthRegis))
                        cmd.Parameters.AddWithValue("@addr", If(String.IsNullOrWhiteSpace(txtb_AddressRegis.Text), CType(DBNull.Value, Object), txtb_AddressRegis.Text.Trim()))
                        cmd.Parameters.AddWithValue("@marital", If(String.IsNullOrWhiteSpace(TextBox11.Text), CType(DBNull.Value, Object), TextBox11.Text.Trim()))
                        cmd.Parameters.AddWithValue("@regdate", DtpOrNull(dtp_RegisdateRegis))
                        cmd.Parameters.AddWithValue("@tel", If(String.IsNullOrWhiteSpace(txtb_TeleRegis.Text), CType(DBNull.Value, Object), txtb_TeleRegis.Text.Trim()))
                        If hasEstimated Then cmd.Parameters.AddWithValue("@estdur", DtpOrNull(dtp_EstimatedRegis))
                        If hasExpected Then cmd.Parameters.AddWithValue("@expectdisc", DtpOrNull(dtp_ExpectedRegis))
                        If hasIssued Then cmd.Parameters.AddWithValue("@regissued", DtpOrNull(DateTimePicker1))
                        If hasWard Then
                            cmd.Parameters.AddWithValue("@ward",
                                If(ComboBox2.DataSource Is Nothing OrElse ComboBox2.SelectedItem Is Nothing,
                                   CType(DBNull.Value, Object), ComboBox2.SelectedValue))
                        End If
                        If hasAdmission Then cmd.Parameters.AddWithValue("@admiss", DtpOrNull(dtp_AdmissRegis))
                        If hasActual Then cmd.Parameters.AddWithValue("@actualdisc", DtpOrNull(dtp_ActualRegis))
                        cmd.Parameters.AddWithValue("@nk", _nextOfKinId)
                        If hasLocalDoctor Then cmd.Parameters.AddWithValue("@ld", _localDoctorId)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' ===== LocalDoctor (ถ้ามีคอลัมน์อ้างอิง) =====
                    If hasLocalDoctor Then
                        ' หา column ชื่อจริงก่อน
                        Dim ldClinicCol As String = PickCol(cn, "LocalDoctor", "Clinic_Number", "ClinicNo")
                        Dim ldTelCol As String = TelCol(cn, "LocalDoctor")
                        Dim ldFirstCol As String = PickCol(cn, "LocalDoctor", "FirstName")
                        Dim ldLastCol As String = PickCol(cn, "LocalDoctor", "LastName")
                        Dim ldFullNameCol As String = PickCol(cn, "LocalDoctor", "Full_Name")

                        If Not String.IsNullOrEmpty(ldClinicCol) Then
                            If _localDoctorId = 0 Then
                                ' สร้างใหม่
                                Dim cols As New List(Of String)
                                Dim vals As New List(Of String)
                                If Not String.IsNullOrEmpty(ldFullNameCol) Then
                                    cols.Add(ldFullNameCol) : vals.Add("@ld_name")
                                Else
                                    cols.Add(ldFirstCol) : vals.Add("@ld_first")
                                    cols.Add(ldLastCol) : vals.Add("@ld_last")
                                End If
                                cols.Add("Address") : vals.Add("@ld_addr")
                                If Not String.IsNullOrEmpty(ldTelCol) Then cols.Add(ldTelCol) : vals.Add("@ld_tel")
                                cols.Add(ldClinicCol) : vals.Add("@ld_clinic")

                                Dim sql = $"INSERT INTO dbo.LocalDoctor({String.Join(",", cols)}) VALUES({String.Join(",", vals)});
                                           SELECT CAST(SCOPE_IDENTITY() AS int);"
                                Using cmd As New SqlCommand(sql, cn, tx)
                                    If Not String.IsNullOrEmpty(ldFullNameCol) Then
                                        Dim fullName = $"{txtb_FirstLocalDoc.Text} {txtb_LastLocalDoc.Text}".Trim()
                                        cmd.Parameters.AddWithValue("@ld_name", If(String.IsNullOrWhiteSpace(fullName), CType(DBNull.Value, Object), fullName))
                                    Else
                                        cmd.Parameters.AddWithValue("@ld_first", If(String.IsNullOrWhiteSpace(txtb_FirstLocalDoc.Text), CType(DBNull.Value, Object), txtb_FirstLocalDoc.Text.Trim()))
                                        cmd.Parameters.AddWithValue("@ld_last", If(String.IsNullOrWhiteSpace(txtb_LastLocalDoc.Text), CType(DBNull.Value, Object), txtb_LastLocalDoc.Text.Trim()))
                                    End If
                                    cmd.Parameters.AddWithValue("@ld_addr", If(String.IsNullOrWhiteSpace(txtb_AddressLocalDoc.Text), CType(DBNull.Value, Object), txtb_AddressLocalDoc.Text.Trim()))
                                    If Not String.IsNullOrEmpty(ldTelCol) Then
                                        cmd.Parameters.AddWithValue("@ld_tel", If(String.IsNullOrWhiteSpace(txtb_teleLocalDoc.Text), CType(DBNull.Value, Object), txtb_teleLocalDoc.Text.Trim()))
                                    End If
                                    cmd.Parameters.AddWithValue("@ld_clinic",
                                        If(cmb_ClinicNoLocalDoc.DataSource Is Nothing OrElse cmb_ClinicNoLocalDoc.SelectedItem Is Nothing,
                                           CType(DBNull.Value, Object), cmb_ClinicNoLocalDoc.SelectedValue))
                                    _localDoctorId = CInt(cmd.ExecuteScalar())
                                End Using
                            Else
                                ' อัปเดตที่มีอยู่
                                Dim sets As New List(Of String)
                                If Not String.IsNullOrEmpty(ldFullNameCol) Then
                                    sets.Add($"{ldFullNameCol}=@ld_name")
                                Else
                                    sets.Add($"{ldFirstCol}=@ld_first")
                                    sets.Add($"{ldLastCol}=@ld_last")
                                End If
                                sets.Add("Address=@ld_addr")
                                If Not String.IsNullOrEmpty(ldTelCol) Then sets.Add($"{ldTelCol}=@ld_tel")
                                sets.Add($"{ldClinicCol}=@ld_clinic")

                                Dim sql = $"UPDATE dbo.LocalDoctor SET {String.Join(", ", sets)} WHERE LD_ID=@id;"
                                Using cmd As New SqlCommand(sql, cn, tx)
                                    cmd.Parameters.AddWithValue("@id", _localDoctorId)
                                    If Not String.IsNullOrEmpty(ldFullNameCol) Then
                                        Dim fullName = $"{txtb_FirstLocalDoc.Text} {txtb_LastLocalDoc.Text}".Trim()
                                        cmd.Parameters.AddWithValue("@ld_name", If(String.IsNullOrWhiteSpace(fullName), CType(DBNull.Value, Object), fullName))
                                    Else
                                        cmd.Parameters.AddWithValue("@ld_first", If(String.IsNullOrWhiteSpace(txtb_FirstLocalDoc.Text), CType(DBNull.Value, Object), txtb_FirstLocalDoc.Text.Trim()))
                                        cmd.Parameters.AddWithValue("@ld_last", If(String.IsNullOrWhiteSpace(txtb_LastLocalDoc.Text), CType(DBNull.Value, Object), txtb_LastLocalDoc.Text.Trim()))
                                    End If
                                    cmd.Parameters.AddWithValue("@ld_addr", If(String.IsNullOrWhiteSpace(txtb_AddressLocalDoc.Text), CType(DBNull.Value, Object), txtb_AddressLocalDoc.Text.Trim()))
                                    If Not String.IsNullOrEmpty(ldTelCol) Then
                                        cmd.Parameters.AddWithValue("@ld_tel", If(String.IsNullOrWhiteSpace(txtb_teleLocalDoc.Text), CType(DBNull.Value, Object), txtb_teleLocalDoc.Text.Trim()))
                                    End If
                                    cmd.Parameters.AddWithValue("@ld_clinic",
                                        If(cmb_ClinicNoLocalDoc.DataSource Is Nothing OrElse cmb_ClinicNoLocalDoc.SelectedItem Is Nothing,
                                           CType(DBNull.Value, Object), cmb_ClinicNoLocalDoc.SelectedValue))
                                    cmd.ExecuteNonQuery()
                                End Using
                            End If
                        End If
                    End If

                    tx.Commit()
                End Using
            End Using

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ========== DELETE ==========
    Private Sub btn_DeletePtnRegis_Click(sender As Object, e As EventArgs) Handles btn_DeletePtnRegis.Click
        If PatientId <= 0 Then Return
        If MessageBox.Show("ต้องการลบข้อมูลผู้ป่วยนี้หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using cn = Conn()
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Using cmd As New SqlCommand("DELETE FROM dbo.Patient WHERE Patient_ID=@id;", cn, tx)
                        cmd.Parameters.AddWithValue("@id", PatientId)
                        cmd.ExecuteNonQuery()
                    End Using
                    If _nextOfKinId > 0 Then
                        Using cmd As New SqlCommand("
IF NOT EXISTS(SELECT 1 FROM dbo.Patient WHERE NextOfKin_ID=@id) 
   DELETE FROM dbo.NextOfKin WHERE NextOfKin_ID=@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", _nextOfKinId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                    If _localDoctorId > 0 AndAlso ColumnExists(cn, "Patient", "LocalDoctor_ID") Then
                        Using cmd As New SqlCommand("
IF NOT EXISTS(SELECT 1 FROM dbo.Patient WHERE LocalDoctor_ID=@id) 
   DELETE FROM dbo.LocalDoctor WHERE LD_ID=@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", _localDoctorId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                    tx.Commit()
                End Using
            End Using
            MessageBox.Show("ลบข้อมูลเรียบร้อย", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ========== CANCEL ==========
    Private Sub btn_CanclePtnRegis_Click(sender As Object, e As EventArgs) Handles btn_CanclePtnRegis.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class



