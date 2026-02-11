Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class FormBed
    Private ReadOnly ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private grid As DataGridView

    Private Sub FormBed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        Me.AcceptButton = btn_searchbed   ' กด Enter เพื่อค้นหา
        LoadGrid(Nothing)
    End Sub

    Private Sub SetupGrid()
        grid = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .ReadOnly = True,
            .AutoGenerateColumns = True,
            .AllowUserToAddRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False
        }
        pnl_bed.Controls.Clear()
        pnl_bed.Controls.Add(grid)
        AddHandler grid.CellDoubleClick, Sub() OpenEdit()
    End Sub

    ' แยกคำจากกล่องค้นหา: ตัดช่องว่างซ้ำ/ขึ้นบรรทัด/แท็บออก
    Private Function SplitTerms(q As String) As List(Of String)
        If String.IsNullOrWhiteSpace(q) Then Return New List(Of String)
        ' ใช้ Regex แบ่งตาม whitespace ทุกชนิด และตัดว่าง
        Dim parts = Regex.Split(q.Trim(), "\s+")
        Dim terms As New List(Of String)
        For Each p In parts
            If Not String.IsNullOrWhiteSpace(p) Then terms.Add(p.Trim())
        Next
        Return terms
    End Function

    Private Sub LoadGrid(q As String)
        Dim terms = SplitTerms(q)

        ' สร้าง SQL พื้นฐาน
        Dim sql As String =
"SELECT 
    b.Bed_Number,
    w.WardName,
    b.Bed_Type,
    b.Bed_Status
FROM dbo.Bed AS b
LEFT JOIN dbo.Ward AS w ON w.WardNumber = b.WardNumber
WHERE 1=1
"

        ' ถ้ามีคำค้นหลายคำ ให้ AND ระหว่างคำ แต่ภายในคำ OR ทุกคอลัมน์ที่อยากค้น
        ' ตัวอย่าง (t0,t1): AND (colA LIKE @t0 OR colB LIKE @t0 ...) AND (colA LIKE @t1 OR ...)
        For i As Integer = 0 To terms.Count - 1
            sql &= vbCrLf & $"  AND (CAST(b.Bed_Number AS NVARCHAR(50)) LIKE @t{i}" &
                             $" OR w.WardName LIKE @t{i}" &
                             $" OR CAST(w.WardNumber AS NVARCHAR(50)) LIKE @t{i}" &   ' ค้นด้วยเลขวอร์ด (ไม่ต้องแสดงคอลัมน์)
                             $" OR b.Bed_Type LIKE @t{i}" &
                             $" OR b.Bed_Status LIKE @t{i})"
        Next

        sql &= vbCrLf & "ORDER BY b.Bed_Number;"

        Using conn As New SqlConnection(ConnStr), cmd As SqlCommand = conn.CreateCommand()
            cmd.CommandText = sql

            ' ใส่พารามิเตอร์แบบกำหนดขนาด (เลี่ยง AddWithValue)
            For i As Integer = 0 To terms.Count - 1
                Dim p = cmd.Parameters.Add($"@t{i}", SqlDbType.NVarChar, 100)
                p.Value = $"%{terms(i)}%"
            Next

            Dim dt As New DataTable()
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
            grid.DataSource = dt
        End Using

        ' ตั้งชื่อหัวคอลัมน์
        If grid.Columns("Bed_Number") IsNot Nothing Then grid.Columns("Bed_Number").HeaderText = "Bed Number"
        If grid.Columns("WardName") IsNot Nothing Then grid.Columns("WardName").HeaderText = "Ward Name"
        If grid.Columns("Bed_Type") IsNot Nothing Then grid.Columns("Bed_Type").HeaderText = "Bed Type"
        If grid.Columns("Bed_Status") IsNot Nothing Then grid.Columns("Bed_Status").HeaderText = "Bed Status"
    End Sub

    Private Function SelectedBedNumber() As Integer?
        If grid Is Nothing OrElse grid.CurrentRow Is Nothing Then Return Nothing
        Dim v = grid.CurrentRow.Cells("Bed_Number").Value
        Dim id As Integer
        If v IsNot Nothing AndAlso Integer.TryParse(v.ToString(), id) Then Return id
        Return Nothing
    End Function

    Private Sub btn_searchbed_Click(sender As Object, e As EventArgs) Handles btn_searchbed.Click
        LoadGrid(txtb_searchbed.Text)
    End Sub

    Private Sub btn_Addbed_Click(sender As Object, e As EventArgs) Handles btn_Addbed.Click
        Using f As New FormAddBed()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_searchbed.Text)
            End If
        End Using
    End Sub

    Private Sub btn_Editbed_Click(sender As Object, e As EventArgs) Handles btn_Editbed.Click
        OpenEdit()
    End Sub

    Private Sub OpenEdit()
        Dim id = SelectedBedNumber()
        If Not id.HasValue Then
            MessageBox.Show("กรุณาเลือกแถวที่ต้องการแก้ไข", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FormEditBed(id.Value)
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_searchbed.Text)
            End If
        End Using
    End Sub
End Class
