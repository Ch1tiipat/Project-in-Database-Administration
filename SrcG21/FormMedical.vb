Public Class FormMedical
    Private Sub btnMedPtn_Click(sender As Object, e As EventArgs) Handles btnMedPtn.Click
        FormMedicalPatientSearch.Show()
    End Sub

    Private Sub btnMedPs_Click(sender As Object, e As EventArgs) Handles btnMedPs.Click
        FormPharmaceuticalSupplie.show()
    End Sub

    Private Sub FormMedical_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class