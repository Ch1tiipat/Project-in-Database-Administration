Imports System.Data
Imports System.Data.SqlClient

Public Class FromEditPatientAppointment2

    Public Property AppointmentId As Integer

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- UI helper ----------
    Private Sub ConfigureCombo(cb As ComboBox)
        cb.DropDownStyle = ComboBoxStyle.DropDownList
        cb.AutoCompleteSource = AutoCompleteSource.ListItems
        cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    ' ---------- Form Load ----------
    Private Sub FromEditPatientAppointment2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatients()
        LoadWards()
        LoadStaff()                 ' Staff → ComboBox1
        LoadStatus()                ' Status → EditStatusAppoint

        dtp_EditAppointDate.ShowCheckBox = True
        dtp_EditAppointDate.Checked = True

        If AppointmentId <= 0 Then
            MessageBox.Show("ไม่พบเลขนัดหมาย", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close() : Return
        End If

        LoadForEdit(AppointmentId)
    End Sub

    ' ---------- Patients ----------
    Private Sub LoadPatients()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
                SELECT Patient_ID,
                       LTRIM(RTRIM(ISNULL(FirstName,''))) +
                       CASE WHEN ISNULL(LastName,'')<>'' THEN ' ' + LastName ELSE '' END AS PatientName
                FROM dbo.Patient
                ORDER BY Patient_ID", cn)
                da.Fill(dt)
            End Using
            cmb_EditPtnApoint.DataSource = dt
            cmb_EditPtnApoint.DisplayMember = "PatientName"
            cmb_EditPtnApoint.ValueMember = "Patient_ID"
            ConfigureCombo(cmb_EditPtnApoint)
        End Using
    End Sub

    ' ---------- Wards ----------
    Private Sub LoadWards()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
                SELECT WardNumber, WardName
                FROM dbo.Ward
                ORDER BY WardNumber", cn)
                da.Fill(dt)
            End Using

            If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
            For Each r As DataRow In dt.Rows
                r("Display") = $"{CInt(r("WardNumber")):00} — {CStr(r("WardName"))}"
            Next

            cmb_EditWardAppoint.DataSource = dt
            cmb_EditWardAppoint.DisplayMember = "Display"
            cmb_EditWardAppoint.ValueMember = "WardNumber"
            ConfigureCombo(cmb_EditWardAppoint)
        End Using
    End Sub

    ' ---------- Staff (ComboBox1) ----------
    Private Sub LoadStaff()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
                SELECT 
                    StaffID,
                    LTRIM(RTRIM(CONCAT(ISNULL(FirstName,''), ' ', ISNULL(LastName,'')))) AS StaffName
                FROM dbo.Staff
                ORDER BY StaffID", cn)
                da.Fill(dt)
            End Using

            If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
            For Each r As DataRow In dt.Rows
                r("Display") = $"{CInt(r("StaffID")):000} — {CStr(r("StaffName"))}"
            Next

            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "Display"
            ComboBox1.ValueMember = "StaffID"
            ConfigureCombo(ComboBox1)
        End Using
    End Sub

    ' ---------- Status (EditStatusAppoint) ----------
    Private Sub LoadStatus()
        With EditStatusAppoint
            .DataSource = Nothing
            .Items.Clear()
            .Items.AddRange(New Object() {"Complete", "Waiting", "Cancel"})
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = 1 ' ค่าเริ่มต้น = Waiting
        End With
    End Sub

    ' ---------- Load current appointment ----------
    Private Sub LoadForEdit(id As Integer)
        Using cn = Conn()
            cn.Open()
            Using cmd As New SqlCommand("
SELECT Appointment_ID, Patient_ID, WardNumber, Date_appoint, ExaminationRoom, Status, Staff_ID
FROM dbo.PatientAppointment
WHERE Appointment_ID=@id;", cn)
                cmd.Parameters.AddWithValue("@id", id)
                Using rd = cmd.ExecuteReader()
                    If Not rd.Read() Then
                        MessageBox.Show("ไม่พบรายการนัด", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Close() : Return
                    End If

                    ' Patient / Ward
                    cmb_EditPtnApoint.SelectedValue = If(rd("Patient_ID") Is DBNull.Value, -1, CInt(rd("Patient_ID")))
                    cmb_EditWardAppoint.SelectedValue = If(rd("WardNumber") Is DBNull.Value, -1, CInt(rd("WardNumber")))

                    ' Date
                    If rd("Date_appoint") Is DBNull.Value Then
                        dtp_EditAppointDate.Checked = False
                    Else
                        dtp_EditAppointDate.Checked = True
                        dtp_EditAppointDate.Value = CDate(rd("Date_appoint"))
                    End If

                    ' Room
                    txtb_EditExamRoom.Text = If(rd("ExaminationRoom") Is DBNull.Value, "", CStr(rd("ExaminationRoom")))

                    ' Status
                    Dim st As String = If(rd("Status") Is DBNull.Value, "", CStr(rd("Status")))
                    If Not String.IsNullOrWhiteSpace(st) AndAlso EditStatusAppoint.Items.Contains(st) Then
                        EditStatusAppoint.SelectedItem = st
                    Else
                        ' กรณีค่าเดิมไม่อยู่ในลิสต์ → ให้เป็น Waiting
                        EditStatusAppoint.SelectedIndex = 1
                    End If

                    ' Staff
                    ComboBox1.SelectedValue = If(rd("Staff_ID") Is DBNull.Value, -1, CInt(rd("Staff_ID")))
                End Using
            End Using
        End Using
    End Sub

    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked,
                  CType(DBNull.Value, Object),
                  dtp.Value.Date)
    End Function

    ' ---------- Save ----------
    Private Sub btn_SaveEditAppoint_Click(sender As Object, e As EventArgs) Handles btn_SaveEditAppoint.Click
        ' validate เบื้องต้น
        If cmb_EditPtnApoint.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือกผู้ป่วย", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If cmb_EditWardAppoint.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Ward", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Staff/แพทย์", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If EditStatusAppoint.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานะนัดหมาย", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If

        Try
            Using cn = Conn()
                cn.Open()
                Using cmd As New SqlCommand("
UPDATE dbo.PatientAppointment
SET Patient_ID=@pid,
    WardNumber=@ward,
    Date_appoint=@dt,
    ExaminationRoom=@room,
    Status=@status,
    Staff_ID=@staff
WHERE Appointment_ID=@id;", cn)

                    cmd.Parameters.AddWithValue("@id", AppointmentId)
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = CInt(cmb_EditPtnApoint.SelectedValue)
                    cmd.Parameters.Add("@ward", SqlDbType.Int).Value = CInt(cmb_EditWardAppoint.SelectedValue)
                    cmd.Parameters.Add("@dt", SqlDbType.Date).Value = DtpOrNull(dtp_EditAppointDate)
                    cmd.Parameters.Add("@room", SqlDbType.NVarChar, 50).Value =
                        If(String.IsNullOrWhiteSpace(txtb_EditExamRoom.Text), CType(DBNull.Value, Object), txtb_EditExamRoom.Text.Trim())
                    cmd.Parameters.Add("@status", SqlDbType.NVarChar, 30).Value = CStr(EditStatusAppoint.SelectedItem)
                    cmd.Parameters.Add("@staff", SqlDbType.Int).Value = CInt(ComboBox1.SelectedValue)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("บันทึกการแก้ไขเรียบร้อย", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------- Delete ----------
    Private Sub btn_EditDeleteAppoint_Click(sender As Object, e As EventArgs) Handles btn_EditDeleteAppoint.Click
        If MessageBox.Show("ต้องการลบรายการนัดนี้หรือไม่?", "Confirm Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using cn = Conn()
                cn.Open()
                Using cmd As New SqlCommand("DELETE FROM dbo.PatientAppointment WHERE Appointment_ID=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", AppointmentId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("ลบเรียบร้อย", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_EditCancleAppoint_Click(sender As Object, e As EventArgs) Handles btn_EditCancleAppoint.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
