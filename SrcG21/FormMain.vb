Public Class FormMain
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormHome.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With txtb_password
            .UseSystemPasswordChar = True   ' ใช้ bullet มาตรฐานของระบบ (•)
            .ForeColor = Color.Black        ' ให้เป็นสีดำเข้ม
            '.Font = New Font(.Font, FontStyle.Bold)  ' (ไม่บังคับ) ถ้าอยากให้ดูเข้มขึ้น
        End With
    End Sub
End Class
