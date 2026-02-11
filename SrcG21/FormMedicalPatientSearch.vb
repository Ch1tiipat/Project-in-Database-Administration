Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class FormMedicalPatientSearch

    ' === Connection ===
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Sub FormMedicalPatientSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With DataGridViewMP
            .Dock = DockStyle.None
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoGenerateColumns = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End With

        Me.AcceptButton = btn_searchMP
        LoadGrid("")     ' โหลดครั้งแรก
    End Sub

    ' === Search ===
    Private Sub btn_searchMP_Click(sender As Object, e As EventArgs) Handles btn_searchMP.Click
        LoadGrid(txtb_Medical.Text.Trim())
    End Sub

    Private Sub txtb_Medical_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_Medical.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btn_searchMP.PerformClick()
        End If
    End Sub

    ' === Add (ถ้ามีปุ่ม) ===
    Private Sub btn_Addmp_Click(sender As Object, e As EventArgs) Handles btn_Addmp.Click
        Using f As New FormAddMedicalPatient()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_Medical.Text.Trim())
            End If
        End Using
    End Sub

    ' === Edit (ถ้ามีปุ่ม) ===
    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Dim id = SelectedMedicationId()
        If Not id.HasValue Then
            MessageBox.Show("กรุณาเลือกรายการก่อน", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FormMedicalPatient1() With {.MedicationId = id.Value}
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_Medical.Text.Trim())
            End If
        End Using
    End Sub

    Private Function SelectedMedicationId() As Integer?
        If DataGridViewMP.CurrentRow Is Nothing Then Return Nothing
        Dim v As Object = Nothing
        If DataGridViewMP.Columns.Contains("Medical_ID") Then
            v = DataGridViewMP.CurrentRow.Cells("Medical_ID").Value
        ElseIf DataGridViewMP.Columns.Contains("Medication_ID") Then
            v = DataGridViewMP.CurrentRow.Cells("Medication_ID").Value
        End If
        Dim id As Integer
        If v IsNot Nothing AndAlso Integer.TryParse(v.ToString(), id) Then Return id
        Return Nothing
    End Function

    ' === หาชื่อคีย์ในวิว (Medical_ID หรือ Medication_ID) ===
    Private Function DetectIdColumnInView() As String
        Using cn As New SqlConnection(ConnStr),
              cmd As New SqlCommand("SELECT TOP 0 * FROM dbo.vw_PatientMedication", cn)
            cn.Open()
            Using rd = cmd.ExecuteReader(CommandBehavior.SchemaOnly)
                Dim schema = rd.GetSchemaTable()
                For Each row As DataRow In schema.Rows
                    Dim col = row("ColumnName").ToString()
                    If col.Equals("Medical_ID", StringComparison.OrdinalIgnoreCase) Then Return "Medical_ID"
                    If col.Equals("Medication_ID", StringComparison.OrdinalIgnoreCase) Then Return "Medication_ID"
                Next
            End Using
        End Using
        ' ดีฟอลต์ถ้าหาไม่เจอ
        Return "Medication_ID"
    End Function

    ' === Load table ===
    Private Sub LoadGrid(keyword As String)
        Dim idCol As String = DetectIdColumnInView()  ' ใช้ชื่อที่มีจริงในวิว

        Dim sb As New StringBuilder()
        sb.AppendLine("SELECT")
        sb.AppendLine($"  {idCol} AS Medical_ID,")
        sb.AppendLine("  PatientName,")
        sb.AppendLine("  DrugName,")
        sb.AppendLine("  Dosage,")
        sb.AppendLine("  Method_of_admin,")
        sb.AppendLine("  UnitPer,")
        sb.AppendLine("  StartDate,")
        sb.AppendLine("  FinishDate,")
        sb.AppendLine("  ChargeNurseName")
        sb.AppendLine("FROM dbo.vw_PatientMedication")
        sb.AppendLine("WHERE (@kw = ''")
        sb.AppendLine("   OR PatientName      LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR DrugName         LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR ISNULL(Dosage,'')          LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR ISNULL(Method_of_admin,'') LIKE '%'+@kw+'%'")
        sb.AppendLine("   OR ISNULL(ChargeNurseName,'') LIKE '%'+@kw+'%')")
        sb.AppendLine("ORDER BY StartDate DESC, Medical_ID;") ' ตรงนี้ใช้ alias ได้ปลอดภัย

        Try
            Dim dt As New DataTable()
            Using cn As New SqlConnection(ConnStr),
                  da As New SqlDataAdapter(sb.ToString(), cn)
                da.SelectCommand.Parameters.AddWithValue("@kw", If(keyword, String.Empty))
                da.Fill(dt)
            End Using

            DataGridViewMP.DataSource = dt

            ' format วันที่
            If DataGridViewMP.Columns.Contains("StartDate") Then
                DataGridViewMP.Columns("StartDate").DefaultCellStyle.Format = "yyyy-MM-dd"
            End If
            If DataGridViewMP.Columns.Contains("FinishDate") Then
                DataGridViewMP.Columns("FinishDate").DefaultCellStyle.Format = "yyyy-MM-dd"
            End If
            ' คอลัมน์ท้ายสุดยืดเต็ม
            If DataGridViewMP.Columns.Count > 0 Then
                DataGridViewMP.Columns(DataGridViewMP.Columns.Count - 1).AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill
            End If

        Catch ex As SqlException
            MessageBox.Show("โหลดข้อมูลไม่สำเร็จ: " & ex.Message, "DB Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
