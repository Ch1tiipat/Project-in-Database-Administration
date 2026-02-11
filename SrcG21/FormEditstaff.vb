Imports System.Data.SqlClient

Public Class FormEditstaff

    '================= CONNECTION =================
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function
    '=============================================

    Private Function ToNullableDecimal(txt As String) As Object
        Dim d As Decimal
        If Decimal.TryParse(txt, d) Then Return d Else Return DBNull.Value
    End Function

    Private Function ToNullableInt(txt As String) As Object
        Dim i As Integer
        If Integer.TryParse(txt, i) Then Return i Else Return DBNull.Value
    End Function

    ' =============== Helper ใหม่สำหรับคอนโทรลที่เพิ่ม ===============
    ' คืนค่า Date เฉพาะวันจาก DTP (หรือ NULL ถ้าไม่ติ๊ก)
    Private Function DtpDateOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked, CType(DBNull.Value, Object), dtp.Value.Date)
    End Function

    ' แปลง DTP (time-only) → จำนวนชั่วโมง (Int) หรือ NULL ถ้าไม่ติ๊ก
    Private Function HoursOrDbNull(dtp As DateTimePicker) As Object
        If dtp.ShowCheckBox AndAlso Not dtp.Checked Then Return DBNull.Value
        Dim hrs As Integer = CInt(Math.Round(dtp.Value.TimeOfDay.TotalHours))
        If hrs < 0 Then hrs = 0
        If hrs > 168 Then hrs = 168
        Return hrs
    End Function

    ' คืนค่าจาก ComboBox → ข้อความ หรือ NULL ถ้ายังไม่เลือก
    Private Function ComboOrDbNull(cbo As ComboBox) As Object
        If cbo.SelectedIndex < 0 OrElse cbo.SelectedItem Is Nothing Then Return DBNull.Value
        Dim s As String = CStr(cbo.SelectedItem).Trim()
        If s = "" Then Return DBNull.Value
        Return s
    End Function

    ' ใช้กับ DateTimePicker (ShowCheckBox=True -> ไม่ติ๊ก = NULL) (คงไว้ใช้กับส่วนอื่นๆ ในฟอร์ม)
    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked, CType(DBNull.Value, Object), dtp.Value)
    End Function
    ' ===============================================================

    Public Enum EditMode
        Staff
        Qualification
        WorkExperience
    End Enum

    Public Property Mode As EditMode
    Public Property KeyId As Integer        ' StaffID / QualID / WorkExID
    Public Property StaffId As Integer = -1 ' ใช้ตอนแก้แถวลูกโดยตรง

    ' ====== เก็บคีย์ของแถวลูกที่โหลดมา (ใช้ตอน Save/Delete) ======
    Private currentQualId As Integer = -1
    Private currentWorkId As Integer = -1

    Private Sub FormEditstaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งค่า DTP ที่มีอยู่เดิม
        For Each p In {dtp_dateQuai, dtp_startdate, dtp_finishwork}
            p.ShowCheckBox = True
            If String.IsNullOrWhiteSpace(p.CustomFormat) Then
                p.Format = DateTimePickerFormat.Custom
                p.CustomFormat = "dddd , MMMM dd, yyyy"
            End If
        Next

        ' -------- NEW: DOB เป็น date-only + optional --------
        With dtp_dob
            .Format = DateTimePickerFormat.Custom
            .CustomFormat = "dddd , MMMM dd, yyyy"
            .ShowCheckBox = True
            .Checked = False
        End With

        ' -------- NEW: Hours Per Week เป็น time-only + spinner + optional --------
        With dtp_hpw
            .Format = DateTimePickerFormat.Custom
            .CustomFormat = "HH:mm"
            .ShowUpDown = True
            .ShowCheckBox = True
            .Checked = False
            .Value = Date.Today.AddHours(8) ' ค่าตั้งต้น 8 ชม.
        End With

        ' -------- NEW: ContractType ComboBox --------
        With cbo_contractType
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Clear()
            .Items.AddRange(New Object() {
                "Permanent",
                "Temporary",
                "Fixed-term",
                "Part-time",
                "Casual",
                "Contractor"
            })
            .SelectedIndex = -1
        End With

        LoadData()
        ApplyButtons()
    End Sub

    Private Sub ApplyButtons()
        btn_saveeditstaff.Enabled = (Mode = EditMode.Staff)
        btn_Deleteeditstaff.Enabled = (Mode = EditMode.Staff)
        btn_savequaledit.Enabled = True
        btn_Saveeditwork.Enabled = True
    End Sub

    Private Sub LoadData()
        Select Case Mode
            Case EditMode.Staff
                LoadStaff_ByStaffId(KeyId)
                LoadLatestQualificationForStaff(KeyId)
                LoadLatestWorkForStaff(KeyId)
            Case EditMode.Qualification
                LoadQualification_ByQualId(KeyId)
            Case EditMode.WorkExperience
                LoadWork_ByWorkId(KeyId)
        End Select
    End Sub

    ' ----------------------- STAFF -----------------------
    Private Sub LoadStaff_ByStaffId(staffId As Integer)
        Using cn = GetConn()
            Dim sql As String = "SELECT TOP 1 * FROM dbo.Staff WHERE StaffID=@id"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", staffId)
                cn.Open()
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        txtb_editname.Text = rd("FirstName").ToString()
                        txtb_editlastname.Text = rd("LastName").ToString()
                        txtb_editAddress.Text = rd("FullAddress").ToString()
                        txtb_editTelephone.Text = rd("Tel").ToString()

                        ' --- NEW: DOB → dtp_dob ---
                        If IsDBNull(rd("DateOfBirth")) Then
                            dtp_dob.Checked = False
                        Else
                            dtp_dob.Value = CDate(rd("DateOfBirth"))
                            dtp_dob.Checked = True
                        End If

                        txtb_editsex.Text = rd("Sex").ToString()
                        txtb_editnin.Text = rd("NIN").ToString()
                        txtb_editPos.Text = rd("Position").ToString()
                        txtb_editsalary.Text = If(IsDBNull(rd("CurrentSalary")), "", rd("CurrentSalary").ToString())
                        txtb_editsalaryscle.Text = rd("SalaryScale").ToString()

                        ' --- NEW: ContractType → cbo_contractType ---
                        Dim ct As String = rd("TypeEmpContract").ToString()
                        If String.IsNullOrWhiteSpace(ct) Then
                            cbo_contractType.SelectedIndex = -1
                        Else
                            Dim idx = cbo_contractType.FindStringExact(ct)
                            cbo_contractType.SelectedIndex = idx
                        End If

                        txtb_editPay.Text = rd("SalaryPayment").ToString()

                        ' --- NEW: HoursPerWeek → dtp_hpw (แสดงเป็นชั่วโมงแบบ time-of-day) ---
                        If IsDBNull(rd("HoursPerWeek")) Then
                            dtp_hpw.Checked = False
                        Else
                            Dim hrs As Integer = CInt(rd("HoursPerWeek"))
                            dtp_hpw.Value = Date.Today.AddHours(Math.Max(0, Math.Min(hrs, 23)))
                            dtp_hpw.Checked = True
                        End If
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' ------------------- QUALIFICATION (โหลดล่าสุดของ Staff) -------------------
    Private Sub LoadLatestQualificationForStaff(staffId As Integer)
        currentQualId = -1
        txtb_editqdty.Clear()
        dtp_dateQuai.Checked = False
        txtb_editqdins.Clear()

        Using cn = GetConn()
            Dim sql As String =
"SELECT TOP 1 QualID, QualType, QualDate, Institution
 FROM dbo.Qualification
 WHERE StaffID=@sid
 ORDER BY QualDate DESC, QualID DESC"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@sid", staffId)
                cn.Open()
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        currentQualId = CInt(rd("QualID"))
                        txtb_editqdty.Text = rd("QualType").ToString()
                        If IsDBNull(rd("QualDate")) Then
                            dtp_dateQuai.Checked = False
                        Else
                            dtp_dateQuai.Value = CDate(rd("QualDate"))
                            dtp_dateQuai.Checked = True
                        End If
                        txtb_editqdins.Text = rd("Institution").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' ------------------- WORK EXPERIENCE (โหลดล่าสุดของ Staff) -------------------
    Private Sub LoadLatestWorkForStaff(staffId As Integer)
        currentWorkId = -1
        txtb_editwpos.Clear()
        dtp_startdate.Checked = False
        dtp_finishwork.Checked = False
        txtb_editwOrgan.Clear()

        Using cn = GetConn()
            Dim sql As String =
"SELECT TOP 1 WorkExID, Ex_Position, Start_Date, Finish_Date, Name_Organization
 FROM dbo.WorkExperience
 WHERE StaffID=@sid
 ORDER BY Start_Date DESC, WorkExID DESC"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@sid", staffId)
                cn.Open()
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        currentWorkId = CInt(rd("WorkExID"))
                        txtb_editwpos.Text = rd("Ex_Position").ToString()

                        If IsDBNull(rd("Start_Date")) Then
                            dtp_startdate.Checked = False
                        Else
                            dtp_startdate.Value = CDate(rd("Start_Date"))
                            dtp_startdate.Checked = True
                        End If

                        If IsDBNull(rd("Finish_Date")) Then
                            dtp_finishwork.Checked = False
                        Else
                            dtp_finishwork.Value = CDate(rd("Finish_Date"))
                            dtp_finishwork.Checked = True
                        End If

                        txtb_editwOrgan.Text = rd("Name_Organization").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' ------------------- โหลดแบบชี้ตรงแถว -------------------
    Private Sub LoadQualification_ByQualId(qualId As Integer)
        Using cn = GetConn()
            Dim sql As String = "SELECT TOP 1 * FROM dbo.Qualification WHERE QualID=@id"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", qualId)
                cn.Open()
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        StaffId = CInt(rd("StaffID"))
                        currentQualId = CInt(rd("QualID"))
                        txtb_editqdty.Text = rd("QualType").ToString()
                        If IsDBNull(rd("QualDate")) Then
                            dtp_dateQuai.Checked = False
                        Else
                            dtp_dateQuai.Value = CDate(rd("QualDate"))
                            dtp_dateQuai.Checked = True
                        End If
                        txtb_editqdins.Text = rd("Institution").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadWork_ByWorkId(workId As Integer)
        Using cn = GetConn()
            Dim sql As String = "SELECT TOP 1 * FROM dbo.WorkExperience WHERE WorkExID=@id"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", workId)
                cn.Open()
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        StaffId = CInt(rd("StaffID"))
                        currentWorkId = CInt(rd("WorkExID"))
                        txtb_editwpos.Text = rd("Ex_Position").ToString()

                        If IsDBNull(rd("Start_Date")) Then
                            dtp_startdate.Checked = False
                        Else
                            dtp_startdate.Value = CDate(rd("Start_Date"))
                            dtp_startdate.Checked = True
                        End If

                        If IsDBNull(rd("Finish_Date")) Then
                            dtp_finishwork.Checked = False
                        Else
                            dtp_finishwork.Value = CDate(rd("Finish_Date"))
                            dtp_finishwork.Checked = True
                        End If

                        txtb_editwOrgan.Text = rd("Name_Organization").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' ================== SAVE / DELETE ==================

    ' ---- STAFF ----
    Private Sub btn_saveeditstaff_Click(sender As Object, e As EventArgs) Handles btn_saveeditstaff.Click
        Using cn = GetConn()
            cn.Open()
            Dim sql As String =
"UPDATE dbo.Staff SET
 FirstName=@FirstName, LastName=@LastName, FullAddress=@Addr, Tel=@Tel, DateOfBirth=@DOB,
 Sex=@Sex, NIN=@NIN, Position=@Pos, CurrentSalary=@Salary, SalaryScale=@SalaryScale,
 TypeEmpContract=@TypeEmp, SalaryPayment=@PayType, HoursPerWeek=@HPW
 WHERE StaffID=@id"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@FirstName", txtb_editname.Text.Trim())
                cmd.Parameters.AddWithValue("@LastName", txtb_editlastname.Text.Trim())
                cmd.Parameters.AddWithValue("@Addr", txtb_editAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@Tel", txtb_editTelephone.Text.Trim())

                ' --- NEW: DOB จาก dtp_dob ---
                cmd.Parameters.AddWithValue("@DOB", DtpDateOrNull(dtp_dob))

                cmd.Parameters.AddWithValue("@Sex", txtb_editsex.Text.Trim())
                cmd.Parameters.AddWithValue("@NIN", txtb_editnin.Text.Trim())
                cmd.Parameters.AddWithValue("@Pos", txtb_editPos.Text.Trim())
                cmd.Parameters.AddWithValue("@Salary", ToNullableDecimal(txtb_editsalary.Text.Trim()))
                cmd.Parameters.AddWithValue("@SalaryScale", txtb_editsalaryscle.Text.Trim())

                ' --- NEW: ContractType จาก ComboBox ---
                cmd.Parameters.AddWithValue("@TypeEmp", ComboOrDbNull(cbo_contractType))

                cmd.Parameters.AddWithValue("@PayType", txtb_editPay.Text.Trim())

                ' --- NEW: HoursPerWeek จาก dtp_hpw (int ชั่วโมง) ---
                cmd.Parameters.AddWithValue("@HPW", HoursOrDbNull(dtp_hpw))

                cmd.Parameters.AddWithValue("@id", KeyId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("บันทึก Staff สำเร็จ", "OK")
    End Sub

    Private Sub btn_Deleteeditstaff_Click(sender As Object, e As EventArgs) Handles btn_Deleteeditstaff.Click
        If MessageBox.Show("ลบ Staff นี้และข้อมูลลูกทั้งหมดหรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return
        Using cn = GetConn()
            cn.Open()
            Using tr = cn.BeginTransaction()
                Try
                    Using c1 As New SqlCommand("DELETE FROM dbo.Qualification WHERE StaffID=@id", cn, tr)
                        c1.Parameters.AddWithValue("@id", KeyId) : c1.ExecuteNonQuery()
                    End Using
                    Using c2 As New SqlCommand("DELETE FROM dbo.WorkExperience WHERE StaffID=@id", cn, tr)
                        c2.Parameters.AddWithValue("@id", KeyId) : c2.ExecuteNonQuery()
                    End Using
                    Using c3 As New SqlCommand("DELETE FROM dbo.Staff WHERE StaffID=@id", cn, tr)
                        c3.Parameters.AddWithValue("@id", KeyId) : c3.ExecuteNonQuery()
                    End Using
                    tr.Commit()
                Catch
                    tr.Rollback()
                    Throw
                End Try
            End Using
        End Using
        MessageBox.Show("ลบ Staff สำเร็จ")
        Me.Close()
    End Sub

    ' ---- QUALIFICATION (Update ถ้ามี / Insert ถ้าไม่มี) ----
    Private Sub btn_savequaledit_Click(sender As Object, e As EventArgs) Handles btn_savequaledit.Click
        Dim sid As Integer = If(Mode = EditMode.Qualification, StaffId, KeyId)

        Using cn = GetConn()
            cn.Open()

            If currentQualId > 0 Then
                Dim up As String =
"UPDATE dbo.Qualification
 SET QualType=@type, QualDate=@date, Institution=@inst
 WHERE QualID=@id"
                Using cmd As New SqlCommand(up, cn)
                    cmd.Parameters.AddWithValue("@type", txtb_editqdty.Text.Trim())
                    cmd.Parameters.AddWithValue("@date", DtpOrNull(dtp_dateQuai))
                    cmd.Parameters.AddWithValue("@inst", txtb_editqdins.Text.Trim())
                    cmd.Parameters.AddWithValue("@id", currentQualId)
                    cmd.ExecuteNonQuery()
                End Using
            Else
                Dim ins As String =
"INSERT INTO dbo.Qualification (StaffID, QualType, QualDate, Institution)
 OUTPUT INSERTED.QualID
 VALUES (@sid, @type, @date, @inst)"
                Using cmd As New SqlCommand(ins, cn)
                    cmd.Parameters.AddWithValue("@sid", sid)
                    cmd.Parameters.AddWithValue("@type", txtb_editqdty.Text.Trim())
                    cmd.Parameters.AddWithValue("@date", DtpOrNull(dtp_dateQuai))
                    cmd.Parameters.AddWithValue("@inst", txtb_editqdins.Text.Trim())
                    currentQualId = CInt(cmd.ExecuteScalar())
                End Using
            End If
        End Using

        MessageBox.Show("บันทึก Qualification สำเร็จ", "OK")
    End Sub

    Private Sub btn_deletequal_Click(sender As Object, e As EventArgs)
        If currentQualId <= 0 Then
            MessageBox.Show("ยังไม่มีรายการที่จะลบ", "ข้อมูลไม่ครบ") : Return
        End If
        If MessageBox.Show("ลบ Qualification นี้หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Using cn = GetConn()
            cn.Open()
            Using cmd As New SqlCommand("DELETE FROM dbo.Qualification WHERE QualID=@id", cn)
                cmd.Parameters.AddWithValue("@id", currentQualId)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        currentQualId = -1
        txtb_editqdty.Clear()
        dtp_dateQuai.Checked = False
        txtb_editqdins.Clear()
        MessageBox.Show("ลบ Qualification สำเร็จ")
    End Sub

    ' ---- WORK EXPERIENCE (Update ถ้ามี / Insert ถ้าไม่มี) ----
    Private Sub btn_Saveeditwork_Click(sender As Object, e As EventArgs) Handles btn_Saveeditwork.Click
        Dim sid As Integer = If(Mode = EditMode.WorkExperience, StaffId, KeyId)

        Using cn = GetConn()
            cn.Open()

            If currentWorkId > 0 Then
                Dim up As String =
"UPDATE dbo.WorkExperience
 SET Name_Organization=@org, Ex_Position=@pos, Start_Date=@start, Finish_Date=@finish
 WHERE WorkExID=@id"
                Using cmd As New SqlCommand(up, cn)
                    cmd.Parameters.AddWithValue("@org", txtb_editwOrgan.Text.Trim())
                    cmd.Parameters.AddWithValue("@pos", txtb_editwpos.Text.Trim())
                    cmd.Parameters.AddWithValue("@start", DtpOrNull(dtp_startdate))
                    cmd.Parameters.AddWithValue("@finish", DtpOrNull(dtp_finishwork))
                    cmd.Parameters.AddWithValue("@id", currentWorkId)
                    cmd.ExecuteNonQuery()
                End Using
            Else
                Dim ins As String =
"INSERT INTO dbo.WorkExperience (StaffID, Name_Organization, Ex_Position, Start_Date, Finish_Date)
 OUTPUT INSERTED.WorkExID
 VALUES (@sid, @org, @pos, @start, @finish)"
                Using cmd As New SqlCommand(ins, cn)
                    cmd.Parameters.AddWithValue("@sid", sid)
                    cmd.Parameters.AddWithValue("@org", txtb_editwOrgan.Text.Trim())
                    cmd.Parameters.AddWithValue("@pos", txtb_editwpos.Text.Trim())
                    cmd.Parameters.AddWithValue("@start", DtpOrNull(dtp_startdate))
                    cmd.Parameters.AddWithValue("@finish", DtpOrNull(dtp_finishwork))
                    currentWorkId = CInt(cmd.ExecuteScalar())
                End Using
            End If
        End Using

        MessageBox.Show("บันทึก Work Experience สำเร็จ", "OK")
    End Sub

    Private Sub btn_deleteWork_Click(sender As Object, e As EventArgs)
        If currentWorkId <= 0 Then
            MessageBox.Show("ยังไม่มีรายการที่จะลบ", "ข้อมูลไม่ครบ") : Return
        End If
        If MessageBox.Show("ลบ Work Experience นี้หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Using cn = GetConn()
            cn.Open()
            Using cmd As New SqlCommand("DELETE FROM dbo.WorkExperience WHERE WorkExID=@id", cn)
                cmd.Parameters.AddWithValue("@id", currentWorkId)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        currentWorkId = -1
        txtb_editwpos.Clear()
        dtp_startdate.Checked = False
        dtp_finishwork.Checked = False
        txtb_editwOrgan.Clear()
        MessageBox.Show("ลบ Work Experience สำเร็จ")
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

End Class
