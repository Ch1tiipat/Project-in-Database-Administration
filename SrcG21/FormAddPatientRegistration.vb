Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Partial Public Class FormAddPatientRegistration

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- Helpers ----------
    Private Sub MakeDtpNullable(c As Control)
        If TypeOf c Is DateTimePicker Then
            Dim d = DirectCast(c, DateTimePicker)
            d.ShowCheckBox = True : d.Checked = True
        End If
        For Each ch As Control In c.Controls : MakeDtpNullable(ch) : Next
    End Sub

    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked, CType(DBNull.Value, Object), dtp.Value.Date)
    End Function

    Private Function ColumnExists(cn As SqlConnection, table As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", table)
            cmd.Parameters.AddWithValue("@c", col)
            Return cmd.ExecuteScalar() IsNot Nothing
        End Using
    End Function

    ' โทรศัพท์: รองรับชื่อคอลัมน์หลายแบบตามสคีมาจริง
    Private Function TelCol(cn As SqlConnection, table As String) As String
        Dim candidates As String()
        If table.Equals("NextOfKin", StringComparison.OrdinalIgnoreCase) Then
            candidates = New String() {"NextOfKin_Tel", "Telephone", "TelNo", "Tel"}
        ElseIf table.Equals("LocalDoctor", StringComparison.OrdinalIgnoreCase) Then
            candidates = New String() {"Tel_LD", "Telephone", "TelNo", "Tel"}
        Else
            candidates = New String() {"Telephone", "TelNo", "Tel"}
        End If
        For Each c In candidates
            If ColumnExists(cn, table, c) Then Return c
        Next
        Return Nothing
    End Function

    ' ---------- Load data ----------
    Private Sub FormAddPatientRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeDtpNullable(Me)
        LoadWards()
        LoadClinics()
    End Sub

    Private Sub LoadWards()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter("
                    SELECT WardNumber, WardName
                    FROM dbo.Ward
                    ORDER BY WardNumber", cn)
                    da.Fill(dt)
                End Using
                cmb_WardReAddRegis.DisplayMember = "WardName"
                cmb_WardReAddRegis.ValueMember = "WardNumber"
                cmb_WardReAddRegis.DataSource = dt
                cmb_WardReAddRegis.DropDownStyle = ComboBoxStyle.DropDownList
            End Using
        Catch
            cmb_WardReAddRegis.DataSource = Nothing
        End Try
    End Sub

    ' ★ แก้ให้ดึงจากตาราง Clinic จริง ๆ
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

                ' ทำคอลัมน์แสดงผลสวย ๆ เช่น "301 — Outpatient"
                If Not dt.Columns.Contains("Display") Then
                    dt.Columns.Add("Display", GetType(String))
                End If
                For Each r As DataRow In dt.Rows
                    r("Display") = $"{r("ClinicNumber")} — {r("ClinicName")}"
                Next

                cmb_ClinicAddLocalDoc.DisplayMember = "Display"
                cmb_ClinicAddLocalDoc.ValueMember = "ClinicNumber"
                cmb_ClinicAddLocalDoc.DataSource = dt
                cmb_ClinicAddLocalDoc.DropDownStyle = ComboBoxStyle.DropDownList
            End Using
        Catch
            cmb_ClinicAddLocalDoc.DataSource = Nothing
        End Try
    End Sub

    ' ---------- Save/Add ----------
    Private Sub btn_SaveAddRegis_Click(sender As Object, e As EventArgs) Handles btn_SaveAddRegis.Click
        ' ชื่อผู้ป่วย (คอนโทรลคุณใช้ prefix btn_ แต่เป็น Text ได้)
        If String.IsNullOrWhiteSpace(btn_FisrtAddRegis.Text) OrElse String.IsNullOrWhiteSpace(btn_LastAddRegis.Text) Then
            MessageBox.Show("กรุณากรอก First/Last Name", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ฟิลด์ที่มักเป็น NOT NULL ใน Patient: Sex, BirthDate, Address, P_Tel, Marital_Status, Date_Registered
        ' เช็คเบื้องต้น (ถ้าไม่อยากเช็ค ให้มั่นใจว่าใน DB อนุญาต NULL)
        If String.IsNullOrWhiteSpace(txtb_SexAddRegis.Text) _
            OrElse String.IsNullOrWhiteSpace(txtb_AddressAddRegis.Text) _
            OrElse String.IsNullOrWhiteSpace(txtb_teleAddRegis.Text) _
            OrElse String.IsNullOrWhiteSpace(txtb_MaritalAddRegis.Text) _
            OrElse Not dtp_DateAddRegis.Checked _
            OrElse Not dtp_RegisAddRegis.Checked Then

            MessageBox.Show("กรอก Sex, BirthDate, Address, P_Tel, Marital_Status และ Date_Registered ให้ครบ", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using cn = Conn()
                cn.Open()

                ' ตรวจคอลัมน์ใน Patient ก่อนสร้าง INSERT แบบไดนามิก
                Dim hasLocalDoctor As Boolean = ColumnExists(cn, "Patient", "LocalDoctor_ID")
                Dim hasWard As Boolean = ColumnExists(cn, "Patient", "WardRequested")
                Dim hasAdmission As Boolean = ColumnExists(cn, "Patient", "AdmissionDate")
                Dim hasActual As Boolean = ColumnExists(cn, "Patient", "ActualDischargeDate")
                Dim hasIssued As Boolean = ColumnExists(cn, "Patient", "DateOfRegistrationIssued")
                Dim hasEstimated As Boolean = ColumnExists(cn, "Patient", "EstimatedStayDuration")
                Dim hasExpected As Boolean = ColumnExists(cn, "Patient", "ExpectedDischargeDate")

                ' โทรศัพท์จริงของตาราง NextOfKin/LocalDoctor
                Dim nkTel As String = TelCol(cn, "NextOfKin")
                Dim ldTel As String = TelCol(cn, "LocalDoctor")

                Using tx = cn.BeginTransaction()

                    ' ---------- NextOfKin ----------
                    Dim nkId As Integer
                    Dim nkCols As New List(Of String) From {"FirstName", "LastName", "Address", "Relationship"}
                    Dim nkVals As New List(Of String) From {"@nk_fn", "@nk_ln", "@nk_addr", "@nk_rel"}
                    If Not String.IsNullOrEmpty(nkTel) Then
                        nkCols.Insert(2, nkTel)     ' แทรกก่อน Address เพื่ออ่านง่าย
                        nkVals.Insert(2, "@nk_tel")
                    End If

                    Dim nkSql As String =
                        $"INSERT INTO dbo.NextOfKin({String.Join(",", nkCols)}) VALUES({String.Join(",", nkVals)});
                          SELECT CAST(SCOPE_IDENTITY() AS int);"

                    Using cmd As New SqlCommand(nkSql, cn, tx)
                        cmd.Parameters.AddWithValue("@nk_fn", txtb_FirstAddNexkin.Text.Trim())
                        cmd.Parameters.AddWithValue("@nk_ln", txtb_LastAddNexkin.Text.Trim())

                        If Not String.IsNullOrEmpty(nkTel) Then
                            ' ถ้าเป็น NOT NULL แนะนำให้บังคับกรอกในฟอร์ม
                            cmd.Parameters.AddWithValue("@nk_tel",
                                If(String.IsNullOrWhiteSpace(txtb_teleAddNexkin.Text),
                                   CType(DBNull.Value, Object), txtb_teleAddNexkin.Text.Trim()))
                        End If

                        cmd.Parameters.AddWithValue("@nk_addr",
                            If(String.IsNullOrWhiteSpace(txtb_AddressAddNexkin.Text),
                               CType(DBNull.Value, Object), txtb_AddressAddNexkin.Text.Trim()))
                        cmd.Parameters.AddWithValue("@nk_rel",
                            If(String.IsNullOrWhiteSpace(txtb_RelaAddNexkin.Text),
                               CType(DBNull.Value, Object), txtb_RelaAddNexkin.Text.Trim()))
                        nkId = CInt(cmd.ExecuteScalar())
                    End Using

                    ' ---------- LocalDoctor (สร้างเมื่อ Patient มีคอลัมน์อ้างอิงเท่านั้น) ----------
                    Dim ldId As Integer = 0
                    If hasLocalDoctor Then
                        ' สคีมาที่ใช้: LD_ID, Full_Name, Address, Tel_LD, Clinic_Number
                        Dim ldCols As New List(Of String) From {"Full_Name", "Address", "Clinic_Number"}
                        Dim ldVals As New List(Of String) From {"@ld_name", "@ld_addr", "@ld_clinic"}
                        If Not String.IsNullOrEmpty(ldTel) AndAlso ldTel.Equals("Tel_LD", StringComparison.OrdinalIgnoreCase) Then
                            ldCols.Insert(2, "Tel_LD")     ' ใส่ก่อน Clinic_Number
                            ldVals.Insert(2, "@ld_tel")
                        End If

                        Dim ldSql As String =
                            $"INSERT INTO dbo.LocalDoctor({String.Join(",", ldCols)}) VALUES({String.Join(",", ldVals)});
                              SELECT CAST(SCOPE_IDENTITY() AS int);"

                        Using cmd As New SqlCommand(ldSql, cn, tx)
                            Dim fullName As String = $"{txtb_FirstAddLocalDoc.Text.Trim()} {txtb_LastAddLocalDoc.Text.Trim()}".Trim()
                            cmd.Parameters.AddWithValue("@ld_name", If(String.IsNullOrWhiteSpace(fullName), CType(DBNull.Value, Object), fullName))
                            cmd.Parameters.AddWithValue("@ld_addr",
                                If(String.IsNullOrWhiteSpace(txtb_AdressAddLocalDoc.Text),
                                   CType(DBNull.Value, Object), txtb_AdressAddLocalDoc.Text.Trim()))

                            If ldCols.Contains("Tel_LD") Then
                                cmd.Parameters.AddWithValue("@ld_tel",
                                    If(String.IsNullOrWhiteSpace(txtb_teleAddLocalDoc.Text),
                                       CType(DBNull.Value, Object), txtb_teleAddLocalDoc.Text.Trim()))
                            End If

                            Dim clinicVal As Object =
                                If(cmb_ClinicAddLocalDoc.DataSource Is Nothing OrElse cmb_ClinicAddLocalDoc.SelectedItem Is Nothing,
                                   CType(DBNull.Value, Object),
                                   CType(cmb_ClinicAddLocalDoc.SelectedValue, Object))
                            cmd.Parameters.AddWithValue("@ld_clinic", clinicVal)
                            ldId = CInt(cmd.ExecuteScalar())
                        End Using
                    End If

                    ' ---------- Patient (INSERT เฉพาะคอลัมน์ที่มีจริง) ----------
                    Dim pCols As New List(Of String) From {"FirstName", "LastName", "Sex", "BirthDate", "Address", "Marital_Status", "Date_Registered", "P_Tel", "NextOfKin_ID"}
                    Dim pVals As New List(Of String) From {"@fn", "@ln", "@sex", "@birth", "@addr", "@marital", "@regdate", "@tel", "@nk"}

                    If hasEstimated Then pCols.Add("EstimatedStayDuration") : pVals.Add("@estdur")
                    If hasExpected Then pCols.Add("ExpectedDischargeDate") : pVals.Add("@expectdisc")
                    If hasIssued Then pCols.Add("DateOfRegistrationIssued") : pVals.Add("@regissued")
                    If hasWard Then pCols.Add("WardRequested") : pVals.Add("@ward")
                    If hasAdmission Then pCols.Add("AdmissionDate") : pVals.Add("@admiss")
                    If hasActual Then pCols.Add("ActualDischargeDate") : pVals.Add("@actualdisc")
                    If hasLocalDoctor Then pCols.Add("LocalDoctor_ID") : pVals.Add("@ld")

                    Dim pSql As String =
                        $"INSERT INTO dbo.Patient({String.Join(",", pCols)}) VALUES({String.Join(",", pVals)});"

                    Using cmd As New SqlCommand(pSql, cn, tx)
                        cmd.Parameters.AddWithValue("@fn", btn_FisrtAddRegis.Text.Trim())
                        cmd.Parameters.AddWithValue("@ln", btn_LastAddRegis.Text.Trim())
                        cmd.Parameters.AddWithValue("@sex",
                            If(String.IsNullOrWhiteSpace(txtb_SexAddRegis.Text),
                               CType(DBNull.Value, Object), txtb_SexAddRegis.Text.Trim()))
                        cmd.Parameters.AddWithValue("@birth", DtpOrNull(dtp_DateAddRegis))
                        cmd.Parameters.AddWithValue("@addr",
                            If(String.IsNullOrWhiteSpace(txtb_AddressAddRegis.Text),
                               CType(DBNull.Value, Object), txtb_AddressAddRegis.Text.Trim()))
                        cmd.Parameters.AddWithValue("@marital",
                            If(String.IsNullOrWhiteSpace(txtb_MaritalAddRegis.Text),
                               CType(DBNull.Value, Object), txtb_MaritalAddRegis.Text.Trim()))
                        cmd.Parameters.AddWithValue("@regdate", DtpOrNull(dtp_RegisAddRegis))
                        cmd.Parameters.AddWithValue("@tel",
                            If(String.IsNullOrWhiteSpace(txtb_teleAddRegis.Text),
                               CType(DBNull.Value, Object), txtb_teleAddRegis.Text.Trim()))
                        cmd.Parameters.AddWithValue("@nk", nkId)

                        If hasEstimated Then cmd.Parameters.AddWithValue("@estdur", DtpOrNull(dtp_EstimatAddRegis))
                        If hasExpected Then cmd.Parameters.AddWithValue("@expectdisc", DtpOrNull(dtp_ExpecAddRegis))
                        If hasIssued Then cmd.Parameters.AddWithValue("@regissued", DtpOrNull(dtp_DateOfAddRegis))
                        If hasWard Then
                            cmd.Parameters.AddWithValue("@ward",
                                If(cmb_WardReAddRegis.DataSource Is Nothing OrElse cmb_WardReAddRegis.SelectedItem Is Nothing,
                                   CType(DBNull.Value, Object), cmb_WardReAddRegis.SelectedValue))
                        End If
                        If hasAdmission Then cmd.Parameters.AddWithValue("@admiss", DtpOrNull(dtp_AdmissAddRegis))
                        If hasActual Then cmd.Parameters.AddWithValue("@actualdisc", DtpOrNull(dtp_ActualAddRegis))
                        If hasLocalDoctor Then cmd.Parameters.AddWithValue("@ld", ldId)

                        cmd.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using
            End Using

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_CancleAddRegis_Click(sender As Object, e As EventArgs) Handles btn_CancleAddRegis.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class



