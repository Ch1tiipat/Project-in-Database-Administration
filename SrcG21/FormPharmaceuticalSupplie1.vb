Imports System.Data
Imports System.Data.SqlClient

Public Class FormPharmaceuticalSupplie1

    ' ===== Connection =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    ' รับ PK จากหน้าค้นหา (Drug_Number)
    Public Property DrugId As Integer

    ' ===== Load =====
    Private Sub FormPharmaceuticalSupplie1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DrugId <= 0 Then
            MessageBox.Show("ไม่พบรหัสยา (DrugId) ที่จะเปิดแก้ไข", "Invalid ID",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Exit Sub
        End If

        Me.AcceptButton = SaveFrPhrSup
        Me.CancelButton = CancleFrPhrSup

        AddHandler txtQty.KeyPress, AddressOf OnlyDigits_KeyPress
        AddHandler txtReorder.KeyPress, AddressOf OnlyDigits_KeyPress

        LoadDrugForEdit()
    End Sub

    Private Sub OnlyDigits_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' ===== โหลดข้อมูลรายการที่จะแก้ไข =====
    Private Sub LoadDrugForEdit()
        Dim sql As String =
"SELECT Drug_Number AS DrugID,
        DrugName,
        [Description],
        Dosage,
        Qty_in_stock,
        Reorder_level
  FROM dbo.Pharmaceutical_Supplie
 WHERE Drug_Number = @id;"

        Try
            Using cn As New SqlConnection(ConnStr),
                  cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DrugId

                cn.Open()
                Using rd = cmd.ExecuteReader()
                    If rd.Read() Then
                        TextBox1E.Text = rd("DrugName").ToString()
                        txtDescription.Text = rd("Description").ToString()
                        txtDosage.Text = rd("Dosage").ToString()
                        txtQty.Text = If(IsDBNull(rd("Qty_in_stock")), "0", Convert.ToInt32(rd("Qty_in_stock")).ToString())
                        txtReorder.Text = If(IsDBNull(rd("Reorder_level")), "0", Convert.ToInt32(rd("Reorder_level")).ToString())
                    Else
                        MessageBox.Show("ไม่พบข้อมูลยา", "Not found",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.DialogResult = DialogResult.Cancel
                        Me.Close()
                    End If
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("โหลดข้อมูลไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== ตรวจสอบก่อนบันทึก =====
    Private Function ValidateForm(ByRef outQty As Integer, ByRef outReorder As Integer) As String
        Dim sb As New Text.StringBuilder()

        If String.IsNullOrWhiteSpace(TextBox1E.Text) Then
            sb.AppendLine("กรุณากรอก DrugName")
        End If

        If String.IsNullOrWhiteSpace(txtDosage.Text) Then
            sb.AppendLine("กรุณากรอก Dosage")
        End If

        If Not Integer.TryParse(txtQty.Text, outQty) Then
            sb.AppendLine("Qty_in_stock ต้องเป็นตัวเลขจำนวนเต็ม")
        End If

        If Not Integer.TryParse(txtReorder.Text, outReorder) Then
            sb.AppendLine("Reorder_level ต้องเป็นตัวเลขจำนวนเต็ม")
        End If

        Return sb.ToString()
    End Function

    ' ===== Save (UPDATE) =====
    Private Sub SaveFrPhrSup_Click(sender As Object, e As EventArgs) Handles SaveFrPhrSup.Click
        Dim qty As Integer, reorder As Integer
        Dim err = ValidateForm(qty, reorder)
        If err.Length > 0 Then
            MessageBox.Show(err, "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim sql As String =
"UPDATE dbo.Pharmaceutical_Supplie
   SET DrugName      = @name,
       [Description] = @desc,
       Dosage        = @dose,
       Qty_in_stock  = @qty,
       Reorder_level = @reorder
 WHERE Drug_Number   = @id;"

        Try
            Using cn As New SqlConnection(ConnStr),
                  cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = TextBox1E.Text.Trim()
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar, -1).Value = txtDescription.Text.Trim()
                cmd.Parameters.Add("@dose", SqlDbType.NVarChar, 50).Value = txtDosage.Text.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty
                cmd.Parameters.Add("@reorder", SqlDbType.Int).Value = reorder
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DrugId

                cn.Open()
                Dim n = cmd.ExecuteNonQuery()
                If n > 0 Then
                    MessageBox.Show("บันทึกเรียบร้อย", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                Else
                    MessageBox.Show("ไม่พบข้อมูลให้แก้ไข", "No change",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As SqlException
            MessageBox.Show("อัปเดตไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== Delete =====
    Private Sub DeletephamaED_Click(sender As Object, e As EventArgs) Handles DeletephamaED.Click
        If MessageBox.Show("ยืนยันลบรายการยา?", "Confirm Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim sql As String = "DELETE FROM dbo.Pharmaceutical_Supplie WHERE Drug_Number = @id;"

        Try
            Using cn As New SqlConnection(ConnStr),
                  cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DrugId

                cn.Open()
                Dim n = cmd.ExecuteNonQuery()
                If n > 0 Then
                    MessageBox.Show("ลบเรียบร้อย", "Deleted",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("ไม่พบข้อมูลให้ลบ", "Not found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As SqlException
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("ผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== Cancel =====
    Private Sub CancleFrPhrSup_Click(sender As Object, e As EventArgs) Handles CancleFrPhrSup.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class


