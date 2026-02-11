Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class FormPharmaceuticalSupplie

    ' === Connection ===
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Sub FormPharmaceuticalSupplie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ตั้งค่ากริด
        With DataGridViewPhama
            .Dock = DockStyle.None
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoGenerateColumns = False   ' << ปิด AutoGenerateColumns
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

        EnsureColumns() ' << เพิ่มคอลัมน์ที่ต้องการแสดงเท่านั้น

        Me.AcceptButton = SrcPhama
        LoadGrid("")
    End Sub

    ' ===== สร้างคอลัมน์ที่ต้องการแสดง =====
    Private Sub EnsureColumns()
        DataGridViewPhama.Columns.Clear()

        ' Drug number (อ่านจากฟิลด์ alias: DrugNumber)
        Dim colDrugNo As New DataGridViewTextBoxColumn() With {
            .Name = "DrugNumber",
            .HeaderText = "Drug number",
            .DataPropertyName = "DrugNumber",
            .ReadOnly = True
        }
        DataGridViewPhama.Columns.Add(colDrugNo)

        ' DrugName
        Dim colName As New DataGridViewTextBoxColumn() With {
            .Name = "DrugName",
            .HeaderText = "DrugName",
            .DataPropertyName = "DrugName",
            .ReadOnly = True
        }
        DataGridViewPhama.Columns.Add(colName)

        ' Dosage
        Dim colDosage As New DataGridViewTextBoxColumn() With {
            .Name = "Dosage",
            .HeaderText = "Dosage",
            .DataPropertyName = "Dosage",
            .ReadOnly = True
        }
        DataGridViewPhama.Columns.Add(colDosage)

        ' Qty_in_stock
        Dim colQty As New DataGridViewTextBoxColumn() With {
            .Name = "Qty_in_stock",
            .HeaderText = "Qty_in_stock",
            .DataPropertyName = "Qty_in_stock",
            .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0"}
        }
        DataGridViewPhama.Columns.Add(colQty)

        ' Reorder_level
        Dim colReorder As New DataGridViewTextBoxColumn() With {
            .Name = "Reorder_level",
            .HeaderText = "Reorder_level",
            .DataPropertyName = "Reorder_level",
            .ReadOnly = True,
            .DefaultCellStyle = New DataGridViewCellStyle() With {.Format = "N0"}
        }
        DataGridViewPhama.Columns.Add(colReorder)

        ' ทำให้คอลัมน์สุดท้ายยืดเต็ม
        If DataGridViewPhama.Columns.Count > 0 Then
            DataGridViewPhama.Columns(DataGridViewPhama.Columns.Count - 1).AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    ' ===== Search =====
    Private Sub SrcPhama_Click(sender As Object, e As EventArgs) Handles SrcPhama.Click
        LoadGrid(TextBoxPhama.Text.Trim())
    End Sub

    Private Sub TextBoxPhama_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPhama.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SrcPhama.PerformClick()
        End If
    End Sub

    ' ===== Add / Edit =====
    Private Sub AddFromPharSup_Click(sender As Object, e As EventArgs) Handles AddFromPharSup.Click
        Using f As New FormAddPharmaceuticalSupplie()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(TextBoxPhama.Text.Trim())
            End If
        End Using
    End Sub

    Private Sub EditPhama_Click(sender As Object, e As EventArgs) Handles EditPhama.Click
        Dim id = SelectedDrugId()
        If Not id.HasValue Then
            MessageBox.Show("กรุณาเลือกรายการก่อน", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FormPharmaceuticalSupplie1() With {.DrugId = id.Value}
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(TextBoxPhama.Text.Trim())
            End If
        End Using
    End Sub

    Private Function SelectedDrugId() As Integer?
        If DataGridViewPhama.CurrentRow Is Nothing Then Return Nothing
        Dim v As Object = Nothing

        ' รองรับชื่อคอลัมน์หลายแบบ
        If DataGridViewPhama.Columns.Contains("DrugNumber") Then
            v = DataGridViewPhama.CurrentRow.Cells("DrugNumber").Value
        ElseIf DataGridViewPhama.Columns.Contains("DrugID") Then
            v = DataGridViewPhama.CurrentRow.Cells("DrugID").Value
        ElseIf DataGridViewPhama.Columns.Contains("Drug_Number") Then
            v = DataGridViewPhama.CurrentRow.Cells("Drug_Number").Value
        End If

        Dim id As Integer
        If v IsNot Nothing AndAlso Integer.TryParse(v.ToString(), id) Then Return id
        Return Nothing
    End Function

    ' ===== ตรวจชื่อคอลัมน์รหัสยาในวิว =====
    Private Function DetectIdColumnInView() As String
        Using cn As New SqlConnection(ConnStr),
              cmd As New SqlCommand("SELECT TOP 0 * FROM dbo.vw_PharmaceuticalSupplie", cn)
            cn.Open()
            Using rd = cmd.ExecuteReader(CommandBehavior.SchemaOnly)
                Dim schema = rd.GetSchemaTable()
                For Each row As DataRow In schema.Rows
                    Dim col = row("ColumnName").ToString()
                    If col.Equals("DrugID", StringComparison.OrdinalIgnoreCase) Then Return "DrugID"
                    If col.Equals("Drug_Number", StringComparison.OrdinalIgnoreCase) Then Return "Drug_Number"
                Next
            End Using
        End Using
        Return "DrugID"
    End Function

    ' ===== Load grid (เฉพาะ 5 คอลัมน์) =====
    Private Sub LoadGrid(keyword As String)
        Dim idCol As String = DetectIdColumnInView()

        Dim sb As New StringBuilder()
        sb.AppendLine("SELECT")
        sb.AppendLine($"  {idCol} AS DrugNumber,")  ' << alias ให้ชื่อคอลัมน์เป็น DrugNumber เพื่อผูกกับกริด
        sb.AppendLine("  DrugName,")
        sb.AppendLine("  Dosage,")
        sb.AppendLine("  Qty_in_stock,")
        sb.AppendLine("  Reorder_level")
        sb.AppendLine("FROM dbo.vw_PharmaceuticalSupplie")
        sb.AppendLine("WHERE (@kw = ''")
        sb.AppendLine("   OR DrugName LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR ISNULL(Dosage,'') LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR CONVERT(NVARCHAR(20), Qty_in_stock) LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR CONVERT(NVARCHAR(20), Reorder_level) LIKE '%'+@kw+'%')")
        sb.AppendLine("ORDER BY DrugName ASC;")

        Try
            Dim dt As New DataTable()
            Using cn As New SqlConnection(ConnStr),
                  da As New SqlDataAdapter(sb.ToString(), cn)
                da.SelectCommand.Parameters.AddWithValue("@kw", If(keyword, String.Empty))
                da.Fill(dt)
            End Using

            DataGridViewPhama.DataSource = dt

        Catch ex As SqlException
            MessageBox.Show("โหลดข้อมูลไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
