<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddBed
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_Addbed = New System.Windows.Forms.Button()
        Me.btn_Canclebed = New System.Windows.Forms.Button()
        Me.cmb_addwardname = New System.Windows.Forms.ComboBox()
        Me.cmb_addbedtype = New System.Windows.Forms.ComboBox()
        Me.cmb_addstatus = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 69)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(77, 69)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Pro73.My.Resources.Resources.logo73
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(71, 63)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Location = New System.Drawing.Point(333, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 42)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "FormBed "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(199, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ward Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(199, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "BedType :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(199, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "BedStatus :"
        '
        'btn_Addbed
        '
        Me.btn_Addbed.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Addbed.Location = New System.Drawing.Point(281, 393)
        Me.btn_Addbed.Name = "btn_Addbed"
        Me.btn_Addbed.Size = New System.Drawing.Size(75, 30)
        Me.btn_Addbed.TabIndex = 10
        Me.btn_Addbed.Text = "Add"
        Me.btn_Addbed.UseVisualStyleBackColor = False
        '
        'btn_Canclebed
        '
        Me.btn_Canclebed.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_Canclebed.Location = New System.Drawing.Point(440, 393)
        Me.btn_Canclebed.Name = "btn_Canclebed"
        Me.btn_Canclebed.Size = New System.Drawing.Size(75, 30)
        Me.btn_Canclebed.TabIndex = 12
        Me.btn_Canclebed.Text = "Cancle"
        Me.btn_Canclebed.UseVisualStyleBackColor = False
        '
        'cmb_addwardname
        '
        Me.cmb_addwardname.FormattingEnabled = True
        Me.cmb_addwardname.Location = New System.Drawing.Point(294, 147)
        Me.cmb_addwardname.Name = "cmb_addwardname"
        Me.cmb_addwardname.Size = New System.Drawing.Size(234, 24)
        Me.cmb_addwardname.TabIndex = 13
        '
        'cmb_addbedtype
        '
        Me.cmb_addbedtype.FormattingEnabled = True
        Me.cmb_addbedtype.Location = New System.Drawing.Point(294, 201)
        Me.cmb_addbedtype.Name = "cmb_addbedtype"
        Me.cmb_addbedtype.Size = New System.Drawing.Size(234, 24)
        Me.cmb_addbedtype.TabIndex = 14
        '
        'cmb_addstatus
        '
        Me.cmb_addstatus.FormattingEnabled = True
        Me.cmb_addstatus.Location = New System.Drawing.Point(294, 246)
        Me.cmb_addstatus.Name = "cmb_addstatus"
        Me.cmb_addstatus.Size = New System.Drawing.Size(234, 24)
        Me.cmb_addstatus.TabIndex = 15
        '
        'FormAddBed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmb_addstatus)
        Me.Controls.Add(Me.cmb_addbedtype)
        Me.Controls.Add(Me.cmb_addwardname)
        Me.Controls.Add(Me.btn_Canclebed)
        Me.Controls.Add(Me.btn_Addbed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormAddBed"
        Me.Text = "FormAddbed"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_Addbed As Button
    Friend WithEvents btn_Canclebed As Button
    Friend WithEvents cmb_addwardname As ComboBox
    Friend WithEvents cmb_addbedtype As ComboBox
    Friend WithEvents cmb_addstatus As ComboBox
End Class
