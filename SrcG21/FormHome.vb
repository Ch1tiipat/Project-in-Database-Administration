Imports System.Data.SqlClient
Imports System.Text

Public Class FormHome

    ' ====== DB ======
    Private Const ConnStr As String =
        "Data Source=DESKTOP-PIKBEC1\DB1101170;Initial Catalog=Wellmeadows;Integrated Security=True;TrustServerCertificate=True"
    Private Function GetConn() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function

    ' ====== UI entry points ======
    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadQuickStats()
    End Sub

    Private Sub btn_home_Click(sender As Object, e As EventArgs) Handles btn_home.Click
        LoadQuickStats()
    End Sub

    ' ====== QUICK STATS ======
    Private Sub LoadQuickStats()
        Try
            Using cn = GetConn()
                cn.Open()

                ' 1) เช็คตารางที่ต้องใช้
                Dim hasAppt As Boolean = HasTable(cn, "PatientAppointment")

                ' 2) ตารางยา + คอลัมน์ qty (ดึงผลรวมจำนวนคงคลัง)
                Dim pharmaTable As String =
                    FirstExistingTable(cn, "Pharmaceutical_Supplies", "PharmaceuticalSupplies", "Pharmaceutical_Supplie")
                Dim qtyCol As String = Nothing
                If Not String.IsNullOrEmpty(pharmaTable) Then
                    qtyCol = FirstExistingColumn(cn, pharmaTable,
                                                 "Qty_in_stock", "Quantity", "Qty", "Stock", "qty")
                End If

                ' 3) สร้าง SQL ดึงรวดเดียว (หลายผลลัพธ์)
                Dim sql As New StringBuilder()
                sql.AppendLine("SELECT COUNT(*) FROM dbo.Ward;")                                   ' wards
                sql.AppendLine("SELECT COUNT(*), SUM(CASE WHEN Bed_Status='Available' THEN 1 ELSE 0 END) FROM dbo.Bed;") ' beds Tot/Avail
                sql.AppendLine("SELECT COUNT(*) FROM dbo.Staff;")                                   ' staff
                sql.AppendLine("SELECT COUNT(*) FROM dbo.Patient;")                                 ' patients

                ' === เปลี่ยนจากนับเฉพาะวันนี้ → นับจำนวนการนัดหมายทั้งหมดของผู้ป่วย ===
                If hasAppt Then
                    sql.AppendLine("SELECT COUNT(*) FROM dbo.PatientAppointment;")                  ' total appointments (all time)
                Else
                    sql.AppendLine("SELECT CAST(0 AS int);")
                End If

                ' รวมจำนวนยาในคลัง (ถ้าไม่เจอตาราง/คอลัมน์ ให้ 0)
                If Not String.IsNullOrEmpty(pharmaTable) AndAlso Not String.IsNullOrEmpty(qtyCol) Then
                    sql.AppendLine($"SELECT ISNULL(SUM(CAST([{qtyCol}] AS bigint)),0) FROM dbo.[{pharmaTable}];")
                Else
                    sql.AppendLine("SELECT CAST(0 AS bigint);")
                End If

                Dim wards As Integer = 0, bedsTot As Integer = 0, bedsAvail As Integer = 0
                Dim staffCnt As Integer = 0, patientCnt As Integer = 0, apptTotal As Integer = 0
                Dim stockQty As Long = 0

                Using cmd As New SqlCommand(sql.ToString(), cn)
                    Using rd = cmd.ExecuteReader()
                        ' 1) wards
                        If rd.Read() AndAlso Not rd.IsDBNull(0) Then wards = rd.GetInt32(0)

                        ' 2) bedsTot, bedsAvail
                        rd.NextResult()
                        If rd.Read() Then
                            bedsTot = If(rd.IsDBNull(0), 0, rd.GetInt32(0))
                            bedsAvail = If(rd.IsDBNull(1), 0, rd.GetInt32(1))
                        End If

                        ' 3) staff
                        rd.NextResult()
                        If rd.Read() AndAlso Not rd.IsDBNull(0) Then staffCnt = rd.GetInt32(0)

                        ' 4) patients
                        rd.NextResult()
                        If rd.Read() AndAlso Not rd.IsDBNull(0) Then patientCnt = rd.GetInt32(0)

                        ' 5) total appointments (all time)
                        rd.NextResult()
                        If rd.Read() AndAlso Not rd.IsDBNull(0) Then apptTotal = rd.GetInt32(0)

                        ' 6) total drugs in stock
                        rd.NextResult()
                        If rd.Read() AndAlso Not rd.IsDBNull(0) Then stockQty = CLng(rd.GetValue(0))
                    End Using
                End Using

                DrawQuickCards(wards, bedsTot, bedsAvail, staffCnt, patientCnt, apptTotal, stockQty)
            End Using

        Catch ex As SqlException
            MessageBox.Show("โหลด Quick Stats ไม่สำเร็จ: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาด: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' วาดการ์ดสรุปใน pbl_home
    Private Sub DrawQuickCards(wards As Integer, bedsTot As Integer, bedsAvail As Integer,
                               staffCnt As Integer, patientCnt As Integer,
                               apptTotal As Integer, stockQty As Long)

        pbl_home.SuspendLayout()
        pbl_home.Controls.Clear()

        Dim flow As New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .WrapContents = True,
            .AutoScroll = True,
            .Padding = New Padding(10),
            .BackColor = Color.WhiteSmoke
        }
        pbl_home.Controls.Add(flow)

        flow.Controls.Add(MakeCard("🏥 Wards", wards.ToString()))
        flow.Controls.Add(MakeCard("🛏️ Beds (Total)", bedsTot.ToString()))
        flow.Controls.Add(MakeCard("🛌 Beds Available", bedsAvail.ToString()))
        flow.Controls.Add(MakeCard("👩‍⚕️ Staff", staffCnt.ToString()))
        flow.Controls.Add(MakeCard("👤 Patients", patientCnt.ToString()))
        flow.Controls.Add(MakeCard("📅 Appointments (All)", apptTotal.ToString())) ' << แก้ชื่อและค่า
        flow.Controls.Add(MakeCard("💊 Drugs in Stock", stockQty.ToString("N0")))  ' ยอดคงคลังรวม

        pbl_home.ResumeLayout()
    End Sub

    Private Function MakeCard(title As String, valueText As String) As Control
        Dim pnl As New Panel() With {
            .Width = 220,
            .Height = 110,
            .Margin = New Padding(10),
            .BackColor = Color.White
        }
        pnl.Padding = New Padding(12)
        pnl.BorderStyle = BorderStyle.FixedSingle

        Dim lblTitle As New Label() With {
            .AutoSize = False,
            .Dock = DockStyle.Top,
            .Height = 26,
            .Text = title,
            .Font = New Font("Segoe UI", 10.0!, FontStyle.Regular),
            .ForeColor = Color.DimGray
        }

        Dim lblValue As New Label() With {
            .AutoSize = False,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI", 26.0!, FontStyle.Bold),
            .Text = valueText
        }

        pnl.Controls.Add(lblValue)
        pnl.Controls.Add(lblTitle)
        Return pnl
    End Function

    ' ====== HELPERS ======
    Private Function HasTable(cn As SqlConnection, table As String, Optional schema As String = "dbo") As Boolean
        Const q = "SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA=@s AND TABLE_NAME=@t"
        Using cmd As New SqlCommand(q, cn)
            cmd.Parameters.AddWithValue("@s", schema)
            cmd.Parameters.AddWithValue("@t", table)
            Dim o = cmd.ExecuteScalar()
            Return o IsNot Nothing
        End Using
    End Function

    Private Function FirstExistingTable(cn As SqlConnection, ParamArray candidates() As String) As String
        Const q = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo'"
        Dim names As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Using cmd As New SqlCommand(q, cn)
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    names.Add(rd.GetString(0))
                End While
            End Using
        End Using
        For Each n In candidates
            If names.Contains(n) Then Return n
        Next
        Return Nothing
    End Function

    Private Function FirstExistingColumn(cn As SqlConnection,
                                     tableName As String,
                                     ParamArray candidates() As String) As String
        If String.IsNullOrWhiteSpace(tableName) Then Return Nothing

        Dim q As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME=@tbl;"

        Using cmd As New SqlCommand(q, cn)
            cmd.Parameters.Add("@tbl", SqlDbType.NVarChar, 128).Value = tableName

            Using rd = cmd.ExecuteReader()
                Dim cols As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                While rd.Read()
                    cols.Add(rd.GetString(0))
                End While
                For Each cand As String In candidates
                    If cols.Contains(cand) Then Return cand
                Next
            End Using
        End Using

        Return Nothing
    End Function

    ' ====== (โค้ดสลับฟอร์มของคุณยังใช้ได้ตามเดิม) ======
    Private Sub switchForm(form As Form)
        pbl_home.Controls.Clear()
        form.TopLevel = False
        form.Dock = DockStyle.Fill
        pbl_home.Controls.Add(form)
        form.BringToFront()
        form.Show()
    End Sub

    ' ปุ่มอื่น ๆ ตามเดิม...
    Private Sub btn_ward_Click(sender As Object, e As EventArgs) Handles btn_ward.Click
        switchForm(New FormWard())
    End Sub
    Private Sub btn_Bed_Click(sender As Object, e As EventArgs) Handles btn_Bed.Click
        switchForm(New FormBed())
    End Sub
    Private Sub btn_Sraff_Click(sender As Object, e As EventArgs) Handles btn_Sraff.Click
        switchForm(New FormStaff())
    End Sub
    Private Sub btn_Patient_Click(sender As Object, e As EventArgs) Handles btn_Patient.Click
        switchForm(New FormPatient())
    End Sub
    Private Sub btn_Requisition_Click(sender As Object, e As EventArgs) Handles btn_Requisition.Click
        switchForm(New FormRequisition())
    End Sub
    Private Sub btn_Report_Click(sender As Object, e As EventArgs) Handles btn_Report.Click
        switchForm(New FormReport())
    End Sub
    Private Sub btn_Medical_Click(sender As Object, e As EventArgs) Handles btn_Medical.Click
        switchForm(New FormMedical())
    End Sub

    Private Sub pbl_home_Paint(sender As Object, e As PaintEventArgs) Handles pbl_home.Paint
    End Sub
End Class

