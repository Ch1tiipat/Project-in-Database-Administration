Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddward
    Private ReadOnly _cs As String

    Public Sub New(cs As String)
        InitializeComponent()
        If String.IsNullOrWhiteSpace(cs) Then Throw New InvalidOperationException("ConnectionString required.")
        _cs = cs
    End Sub

    Private Sub FormAddward1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtb_editwardid.ReadOnly = True
        txtb_editwardid.TabStop = False
        Me.AcceptButton = btn_Addward     ' ปุ่ม Add
        Me.CancelButton = btn_cancle      ' ปุ่ม Cancel
    End Sub

    ' ===== ป้องกันให้ totalbed พิมพ์ได้เฉพาะตัวเลข =====
    Private Sub totalbed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles totalbed.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ADD
    Private Sub btn_Addward_Click(sender As Object, e As EventArgs) Handles btn_Addward.Click
        ' --- ตรวจว่าง ---
        If String.IsNullOrWhiteSpace(txtb_name.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_exnum.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_location.Text) OrElse
           String.IsNullOrWhiteSpace(totalbed.Text) Then
            MessageBox.Show("กรอกข้อมูลให้ครบทุกช่อง", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- ตรวจ Total Bed เป็นตัวเลข ≥ 0 ---
        Dim beds As Integer
        If Not Integer.TryParse(totalbed.Text.Trim(), beds) OrElse beds < 0 Then
            MessageBox.Show("Total Bed ต้องเป็นเลขจำนวนเต็มตั้งแต่ 0 ขึ้นไป", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            totalbed.Focus()
            totalbed.SelectAll()
            Exit Sub
        End If

        Try
            Using cn As New SqlConnection(_cs)
                cn.Open()

                Dim sql As String =
"INSERT INTO dbo.Ward (WardName, WardLocation, TotalBed, TelExten)
 VALUES (@WardName, @WardLocation, @TotalBed, @TelExten);
 SELECT CAST(SCOPE_IDENTITY() AS int);"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@WardName", SqlDbType.NVarChar, 100).Value = txtb_name.Text.Trim()
                    cmd.Parameters.Add("@WardLocation", SqlDbType.NVarChar, 50).Value = txtb_location.Text.Trim()
                    cmd.Parameters.Add("@TotalBed", SqlDbType.Int).Value = beds
                    cmd.Parameters.Add("@TelExten", SqlDbType.NVarChar, 10).Value = txtb_exnum.Text.Trim()

                    Dim newId As Integer = CInt(cmd.ExecuteScalar())
                    txtb_editwardid.Text = newId.ToString()
                End Using
            End Using

            MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException
            MessageBox.Show("SQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    End Sub
End Class
