Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddPharmaceuticalSupplie

    ' === Connection ===
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Sub FormAddPharmaceuticalSupplie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' บังคับช่องจำนวนให้พิมพ์ตัวเลขเท่านั้น
        AddHandler TextBox5.KeyPress, AddressOf OnlyDigits_KeyPress   ' Qty_in_stock
        AddHandler TextBox6.KeyPress, AddressOf OnlyDigits_KeyPress   ' Reorder_level

        Me.AcceptButton = Button1save
        Me.CancelButton = Button2can
    End Sub

    Private Sub OnlyDigits_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ===== ตรวจสอบข้อมูล =====
    Private Function ValidateForm(ByRef qty As Integer, ByRef reorder As Integer) As String
        Dim sb As New System.Text.StringBuilder()

        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            sb.AppendLine("กรุณากรอก DrugName")
        End If
        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            sb.AppendLine("กรุณากรอก Dosage")
        End If
        If Not Integer.TryParse(TextBox5.Text, qty) Then
            sb.AppendLine("Qty_in_stock ต้องเป็นตัวเลขจำนวนเต็ม")
        End If
        If Not Integer.TryParse(TextBox6.Text, reorder) Then
            sb.AppendLine("Reorder_level ต้องเป็นตัวเลขจำนวนเต็ม")
        End If

        Return sb.ToString()
    End Function

    ' ===== Save =====
    Private Sub Button1save_Click(sender As Object, e As EventArgs) Handles Button1save.Click
        Dim qty As Integer, reorder As Integer
        Dim err = ValidateForm(qty, reorder)
        If err.Length > 0 Then
            MessageBox.Show(err, "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' กันชื่อซ้ำแบบง่าย ๆ
        Dim existsSql As String =
"SELECT COUNT(1) 
   FROM dbo.Pharmaceutical_Supplie 
  WHERE DrugName = @name;"

        ' เพิ่ม Cost_per_unit = 0 (ไม่มี TextBox7)
        Dim insertSql As String =
"INSERT INTO dbo.Pharmaceutical_Supplie
 (DrugName, [Description], Dosage, Method_of_admin, Qty_in_stock, Reorder_level, Cost_per_unit)
 OUTPUT INSERTED.Drug_Number
 VALUES
 (@name, @desc, @dose, @moa, @qty, @reorder, @cost);"

        Try
            Using cn As New SqlConnection(ConnStr)
                cn.Open()

                ' ตรวจชื่อซ้ำ
                Using chk As New SqlCommand(existsSql, cn)
                    chk.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = TextBox1.Text.Trim()
                    Dim dup = Convert.ToInt32(chk.ExecuteScalar())
                    If dup > 0 Then
                        If MessageBox.Show("มีชื่อยานี้อยู่แล้ว ต้องการเพิ่มซ้ำหรือไม่?",
                                           "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Exit Sub
                        End If
                    End If
                End Using

                ' Insert จริง
                Using cmd As New SqlCommand(insertSql, cn)
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = TextBox1.Text.Trim()
                    cmd.Parameters.Add("@desc", SqlDbType.NVarChar, -1).Value = TextBox3.Text.Trim()
                    cmd.Parameters.Add("@dose", SqlDbType.NVarChar, 50).Value = TextBox4.Text.Trim()
                    cmd.Parameters.Add("@moa", SqlDbType.NVarChar, 100).Value = ""     ' ฟอร์มนี้ไม่มีช่อง Method_of_admin → ค่าว่าง
                    cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty
                    cmd.Parameters.Add("@reorder", SqlDbType.Int).Value = reorder

                    ' ===== Cost_per_unit = 0 =====
                    ' ถ้าคอลัมน์เป็น DECIMAL(18,2)
                    Dim p = cmd.Parameters.Add("@cost", SqlDbType.Decimal)
                    p.Precision = 18 : p.Scale = 2 : p.Value = 0D
                    ' (ถ้าใน DB เป็น money ให้ใช้แทน: cmd.Parameters.Add("@cost", SqlDbType.Money).Value = 0D)

                    Dim newId = Convert.ToInt32(cmd.ExecuteScalar())
                    MessageBox.Show($"บันทึกสำเร็จ (Drug_Number = {newId})",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using

            Me.DialogResult = DialogResult.OK

        Catch ex As SqlException
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== Cancel =====
    Private Sub Button2can_Click(sender As Object, e As EventArgs) Handles Button2can.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class

