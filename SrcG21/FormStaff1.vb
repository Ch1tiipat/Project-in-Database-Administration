Imports System.Data.SqlClient

Public Class FormStaff1

    '================= CONNECTION =================
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function
    '=============================================

    ' กริดหลัก (วางใน pnl_staffsearch)
    Private gridStaff As New DataGridView()

    Private Sub FormStaff1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        BuildGridLayout()
        LoadStaff("")                      ' โหลดครั้งแรก
    End Sub

    '---------------- UI: ทำให้เห็น "เต็มตาราง" ----------------
    Private Sub BuildGridLayout()
        gridStaff.Dock = DockStyle.Fill
        gridStaff.ReadOnly = True
        gridStaff.MultiSelect = False
        gridStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        gridStaff.AutoGenerateColumns = True

        gridStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        gridStaff.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        gridStaff.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        gridStaff.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        gridStaff.ScrollBars = ScrollBars.Both

        gridStaff.AllowUserToAddRows = False
        gridStaff.AllowUserToDeleteRows = False
        gridStaff.BackgroundColor = Color.White
        gridStaff.BorderStyle = BorderStyle.Fixed3D
        gridStaff.RowHeadersVisible = False

        pnl_staffsearch.Controls.Clear()
        pnl_staffsearch.Controls.Add(gridStaff)

        AddHandler gridStaff.DataBindingComplete, AddressOf GridStaff_DataBindingComplete
        AddHandler gridStaff.CellDoubleClick, AddressOf gridStaff_CellDoubleClick
    End Sub

    ' เรียกหลัง bind เสร็จ
    Private Sub GridStaff_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        AdjustGridColumns()
    End Sub

    Private Sub AdjustGridColumns()
        If gridStaff.Columns.Count = 0 Then Exit Sub

        If gridStaff.Columns.Contains("StaffID") Then gridStaff.Columns("StaffID").HeaderText = "Staff ID"
        If gridStaff.Columns.Contains("FullName") Then gridStaff.Columns("FullName").HeaderText = "Full name"
        If gridStaff.Columns.Contains("Tel") Then gridStaff.Columns("Tel").HeaderText = "Telephone"
        If gridStaff.Columns.Contains("Position") Then gridStaff.Columns("Position").HeaderText = "Position"
        If gridStaff.Columns.Contains("SalaryPayment") Then gridStaff.Columns("SalaryPayment").HeaderText = "Salary Payment"
        If gridStaff.Columns.Contains("Name_Organization") Then gridStaff.Columns("Name_Organization").HeaderText = "Organization"
        If gridStaff.Columns.Contains("QualType") Then gridStaff.Columns("QualType").HeaderText = "Qualification"
        If gridStaff.Columns.Contains("Ex_Position") Then gridStaff.Columns("Ex_Position").HeaderText = "Ex. Position"

        For Each col As DataGridViewColumn In gridStaff.Columns
            col.MinimumWidth = 90
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        Dim lastCol As DataGridViewColumn = gridStaff.Columns(gridStaff.Columns.Count - 1)
        lastCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        gridStaff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    '------------------------------------------------------------

    '================= Helper ตรวจว่าข้อความเป็นตัวเลขล้วนหรือไม่ =================
    Private Function IsDigitsOnly(ByVal text As String) As Boolean
        If String.IsNullOrWhiteSpace(text) Then Return False
        For Each c As Char In text
            If Not Char.IsDigit(c) Then Return False
        Next
        Return True
    End Function
    '==========================================================================

    '================= DATA LOADER (Exact match ตามที่พิมพ์) =================
    Private Sub LoadStaff(keyword As String)
        Dim kw As String = If(keyword, "").Trim()

        Using cn = GetConn()
            ' SELECT ดึงคอลัมน์ตามที่ต้องการ + ใช้ OUTER APPLY หา Qual/Work ล่าสุด
            Dim sqlSelect As String =
"SELECT  s.StaffID,
         (s.FirstName + ' ' + s.LastName) AS FullName,
         s.Tel,
         s.Position,
         s.SalaryPayment,
         wa.Name_Organization,
         qa.QualType,
         wa.Ex_Position
FROM dbo.Staff s
OUTER APPLY (
    SELECT TOP 1 
           w.WorkExID,
           w.Name_Organization, 
           w.Ex_Position
    FROM dbo.WorkExperience w
    WHERE w.StaffID = s.StaffID
    ORDER BY w.Start_Date DESC, w.WorkExID DESC
) wa
OUTER APPLY (
    SELECT TOP 1
           q.QualID,
           q.QualType
    FROM dbo.Qualification q
    WHERE q.StaffID = s.StaffID
    ORDER BY q.QualDate DESC, q.QualID DESC
) qa
"

            Dim whereSql As String
            Dim isId As Boolean = False
            Dim idVal As Integer = 0
            Dim txtVal As String = ""

            If kw = "" Then
                whereSql = "WHERE 1=1"
            ElseIf IsDigitsOnly(kw) Then
                ' ตัวเลขล้วน => เจาะจง StaffID
                isId = True
                idVal = Integer.Parse(kw)
                whereSql = "WHERE s.StaffID = @id"
            Else
                ' ข้อความ => ตรงตัวกับฟิลด์สำคัญ
                txtVal = kw
                whereSql =
"WHERE (
       s.FirstName = @txt
    OR s.LastName  = @txt
    OR (s.FirstName + ' ' + s.LastName) = @txt
    OR s.Position = @txt
    OR s.SalaryPayment = @txt
    OR ISNULL(wa.Name_Organization,'') = @txt
    OR ISNULL(wa.Ex_Position,'')       = @txt
    OR ISNULL(qa.QualType,'')          = @txt )"
            End If

            Dim sql As String = sqlSelect & vbCrLf & whereSql & vbCrLf & "ORDER BY s.StaffID;"

            Using cmd As New SqlCommand(sql, cn)
                If isId Then
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idVal
                ElseIf txtVal <> "" Then
                    cmd.Parameters.Add("@txt", SqlDbType.NVarChar, 200).Value = txtVal
                End If

                Using da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    gridStaff.DataSource = dt
                End Using
            End Using
        End Using

        AdjustGridColumns()
    End Sub
    '====================================================================

    '-------------------- BUTTON EVENTS --------------------
    Private Sub bnt_staffsearch_Click(sender As Object, e As EventArgs) Handles bnt_staffsearch.Click
        LoadStaff(txtb_searchstaff.Text.Trim())
    End Sub

    Private Sub txtb_searchstaff_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_searchstaff.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            bnt_staffsearch.PerformClick()
        End If
    End Sub

    Private Sub bnt_staffadd_Click(sender As Object, e As EventArgs) Handles bnt_staffadd.Click
        Using f As New FormAddstaff1()
            f.ShowDialog(Me)
        End Using
        LoadStaff(txtb_searchstaff.Text.Trim())
    End Sub

    Private Sub bnt_staffEdit_Click(sender As Object, e As EventArgs) Handles bnt_staffEdit.Click
        OpenEditForSelectedStaff()
    End Sub

    Private Sub gridStaff_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        OpenEditForSelectedStaff()
    End Sub

    Private Sub OpenEditForSelectedStaff()
        If gridStaff.CurrentRow Is Nothing Then Return
        Dim staffId As Integer = CInt(gridStaff.CurrentRow.Cells("StaffID").Value)
        Using f As New FormEditstaff()
            f.Mode = FormEditstaff.EditMode.Staff
            f.KeyId = staffId
            f.ShowDialog(Me)
        End Using
        LoadStaff(txtb_searchstaff.Text.Trim())
    End Sub
    '-------------------------------------------------------

End Class
