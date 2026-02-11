Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Text.RegularExpressions

Public Class FormReportStaff

    '================= CONNECTION =================
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function
    '=============================================

    Private ReadOnly grid As New DataGridView()

    Private Sub FormReportStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5")
        BuildGrid()
        Me.AcceptButton = btn_staff
        LoadReports("") ' เปิดครั้งแรกดึงทั้งหมด
    End Sub

    Private Sub BuildGrid()
        grid.Dock = DockStyle.Fill
        grid.ReadOnly = True
        grid.AllowUserToAddRows = False
        grid.AllowUserToDeleteRows = False
        grid.RowHeadersVisible = False
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grid.MultiSelect = False
        grid.AutoGenerateColumns = False
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' ===== คอลัมน์ที่ต้องการแสดง =====
        grid.Columns.Clear()

        grid.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "ReportStaff_ID",
            .DataPropertyName = "ReportStaff_ID",
            .HeaderText = "ReportStaff_ID",
            .Visible = False
        })

        grid.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Staff_ID",
            .DataPropertyName = "Staff_ID",
            .HeaderText = "Staff ID",
            .MinimumWidth = 90
        })

        grid.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "StaffName",
            .DataPropertyName = "StaffName",
            .HeaderText = "Staff name",
            .MinimumWidth = 140
        })

        grid.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Position",
            .DataPropertyName = "Position",
            .HeaderText = "Position",
            .MinimumWidth = 120
        })

        grid.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Total_Shifts",
            .DataPropertyName = "Total_Shifts",
            .HeaderText = "Total shifts",
            .MinimumWidth = 110
        })

        grid.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Total_Hours",
            .DataPropertyName = "Total_Hours",
            .HeaderText = "Total hours",
            .MinimumWidth = 110,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "0.##"}
        })

        ' ให้คอลัมน์สุดท้ายขยายเต็ม
        grid.Columns(grid.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        pnl_staff.Controls.Clear()
        pnl_staff.Controls.Add(grid)

        AddHandler grid.DataBindingComplete, AddressOf Grid_DataBindingComplete
    End Sub

    Private Sub Grid_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If grid.Columns.Contains("Staff_ID") Then
            grid.Sort(grid.Columns("Staff_ID"), ComponentModel.ListSortDirection.Ascending)
        End If
    End Sub

    ' ------- helper: แยกคำค้นด้วย whitespace -------
    Private Function SplitTerms(q As String) As List(Of String)
        If String.IsNullOrWhiteSpace(q) Then Return New List(Of String)
        Dim parts = Regex.Split(q.Trim(), "\s+")
        Dim terms As New List(Of String)
        For Each p In parts
            If Not String.IsNullOrWhiteSpace(p) Then terms.Add(p.Trim())
        Next
        Return terms
    End Function

    ' ---------------- Data load ----------------
    Private Sub LoadReports(keyword As String)
        Try
            Using cn = GetConn()
                cn.Open()

                Dim terms = SplitTerms(keyword)

                Dim sb As New StringBuilder()

                ' คำนวณสดจาก StaffAssignment + Shift (อิง ShiftID, Start_Time, End_Time)
                sb.AppendLine("
WITH rpt AS (
    SELECT
        0 AS ReportStaff_ID,                               -- คีย์จำลอง (ซ่อน)
        s.StaffID                              AS Staff_ID,
        (s.FirstName + ' ' + s.LastName)       AS StaffName,
        s.Position,
        COUNT(a.AssignmentID)                  AS Total_Shifts,
        SUM(CASE
              WHEN sh.Start_Time IS NOT NULL AND sh.End_Time IS NOT NULL
                   THEN DATEDIFF(MINUTE, sh.Start_Time, sh.End_Time) / 60.0
              ELSE 0
            END)                               AS Total_Hours
    FROM dbo.Staff s
    LEFT JOIN dbo.StaffAssignment a
           ON a.StaffID = s.StaffID
    LEFT JOIN dbo.Shift sh
           ON sh.ShiftID = a.ShiftID
    GROUP BY s.StaffID, s.FirstName, s.LastName, s.Position
)
SELECT *
FROM rpt
WHERE 1=1
")

                ' AND ระหว่างคำ แต่ละคำ OR ระหว่างคอลัมน์
                For i As Integer = 0 To terms.Count - 1
                    Dim t = terms(i)
                    Dim isInt As Boolean = Integer.TryParse(t, New Integer())

                    Dim block As New StringBuilder()
                    block.AppendLine($"  AND (")
                    block.AppendLine($"        CAST(Staff_ID AS nvarchar(50)) LIKE @t{i}")
                    If isInt Then
                        block.AppendLine($"     OR Staff_ID = @id{i}") ' หากเป็นตัวเลข ให้เทียบเท่ากันตรง ๆ ด้วย
                    End If
                    block.AppendLine($"     OR StaffName LIKE @t{i}")
                    block.AppendLine($"     OR Position  LIKE @t{i}")
                    block.AppendLine($"     OR CONVERT(nvarchar(50), Total_Shifts) LIKE @t{i}")
                    block.AppendLine($"     OR CONVERT(nvarchar(50), Total_Hours)  LIKE @t{i}")
                    block.AppendLine($"      )")

                    sb.Append(block.ToString())
                Next

                sb.AppendLine("ORDER BY Staff_ID ASC;")

                Using da As New SqlDataAdapter(sb.ToString(), cn)
                    ' ใส่พารามิเตอร์
                    For i As Integer = 0 To terms.Count - 1
                        Dim pLike = da.SelectCommand.Parameters.Add($"@t{i}", SqlDbType.NVarChar, 100)
                        pLike.Value = $"%{terms(i)}%"

                        Dim idVal As Integer
                        If Integer.TryParse(terms(i), idVal) Then
                            Dim pId = da.SelectCommand.Parameters.Add($"@id{i}", SqlDbType.Int)
                            pId.Value = idVal
                        End If
                    Next

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    Dim view As DataView = dt.DefaultView
                    view.Sort = "Staff_ID ASC"
                    grid.DataSource = view.ToTable()
                End Using
            End Using

        Catch ex As SqlException
            MessageBox.Show("โหลด Staff Report ไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' -----------------------------------------

    '========== UI EVENTS ==========
    Private Sub btn_staff_Click(sender As Object, e As EventArgs) Handles btn_staff.Click
        LoadReports(txtb_searchstaff.Text)
    End Sub

    Private Sub txtb_searchstaff_TextChanged(sender As Object, e As EventArgs) Handles txtb_searchstaff.TextChanged
        LoadReports(txtb_searchstaff.Text)
    End Sub

    Private Sub txtb_searchstaff_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_searchstaff.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btn_staff.PerformClick()
        End If
    End Sub

End Class
