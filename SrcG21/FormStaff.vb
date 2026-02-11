Public Class FormStaff
    Private Sub btnStaffSt_Click(sender As Object, e As EventArgs) Handles btnStaffSt.Click
        FormStaff1.Show()
    End Sub

    Private Sub FormStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStaffAsm_Click(sender As Object, e As EventArgs) Handles btnStaffAsm.Click
        FormStaffAssingment.Show()
    End Sub
End Class