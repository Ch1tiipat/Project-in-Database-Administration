Imports System.Data
Imports System.Data.SqlClient

Public Class FormEditward1
    Private ReadOnly _cs As String

    ' รับ Connection String ตอนสร้างฟอร์ม
    Public Sub New(cs As String)
        InitializeComponent()
        If String.IsNullOrWhiteSpace(cs) Then Throw New InvalidOperationException("ConnectionString required.")
        _cs = cs
    End Sub

    ' ===== รับค่า WardNumber จากตารางที่เรียกฟอร์มนี้ =====
    Public Property WardNumber As Integer = 0

    Private Sub FormEditward1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtb_Editward.ReadOnly = True
        txtb_Editward.TabStop = False
        Me.AcceptButton = btn_Save
        Me.CancelButton = btn_cancle

        If WardNumber > 0 Then
            LoadWard(WardNumber)
        End If
    End Sub

    ' ===== โหลดข้อมูลวอร์ดมาใส่คอนโทรล =====
    Private Sub LoadWard(wardNo As Integer)
        Const sql As String = "
            SELECT WardNumber, WardName, WardLocation, TotalBed, TelExten
            FROM dbo.Ward
            WHERE WardNumber = @id;"

        Try
            Using cn As New SqlConnection(_cs)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = wardNo
                    cn.Open()
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            txtb_Editward.Text = rd("WardNumber").ToString()
                            txtb_editwardname.Text = If(rd.IsDBNull(rd.GetOrdinal("WardName")), "", rd("WardName").ToString())
                            txtb_location.Text = If(rd.IsDBNull(rd.GetOrdinal("WardLocation")), "", rd("WardLocation").ToString())
                            ttbedinward.Text = If(rd.IsDBNull(rd.GetOrdinal("TotalBed")), "0", rd("TotalBed").ToString())
                            txtb_editnum.Text = If(rd.IsDBNull(rd.GetOrdinal("TelExten")), "", rd("TelExten").ToString())
                        Else
                            MessageBox.Show("ไม่พบข้อมูล Ward นี้", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("โหลดข้อมูลวอร์ดไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== บันทึกการแก้ไข (UPDATE) =====
    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If String.IsNullOrWhiteSpace(txtb_Editward.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_editwardname.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_editnum.Text) OrElse
           String.IsNullOrWhiteSpace(txtb_location.Text) OrElse
           String.IsNullOrWhiteSpace(ttbedinward.Text) Then
            MessageBox.Show("กรอกข้อมูลให้ครบ", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim beds As Integer
        If Not Integer.TryParse(ttbedinward.Text.Trim(), beds) OrElse beds < 0 Then
            MessageBox.Show("Total Bed ต้องเป็นเลขจำนวนเต็มตั้งแต่ 0 ขึ้นไป", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ttbedinward.Focus()
            ttbedinward.SelectAll()
            Exit Sub
        End If

        Try
            Using cn As New SqlConnection(_cs)
                cn.Open()
                Dim sql As String =
"UPDATE dbo.Ward
   SET WardName=@WardName,
       WardLocation=@WardLocation,
       TotalBed=@TotalBed,
       TelExten=@TelExten
 WHERE WardNumber=@WardNumber;"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@WardNumber", SqlDbType.Int).Value = Integer.Parse(txtb_Editward.Text.Trim())
                    cmd.Parameters.Add("@WardName", SqlDbType.NVarChar, 100).Value = txtb_editwardname.Text.Trim()
                    cmd.Parameters.Add("@WardLocation", SqlDbType.NVarChar, 50).Value = txtb_location.Text.Trim()
                    cmd.Parameters.Add("@TotalBed", SqlDbType.Int).Value = beds
                    cmd.Parameters.Add("@TelExten", SqlDbType.NVarChar, 10).Value = txtb_editnum.Text.Trim()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("บันทึกการแก้ไขแล้ว", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException
            MessageBox.Show("SQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("อัปเดตไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== ลบ (DELETE) =====
    Private Sub btn_EditDelete_Click(sender As Object, e As EventArgs) Handles btn_EditDelete.Click
        If String.IsNullOrWhiteSpace(txtb_Editward.Text) Then
            MessageBox.Show("ยังไม่มี Ward ID", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("ยืนยันการลบรายการนี้?", "Confirm",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Try
            Using cn As New SqlConnection(_cs)
                cn.Open()
                Using cmd As New SqlCommand("DELETE FROM dbo.Ward WHERE WardNumber=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Integer.Parse(txtb_Editward.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("ลบสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException
            MessageBox.Show("SQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== ยกเลิก =====
    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' ===== ให้พิมพ์ได้เฉพาะตัวเลขใน Total Bed =====
    Private Sub ttbedinward_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ttbedinward.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
