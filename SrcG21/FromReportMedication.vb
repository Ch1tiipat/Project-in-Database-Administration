Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class FromReportMedication

    ' ===== DB CONFIG =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function
    ' =====================

    ' Grid (วางลงใน pnl_Medi)
    Private ReadOnly grid As New DataGridView()

    ' Auto refresh แบบเบา ๆ
    Private ReadOnly refreshTimer As New Timer() With {.Interval = 2000} ' 2 วิ (ปรับได้)
    Private lastSig As String = ""

    ' ---------- Form lifecycle ----------
    Private Sub FromReportMedication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5")
        BuildGrid()
        LoadData("")                       ' โหลดครั้งแรก

        AddHandler refreshTimer.Tick, AddressOf RefreshTimer_Tick
        refreshTimer.Start()
    End Sub

    Private Sub FromReportMedication_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        refreshTimer.Stop()
        RemoveHandler refreshTimer.Tick, AddressOf RefreshTimer_Tick
    End Sub

    ' ---------- Build grid ----------
    Private Sub BuildGrid()
        With grid
            .Dock = DockStyle.Fill
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        End With

        pnl_Medi.Controls.Clear()
        pnl_Medi.Controls.Add(grid)

        AddHandler grid.DataBindingComplete, AddressOf Grid_DataBindingComplete
    End Sub

    Private Sub Grid_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        ' ชื่อหัวคอลัมน์ให้อ่านง่าย
        Dim headers As New Dictionary(Of String, String) From {
            {"WardNumber", "Ward number"},
            {"WardName", "Ward name"},
            {"Drug_Number", "Drug number"},
            {"DrugName", "Drug name"},
            {"Requests", "Requests"},
            {"TotalRequested", "Total requested"},
            {"Qty_in_stock", "Qty in stock"}
        }
        For Each kv In headers
            If grid.Columns.Contains(kv.Key) Then grid.Columns(kv.Key).HeaderText = kv.Value
        Next

        ' จัดรูปแบบชิดขวาสำหรับตัวเลข
        For Each n In New String() {"WardNumber", "Drug_Number", "Requests", "TotalRequested", "Qty_in_stock"}
            If grid.Columns.Contains(n) Then
                grid.Columns(n).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        ' คอลัมน์สุดท้ายยืด
        If grid.Columns.Count > 0 Then
            grid.Columns(grid.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    ' ---------- Load data from VIEW + ค้นหา "หลายคำ" (AND ของแต่ละคำ, OR ของทุกคอลัมน์) ----------
    Private Sub LoadData(keyword As String)
        Using cn = GetConn()
            cn.Open()

            Dim raw As String = If(String.IsNullOrWhiteSpace(keyword), "", keyword.Trim())
            Dim terms As List(Of String) = raw.Split({" "c, ControlChars.Tab}, StringSplitOptions.RemoveEmptyEntries) _
                                              .Select(Function(s) s.Trim()) _
                                              .Where(Function(s) s.Length > 0) _
                                              .Distinct(StringComparer.OrdinalIgnoreCase) _
                                              .ToList()

            Dim sb As New StringBuilder()
            sb.AppendLine("SELECT *")
            sb.AppendLine("FROM dbo.vw_MedicationRequestsSummary")

            ' ถ้าไม่มีคำค้น -> ไม่ต้องใส่ WHERE
            If terms.Count > 0 Then
                sb.AppendLine("WHERE 1=1")

                ' สำหรับแต่ละ term: สร้างกลุ่มเงื่อนไข OR ครอบทุกคอลัมน์
                For i As Integer = 0 To terms.Count - 1
                    Dim p As String = "@k" & i.ToString()
                    sb.AppendLine("  AND (")
                    sb.AppendLine("        WardName LIKE " & p)
                    sb.AppendLine("     OR CONVERT(varchar(50), WardNumber)     LIKE " & p)
                    sb.AppendLine("     OR DrugName LIKE " & p)
                    sb.AppendLine("     OR CONVERT(varchar(50), Drug_Number)    LIKE " & p)
                    sb.AppendLine("     OR CONVERT(varchar(50), Requests)       LIKE " & p)
                    sb.AppendLine("     OR CONVERT(varchar(50), TotalRequested) LIKE " & p)
                    sb.AppendLine("     OR CONVERT(varchar(50), Qty_in_stock)   LIKE " & p)
                    sb.AppendLine("      )")
                Next
            End If

            sb.AppendLine("ORDER BY Requests DESC, WardNumber, Drug_Number;")

            Using da As New SqlDataAdapter(sb.ToString(), cn)
                ' ผูกพารามิเตอร์หลายคำ
                For i As Integer = 0 To terms.Count - 1
                    da.SelectCommand.Parameters.Add("@k" & i.ToString(), SqlDbType.VarChar, 100).Value = "%" & terms(i) & "%"
                Next

                Dim dt As New DataTable()
                da.Fill(dt)
                grid.DataSource = dt
            End Using
        End Using
    End Sub

    ' ---------- Smart polling: ถ้าข้อมูลต้นทางเปลี่ยน ค่อยรีโหลด ----------
    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs)
        Try
            Using cn = GetConn(), cmd As New SqlCommand("
-- สร้าง signature จากตารางต้นทาง: เปลี่ยนเมื่อมี insert/update/delete
SELECT
      CAST((SELECT COUNT(*) AS c1, MAX(Requisition_ID) AS m1 FROM dbo.Ward_Requisition) AS NVARCHAR(100))
    + CAST((SELECT COUNT(*) AS c2, MAX(Item_ID) AS m2, SUM(CHECKSUM(Quantity_requested)) AS s2 FROM dbo.Requisition_Item) AS NVARCHAR(200))
    + CAST((SELECT COUNT(*) AS c3, SUM(CHECKSUM(Drug_Number, ISNULL(Qty_in_stock,0))) AS s3 FROM dbo.Pharmaceutical_Supplie) AS NVARCHAR(200))", cn)
                cn.Open()
                Dim sig As String = Convert.ToString(cmd.ExecuteScalar())
                If sig <> lastSig Then
                    lastSig = sig
                    LoadData(textb_me.Text)
                End If
            End Using
        Catch
            ' เงียบ ๆ ไว้ รอบหน้าลองใหม่
        End Try
    End Sub

    ' ---------- Search UI ----------
    Private Sub btn_me_Click(sender As Object, e As EventArgs) Handles btn_me.Click
        LoadData(textb_me.Text)
    End Sub

    Private Sub textb_me_KeyDown(sender As Object, e As KeyEventArgs) Handles textb_me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btn_me.PerformClick()
        End If
    End Sub

End Class



