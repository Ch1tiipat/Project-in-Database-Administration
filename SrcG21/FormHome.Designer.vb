<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.btn_ward = New System.Windows.Forms.Button()
        Me.btn_Bed = New System.Windows.Forms.Button()
        Me.btn_Sraff = New System.Windows.Forms.Button()
        Me.btn_Patient = New System.Windows.Forms.Button()
        Me.btn_Medical = New System.Windows.Forms.Button()
        Me.btn_Requisition = New System.Windows.Forms.Button()
        Me.btn_Report = New System.Windows.Forms.Button()
        Me.pbl_home = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(819, 69)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(71, 69)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Pro73.My.Resources.Resources.logo73
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(65, 63)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(69, 431)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btn_home, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_ward, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Bed, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Sraff, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Patient, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Medical, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Requisition, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Report, 0, 7)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(69, 431)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btn_home
        '
        Me.btn_home.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_home.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_home.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_home.Location = New System.Drawing.Point(3, 3)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(63, 47)
        Me.btn_home.TabIndex = 0
        Me.btn_home.Text = "Home"
        Me.btn_home.UseVisualStyleBackColor = False
        '
        'btn_ward
        '
        Me.btn_ward.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_ward.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_ward.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_ward.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_ward.Location = New System.Drawing.Point(3, 56)
        Me.btn_ward.Name = "btn_ward"
        Me.btn_ward.Size = New System.Drawing.Size(63, 47)
        Me.btn_ward.TabIndex = 1
        Me.btn_ward.Text = "Ward"
        Me.btn_ward.UseVisualStyleBackColor = False
        '
        'btn_Bed
        '
        Me.btn_Bed.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Bed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Bed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Bed.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Bed.Location = New System.Drawing.Point(3, 109)
        Me.btn_Bed.Name = "btn_Bed"
        Me.btn_Bed.Size = New System.Drawing.Size(63, 47)
        Me.btn_Bed.TabIndex = 2
        Me.btn_Bed.Text = "Bed"
        Me.btn_Bed.UseVisualStyleBackColor = False
        '
        'btn_Sraff
        '
        Me.btn_Sraff.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Sraff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Sraff.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Sraff.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Sraff.Location = New System.Drawing.Point(3, 162)
        Me.btn_Sraff.Name = "btn_Sraff"
        Me.btn_Sraff.Size = New System.Drawing.Size(63, 47)
        Me.btn_Sraff.TabIndex = 3
        Me.btn_Sraff.Text = "Staff"
        Me.btn_Sraff.UseVisualStyleBackColor = False
        '
        'btn_Patient
        '
        Me.btn_Patient.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Patient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Patient.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Patient.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Patient.Location = New System.Drawing.Point(3, 215)
        Me.btn_Patient.Name = "btn_Patient"
        Me.btn_Patient.Size = New System.Drawing.Size(63, 47)
        Me.btn_Patient.TabIndex = 4
        Me.btn_Patient.Text = "Patient"
        Me.btn_Patient.UseVisualStyleBackColor = False
        '
        'btn_Medical
        '
        Me.btn_Medical.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Medical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Medical.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Medical.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Medical.Location = New System.Drawing.Point(3, 268)
        Me.btn_Medical.Name = "btn_Medical"
        Me.btn_Medical.Size = New System.Drawing.Size(63, 47)
        Me.btn_Medical.TabIndex = 5
        Me.btn_Medical.Text = "Medical"
        Me.btn_Medical.UseVisualStyleBackColor = False
        '
        'btn_Requisition
        '
        Me.btn_Requisition.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Requisition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Requisition.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Requisition.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Requisition.Location = New System.Drawing.Point(3, 321)
        Me.btn_Requisition.Name = "btn_Requisition"
        Me.btn_Requisition.Size = New System.Drawing.Size(63, 47)
        Me.btn_Requisition.TabIndex = 6
        Me.btn_Requisition.Text = "Requisition"
        Me.btn_Requisition.UseVisualStyleBackColor = False
        '
        'btn_Report
        '
        Me.btn_Report.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Report.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_Report.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Report.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Report.Location = New System.Drawing.Point(3, 374)
        Me.btn_Report.Name = "btn_Report"
        Me.btn_Report.Size = New System.Drawing.Size(63, 54)
        Me.btn_Report.TabIndex = 7
        Me.btn_Report.Text = "Report"
        Me.btn_Report.UseVisualStyleBackColor = False
        '
        'pbl_home
        '
        Me.pbl_home.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pbl_home.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbl_home.Location = New System.Drawing.Point(69, 69)
        Me.pbl_home.Name = "pbl_home"
        Me.pbl_home.Size = New System.Drawing.Size(750, 431)
        Me.pbl_home.TabIndex = 2
        '
        'FormHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(819, 500)
        Me.Controls.Add(Me.pbl_home)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormHome"
        Me.Text = "FormHome"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btn_home As Button
    Friend WithEvents btn_ward As Button
    Friend WithEvents btn_Bed As Button
    Friend WithEvents btn_Sraff As Button
    Friend WithEvents btn_Patient As Button
    Friend WithEvents btn_Medical As Button
    Friend WithEvents btn_Requisition As Button
    Friend WithEvents btn_Report As Button
    Friend WithEvents pbl_home As Panel
End Class
