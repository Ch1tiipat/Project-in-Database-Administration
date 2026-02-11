<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddward
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtb_editwardid = New System.Windows.Forms.TextBox()
        Me.txtb_wardname = New System.Windows.Forms.TextBox()
        Me.txtb_totalbed = New System.Windows.Forms.TextBox()
        Me.txtb_salary = New System.Windows.Forms.TextBox()
        Me.txt_exnum = New System.Windows.Forms.TextBox()
        Me.txtb_location = New System.Windows.Forms.TextBox()
        Me.btn_Addward = New System.Windows.Forms.Button()
        Me.btn_Cancle = New System.Windows.Forms.Button()
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(70, 69)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Pro73.My.Resources.Resources.logo73
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 63)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(328, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 44)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Formward"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(191, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ward ID :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(191, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ward Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(191, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total Beds :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(191, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Salary Scale :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(191, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "ExtensionNumber :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(194, 327)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Location :"
        '
        'txtb_editwardid
        '
        Me.txtb_editwardid.Location = New System.Drawing.Point(320, 151)
        Me.txtb_editwardid.Name = "txtb_editwardid"
        Me.txtb_editwardid.Size = New System.Drawing.Size(207, 22)
        Me.txtb_editwardid.TabIndex = 8
        '
        'txtb_wardname
        '
        Me.txtb_wardname.Location = New System.Drawing.Point(320, 182)
        Me.txtb_wardname.Name = "txtb_wardname"
        Me.txtb_wardname.Size = New System.Drawing.Size(207, 22)
        Me.txtb_wardname.TabIndex = 9
        '
        'txtb_totalbed
        '
        Me.txtb_totalbed.Location = New System.Drawing.Point(320, 216)
        Me.txtb_totalbed.Name = "txtb_totalbed"
        Me.txtb_totalbed.Size = New System.Drawing.Size(207, 22)
        Me.txtb_totalbed.TabIndex = 10
        '
        'txtb_salary
        '
        Me.txtb_salary.Location = New System.Drawing.Point(320, 251)
        Me.txtb_salary.Name = "txtb_salary"
        Me.txtb_salary.Size = New System.Drawing.Size(207, 22)
        Me.txtb_salary.TabIndex = 11
        '
        'txt_exnum
        '
        Me.txt_exnum.Location = New System.Drawing.Point(320, 286)
        Me.txt_exnum.Name = "txt_exnum"
        Me.txt_exnum.Size = New System.Drawing.Size(207, 22)
        Me.txt_exnum.TabIndex = 12
        '
        'txtb_location
        '
        Me.txtb_location.Location = New System.Drawing.Point(320, 321)
        Me.txtb_location.Name = "txtb_location"
        Me.txtb_location.Size = New System.Drawing.Size(207, 22)
        Me.txtb_location.TabIndex = 13
        '
        'btn_Addward
        '
        Me.btn_Addward.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Addward.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Addward.Location = New System.Drawing.Point(546, 373)
        Me.btn_Addward.Name = "btn_Addward"
        Me.btn_Addward.Size = New System.Drawing.Size(75, 23)
        Me.btn_Addward.TabIndex = 14
        Me.btn_Addward.Text = "Add"
        Me.btn_Addward.UseVisualStyleBackColor = False
        '
        'btn_Cancle
        '
        Me.btn_Cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_Cancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Cancle.Location = New System.Drawing.Point(665, 373)
        Me.btn_Cancle.Name = "btn_Cancle"
        Me.btn_Cancle.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancle.TabIndex = 16
        Me.btn_Cancle.Text = "Cancle"
        Me.btn_Cancle.UseVisualStyleBackColor = False
        '
        'FormAddward
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_Cancle)
        Me.Controls.Add(Me.btn_Addward)
        Me.Controls.Add(Me.txtb_location)
        Me.Controls.Add(Me.txt_exnum)
        Me.Controls.Add(Me.txtb_salary)
        Me.Controls.Add(Me.txtb_totalbed)
        Me.Controls.Add(Me.txtb_wardname)
        Me.Controls.Add(Me.txtb_editwardid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormAddward"
        Me.Text = "FormAddward"
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtb_editwardid As TextBox
    Friend WithEvents txtb_wardname As TextBox
    Friend WithEvents txtb_totalbed As TextBox
    Friend WithEvents txtb_salary As TextBox
    Friend WithEvents txt_exnum As TextBox
    Friend WithEvents txtb_location As TextBox
    Friend WithEvents btn_Addward As Button
    Friend WithEvents btn_Cancle As Button
End Class
