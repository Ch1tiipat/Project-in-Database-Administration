Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class FormWard

    Private ReadOnly connectionString As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private WithEvents dgvWard As New DataGridView With {
        .Dock = DockStyle.Fill,
        .ReadOnly = True,
        .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        .MultiSelect = False,
        .AutoGenerateColumns = True
    }

    Private Sub FormWard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnl_ward.Controls.Clear()
        pnl_ward.Controls.Add(dgvWard)
        RefreshGrid()
    End Sub

    ' ------------------------ SEARCH (type-anything) ------------------------
    Private Sub RefreshGrid(Optional query As String = "")
        Dim q As String = If(query, String.Empty).Trim()

        Using cn As New SqlConnection(connectionString)
            cn.Open()

            Dim sb As New StringBuilder()
            sb.AppendLine("SELECT WardNumber, WardName, WardLocation, TotalBed, TelExten")
            sb.AppendLine("FROM dbo.Ward")

            Dim cmd As New SqlCommand() With {.Connection = cn}
            Dim whereParts As New List(Of String)

            ' โหมดพิมพ์อะไรก็หา: LIKE ทุกคอลัมน์ (ตัวเลขก็แปลงเป็นข้อความแล้ว LIKE)
            If q <> "" Then
                whereParts.Add("CAST(WardNumber AS nvarchar(32))   LIKE @q")
                whereParts.Add("WardName                          LIKE @q")
                whereParts.Add("WardLocation                      LIKE @q")
                whereParts.Add("CAST(TotalBed  AS nvarchar(32))   LIKE @q")
                whereParts.Add("CAST(TelExten  AS nvarchar(32))   LIKE @q")

                cmd.Parameters.Add("@q", SqlDbType.NVarChar, 100).Value = "%" & q & "%"
            End If

            If whereParts.Count > 0 Then
                sb.AppendLine("WHERE " & String.Join(" OR ", whereParts))
            End If

            sb.AppendLine("ORDER BY WardNumber;")
            cmd.CommandText = sb.ToString()

            Using da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvWard.DataSource = dt
            End Using
        End Using

        ' หัวคอลัมน์สวยๆ
        If dgvWard.Columns.Contains("WardNumber") Then dgvWard.Columns("WardNumber").HeaderText = "Ward ID"
        If dgvWard.Columns.Contains("WardName") Then dgvWard.Columns("WardName").HeaderText = "Ward Name"
        If dgvWard.Columns.Contains("WardLocation") Then dgvWard.Columns("WardLocation").HeaderText = "Location"
        If dgvWard.Columns.Contains("TotalBed") Then dgvWard.Columns("TotalBed").HeaderText = "Total Beds"
        If dgvWard.Columns.Contains("TelExten") Then dgvWard.Columns("TelExten").HeaderText = "Tel Exten"

        For Each c As DataGridViewColumn In dgvWard.Columns
            c.MinimumWidth = 90
        Next
        If dgvWard.Columns.Count > 0 Then
            dgvWard.Columns(dgvWard.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    ' ------------------------ UI EVENTS ------------------------
    Private Sub btn_ward_Click(sender As Object, e As EventArgs) Handles btn_ward.Click
        RefreshGrid(txtb_ward.Text)
    End Sub

    Private Sub txtb_ward_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb_ward.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            RefreshGrid(txtb_ward.Text)
        End If
    End Sub

    Private Sub btn_Addward_Click(sender As Object, e As EventArgs) Handles btn_Addward.Click
        Using f As New FormAddward(connectionString)
            If f.ShowDialog(Me) = DialogResult.OK Then
                RefreshGrid(txtb_ward.Text)
            End If
        End Using
    End Sub

    Private Sub btn_Editward_Click(sender As Object, e As EventArgs) Handles btn_Editward.Click
        OpenEdit()
    End Sub

    Private Sub dgvWard_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWard.CellDoubleClick
        If e.RowIndex >= 0 Then OpenEdit()
    End Sub

    Private Sub OpenEdit()
        If dgvWard.CurrentRow Is Nothing Then
            MessageBox.Show("กรุณาเลือกแถวเพื่อแก้ไข", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using f As New FormEditward1(connectionString)
            f.txtb_Editward.Text = dgvWard.CurrentRow.Cells("WardNumber").Value?.ToString()
            f.txtb_editwardname.Text = dgvWard.CurrentRow.Cells("WardName").Value?.ToString()
            f.txtb_location.Text = dgvWard.CurrentRow.Cells("WardLocation").Value?.ToString()
            f.txtb_editnum.Text = dgvWard.CurrentRow.Cells("TelExten").Value?.ToString()
            If f.ShowDialog(Me) = DialogResult.OK Then
                RefreshGrid(txtb_ward.Text)
            End If
        End Using
    End Sub

End Class


