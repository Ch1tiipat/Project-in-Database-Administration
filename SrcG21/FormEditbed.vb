Imports System.Data.SqlClient

Public Class FormEditBed
    Private ReadOnly ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private ReadOnly _bedNumber As Integer

    ' เรียกจาก FormBed ตอนกด Edit
    Public Sub New(bedNumber As Integer)
        InitializeComponent()
        _bedNumber = bedNumber
    End Sub

    Private Sub FormEditBed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' แนะนำให้ล็อกให้เลือกจากรายการเท่านั้น
        cmb_wardname.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_Editbedtype.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_editbedstatus.DropDownStyle = ComboBoxStyle.DropDownList

        LoadWardCombo()
        LoadBedTypeCombo()
        LoadBedStatusCombo()

        ' โหลดข้อมูลเดิมของเตียงนี้ แล้วเซ็ตค่าให้คอมโบ
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText =
"SELECT b.Bed_Number, w.WardName, b.Bed_Type, b.Bed_Status
   FROM dbo.Bed b
   LEFT JOIN dbo.Ward w ON w.WardNumber = b.WardNumber
  WHERE b.Bed_Number=@Bed_Number;"
            cmd.Parameters.AddWithValue("@Bed_Number", _bedNumber)
            conn.Open()
            Using r = cmd.ExecuteReader()
                If r.Read() Then
                    Dim wardName = r("WardName").ToString()
                    Dim bedType = r("Bed_Type").ToString()
                    Dim bedStatus = r("Bed_Status").ToString()

                    ' เลือกค่าในคอมโบ ถ้าไม่มีในลิสต์ให้เติมเข้าไปก่อน
                    If Not cmb_wardname.Items.Contains(wardName) AndAlso wardName <> "" Then
                        cmb_wardname.Items.Add(wardName)
                    End If
                    cmb_wardname.SelectedItem = wardName

                    If Not cmb_Editbedtype.Items.Contains(bedType) AndAlso bedType <> "" Then
                        cmb_Editbedtype.Items.Add(bedType)
                    End If
                    cmb_Editbedtype.SelectedItem = bedType

                    If Not cmb_editbedstatus.Items.Contains(bedStatus) AndAlso bedStatus <> "" Then
                        cmb_editbedstatus.Items.Add(bedStatus)
                    End If
                    cmb_editbedstatus.SelectedItem = bedStatus
                End If
            End Using
        End Using
    End Sub

    Private Sub LoadWardCombo()
        cmb_wardname.Items.Clear()
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = "SELECT WardName FROM dbo.Ward ORDER BY WardName;"
            conn.Open()
            Using r = cmd.ExecuteReader()
                While r.Read()
                    cmb_wardname.Items.Add(r.GetString(0))
                End While
            End Using
        End Using
        If cmb_wardname.Items.Count = 0 Then
            cmb_wardname.Items.AddRange({"Orthopaedic", "Geriatric", "Cardiology", "Neurology", "General"})
        End If
    End Sub

    Private Sub LoadBedTypeCombo()
        cmb_Editbedtype.Items.Clear()
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = "SELECT DISTINCT Bed_Type FROM dbo.Bed WHERE Bed_Type IS NOT NULL ORDER BY Bed_Type;"
            conn.Open()
            Using r = cmd.ExecuteReader()
                While r.Read()
                    cmb_Editbedtype.Items.Add(r.GetString(0))
                End While
            End Using
        End Using
        If cmb_Editbedtype.Items.Count = 0 Then
            cmb_Editbedtype.Items.AddRange({"Standard", "ICU"})
        End If
    End Sub

    Private Sub LoadBedStatusCombo()
        cmb_editbedstatus.Items.Clear()
        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = "SELECT DISTINCT Bed_Status FROM dbo.Bed WHERE Bed_Status IS NOT NULL ORDER BY Bed_Status;"
            conn.Open()
            Using r = cmd.ExecuteReader()
                While r.Read()
                    cmb_editbedstatus.Items.Add(r.GetString(0))
                End While
            End Using
        End Using
        If cmb_editbedstatus.Items.Count = 0 Then
            cmb_editbedstatus.Items.AddRange({"Available", "Occupied"})
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Dim wardName = If(cmb_wardname.SelectedItem?.ToString(), "").Trim()
            Dim bedType = If(cmb_Editbedtype.SelectedItem?.ToString(), "").Trim()
            Dim bedStatus = If(cmb_editbedstatus.SelectedItem?.ToString(), "").Trim()

            If wardName = "" OrElse bedType = "" OrElse bedStatus = "" Then
                MessageBox.Show("กรุณาเลือก Ward, Bed Type และ Bed Status ให้ครบ", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
                cmd.CommandText =
"DECLARE @WardNumber INT = (SELECT TOP 1 WardNumber FROM dbo.Ward WHERE WardName=@WardName);
IF @WardNumber IS NULL
BEGIN
    RAISERROR('ไม่พบ WardName ในตาราง Ward', 16, 1); RETURN;
END
UPDATE dbo.Bed
   SET WardNumber=@WardNumber,
       Bed_Type=@Bed_Type,
       Bed_Status=@Bed_Status
 WHERE Bed_Number=@Bed_Number;"
                cmd.Parameters.AddWithValue("@Bed_Number", _bedNumber)
                cmd.Parameters.AddWithValue("@WardName", wardName)
                cmd.Parameters.AddWithValue("@Bed_Type", bedType)
                cmd.Parameters.AddWithValue("@Bed_Status", bedStatus)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("บันทึกสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ:" & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_deletebed_Click(sender As Object, e As EventArgs) Handles btn_deletebed.Click
        If MessageBox.Show("ลบข้อมูลเตียงนี้?", "Confirm",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM dbo.Bed WHERE Bed_Number=@Bed_Number;"
                cmd.Parameters.AddWithValue("@Bed_Number", _bedNumber)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("ลบข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ:" & Environment.NewLine & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
