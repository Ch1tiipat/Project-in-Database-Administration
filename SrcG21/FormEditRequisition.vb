Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Linq

Public Class FormEditRequisition
    Private Const DefaultConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    Private ConnStr As String = DefaultConnStr

    Public Property RequisitionId As Integer
    Public Property ItemId As Integer

    Public Sub New()
        InitializeComponent()
        Me.AcceptButton = btn_saveeidt
        Me.CancelButton = btn_cancleedit
    End Sub

    Public Sub New(connStr As String)
        Me.New()
        If Not String.IsNullOrWhiteSpace(connStr) Then Me.ConnStr = connStr ' FIX
    End Sub

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    Private Sub FormEditRequisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ใช้ DateTimePicker แทน Combo สำหรับวันที่
        With DateTimePicker1
            .Format = DateTimePickerFormat.Custom
            .CustomFormat = "yyyy-MM-dd"
            .ShowCheckBox = False
        End With

        For Each cb In {cmb_editnum, cmb_editnuid, cmb_editrenum}
            cb.DropDownStyle = ComboBoxStyle.DropDownList
        Next

        LoadCombos()
        LoadCurrentRow()
    End Sub

    ' ---------------------- LOAD COMBOS ----------------------
    Private Sub LoadCombos()
        LoadWardNumberCombo()
        LoadChargeNurseCombo()
        LoadDrugNumberCombo()
    End Sub

    Private Sub LoadWardNumberCombo()
        Dim dt As New DataTable()
        Using cn = GetConn(), cmd As New SqlCommand("
SELECT WardNumber, WardName
FROM dbo.Ward
ORDER BY WardName;", cn)
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using
        If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
        For Each r As DataRow In dt.Rows
            r("Display") = $"{r("WardName")} ({r("WardNumber")})"
        Next
        cmb_editnum.DataSource = dt
        cmb_editnum.DisplayMember = "Display"
        cmb_editnum.ValueMember = "WardNumber"
        cmb_editnum.SelectedIndex = If(cmb_editnum.Items.Count > 0, 0, -1)
    End Sub

    ' CN_ID - NurseName
    Private Sub LoadChargeNurseCombo()
        Dim dt As New DataTable()
        Using cn = GetConn(), cmd As New SqlCommand("
SELECT DISTINCT CN_ID, NurseName
FROM dbo.vw_Requisition
WHERE CN_ID IS NOT NULL
ORDER BY NurseName, CN_ID;", cn)
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using
        If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
        For Each r As DataRow In dt.Rows
            Dim idText = Convert.ToString(r("CN_ID"))
            Dim nameText = If(r("NurseName") Is DBNull.Value, "", Convert.ToString(r("NurseName")))
            r("Display") = $"{idText} - {nameText}"
        Next
        cmb_editnuid.DataSource = dt
        cmb_editnuid.DisplayMember = "Display"
        cmb_editnuid.ValueMember = "CN_ID"
        cmb_editnuid.SelectedIndex = If(cmb_editnuid.Items.Count > 0, 0, -1)
    End Sub

    ' DrugID - DrugName
    Private Sub LoadDrugNumberCombo()
        Dim dt As New DataTable()
        Using cn = GetConn(), cmd As New SqlCommand("
SELECT DrugID, DrugName
FROM dbo.vw_PharmaceuticalSupplie
ORDER BY DrugID;", cn)
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using
        If Not dt.Columns.Contains("Display") Then dt.Columns.Add("Display", GetType(String))
        For Each r As DataRow In dt.Rows
            Dim idText = Convert.ToString(r("DrugID"))
            Dim nameText = If(r("DrugName") Is DBNull.Value, "", Convert.ToString(r("DrugName")))
            r("Display") = $"{idText} - {nameText}"
        Next
        cmb_editrenum.DataSource = dt
        cmb_editrenum.DisplayMember = "Display"
        cmb_editrenum.ValueMember = "DrugID"
        cmb_editrenum.SelectedIndex = If(cmb_editrenum.Items.Count > 0, 0, -1)
    End Sub

    ' ---------------------- LOAD CURRENT ROW ----------------------
    Private Sub LoadCurrentRow()
        Using cn = GetConn(), cmd As New SqlCommand("
SELECT wr.Requisition_ID, wr.Requisition_date, wr.WardNumber, wr.CN_ID,
       ri.Item_ID, ri.Drug_Number, ri.Quantity_requested
FROM dbo.Ward_Requisition wr
JOIN dbo.Requisition_Item ri ON ri.Requisition_ID = wr.Requisition_ID
WHERE wr.Requisition_ID = @rid AND ri.Item_ID = @iid;", cn)
            cmd.Parameters.Add("@rid", SqlDbType.Int).Value = RequisitionId
            cmd.Parameters.Add("@iid", SqlDbType.Int).Value = ItemId
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    ' วันที่ -> DateTimePicker
                    DateTimePicker1.Value = CDate(rd("Requisition_date"))

                    ' คอมโบอื่น ๆ
                    SelectComboValue(cmb_editnum, CInt(rd("WardNumber")))
                    SelectComboValue(cmb_editnuid, CInt(rd("CN_ID")))
                    ' Drug_Number ในฐาน = DrugID ที่ใช้เป็น ValueMember
                    SelectComboValue(cmb_editrenum, CInt(rd("Drug_Number")))
                    txtb_editrequan.Text = rd("Quantity_requested").ToString()
                Else
                    MessageBox.Show("ไม่พบข้อมูลสำหรับแก้ไข", "Not found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.DialogResult = DialogResult.Cancel
                    Me.Close()
                End If
            End Using
        End Using
    End Sub

    Private Sub SelectComboValue(cb As ComboBox, value As Object)
        Dim dt = TryCast(cb.DataSource, DataTable)
        If dt IsNot Nothing Then
            Dim exists = dt.AsEnumerable().Any(Function(r) Object.Equals(r(cb.ValueMember), value))
            If Not exists Then
                Dim row = dt.NewRow()
                row(cb.ValueMember) = value
                If dt.Columns.Contains(cb.DisplayMember) Then row(cb.DisplayMember) = value.ToString()
                dt.Rows.InsertAt(row, 0)
                cb.DataSource = dt
            End If
        End If
        cb.SelectedValue = value
    End Sub

    ' ---------------------- SAVE ----------------------
    Private Sub btn_saveeidt_Click(sender As Object, e As EventArgs) Handles btn_saveeidt.Click
        If cmb_editnum.SelectedValue Is Nothing OrElse
           cmb_editnuid.SelectedValue Is Nothing OrElse
           cmb_editrenum.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือกข้อมูลให้ครบทุกช่อง", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim qty As Integer
        If Not Integer.TryParse(txtb_editrequan.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity requested ต้องเป็นตัวเลขมากกว่า 0", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtb_editrequan.Focus() : txtb_editrequan.SelectAll()
            Exit Sub
        End If

        Dim d As Date = DateTimePicker1.Value.Date
        Dim wardNumber As Integer = CInt(cmb_editnum.SelectedValue)
        Dim cnId As Integer = CInt(cmb_editnuid.SelectedValue)
        Dim drugNumber As Integer = CInt(cmb_editrenum.SelectedValue)

        Try
            Using cn = GetConn()
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Using cmd1 As New SqlCommand("
UPDATE dbo.Ward_Requisition
   SET Requisition_date = @d, WardNumber = @w, CN_ID = @cn
 WHERE Requisition_ID = @rid;", cn, tx)
                        cmd1.Parameters.Add("@d", SqlDbType.Date).Value = d
                        cmd1.Parameters.Add("@w", SqlDbType.Int).Value = wardNumber
                        cmd1.Parameters.Add("@cn", SqlDbType.Int).Value = cnId
                        cmd1.Parameters.Add("@rid", SqlDbType.Int).Value = RequisitionId
                        cmd1.ExecuteNonQuery()
                    End Using
                    Using cmd2 As New SqlCommand("
UPDATE dbo.Requisition_Item
   SET Drug_Number = @drug, Quantity_requested = @qty
 WHERE Item_ID = @iid AND Requisition_ID = @rid;", cn, tx)
                        cmd2.Parameters.Add("@drug", SqlDbType.Int).Value = drugNumber
                        cmd2.Parameters.Add("@qty", SqlDbType.Int).Value = qty
                        cmd2.Parameters.Add("@iid", SqlDbType.Int).Value = ItemId
                        cmd2.Parameters.Add("@rid", SqlDbType.Int).Value = RequisitionId
                        cmd2.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                End Using
            End Using

            MessageBox.Show("บันทึกเรียบร้อย", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As SqlException
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "SQL Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ---------------------- DELETE & CANCEL ----------------------
    Private Sub btn_Deleteedit_Click(sender As Object, e As EventArgs) Handles btn_Deleteedit.Click
        If MessageBox.Show("ยืนยันลบรายการนี้?", "Confirm",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using cn = GetConn()
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Using cmd As New SqlCommand("DELETE FROM dbo.Requisition_Item WHERE Item_ID=@iid;", cn, tx)
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = ItemId
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmd As New SqlCommand("
IF NOT EXISTS (SELECT 1 FROM dbo.Requisition_Item WHERE Requisition_ID=@rid)
    DELETE FROM dbo.Ward_Requisition WHERE Requisition_ID=@rid;", cn, tx)
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = RequisitionId
                        cmd.ExecuteNonQuery()
                    End Using
                    tx.Commit()
                End Using
            End Using
            MessageBox.Show("ลบเรียบร้อย", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cancleedit_Click(sender As Object, e As EventArgs) Handles btn_cancleedit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
