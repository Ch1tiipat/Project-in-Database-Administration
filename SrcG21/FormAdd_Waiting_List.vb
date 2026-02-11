Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddWaitingList

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ---------- utils ----------
    Private Sub MakeDtpNullable(c As Control)
        If TypeOf c Is DateTimePicker Then
            Dim d = DirectCast(c, DateTimePicker)
            d.ShowCheckBox = True
            d.Checked = True
        End If
        For Each ch As Control In c.Controls
            MakeDtpNullable(ch)
        Next
    End Sub

    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        If dtp.ShowCheckBox AndAlso Not dtp.Checked Then
            Return DBNull.Value
        End If
        Return dtp.Value.Date
    End Function

    ' ---------- load ----------
    Private Sub FormAddWaitingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeDtpNullable(Me)
        LoadPatients()
        LoadWards()
        LoadStatuses()
    End Sub

    Private Sub LoadPatients()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter("
                    SELECT CAST(Patient_ID AS int) AS Patient_ID,
                           (FirstName + ' ' + LastName) AS PatientName
                    FROM dbo.Patient
                    ORDER BY PatientName;", cn)
                    da.Fill(dt)
                End Using
                With cmb_addpanid
                    .DisplayMember = "PatientName"
                    .ValueMember = "Patient_ID"
                    .DataSource = dt
                    .DropDownStyle = ComboBoxStyle.DropDownList
                End With
            End Using
        Catch
            cmb_addpanid.DataSource = Nothing
        End Try
    End Sub

    Private Sub LoadWards()
        Try
            Using cn = Conn()
                cn.Open()
                Dim dt As New DataTable()
                Using da As New SqlDataAdapter("
                    SELECT WardNumber, WardName
                    FROM dbo.Ward
                    ORDER BY WardName;", cn)
                    da.Fill(dt)
                End Using
                With cmb_addward
                    .DisplayMember = "WardName"
                    .ValueMember = "WardNumber"
                    .DataSource = dt
                    .DropDownStyle = ComboBoxStyle.DropDownList
                End With
            End Using
        Catch
            cmb_addward.DataSource = Nothing
        End Try
    End Sub

    Private Sub LoadStatuses()
        cmb_addstatus.Items.Clear()
        cmb_addstatus.Items.AddRange(New Object() {"Waiting", "Bed Assigned"})
        cmb_addstatus.DropDownStyle = ComboBoxStyle.DropDownList
        If cmb_addstatus.Items.Count > 0 Then cmb_addstatus.SelectedIndex = 0
    End Sub

    ' ---------- actions ----------
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        ' validate
        If cmb_addpanid.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือก Patient", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If cmb_addward.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือก Ward", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If cmb_addstatus.SelectedItem Is Nothing Then
            MessageBox.Show("กรุณาเลือก Status", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using cn = Conn()
                cn.Open()

                Using cmd As New SqlCommand("
INSERT INTO dbo.Waiting_List (Patient_ID, Date_Added, WardNumber, Status)
VALUES (@pid, @dateAdded, @wardNumber, @status);", cn)

                    ' แนะนำให้ระบุชนิดพารามิเตอร์ให้ตรงกับคอลัมน์
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = CInt(cmb_addpanid.SelectedValue)

                    ' ถ้า Date_Added เป็น NOT NULL ควรบังคับให้ติ๊ก Checkbox ของ dtp_adddate
                    Dim dateObj As Object = DtpOrNull(dtp_adddate)
                    If dateObj Is DBNull.Value Then
                        cmd.Parameters.Add("@dateAdded", SqlDbType.Date).Value = Date.Today
                    Else
                        cmd.Parameters.Add("@dateAdded", SqlDbType.Date).Value = CDate(dateObj)
                    End If

                    cmd.Parameters.Add("@wardNumber", SqlDbType.Int).Value = CInt(cmb_addward.SelectedValue)
                    cmd.Parameters.Add("@status", SqlDbType.VarChar, 20).Value = cmb_addstatus.Text

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("เพิ่มรายการสำเร็จ", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class

