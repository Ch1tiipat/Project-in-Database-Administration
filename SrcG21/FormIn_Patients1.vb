Imports System.Data
Imports System.Data.SqlClient

Public Class FormIn_Patients1

    Public Property InpatientId As Integer

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    '---------------- Helpers ----------------
    Private Function ColumnExists(cn As SqlConnection, tableName As String, col As String) As Boolean
        Using cmd As New SqlCommand("
SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t AND COLUMN_NAME=@c", cn)
            cmd.Parameters.AddWithValue("@t", tableName)
            cmd.Parameters.AddWithValue("@c", col)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    Private Function PickCol(cn As SqlConnection, table As String, ParamArray cands() As String) As String
        For Each c In cands
            If ColumnExists(cn, table, c) Then Return c
        Next
        Return ""
    End Function

    Private Sub SetupDatePickers()
        For Each d In {dtp_inward, DateTimePicker1, dtp_lave}
            d.ShowCheckBox = True
            d.Checked = True
        Next
    End Sub

    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked, CType(DBNull.Value, Object), dtp.Value)
    End Function

    Private Function CalcStayDays() As Integer
        ' คำนวณจำนวนวันพัก (>=0)
        If dtp_lave.Checked Then
            Return Math.Max(0, CInt((dtp_lave.Value.Date - dtp_inward.Value.Date).TotalDays))
        ElseIf DateTimePicker1.Checked Then
            Return Math.Max(0, CInt((DateTimePicker1.Value.Date - dtp_inward.Value.Date).TotalDays))
        End If
        Return 0
    End Function

    '---------------- Load lookups ----------------
    Private Sub LoadPatients()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
SELECT Patient_ID,
       (CAST(Patient_ID AS varchar(10)) + ' - ' +
        LTRIM(RTRIM(ISNULL(FirstName,''))) +
        CASE WHEN ISNULL(LastName,'')<>'' THEN ' ' + LastName ELSE '' END) AS DisplayName
FROM dbo.Patient
ORDER BY FirstName, LastName;", cn)
                da.Fill(dt)
            End Using
            With cmb_PatientID
                .DisplayMember = "DisplayName"
                .ValueMember = "Patient_ID"
                .DataSource = dt
                .DropDownStyle = ComboBoxStyle.DropDownList
                .AutoCompleteSource = AutoCompleteSource.ListItems   ' <<< กำหนด Source ก่อน
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend   ' <<< แล้วค่อย Mode
            End With
        End Using
    End Sub

    Private Sub LoadWards()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
SELECT WardNumber,
       (RIGHT('00' + CAST(WardNumber AS varchar(10)),2) + ' - ' + WardName) AS DisplayName,
       WardName
FROM dbo.Ward
ORDER BY WardNumber;", cn)
                da.Fill(dt)
            End Using
            With cmb_wardnb
                .DisplayMember = "DisplayName"
                .ValueMember = "WardNumber"
                .DataSource = dt
                .DropDownStyle = ComboBoxStyle.DropDownList
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End With
        End Using
    End Sub

    Private Sub LoadBedsByWard(wardNo As Integer)
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
SELECT Bed_Number AS BedNumber
FROM dbo.Bed
WHERE WardNumber=@w
ORDER BY Bed_Number;", cn)
                da.SelectCommand.Parameters.AddWithValue("@w", wardNo)
                da.Fill(dt)
            End Using
            With cmb_bednb
                .DisplayMember = "BedNumber"
                .ValueMember = "BedNumber"
                .DataSource = dt
                .DropDownStyle = ComboBoxStyle.DropDownList
            End With
        End Using
    End Sub

    Private Sub cmb_wardnb_SelectedValueChanged(sender As Object, e As EventArgs)
        Dim wardTmp As Integer
        If cmb_wardnb.SelectedValue Is Nothing OrElse Not Integer.TryParse(cmb_wardnb.SelectedValue.ToString(), wardTmp) Then
            cmb_bednb.DataSource = Nothing : Return
        End If
        LoadBedsByWard(wardTmp)
    End Sub

    '---------------- Load record to edit ----------------
    Private Sub LoadForEdit(id As Integer)
        Using cn = Conn()
            cn.Open()

            ' map ชื่อคอลัมน์จริงของ In_Patient
            Dim tbl = "In_Patient"
            Dim colPid = PickCol(cn, tbl, "Patient_ID", "PatientID")
            Dim colWardReq = PickCol(cn, tbl, "Ward_Required", "WardRequired")
            Dim colBed = PickCol(cn, tbl, "Bed_Number", "BedNumber", "BedNo")
            Dim colDateIn = PickCol(cn, tbl, "DateInWard", "Date_In_Ward", "AdmitDate")
            Dim colStay = PickCol(cn, tbl, "ExpectedToStay", "ExpectedStay", "LengthOfStay")
            Dim colLeave = PickCol(cn, tbl, "ExpectLeaveWard", "ExpectedLeaveWard", "ExpectedLeaveDate")

            Using cmd As New SqlCommand($"
SELECT Inpatient_ID, {colPid} AS Patient_ID,
       {colWardReq} AS Ward_Required, {colBed} AS Bed_Number,
       {colDateIn} AS DateInWard,
       {colStay}   AS ExpectedToStay,
       {If(colLeave = "", "NULL", colLeave)} AS ExpectLeaveWard
FROM dbo.{tbl}
WHERE Inpatient_ID=@id;", cn)
                cmd.Parameters.AddWithValue("@id", id)
                Using rd = cmd.ExecuteReader()
                    If Not rd.Read() Then
                        MessageBox.Show("ไม่พบข้อมูล", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Close() : Return
                    End If

                    ' Patient
                    If rd("Patient_ID") IsNot DBNull.Value Then
                        cmb_PatientID.SelectedValue = CInt(rd("Patient_ID"))
                    End If

                    ' Ward: แปลงจากชื่อวอร์ด -> หา WardNumber ที่ตรงใน combo
                    Dim wardName As String = If(rd("Ward_Required") Is DBNull.Value, "", CStr(rd("Ward_Required")))
                    If wardName <> "" Then
                        Dim dv As DataTable = CType(cmb_wardnb.DataSource, DataTable)
                        Dim found = dv.Select("WardName = '" & wardName.Replace("'", "''") & "'")
                        If found.Length > 0 Then cmb_wardnb.SelectedValue = CInt(found(0)("WardNumber"))
                    End If

                    ' Bed
                    If rd("Bed_Number") IsNot DBNull.Value Then
                        Dim wno As Integer
                        If Integer.TryParse(cmb_wardnb.SelectedValue?.ToString(), wno) Then
                            LoadBedsByWard(wno)
                            cmb_bednb.SelectedValue = CInt(rd("Bed_Number"))
                        End If
                    End If

                    ' Dates
                    If rd("DateInWard") Is DBNull.Value Then
                        dtp_inward.Checked = False
                    Else
                        dtp_inward.Checked = True : dtp_inward.Value = CDate(rd("DateInWard"))
                    End If

                    ' ExpectedToStay (int) — แสดงเป็นวันที่ปลายทางใน DateTimePicker1 ถ้าต้องการ
                    If rd("ExpectedToStay") Is DBNull.Value Then
                        DateTimePicker1.Checked = False
                    Else
                        DateTimePicker1.Checked = True
                        ' แปลงจำนวนวัน -> วันที่ประมาณการ (เริ่มจาก DateInWard)
                        Dim d0 As Date = If(dtp_inward.Checked, dtp_inward.Value.Date, Date.Today)
                        DateTimePicker1.Value = d0.AddDays(CInt(rd("ExpectedToStay")))
                    End If

                    If Not IsDBNull(rd("ExpectLeaveWard")) Then
                        dtp_lave.Checked = True : dtp_lave.Value = CDate(rd("ExpectLeaveWard"))
                    Else
                        dtp_lave.Checked = False
                    End If
                End Using
            End Using
        End Using
    End Sub

    '---------------- Form events ----------------
    Private Sub FormIn_Patients1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDatePickers()
        LoadPatients()
        LoadWards()
        AddHandler cmb_wardnb.SelectedValueChanged, AddressOf cmb_wardnb_SelectedValueChanged

        If InpatientId <= 0 Then
            MessageBox.Show("ไม่พบ Inpatient_ID", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close() : Return
        End If

        LoadForEdit(InpatientId)
    End Sub

    '---------------- Save / Delete ----------------
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Using cn = Conn()
                cn.Open()

                Dim tbl = "In_Patient"
                Dim colPid = PickCol(cn, tbl, "Patient_ID", "PatientID")
                Dim colWardReq = PickCol(cn, tbl, "Ward_Required", "WardRequired")
                Dim colBed = PickCol(cn, tbl, "Bed_Number", "BedNumber", "BedNo")
                Dim colDateIn = PickCol(cn, tbl, "DateInWard", "Date_In_Ward", "AdmitDate")
                Dim colStay = PickCol(cn, tbl, "ExpectedToStay", "ExpectedStay", "LengthOfStay")
                Dim colLeave = PickCol(cn, tbl, "ExpectLeaveWard", "ExpectedLeaveWard", "ExpectedLeaveDate")

                If colPid = "" OrElse colWardReq = "" OrElse colBed = "" OrElse colDateIn = "" OrElse colStay = "" Then
                    MessageBox.Show("โครงสร้าง In_Patient ไม่ครบสำหรับบันทึก", "Schema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' เตรียมค่า
                Dim wardName As String = ""
                Dim drv = TryCast(cmb_wardnb.SelectedItem, DataRowView)
                If drv IsNot Nothing AndAlso drv.Row.Table.Columns.Contains("WardName") Then wardName = CStr(drv("WardName"))

                Dim days As Integer = CalcStayDays()

                Dim sql As String = $"
UPDATE dbo.{tbl}
   SET {colPid}=@pid,
       {colWardReq}=@wardReq,
       {colBed}=@bed,
       {colDateIn}=@dtin,
       {colStay}=@stay" &
       If(colLeave <> "", "," & colLeave & "=@leave", "") &
       "
 WHERE Inpatient_ID=@id;"

                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", InpatientId)
                    cmd.Parameters.AddWithValue("@pid", CInt(cmb_PatientID.SelectedValue))
                    cmd.Parameters.AddWithValue("@wardReq", wardName)
                    cmd.Parameters.AddWithValue("@bed", CInt(cmb_bednb.SelectedValue))
                    cmd.Parameters.Add("@dtin", SqlDbType.DateTime).Value = DtpOrNull(dtp_inward)
                    cmd.Parameters.Add("@stay", SqlDbType.Int).Value = days
                    If colLeave <> "" Then
                        cmd.Parameters.Add("@leave", SqlDbType.DateTime).Value = DtpOrNull(dtp_lave)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("บันทึกเรียบร้อย", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("บันทึกไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If MessageBox.Show("ต้องการลบรายการนี้หรือไม่?", "Confirm Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using cn = Conn()
                cn.Open()
                Using cmd As New SqlCommand("DELETE FROM dbo.In_Patient WHERE Inpatient_ID=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", InpatientId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("ลบเรียบร้อย", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("ลบไม่สำเร็จ: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class

