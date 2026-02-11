Imports System.Data.SqlClient

Public Class FormAddstaff1

    '---- ตั้งค่าเชื่อมต่อ (แก้ตามเครื่องคุณ) ----
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    Private Function ToNullableDecimal(txt As String) As Object
        Dim d As Decimal
        If Decimal.TryParse(txt, d) Then Return d Else Return DBNull.Value
    End Function
    Private Function ToNullableInt(txt As String) As Object
        Dim i As Integer
        If Integer.TryParse(txt, i) Then Return i Else Return DBNull.Value
    End Function

    ' คืนค่า DateTimePicker เป็น Date หรือ DBNull (ถ้าไม่ติ๊กเช็คบ็อกซ์)
    Private Function DateOrDbNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked, CType(DBNull.Value, Object), dtp.Value.Date)
    End Function

    ' --- เพิ่ม: แปลง Hours Per Week จาก DTP (time-only) เป็นจำนวนชั่วโมง (Int) หรือ DBNull ---
    Private Function HoursOrDbNull(dtp As DateTimePicker) As Object
        If dtp.ShowCheckBox AndAlso Not dtp.Checked Then Return DBNull.Value

        ' ใช้เฉพาะส่วน "เวลา" ของ DateTimePicker
        Dim hrs As Integer = CInt(Math.Round(dtp.Value.TimeOfDay.TotalHours))
        ' กันค่าผิดปกติ 0..168 ชม./สัปดาห์ (แต่ DTP time-only ปกติได้สูงสุด 23 ชม.)
        If hrs < 0 Then hrs = 0
        If hrs > 168 Then hrs = 168
        Return hrs
    End Function

    ' --- เพิ่ม: คืนค่า ComboBox เป็นข้อความที่เลือก หรือ DBNull ---
    Private Function ComboOrDbNull(cbo As ComboBox) As Object
        If cbo.SelectedIndex < 0 OrElse String.IsNullOrWhiteSpace(CStr(cbo.SelectedItem)) Then
            Return DBNull.Value
        End If
        Return CStr(cbo.SelectedItem)
    End Function

    Private newStaffId As Integer = -1

    Private Sub FormAddstaff1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_addQuali.Enabled = False
        btn_AddWork.Enabled = False

        ' ตั้งค่า DateTimePicker เดิม
        SetupDtp(dtp_adddate)
        SetupDtp(dtp_addstart)
        SetupDtp(dtp_finish)

        ' --- ตั้งค่า DOB (date only) ---
        SetupDtp(dtp_dob)

        ' --- ตั้งค่า Hours Per Week (time only + spin) ---
        SetupHoursPicker(dtp_hpw)

        ' --- ตั้งค่า ContractType ComboBox ---
        SetupContractType(cbo_contractType)
    End Sub

    Private Sub SetupDtp(dtp As DateTimePicker)
        dtp.Format = DateTimePickerFormat.Custom
        dtp.CustomFormat = "dddd , MMMM dd, yyyy"
        dtp.ShowCheckBox = True    ' ไม่ติ๊ก = NULL
        dtp.Checked = False        ' เริ่มต้นเป็นว่าง
    End Sub

    ' --- เพิ่ม: DTP แบบเวลาอย่างเดียว (ใช้สำหรับ Hours Per Week) ---
    Private Sub SetupHoursPicker(dtp As DateTimePicker)
        dtp.Format = DateTimePickerFormat.Custom
        dtp.CustomFormat = "HH:mm"
        dtp.ShowUpDown = True      ' เป็นสปินเนอร์ ไม่ต้องเปิดปฏิทิน
        dtp.ShowCheckBox = True    ' ไม่ติ๊ก = NULL
        dtp.Checked = False
        ' ตั้งค่าเริ่มต้น เช่น 08:00 ชั่วโมง/สัปดาห์ (จะถูกปัดเป็น 8 ชั่วโมง)
        dtp.Value = Date.Today.AddHours(8)
    End Sub

    ' --- เพิ่ม: เตรียมรายการใน ComboBox ---
    Private Sub SetupContractType(cbo As ComboBox)
        cbo.DropDownStyle = ComboBoxStyle.DropDownList
        cbo.Items.Clear()
        ' ใส่รายการตามที่ DB ของคุณรองรับ/ต้องการ
        cbo.Items.AddRange(New Object() {
            "Permanent",
            "Temporary",
            "Fixed-term",
            "Part-time",
            "Casual",
            "Contractor"
        })
        cbo.SelectedIndex = -1 ' ยังไม่เลือก = NULL
    End Sub

    '--- เพิ่ม Staff ---
    Private Sub btn_addstaff1_Click(sender As Object, e As EventArgs) Handles btn_addstaff1.Click
        Using cn = GetConn()
            cn.Open()
            Dim sql As String =
"INSERT INTO dbo.Staff
 (FirstName, LastName, FullAddress, Tel, DateOfBirth, Sex, NIN, Position,
  CurrentSalary, SalaryScale, TypeEmpContract, SalaryPayment, HoursPerWeek)
 OUTPUT INSERTED.StaffID
 VALUES (@FirstName, @LastName, @Addr, @Tel, @DOB, @Sex, @NIN, @Pos,
         @Salary, @SalaryScale, @TypeEmp, @PayType, @HPW);"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@FirstName", txtb_addstaffname.Text.Trim())
                cmd.Parameters.AddWithValue("@LastName", txtb_addstafflastname.Text.Trim())
                cmd.Parameters.AddWithValue("@Addr", txtb_addstaffAddres.Text.Trim())
                cmd.Parameters.AddWithValue("@Tel", txtb_addstaffphon.Text.Trim())

                ' เปลี่ยนเป็นใช้ DTP ของ DOB
                cmd.Parameters.AddWithValue("@DOB", DateOrDbNull(dtp_dob))

                cmd.Parameters.AddWithValue("@Sex", txtb_addstafflSex.Text.Trim())
                cmd.Parameters.AddWithValue("@NIN", txtb_addstaffnin.Text.Trim())
                cmd.Parameters.AddWithValue("@Pos", txtb_addstaffposi.Text.Trim())
                cmd.Parameters.AddWithValue("@Salary", ToNullableDecimal(txtb_addstaffsalary.Text.Trim()))
                cmd.Parameters.AddWithValue("@SalaryScale", txtb_addstaffsalarysc.Text.Trim())

                ' เปลี่ยนเป็นใช้ ComboBox ของ ContractType
                cmd.Parameters.AddWithValue("@TypeEmp", ComboOrDbNull(cbo_contractType))

                cmd.Parameters.AddWithValue("@PayType", txtb_addstaffpayty.Text.Trim())

                ' เปลี่ยนเป็นใช้ DTP (time-only) ของ Hours Per Week -> แปลงเป็นจำนวนชั่วโมง (Int)
                cmd.Parameters.AddWithValue("@HPW", HoursOrDbNull(dtp_hpw))

                newStaffId = CInt(cmd.ExecuteScalar())
            End Using
        End Using

        If newStaffId > 0 Then
            MessageBox.Show("เพิ่ม Staff สำเร็จ (StaffID=" & newStaffId & ")", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btn_addQuali.Enabled = True
            btn_AddWork.Enabled = True
        End If
    End Sub

    '--- เพิ่ม Qualification (เดิม) ---
    Private Sub btn_addQuali_Click(sender As Object, e As EventArgs) Handles btn_addQuali.Click
        If newStaffId <= 0 Then
            MessageBox.Show("กรุณาเพิ่ม Staff ก่อน", "ข้อมูลไม่ครบ")
            Return
        End If

        Using cn = GetConn()
            cn.Open()
            Dim sql As String =
"INSERT INTO dbo.Qualification (StaffID, QualDate, QualType, Institution)
 VALUES (@sid, @qdate, @qtype, @inst)"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@sid", newStaffId)
                cmd.Parameters.AddWithValue("@qdate", DateOrDbNull(dtp_adddate)) ' ใช้ DTP
                cmd.Parameters.AddWithValue("@qtype", txtb_dttype.Text.Trim())
                cmd.Parameters.AddWithValue("@inst", txtb_dtins.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("เพิ่ม Qualification สำเร็จ", "OK")
    End Sub

    '--- เพิ่ม Work Experience (เดิม) ---
    Private Sub btn_AddWork_Click(sender As Object, e As EventArgs) Handles btn_AddWork.Click
        If newStaffId <= 0 Then
            MessageBox.Show("กรุณาเพิ่ม Staff ก่อน", "ข้อมูลไม่ครบ")
            Return
        End If

        Using cn = GetConn()
            cn.Open()
            Dim sql As String =
"INSERT INTO dbo.WorkExperience (StaffID, Name_Organization, Ex_Position, Start_Date, Finish_Date)
 VALUES (@sid, @org, @pos, @start, @finish)"
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@sid", newStaffId)
                cmd.Parameters.AddWithValue("@org", txtb_addwexdorg.Text.Trim())
                cmd.Parameters.AddWithValue("@pos", txtb_addwexdposltion.Text.Trim())
                cmd.Parameters.AddWithValue("@start", DateOrDbNull(dtp_addstart))
                cmd.Parameters.AddWithValue("@finish", DateOrDbNull(dtp_finish))
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("เพิ่ม Work Experience สำเร็จ", "OK")
    End Sub

    Private Sub btn_cancleaddstaff_Click(sender As Object, e As EventArgs) Handles btn_cancleaddstaff.Click
        Me.Close()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
    End Sub
End Class
