<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddStaffAssingment
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmb_Wname = New System.Windows.Forms.ComboBox()
        Me.txtb_pos = New System.Windows.Forms.TextBox()
        Me.cmb_shift = New System.Windows.Forms.ComboBox()
        Me.btn_addAss = New System.Windows.Forms.Button()
        Me.bnt_addCan = New System.Windows.Forms.Button()
        Me.StaffIDAssAdd = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(192, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(436, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Staff  Assignment"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(358, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Staff Rota"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(144, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ward Name :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(144, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Position :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(144, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Week :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(144, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Shift :"
        '
        'cmb_Wname
        '
        Me.cmb_Wname.FormattingEnabled = True
        Me.cmb_Wname.Location = New System.Drawing.Point(297, 173)
        Me.cmb_Wname.Name = "cmb_Wname"
        Me.cmb_Wname.Size = New System.Drawing.Size(263, 24)
        Me.cmb_Wname.TabIndex = 10
        '
        'txtb_pos
        '
        Me.txtb_pos.Location = New System.Drawing.Point(297, 214)
        Me.txtb_pos.Name = "txtb_pos"
        Me.txtb_pos.Size = New System.Drawing.Size(263, 22)
        Me.txtb_pos.TabIndex = 14
        '
        'cmb_shift
        '
        Me.cmb_shift.FormattingEnabled = True
        Me.cmb_shift.Location = New System.Drawing.Point(297, 289)
        Me.cmb_shift.Name = "cmb_shift"
        Me.cmb_shift.Size = New System.Drawing.Size(263, 24)
        Me.cmb_shift.TabIndex = 16
        '
        'btn_addAss
        '
        Me.btn_addAss.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_addAss.Location = New System.Drawing.Point(307, 373)
        Me.btn_addAss.Name = "btn_addAss"
        Me.btn_addAss.Size = New System.Drawing.Size(75, 29)
        Me.btn_addAss.TabIndex = 17
        Me.btn_addAss.Text = "Add"
        Me.btn_addAss.UseVisualStyleBackColor = False
        '
        'bnt_addCan
        '
        Me.bnt_addCan.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.bnt_addCan.Location = New System.Drawing.Point(460, 373)
        Me.bnt_addCan.Name = "bnt_addCan"
        Me.bnt_addCan.Size = New System.Drawing.Size(75, 29)
        Me.bnt_addCan.TabIndex = 18
        Me.bnt_addCan.Text = "Cancle"
        Me.bnt_addCan.UseVisualStyleBackColor = False
        '
        'StaffIDAssAdd
        '
        Me.StaffIDAssAdd.FormattingEnabled = True
        Me.StaffIDAssAdd.Location = New System.Drawing.Point(297, 132)
        Me.StaffIDAssAdd.Name = "StaffIDAssAdd"
        Me.StaffIDAssAdd.Size = New System.Drawing.Size(263, 24)
        Me.StaffIDAssAdd.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(144, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Staff ID"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(297, 252)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(263, 22)
        Me.TextBox1.TabIndex = 21
        '
        'FormAddStaffAssingment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 524)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StaffIDAssAdd)
        Me.Controls.Add(Me.bnt_addCan)
        Me.Controls.Add(Me.btn_addAss)
        Me.Controls.Add(Me.cmb_shift)
        Me.Controls.Add(Me.txtb_pos)
        Me.Controls.Add(Me.cmb_Wname)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAddStaffAssingment"
        Me.Text = "FormAddStaffAssingment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmb_Wname As ComboBox
    Friend WithEvents txtb_pos As TextBox
    Friend WithEvents cmb_shift As ComboBox
    Friend WithEvents btn_addAss As Button
    Friend WithEvents bnt_addCan As Button
    Friend WithEvents StaffIDAssAdd As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
