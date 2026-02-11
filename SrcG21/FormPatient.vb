Public Class FormPatient
    Private Sub FormPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnPtnRe_Click(sender As Object, e As EventArgs) Handles btnPtnRe.Click
        FormPatientRegistration.Show()
    End Sub

    Private Sub btnPtnApp_Click(sender As Object, e As EventArgs) Handles btnPtnApp.Click
        FromEditPatientAppointment1.Show()
    End Sub

    Private Sub btnPtnInptn_Click(sender As Object, e As EventArgs) Handles btnPtnInptn.Click
        FormIn_Patients.Show()
    End Sub

    Private Sub btnPtnWal_Click(sender As Object, e As EventArgs) Handles btnPtnWal.Click
        FromWaitingList.show()
    End Sub
End Class