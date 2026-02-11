Imports System.Data
Imports System.Data.SqlClient

Public Class FormRequisition

    ' ===== DB CONFIG =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function
    ' =====================

    Private Sub FormRequisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = ColorTranslator.FromHtml("#F5F5F5")
        SetupGrid()
        Me.AcceptButton = btn_SearchReq

        ResizeGrid()
        AddHandler Me.Resize, AddressOf ResizeGrid

        LoadRequisition("")    ' โหลดรอบแรก
    End Sub

    ' ---------- Setup DataGridView1 (กำหนดคอลัมน์เอง) ----------
    Private Sub SetupGrid()
        With DataGridView1
            .Dock = DockStyle.None
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .AutoGenerateColumns = False
            .BorderStyle = BorderStyle.None
        End With

        DataGridView1.Columns.Clear()

        ' ซ่อนไว้ใช้ภายใน (สำคัญสำหรับหน้าแก้ไข)
        AddHiddenCol("Requisition_ID")            ' << เพิ่มให้มีแน่นอน
        AddHiddenCol("Item_ID")
        AddHiddenCol("Drug_Number")
        AddHiddenCol("DrugName")

        ' คอลัมน์ที่ต้องการแสดง (ถ้าอยากให้แสดงน้อยลง ก็ลบอันที่ไม่ต้องการได้)
        AddTextCol("WardNumber", "Ward Number", 100, , DataGridViewContentAlignment.MiddleRight)
        AddTextCol("WardName", "Ward Name", 140)
        AddTextCol("CN_ID", "CN ID", 90, , DataGridViewContentAlignment.MiddleRight)
        AddTextCol("ChargeNurseName", "Charge Nurse Name", 160)
        AddTextCol("Drug", "Drug number (ID - Name)", 220)
        AddTextCol("Quantity_requested", "Quantity requested", 130, , DataGridViewContentAlignment.MiddleRight)
        AddTextCol("Requisition_date", "Requisition Date", 110, "yyyy-MM-dd")

        AddHandler DataGridView1.CellDoubleClick, AddressOf DataGridView1_CellDoubleClick
    End Sub

    Private Sub AddTextCol(prop As String, header As String, width As Integer,
                           Optional format As String = Nothing,
                           Optional align As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft)
        Dim c As New DataGridViewTextBoxColumn()
        c.DataPropertyName = prop
        c.HeaderText = header
        c.Width = width
        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        c.DefaultCellStyle.Alignment = align
        If Not String.IsNullOrEmpty(format) Then c.DefaultCellStyle.Format = format
        DataGridView1.Columns.Add(c)
    End Sub

    Private Sub AddHiddenCol(prop As String)
        Dim c As New DataGridViewTextBoxColumn()
        c.DataPropertyName = prop
        c.HeaderText = prop
        c.Visible = False
        DataGridView1.Columns.Add(c)
    End Sub

    ' ---------- จัดกริดให้พอดีดีไซน์ ----------
    Private Sub ResizeGrid(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing)
        Dim margin As Integer = 10

        Dim topY As Integer = MaxBottomOf("lblSearch", "txtb_search", "btn_SearchReq") + margin
        If topY < 60 Then topY = 60

        Dim bottomLimit As Integer = MinTopOf("btn_add", "btn_EditReq")
        If bottomLimit <= 0 Then bottomLimit = Me.ClientSize.Height - margin

        Dim h As Integer = bottomLimit - topY - margin
        Dim w As Integer = Me.ClientSize.Width - (margin * 2)

        If h < 150 Then h = 150
        If w < 300 Then w = 300

        DataGridView1.Location = New Point(margin, topY)
        DataGridView1.Size = New Size(w, h)
        DataGridView1.BringToFront()
    End Sub

    Private Function MaxBottomOf(ParamArray names() As String) As Integer
        Dim maxB As Integer = 0
        For Each n In names
            Dim cs() As Control = Me.Controls.Find(n, True)
            If cs IsNot Nothing AndAlso cs.Length > 0 Then
                For Each c As Control In cs
                    If c.Visible AndAlso c.Bottom > maxB Then maxB = c.Bottom
                Next
            End If
        Next
        Return maxB
    End Function

    Private Function MinTopOf(ParamArray names() As String) As Integer
        Dim minT As Integer = Integer.MaxValue
        Dim found As Boolean = False
        For Each n In names
            Dim cs() As Control = Me.Controls.Find(n, True)
            If cs IsNot Nothing AndAlso cs.Length > 0 Then
                For Each c As Control In cs
                    If c.Visible Then
                        If c.Top < minT Then minT = c.Top
                        found = True
                    End If
                Next
            End If
        Next
        If found Then Return minT Else Return 0
    End Function

    ' ---------- Load data (มี Quantity_requested แน่นอน) ----------
    Private Sub LoadRequisition(keyword As String)
        Using cn = GetConn()
            cn.Open()

            Dim sql As String =
"SELECT
    r.Requisition_ID,
    r.Requisition_date,
    r.WardNumber,
    r.WardName,
    r.CN_ID,
    r.NurseName AS ChargeNurseName,
    ri.Item_ID,
    ri.DrugID     AS Drug_Number,
    ps.DrugName   AS DrugName,
    CAST(ri.DrugID AS varchar(20)) + ' - ' + ISNULL(ps.DrugName,'') AS Drug,
    ISNULL(ri.Quantity_requested, 0) AS Quantity_requested
FROM dbo.vw_Requisition AS r
LEFT JOIN dbo.vw_RequisitionItems AS ri
       ON ri.Requisition_ID = r.Requisition_ID
LEFT JOIN dbo.vw_PharmaceuticalSupplie AS ps
       ON ps.DrugID = ri.DrugID
WHERE
    (@q = '')
    OR CONVERT(varchar(50), r.Requisition_ID)       LIKE @like
    OR CONVERT(varchar(10), r.Requisition_date,120) LIKE @like
    OR CONVERT(varchar(50), r.WardNumber)           LIKE @like
    OR r.WardName                                   LIKE @like
    OR CONVERT(varchar(50), r.CN_ID)                LIKE @like
    OR r.NurseName                                  LIKE @like
    OR CONVERT(varchar(50), ri.DrugID)              LIKE @like
    OR ps.DrugName                                  LIKE @like
    OR CONVERT(varchar(50), ISNULL(ri.Quantity_requested,0)) LIKE @like
ORDER BY r.Requisition_date DESC, r.Requisition_ID DESC, ri.Item_ID ASC;"

            Using da As New SqlDataAdapter(sql, cn)
                Dim q As String = If(String.IsNullOrWhiteSpace(keyword), "", keyword.Trim())
                da.SelectCommand.Parameters.Add("@q", SqlDbType.VarChar, 100).Value = q
                da.SelectCommand.Parameters.Add("@like", SqlDbType.VarChar, 110).Value = "%" & q & "%"

                Dim dt As New DataTable()
                da.Fill(dt)

                ' เผื่อชื่อคอลัมน์จาก view ต่างไป ให้รีเนมให้ตรงกับกริด
                If Not dt.Columns.Contains("Quantity_requested") Then
                    For Each cand In New String() {"QuantityRequested", "QtyRequested", "RequestedQty", "Quantity"}
                        If dt.Columns.Contains(cand) Then
                            dt.Columns(cand).ColumnName = "Quantity_requested"
                            Exit For
                        End If
                    Next
                    If Not dt.Columns.Contains("Quantity_requested") Then
                        dt.Columns.Add("Quantity_requested", GetType(Integer))
                    End If
                End If

                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    ' ---------- Search ----------
    Private Sub btn_SearchReq_Click(sender As Object, e As EventArgs) Handles btn_SearchReq.Click
        LoadRequisition(txtb_search.Text)
    End Sub

    Private Sub txtb_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btn_SearchReq.PerformClick()
        End If
    End Sub

    ' ---------- Add / Edit ----------
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Using f As New FormAddRequstion(ConnStr)
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadRequisition(txtb_search.Text)
            End If
        End Using
    End Sub

    Private Sub btn_EditReq_Click(sender As Object, e As EventArgs) Handles btn_EditReq.Click
        OpenEditCurrentRow()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then OpenEditCurrentRow()
    End Sub

    Private Sub OpenEditCurrentRow()
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("กรุณาเลือกแถวที่ต้องการแก้ไข", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim reqId As Integer = 0
        Dim itemId As Integer = 0

        ' วิธีที่ 1: อ่านจากคอลัมน์ในกริด (ถ้ามี)
        If DataGridView1.Columns.Contains("Requisition_ID") Then
            Dim v = DataGridView1.CurrentRow.Cells("Requisition_ID").Value
            If v IsNot Nothing AndAlso v IsNot DBNull.Value Then reqId = Convert.ToInt32(v)
        End If
        If DataGridView1.Columns.Contains("Item_ID") Then
            Dim v2 = DataGridView1.CurrentRow.Cells("Item_ID").Value
            If v2 IsNot Nothing AndAlso v2 IsNot DBNull.Value Then itemId = Convert.ToInt32(v2)
        End If

        ' วิธีที่ 2: ดึงจาก DataSource ตรง ๆ เผื่อหัวตารางไม่โชว์คอลัมน์
        If reqId = 0 OrElse itemId = 0 Then
            Dim drv = TryCast(DataGridView1.CurrentRow.DataBoundItem, DataRowView)
            If drv IsNot Nothing Then
                If reqId = 0 AndAlso drv.Row.Table.Columns.Contains("Requisition_ID") Then
                    reqId = Convert.ToInt32(drv("Requisition_ID"))
                End If
                If itemId = 0 AndAlso drv.Row.Table.Columns.Contains("Item_ID") Then
                    itemId = Convert.ToInt32(drv("Item_ID"))
                End If
            End If
        End If

        If reqId = 0 Then
            MessageBox.Show("ไม่พบ Requisition_ID ของแถวที่เลือก", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using f As New FormEditRequisition(ConnStr)
            Try : f.RequisitionId = reqId : Catch : End Try
            Try : f.ItemId = itemId : Catch : End Try
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadRequisition(txtb_search.Text)
            End If
        End Using
    End Sub

End Class






