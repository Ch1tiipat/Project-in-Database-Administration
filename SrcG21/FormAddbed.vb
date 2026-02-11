Imports System.Data.SqlClient

Public Class FormAddBed
    Private ReadOnly ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Sub FormAddBed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ปิดการพิมพ์อิสระ (แนะนำ)
        cmb_addwardname.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_addbedtype.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_addstatus.DropDownStyle = ComboBoxStyle.DropDownList

        ' โหลดคอมโบบ็อกซ์ทั้งหมด
        LoadWardCombo()
        LoadBedTypeCombo()
        LoadBedStatusCombo()
    End Sub

    Private Sub LoadWardCombo()
        cmb_addwardname.Items.Clear()
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = "SELECT WardName FROM dbo.Ward ORDER BY WardName"
            conn.Open()
            Using r = cmd.ExecuteReader()
                While r.Read()
                    cmb_addwardname.Items.Add(r.GetString(0))
                End While
            End Using
        End Using
        ' เผื่อกรณีฐานข้อมูลยังว่าง
        If cmb_addwardname.Items.Count = 0 Then
            cmb_addwardname.Items.AddRange({"Orthopaedic", "Geriatric", "Cardiology", "Neurology", "General"})
        End If
    End Sub

    Private Sub LoadBedTypeCombo()
        cmb_addbedtype.Items.Clear()
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = "SELECT DISTINCT Bed_Type FROM dbo.Bed WHERE Bed_Type IS NOT NULL ORDER BY Bed_Type"
            conn.Open()
            Using r = cmd.ExecuteReader()
                While r.Read()
                    cmb_addbedtype.Items.Add(r.GetString(0))
                End While
            End Using
        End Using
        If cmb_addbedtype.Items.Count = 0 Then
            cmb_addbedtype.Items.AddRange({"Standard", "ICU"})
        End If
    End Sub

    Private Sub LoadBedStatusCombo()
        cmb_addstatus.Items.Clear()
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = "SELECT DISTINCT Bed_Status FROM dbo.Bed WHERE Bed_Status IS NOT NULL ORDER BY Bed_Status"
            conn.Open()
            Using r = cmd.ExecuteReader()
                While r.Read()
                    cmb_addstatus.Items.Add(r.GetString(0))
                End While
            End Using
        End Using
        If cmb_addstatus.Items.Count = 0 Then
            cmb_addstatus.Items.AddRange({"Available", "Occupied"})
        End If
    End Sub

    Private Sub btn_Addbed_Click(sender As Object, e As EventArgs) Handles btn_Addbed.Click
        Try
            Dim wardName As String = If(cmb_addwardname.SelectedItem?.ToString(), cmb_addwardname.Text).Trim()
            Dim bedType As String = If(cmb_addbedtype.SelectedItem?.ToString(), cmb_addbedtype.Text).Trim()
            Dim bedStatus As String = If(cmb_addstatus.SelectedItem?.ToString(), cmb_addstatus.Text).Trim()

            If String.IsNullOrWhiteSpace(wardName) OrElse
               String.IsNullOrWhiteSpace(bedType) OrElse
               String.IsNullOrWhiteSpace(bedStatus) Then
                MessageBox.Show("กรอก/เลือก Ward, Bed Type และ Bed Status ให้ครบ", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim newBedNumber As Integer
            Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
                ' ไม่ระบุ Bed_Number ให้ DB สร้าง (IDENTITY) แล้วอ่านกลับด้วย SCOPE_IDENTITY()
                cmd.CommandText =
"DECLARE @WardNumber INT = (SELECT TOP 1 WardNumber FROM dbo.Ward WHERE WardName=@WardName);
IF @WardNumber IS NULL
BEGIN
    RAISERROR('ไม่พบ WardName ในตาราง Ward', 16, 1); RETURN;
END
INSERT INTO dbo.Bed (Bed_Status, Bed_Type, WardNumber)
VALUES (@Bed_Status, @Bed_Type, @WardNumber);
SELECT CAST(SCOPE_IDENTITY() AS INT);"

                cmd.Parameters.AddWithValue("@WardName", wardName)
                cmd.Parameters.AddWithValue("@Bed_Status", bedStatus)
                cmd.Parameters.AddWithValue("@Bed_Type", bedType)

                conn.Open()
                newBedNumber = CInt(cmd.ExecuteScalar())
            End Using

            MessageBox.Show($"เพิ่มข้อมูลสำเร็จ (Bed Number = {newBedNumber})", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ:" & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Canclebed_Click(sender As Object, e As EventArgs) Handles btn_Canclebed.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
