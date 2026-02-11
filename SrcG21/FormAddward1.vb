Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddward1
    Private ReadOnly _cs As String
    Public Sub New(cs As String)
        InitializeComponent()
        If String.IsNullOrWhiteSpace(cs) Then Throw New InvalidOperationException("ConnectionString required.")
        _cs = cs
    End Sub

    Private Sub FormAddward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtb_editwardid.ReadOnly = True
        txtb_editwardid.TabStop = False
        Me.AcceptButton = btn_Addward
        Me.CancelButton = btn_Cancle
    End Sub

    ' Add
    Private Sub btn_Addditward_Click(sender As Object, e As EventArgs) Handles btn_Addward.Click
        Dim n As Integer
        If String.IsNullOrWhiteSpace(txtb_wardname.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_totalbed.Text) OrElse
           String.IsNullOrWhiteSpace(txt_exnum.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_location.Text) Then
            MessageBox.Show("กรอกข้อมูลให้ครบ", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If
        If Not Integer.TryParse(txtb_totalbed.Text, n) Then
            MessageBox.Show("Total Beds ต้องเป็นตัวเลข", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
        End If

        Try
            Using cn As New SqlConnection(_cs)
                cn.Open()
                Dim sql As String =
                    "INSERT INTO dbo.Ward (WardName, WardLocation, TotalBed, TelExten)
                     VALUES (@WardName, @WardLocation, @TotalBed, @TelExten);
                     SELECT CAST(SCOPE_IDENTITY() AS int);"
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@WardName", txtb_wardname.Text.Trim())
                    cmd.Parameters.AddWithValue("@WardLocation", txtb_location.Text.Trim())
                    cmd.Parameters.AddWithValue("@TotalBed", Integer.Parse(txtb_totalbed.Text.Trim()))
                    cmd.Parameters.AddWithValue("@TelExten", txt_exnum.Text.Trim())
                    Dim newId As Integer = CInt(cmd.ExecuteScalar())
                    txtb_editwardid.Text = newId.ToString()
                End Using
            End Using

            MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel
    Private Sub btn_Cancle_Click(sender As Object, e As EventArgs) Handles btn_Cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
