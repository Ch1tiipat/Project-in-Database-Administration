Imports System.Data
Imports System.Data.SqlClient

Public Class FormStaffAssingment

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ===== helpers =====
    Private Function ColumnExists(cn As SqlConnection, tableOrView As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", tableOrView)
            cmd.Parameters.AddWithValue("@c", col)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    Private _idCol As String = "AssignmentID"
    Private _nameExpr As String = "StaffName"
    Private _wardCol As String = "WardName"
    Private _posCol As String = "Position"
    Private _shiftCol As String = "Shift" ' หรือ Shift_Type

    Private Sub DetectColumns(cn As SqlConnection)
        For Each c In {"AssignmentID", "Assign_ID", "ID"}
            If ColumnExists(cn, "vw_StaffAssignment", c) OrElse ColumnExists(cn, "StaffAssignment", c) Then
                _idCol = c : Exit For
            End If
        Next

        If ColumnExists(cn, "vw_StaffAssignment", "StaffName") Then
            _nameExpr = "StaffName"
        ElseIf ColumnExists(cn, "vw_StaffAssignment", "FullName") Then
            _nameExpr = "FullName"
        Else
            ' สำรองกรณีวิวให้ FirstName/LastName มาแยก
            Dim hasF = ColumnExists(cn, "vw_StaffAssignment", "FirstName")
            Dim hasL = ColumnExists(cn, "vw_StaffAssignment", "LastName")
            If hasF OrElse hasL Then
                _nameExpr = $"ISNULL({If(hasF, "FirstName", "NULL")},'') + ' ' + ISNULL({If(hasL, "LastName", "NULL")},'')"
            Else
                _nameExpr = "CAST(NULL AS nvarchar(200))"
            End If
        End If

        _wardCol = If(ColumnExists(cn, "vw_StaffAssignment", "WardName"), "WardName",
                   If(ColumnExists(cn, "vw_StaffAssignment", "Ward_Name"), "Ward_Name", "NULL"))
        _posCol = If(ColumnExists(cn, "vw_StaffAssignment", "Position"), "Position", "NULL")
        _shiftCol = If(ColumnExists(cn, "vw_StaffAssignment", "Shift"), "Shift",
                   If(ColumnExists(cn, "vw_StaffAssignment", "Shift_Type"), "Shift_Type", "NULL"))
    End Sub

    Private Sub FormStaffAssingment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using cn = Conn()
            cn.Open()
            DetectColumns(cn)
        End Using
        SetupGrid()
        LoadGrid("")
    End Sub

    Private Sub SetupGrid()
        With DataGridView1
            .AutoGenerateColumns = False
            .Columns.Clear()
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "RowID", .HeaderText = "AssignmentID", .DataPropertyName = "RowID"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "StaffName", .HeaderText = "Staff name", .DataPropertyName = "StaffName"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "WardName", .HeaderText = "Ward Name", .DataPropertyName = "WardName"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Position", .HeaderText = "Position", .DataPropertyName = "Position"})
            .Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Shift", .HeaderText = "Shift", .DataPropertyName = "Shift"})
        End With
    End Sub

    ' helper ทำเงื่อนไข LIKE ให้สั้นลง และกัน NULL
    Private Function LikeExpr(colExpr As String) As String
        If String.Equals(colExpr, "NULL", StringComparison.OrdinalIgnoreCase) Then Return ""
        Return $"OR COALESCE(CAST({colExpr} AS nvarchar(4000)),'') LIKE '%' + @q + '%'"
    End Function

    Private Sub LoadGrid(q As String)
        Try
            Using cn = Conn()
                cn.Open()
                DetectColumns(cn)

                Dim nameForLike = If(_nameExpr.Contains("+"), "(" & _nameExpr & ")", _nameExpr)

                Dim sql As String =
$"SELECT 
      CAST({_idCol} AS int) AS RowID,
      {_nameExpr}           AS StaffName,
      {_wardCol}            AS WardName,
      {_posCol}             AS Position,
      {_shiftCol}           AS [Shift]
  FROM dbo.vw_StaffAssignment
 WHERE (@q = '')
    OR (COALESCE(CAST({nameForLike} AS nvarchar(4000)),'') LIKE '%' + @q + '%'
        {LikeExpr(_wardCol)}
        {LikeExpr(_posCol)}
        {LikeExpr(_shiftCol)})
 ORDER BY RowID DESC;"

                Dim dt As New DataTable()
                Using da As New SqlDataAdapter(sql, cn)
                    da.SelectCommand.Parameters.Add("@q", SqlDbType.NVarChar, 200).Value = If(q, "").Trim()
                    da.Fill(dt)
                End Using

                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("โหลดรายการไม่ได้: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetRowId() As Integer?
        If DataGridView1.CurrentRow Is Nothing Then Return Nothing
        Dim v = DataGridView1.CurrentRow.Cells("RowID").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return Nothing
        Return CInt(v)
    End Function

    Private Sub bnt_staffass_Click(sender As Object, e As EventArgs) Handles bnt_staffass.Click
        LoadGrid(txtb_searchstaffass.Text)
    End Sub

    Private Sub txtb_searchstaffass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_searchstaffass.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            bnt_staffass.PerformClick()
        End If
    End Sub

    Private Sub bnt_staffassedit_Click(sender As Object, e As EventArgs) Handles bnt_staffassedit.Click
        Dim rid = GetRowId()
        If Not rid.HasValue Then
            MessageBox.Show("กรุณาเลือกรายการในตารางก่อน", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FromstaffAssingmentEdit()
            f.RowID = rid.Value
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_searchstaffass.Text)
            End If
        End Using
    End Sub

    Private Sub bnt_addstaffass_Click(sender As Object, e As EventArgs) Handles bnt_addstaffass.Click
        Using f As New FormAddStaffAssingment()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_searchstaffass.Text)
            End If
        End Using
    End Sub

End Class


