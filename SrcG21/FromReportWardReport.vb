Imports System.Data.SqlClient

Public Class FromReportWardReport

    ' ปรับให้ตรงเครื่องคุณ
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' grid วางใน Panel: Pnl_ward
    Private ReadOnly grid As New DataGridView()

    Private Sub FromReportWardReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5")
        BuildGrid()
        LoadWardReport("")    ' โหลดครั้งแรก
    End Sub

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

        Pnl_ward.Controls.Clear()
        Pnl_ward.Controls.Add(grid)

        AddHandler grid.DataBindingComplete, AddressOf Grid_DataBindingComplete
    End Sub

    Private Sub Grid_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        If grid.Columns.Contains("ReportWard_ID") Then grid.Columns("ReportWard_ID").Visible = False

        Dim headers = New Dictionary(Of String, String) From {
            {"Generated_Date", "Generated date"},
            {"Ward_Number", "Ward number"},
            {"Ward_Name", "Ward name"},
            {"Tel_Exten", "Tel. ext"},
            {"TotalBeds", "Total beds"},
            {"Beds_Used", "Beds used"},
            {"Beds_Available", "Beds available"},
            {"Waiting_Count", "Waiting"}
        }
        For Each kv In headers
            If grid.Columns.Contains(kv.Key) Then grid.Columns(kv.Key).HeaderText = kv.Value
        Next

        If grid.Columns.Contains("Generated_Date") Then
            grid.Columns("Generated_Date").DefaultCellStyle.Format = "yyyy-MM-dd"
        End If

        For Each c As DataGridViewColumn In grid.Columns
            c.MinimumWidth = 95
        Next
        If grid.Columns.Count > 0 Then
            grid.Columns(grid.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    ' ====== โหลดข้อมูล + ค้นหาแบบ Hybrid (เลข/วันที่ = เทียบตรง, ข้อความ = LIKE ครอบทุกคอลัมน์) ======
    Private Sub LoadWardReport(keyword As String)
        Using cn = GetConn()
            cn.Open()

            Dim q As String = If(String.IsNullOrWhiteSpace(keyword), "", keyword.Trim())
            Dim num As Integer, isNum As Boolean = Integer.TryParse(q, num)
            Dim d As Date, isDate As Boolean = Date.TryParse(q, d)

            Dim sql As String = "
;WITH BedsAgg AS (
    SELECT
        WardNumber,
        SUM(CASE WHEN Bed_Status = 'Occupied'  THEN 1 ELSE 0 END) AS Beds_Used,
        SUM(CASE WHEN Bed_Status = 'Available' THEN 1 ELSE 0 END) AS Beds_Available
    FROM dbo.Bed
    GROUP BY WardNumber
),
WaitAgg AS (
    SELECT WardNumber, COUNT(*) AS Waiting_Count
    FROM dbo.Waiting_List
    WHERE Status = 'Waiting'
    GROUP BY WardNumber
),
LatestDate AS (
    SELECT MAX(Generated_Date) AS LatestDate
    FROM dbo.WardReport
)
SELECT
    wrx.ReportWard_ID,
    CONVERT(date, COALESCE(wrx.Generated_Date, ld.LatestDate)) AS Generated_Date,
    w.WardNumber         AS Ward_Number,
    w.WardName           AS Ward_Name,
    w.TelExten           AS Tel_Exten,
    w.TotalBed           AS TotalBeds,
    ISNULL(b.Beds_Used, 0)       AS Beds_Used,
    ISNULL(b.Beds_Available, 0)  AS Beds_Available,
    ISNULL(wt.Waiting_Count, 0)   AS Waiting_Count
FROM dbo.Ward AS w
CROSS JOIN LatestDate AS ld
OUTER APPLY (
    SELECT TOP (1) wr.ReportWard_ID, wr.Generated_Date
    FROM dbo.WardReport AS wr
    WHERE wr.Ward_Number = w.WardNumber
    ORDER BY wr.Generated_Date DESC, wr.ReportWard_ID DESC
) AS wrx
LEFT JOIN BedsAgg AS b ON b.WardNumber = w.WardNumber
LEFT JOIN WaitAgg AS wt ON wt.WardNumber = w.WardNumber
WHERE
  (@q = '')
  OR (
        -- เคสเลขล้วน: เทียบแบบ '=' กับคอลัมน์ตัวเลข
        (@isNum = 1 AND (
            w.WardNumber = @num OR
            w.TelExten = @num OR
            w.TotalBed = @num OR
            ISNULL(b.Beds_Used,0) = @num OR
            ISNULL(b.Beds_Available,0) = @num OR
            ISNULL(wt.Waiting_Count,0) = @num
        ))
        -- เคสวันที่: เทียบ '=' กับคอลัมน์วันที่
        OR (@isDate = 1 AND CONVERT(date, COALESCE(wrx.Generated_Date, ld.LatestDate)) = @d)
        -- ข้อความทั่วไป: LIKE ครอบทุกคอลัมน์ที่แสดง
        OR (
            w.WardName                                   LIKE @like
            OR CONVERT(varchar(10), COALESCE(wrx.Generated_Date, ld.LatestDate), 120) LIKE @like
            OR CONVERT(varchar(50), w.WardNumber)        LIKE @like
            OR CONVERT(varchar(50), w.TelExten)          LIKE @like
            OR CONVERT(varchar(50), w.TotalBed)          LIKE @like
            OR CONVERT(varchar(50), ISNULL(b.Beds_Used,0))       LIKE @like
            OR CONVERT(varchar(50), ISNULL(b.Beds_Available,0))  LIKE @like
            OR CONVERT(varchar(50), ISNULL(wt.Waiting_Count,0))  LIKE @like
        )
     )
ORDER BY COALESCE(wrx.Generated_Date, ld.LatestDate) DESC, w.WardNumber;"

            Using da As New SqlDataAdapter(sql, cn)
                da.SelectCommand.Parameters.Add("@q", SqlDbType.VarChar, 100).Value = q
                da.SelectCommand.Parameters.Add("@like", SqlDbType.VarChar, 110).Value = "%" & q & "%"
                da.SelectCommand.Parameters.Add("@isNum", SqlDbType.Int).Value = If(isNum, 1, 0)
                da.SelectCommand.Parameters.Add("@num", SqlDbType.Int).Value = If(isNum, num, 0)
                da.SelectCommand.Parameters.Add("@isDate", SqlDbType.Int).Value = If(isDate, 1, 0)
                da.SelectCommand.Parameters.Add("@d", SqlDbType.Date).Value = If(isDate, d.Date, DBNull.Value)

                Dim dt As New DataTable()
                da.Fill(dt)
                grid.DataSource = dt
            End Using
        End Using
    End Sub

    ' ปุ่ม Search
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        LoadWardReport(txtb_searchward.Text)
    End Sub

    ' กด Enter เพื่อค้นหา
    Private Sub txtb_searchward_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_searchward.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btn_search.PerformClick()
        End If
    End Sub

End Class
