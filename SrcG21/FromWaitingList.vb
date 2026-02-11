Imports System.Data
Imports System.Data.SqlClient

Public Class FromWaitingList

    ' ===== ปรับให้ตรงเครื่องของคุณ =====
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    ' ====================================

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ตรวจว่าคอลัมน์มีจริงหรือไม่
    Private Function ColumnExists(cn As SqlConnection, tableOrView As String, col As String) As Boolean
        Const sql = "SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c"
        Using cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@t", tableOrView)
            cmd.Parameters.AddWithValue("@c", col)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    ' หา ID column ของ Waiting_List / vw_WaitingList
    Private Function DetectIdColumn(cn As SqlConnection) As String
        For Each colName As String In New String() {"WaitingList_ID", "Waiting_ID", "ID"}
            If ColumnExists(cn, "Waiting_List", colName) OrElse ColumnExists(cn, "vw_WaitingList", colName) Then
                Return colName
            End If
        Next
        Return Nothing ' ไม่มีจริง ๆ (กรณีพิเศษ)
    End Function

    Private _idColumn As String = Nothing

    Private Sub FromWaitingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using cn = Conn()
            cn.Open()
            _idColumn = DetectIdColumn(cn)
        End Using
        LoadGrid("")
    End Sub

    Private Sub LoadGrid(query As String)
        Try
            Using cn = Conn()
                cn.Open()

                Dim idSel As String = If(String.IsNullOrEmpty(_idColumn),
                                         "NULL AS RowID",
                                         $"CAST({_idColumn} AS int) AS RowID")

                Dim sql As String =
$"SELECT {idSel},
        CAST(Patient_ID AS int) AS Patient_ID,
        PatientName,
        DateAdded,
        WardRequired,
        Status
   FROM dbo.vw_WaitingList
  WHERE (@q='' 
         OR PatientName LIKE '%' + @q + '%'
         OR CONVERT(varchar(20), Patient_ID)=@q
         OR WardRequired LIKE '%' + @q + '%'
         OR Status LIKE '%' + @q + '%')
  ORDER BY DateAdded DESC;"

                Using da As New SqlDataAdapter(sql, cn)
                    da.SelectCommand.Parameters.AddWithValue("@q", query.Trim())
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    DataGridView1.DataSource = dt
                    DataGridView1.AutoGenerateColumns = True
                    DataGridView1.ReadOnly = True
                    DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    DataGridView1.MultiSelect = False

                    If DataGridView1.Columns.Contains("RowID") Then
                        DataGridView1.Columns("RowID").Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("โหลดรายการไม่ได้: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click
        LoadGrid(txtb_search.Text)
    End Sub

    Private Function GetSelectedRowId() As Integer?
        If DataGridView1.CurrentRow Is Nothing Then Return Nothing
        If Not DataGridView1.Columns.Contains("RowID") Then Return Nothing
        Dim v = DataGridView1.CurrentRow.Cells("RowID").Value
        If v Is Nothing OrElse v Is DBNull.Value Then Return Nothing
        Return CInt(v)
    End Function

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Using f As New FormAddWaitingList()
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_search.Text)
            End If
        End Using
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        Dim rid = GetSelectedRowId()
        If Not rid.HasValue Then
            MessageBox.Show("กรุณาเลือกแถวที่ต้องการแก้ไขจากตารางก่อน", "Edit",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New FromWaitingList1()
            f.RowID = rid.Value
            If f.ShowDialog(Me) = DialogResult.OK Then
                LoadGrid(txtb_search.Text)
            End If
        End Using
    End Sub

End Class

