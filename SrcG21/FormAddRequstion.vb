Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Linq

Public Class FormAddRequstion

    Private ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Public Sub New()
        InitializeComponent()
        Me.AcceptButton = btn_add
        Me.CancelButton = btn_cancle
    End Sub

    Public Sub New(connStr As String)
        Me.New()
        If Not String.IsNullOrWhiteSpace(connStr) Then
            Me.ConnStr = connStr   ' FIX: เซ็ตให้ฟิลด์ของคลาส
        End If
    End Sub

    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    Private Sub FormAddRequstion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ใช้ DTP แทน Combo สำหรับวันที่
        With DateTimePicker1
            .Format = DateTimePickerFormat.Custom
            .CustomFormat = "yyyy-MM-dd"
            .ShowCheckBox = False
            .Value = Date.Today
        End With

        For Each cb In {cmb_addnum, cmb_addnurseid, cmb_addrenum}
            cb.DropDownStyle = ComboBoxStyle.DropDownList
        Next

        LoadAllCombos()
    End Sub

    '---------------------- LOAD COMBOS ----------------------
    Private Sub LoadAllCombos()
        LoadWardCombo()
        LoadChargeNurseCombo()
        LoadDrugCombo()
    End Sub

    Private Sub LoadWardCombo()
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
        cmb_addnum.DataSource = dt
        cmb_addnum.DisplayMember = "Display"
        cmb_addnum.ValueMember = "WardNumber"
        cmb_addnum.SelectedIndex = If(cmb_addnum.Items.Count > 0, 0, -1)
    End Sub

    ' แสดง CN_ID - NurseName
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
            Dim idText As String = Convert.ToString(r("CN_ID"))
            Dim nameText As String = If(r("NurseName") Is DBNull.Value, "", Convert.ToString(r("NurseName")))
            r("Display") = $"{idText} - {nameText}"
        Next
        cmb_addnurseid.DataSource = dt
        cmb_addnurseid.DisplayMember = "Display"
        cmb_addnurseid.ValueMember = "CN_ID"
        cmb_addnurseid.SelectedIndex = If(cmb_addnurseid.Items.Count > 0, 0, -1)
    End Sub

    ' แสดง DrugID - DrugName
    Private Sub LoadDrugCombo()
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
            Dim idText As String = Convert.ToString(r("DrugID"))
            Dim nameText As String = If(r("DrugName") Is DBNull.Value, "", Convert.ToString(r("DrugName")))
            r("Display") = $"{idText} - {nameText}"
        Next
        cmb_addrenum.DataSource = dt
        cmb_addrenum.DisplayMember = "Display"
        cmb_addrenum.ValueMember = "DrugID"  ' เก็บค่าเป็นรหัสยา
        cmb_addrenum.SelectedIndex = If(cmb_addrenum.Items.Count > 0, 0, -1)
    End Sub

    '---------------------- SAVE ----------------------
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        ' ตรวจเลือกครบ
        If cmb_addnum.SelectedValue Is Nothing OrElse
           cmb_addnurseid.SelectedValue Is Nothing OrElse
           cmb_addrenum.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือก Ward, Charge Nurse และ Drug ให้ครบ", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' ตรวจจำนวน
        Dim qty As Integer
        If Not Integer.TryParse(txtb_addrequan.Text.Trim(), qty) OrElse qty <= 0 Then
            MessageBox.Show("Quantity requested ต้องเป็นตัวเลขมากกว่า 0", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtb_addrequan.Focus() : txtb_addrequan.SelectAll()
            Exit Sub
        End If

        Dim reqDate As Date = DateTimePicker1.Value.Date
        Dim wardNum As Integer = CInt(cmb_addnum.SelectedValue)
        Dim cnId As Integer = CInt(cmb_addnurseid.SelectedValue)
        Dim drugNum As Integer = CInt(cmb_addrenum.SelectedValue)

        Try
            Using cn = GetConn()
                cn.Open()
                Using tx = cn.BeginTransaction()

                    ' 1) Insert head
                    Dim reqId As Integer
                    Using cmd As New SqlCommand("
INSERT INTO dbo.Ward_Requisition (Requisition_date, CN_ID, WardNumber)
VALUES (@d, @cn, @w);
SELECT CAST(SCOPE_IDENTITY() AS int);", cn, tx)
                        cmd.Parameters.Add("@d", SqlDbType.[Date]).Value = reqDate
                        cmd.Parameters.Add("@cn", SqlDbType.Int).Value = cnId
                        cmd.Parameters.Add("@w", SqlDbType.Int).Value = wardNum
                        reqId = CInt(cmd.ExecuteScalar())
                    End Using

                    ' 2) Insert item
                    Using cmd As New SqlCommand("
INSERT INTO dbo.Requisition_Item (Quantity_requested, Requisition_ID, Drug_Number)
VALUES (@q, @rid, @drug);", cn, tx)
                        cmd.Parameters.Add("@q", SqlDbType.Int).Value = qty
                        cmd.Parameters.Add("@rid", SqlDbType.Int).Value = reqId
                        cmd.Parameters.Add("@drug", SqlDbType.Int).Value = drugNum
                        cmd.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using
            End Using

            MessageBox.Show("บันทึกเรียบร้อย", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmb_addrenum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_addrenum.SelectedIndexChanged
        ' ตัวอย่าง: ถ้าต้องโชว์ชื่อยาใน Label แยก
        'Dim drv = TryCast(cmb_addrenum.SelectedItem, DataRowView)
        'If drv IsNot Nothing Then lblDrugName.Text = Convert.ToString(drv("DrugName"))
    End Sub
End Class

