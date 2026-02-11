Imports System.Data
Imports System.Data.SqlClient

Public Class FormAddIn_Patients

    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"

    Private Function Conn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' -------------------- generic schema helpers --------------------
    Private Function TableExists(cn As SqlConnection, tableName As String) As Boolean
        Using cmd As New SqlCommand("
SELECT 1
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t", cn)
            cmd.Parameters.AddWithValue("@t", tableName)
            Return (cmd.ExecuteScalar() IsNot Nothing)
        End Using
    End Function

    Private Function FirstExistingColumn(cn As SqlConnection, tableName As String, ParamArray candidates() As String) As String
        Using cmd As New SqlCommand("
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t", cn)
            cmd.Parameters.AddWithValue("@t", tableName)
            Dim cols As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    cols.Add(rd.GetString(0))
                End While
            End Using
            For Each c In candidates
                If cols.Contains(c) Then Return c
            Next
            Return ""
        End Using
    End Function

    ' -------------------- Form lifecycle --------------------
    Private Sub FormAddIn_Patients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDatePickers()
        LoadPatients()
        LoadWards()
        cmb_bednb.DataSource = Nothing
        cmb_bednb.DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler cmb_wardnb.SelectionChangeCommitted, AddressOf cmb_wardnb_SelectionChangeCommitted
    End Sub

    Private Sub SetupDatePickers()
        For Each d In {dtp_dateward, DateTimePicker1, dtp_lavedate}
            d.ShowCheckBox = True
            d.Checked = True
        Next
        dtp_dateward.Value = Date.Today
    End Sub

    ' -------------------- load lists --------------------
    Private Sub LoadPatients()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
SELECT Patient_ID,
       (CAST(Patient_ID AS varchar(10))+' - '+FirstName+' '+LastName) AS DisplayName
FROM dbo.Patient
ORDER BY FirstName, LastName;", cn)
                da.Fill(dt)
            End Using
            cmb_patientID.DisplayMember = "DisplayName"
            cmb_patientID.ValueMember = "Patient_ID"
            cmb_patientID.DataSource = dt
            cmb_patientID.DropDownStyle = ComboBoxStyle.DropDownList
        End Using
    End Sub

    Private Sub LoadWards()
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
SELECT WardNumber, WardName,
       (CAST(WardNumber AS varchar(10))+' - '+WardName) AS DisplayName
FROM dbo.Ward
ORDER BY WardNumber;", cn)
                da.Fill(dt)
            End Using
            cmb_wardnb.DisplayMember = "DisplayName"
            cmb_wardnb.ValueMember = "WardNumber"
            cmb_wardnb.DataSource = dt
            cmb_wardnb.DropDownStyle = ComboBoxStyle.DropDownList
        End Using
    End Sub

    Private Sub LoadBedsByWard(wardNo As Integer)
        Using cn = Conn()
            cn.Open()
            Dim dt As New DataTable()
            Using da As New SqlDataAdapter("
SELECT Bed_Number AS BedNumber
FROM dbo.Bed
WHERE WardNumber=@w AND Bed_Status='Available'
ORDER BY Bed_Number;", cn)
                da.SelectCommand.Parameters.Add("@w", SqlDbType.Int).Value = wardNo
                da.Fill(dt)
            End Using

            If dt.Rows.Count = 0 Then
                MessageBox.Show("วอร์ดนี้ไม่มีเตียงว่าง (Available).", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmb_bednb.DataSource = Nothing : Return
            End If

            cmb_bednb.DisplayMember = "BedNumber"
            cmb_bednb.ValueMember = "BedNumber"
            cmb_bednb.DataSource = dt
        End Using
    End Sub

    Private Sub cmb_wardnb_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cmb_wardnb.SelectedValue Is Nothing Then
            cmb_bednb.DataSource = Nothing : Return
        End If
        Dim wardNo As Integer
        If Integer.TryParse(cmb_wardnb.SelectedValue.ToString(), wardNo) Then
            LoadBedsByWard(wardNo)
        Else
            cmb_bednb.DataSource = Nothing
        End If
    End Sub

    ' -------------------- helpers --------------------
    Private Function DtpOrNull(dtp As DateTimePicker) As Object
        Return If(dtp.ShowCheckBox AndAlso Not dtp.Checked, CType(DBNull.Value, Object), dtp.Value)
    End Function

    Private Function GetPatientCol_InPatient(cn As SqlConnection) As String
        ' ใน In_Patient บางฐานใช้ Patient_ID บางฐานใช้ PatientID
        Dim col = FirstExistingColumn(cn, "In_Patient", "Patient_ID", "PatientID")
        Return col
    End Function

    Private Function GetExpectLeaveCol(cn As SqlConnection) As String
        Return FirstExistingColumn(cn, "In_Patient",
            "ExpectLeaveWard", "ExpectedLeaveWard", "ExpectedLeaveDate", "LeaveExpected", "LeaveExpect")
    End Function

    Private Function GetNextOfKinId(cn As SqlConnection, patientId As Integer) As Integer?
        ' 1) ดึงจากตาราง Patient ก่อน (ตามสคีมาของคุณ)
        Using cmd As New SqlCommand("
SELECT NextOfKin_ID 
FROM dbo.Patient 
WHERE Patient_ID = @pid;", cn)
            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = patientId
            Dim o = cmd.ExecuteScalar()
            If o IsNot Nothing AndAlso o IsNot DBNull.Value Then
                Return CInt(o)
            End If
        End Using

        ' 2) เผื่อบางฐานไม่มีใน Patient → fallback ไปหาที่ตาราง NextOfKin โดยผูกด้วย Patient_ID
        Dim tableName As String = "NextOfKin"
        Using cmd2 As New SqlCommand("
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@t)
    SELECT TOP (1) NextOfKin_ID 
    FROM dbo.NextOfKin 
    WHERE Patient_ID=@pid 
    ORDER BY NextOfKin_ID
ELSE
    SELECT NULL;", cn)
            cmd2.Parameters.AddWithValue("@t", tableName)
            cmd2.Parameters.AddWithValue("@pid", patientId)
            Dim o2 = cmd2.ExecuteScalar()
            If o2 IsNot Nothing AndAlso o2 IsNot DBNull.Value Then
                Return CInt(o2)
            End If
        End Using

        ' 3) หาไม่เจอจริง ๆ
        Return Nothing
    End Function


    ' -------------------- Add --------------------
    Private Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        If cmb_patientID.SelectedValue Is Nothing OrElse
           cmb_wardnb.SelectedValue Is Nothing OrElse
           cmb_bednb.SelectedValue Is Nothing Then
            MessageBox.Show("กรุณาเลือก Patient, Ward และ Bed ให้ครบ", "Validate",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim pid As Integer = CInt(cmb_patientID.SelectedValue)
        Dim wardNo As Integer = CInt(cmb_wardnb.SelectedValue)
        Dim bedNo As Integer = CInt(cmb_bednb.SelectedValue)

        ' ใช้ชื่อวอร์ด (text) ใส่ Ward_Required
        Dim wardName As String = ""
        Dim wdrv = TryCast(cmb_wardnb.SelectedItem, DataRowView)
        If wdrv IsNot Nothing Then wardName = CStr(wdrv("WardName"))

        Try
            Using cn = Conn()
                cn.Open()

                ' เลือกชื่อคอลัมน์ผู้ป่วยใน In_Patient ให้ถูก (Patient_ID / PatientID)
                Dim patientCol = GetPatientCol_InPatient(cn)
                If String.IsNullOrEmpty(patientCol) Then
                    MessageBox.Show("ไม่พบคอลัมน์ Patient_ID/PatientID ใน In_Patient", "Schema",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' ต้องมี NOK
                Dim nokId = GetNextOfKinId(cn, pid)
                If Not nokId.HasValue Then
                    MessageBox.Show("ผู้ป่วยยังไม่มี Next of kin (NextOfKin_ID เป็น NOT NULL). กรุณาเพิ่มในตาราง NextOfKin ก่อน",
                                    "NextOfKin จำเป็น", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' ExpectedToStay เป็นจำนวนวัน (>=0)
                Dim expectedDays As Integer = 0
                If dtp_lavedate.Checked Then
                    expectedDays = Math.Max(0, CInt((dtp_lavedate.Value.Date - dtp_dateward.Value.Date).TotalDays))
                ElseIf DateTimePicker1.Checked Then
                    expectedDays = Math.Max(0, CInt((DateTimePicker1.Value.Date - dtp_dateward.Value.Date).TotalDays))
                End If

                Dim expectLeaveCol = GetExpectLeaveCol(cn)

                Using tr = cn.BeginTransaction()
                    ' INSERT 6 คอลัมน์ NOT NULL
                    Dim sqlInsert As String =
$"INSERT INTO dbo.In_Patient
    ([{patientCol}], [Ward_Required], [Bed_Number], [DateInWard], [ExpectedToStay], [NextOfKin_ID])
  VALUES
    (@pid, @wardReq, @bed, @dateIn, @stay, @nok);"

                    Using cmd As New SqlCommand(sqlInsert, cn, tr)
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = pid
                        cmd.Parameters.Add("@wardReq", SqlDbType.NVarChar, 100).Value = wardName
                        cmd.Parameters.Add("@bed", SqlDbType.Int).Value = bedNo
                        cmd.Parameters.Add("@dateIn", SqlDbType.DateTime).Value = dtp_dateward.Value
                        cmd.Parameters.Add("@stay", SqlDbType.Int).Value = expectedDays
                        cmd.Parameters.Add("@nok", SqlDbType.Int).Value = nokId.Value
                        cmd.ExecuteNonQuery()
                    End Using

                    ' ใส่วันคาดว่าจะออก ถ้าผู้ใช้เลือก และตารางมีคอลัมน์ดังกล่าว
                    If dtp_lavedate.Checked AndAlso Not String.IsNullOrEmpty(expectLeaveCol) Then
                        Using cmd2 As New SqlCommand(
                            $"UPDATE dbo.In_Patient
                               SET [{expectLeaveCol}] = @leave
                             WHERE Inpatient_ID = SCOPE_IDENTITY();", cn, tr)
                            cmd2.Parameters.Add("@leave", SqlDbType.DateTime).Value = dtp_lavedate.Value
                            cmd2.ExecuteNonQuery()
                        End Using
                    End If

                    ' อัปเดตเตียงเป็น Occupied
                    Using cmdB As New SqlCommand("
UPDATE dbo.Bed SET Bed_Status='Occupied'
WHERE WardNumber=@w AND Bed_Number=@b;", cn, tr)
                        cmdB.Parameters.Add("@w", SqlDbType.Int).Value = wardNo
                        cmdB.Parameters.Add("@b", SqlDbType.Int).Value = bedNo
                        cmdB.ExecuteNonQuery()
                    End Using

                    tr.Commit()
                End Using
            End Using

            MessageBox.Show("เพิ่ม In-Patient เรียบร้อย", "Add",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("เพิ่มไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_cancle_Click(sender As Object, e As EventArgs) Handles btn_cancle.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
