Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddPatientAppointment

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- LOAD ----------
    Private Sub FormAddPatientAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatients()
        LoadWards()
        LoadStaff()      ' โหลด Staff ลง ComboBox1
        LoadStatus()     ' โหลดสถานะลง AddStatusAppoint

        dtp_AddAppointDate.ShowCheckBox = True   ' ติ๊กออกได้เพื่อไม่บันทึกเวลา (NULL)
        dtp_AddAppointDate.Checked = True
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

            cmb_AddPtnApoint.DataBindings.Clear()
            cmb_AddPtnApoint.DataSource = Nothing
            cmb_AddPtnApoint.DisplayMember = "PatientName"
            cmb_AddPtnApoint.ValueMember = "Patient_ID"
            cmb_AddPtnApoint.DataSource = dt

            cmb_AddPtnApoint.DropDownStyle = ComboBoxStyle.DropDownList
            cmb_AddPtnApoint.AutoCompleteSource = AutoCompleteSource.ListItems
            cmb_AddPtnApoint.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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

            cmb_AddWardAppoint.DisplayMember = "Display"
            cmb_AddWardAppoint.ValueMember = "WardNumber"
            cmb_AddWardAppoint.DataSource = dt

            cmb_AddWardAppoint.DropDownStyle = ComboBoxStyle.DropDownList
            cmb_AddWardAppoint.AutoCompleteSource = AutoCompleteSource.ListItems
            cmb_AddWardAppoint.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    ' ---------- Staff: โชว์ "ID — ชื่อ นามสกุล", ค่า = StaffID ----------
    Private Sub LoadStaff()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()

            Dim sql As String = "
            SELECT 
                StaffID,
                LTRIM(RTRIM(CONCAT(ISNULL(FirstName,''), ' ', ISNULL(LastName,'')))) AS StaffName
            FROM dbo.Staff
            ORDER BY StaffID"

            Using da As New SqlDataAdapter(sql, cn)
                da.Fill(dt)
            End Using

            If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
            For Each r As DataRow In dt.Rows
                r("Display") = $"{CInt(r("StaffID")):000} — {CStr(r("StaffName"))}"
            Next

            ComboBox1.DataSource = Nothing
            ComboBox1.DisplayMember = "Display"
            ComboBox1.ValueMember = "StaffID"
            ComboBox1.DataSource = dt

            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems
            ComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    ' ---------- Status: คอมโบ 3 ค่า ----------
    Private Sub LoadStatus()
        With AddStatusAppoint
            .DataSource = Nothing
            .Items.Clear()
            .Items.AddRange(New Object() {"Complete", "Waiting", "Cancel"})
            .DropDownStyle = ComboBoxStyle.DropDownList
            .SelectedIndex = 1 ' ค่าเริ่มต้น = Waiting
        End With
    End Sub

    Private Function DbOrNull(s As String) As Object
        Return If(String.IsNullOrWhiteSpace(s), CType(DBNull.Value, Object), s.Trim())
    End Function

    ' ---------- ADD ----------
    Private Sub btn_AddAppoint_Click(sender As Object, e As EventArgs) Handles btn_AddAppoint.Click
        If cmb_AddPtnApoint.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือกผู้ป่วย", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If cmb_AddWardAppoint.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Ward", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Staff/แพทย์", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If AddStatusAppoint.SelectedIndex < 0 Then
            MessageBox.Show("กรุณาเลือกสถานะนัดหมาย", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If

        Try
            Using cn As New SqlConnection(ConnStr),
                  cmd As New SqlCommand("
                    INSERT INTO dbo.PatientAppointment
                        (Patient_ID, WardNumber, Date_appoint, Time_appoint, ExaminationRoom, Status, Staff_ID)
                    VALUES
                        (@pid, @ward, @dt, @tm, @room, @status, @staff);", cn)

                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = CInt(cmb_AddPtnApoint.SelectedValue)
                cmd.Parameters.Add("@ward", SqlDbType.Int).Value = CInt(cmb_AddWardAppoint.SelectedValue)
                cmd.Parameters.Add("@dt", SqlDbType.Date).Value = dtp_AddAppointDate.Value.Date

                ' เวลา: ถ้าเอาติ๊กออก → บันทึกเป็น NULL
                Dim tmVal As Object =
                    If(dtp_AddAppointDate.ShowCheckBox AndAlso Not dtp_AddAppointDate.Checked,
                       CType(DBNull.Value, Object),
                       CType(dtp_AddAppointDate.Value.TimeOfDay, Object))
                Dim pTm = cmd.Parameters.Add("@tm", SqlDbType.Time)
                pTm.Value = tmVal

                cmd.Parameters.Add("@room", SqlDbType.NVarChar, 50).Value = DbOrNull(txtb_AddExamRoom.Text)

                ' ใช้ค่าที่เลือกจากคอมโบ (DropDownList → ต้องมีค่าเสมอ)
                cmd.Parameters.Add("@status", SqlDbType.NVarChar, 30).Value = CStr(AddStatusAppoint.SelectedItem)

                cmd.Parameters.Add("@staff", SqlDbType.Int).Value = CInt(ComboBox1.SelectedValue)

                cn.Open()
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("เพิ่มรายการนัดเรียบร้อย", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException
            MessageBox.Show("บันทึกไม่สำเร็จ (SQL): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_CancleAppoint_Click(sender As Object, e As EventArgs) Handles btn_CancleAppoint.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
