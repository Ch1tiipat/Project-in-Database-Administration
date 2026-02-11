<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEditBed
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_wardname = New System.Windows.Forms.ComboBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_deletebed = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.cmb_Editbedtype = New System.Windows.Forms.ComboBox()
        Me.cmb_editbedstatus = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Location = New System.Drawing.Point(315, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 42)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FormEditBed "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(174, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ward Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(174, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "BedType :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(174, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "BedStatus :"
        '
        'cmb_wardname
        '
        Me.cmb_wardname.FormattingEnabled = True
        Me.cmb_wardname.Location = New System.Drawing.Point(279, 97)
        Me.cmb_wardname.Name = "cmb_wardname"
        Me.cmb_wardname.Size = New System.Drawing.Size(270, 24)
        Me.cmb_wardname.TabIndex = 8
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_save.Location = New System.Drawing.Point(243, 281)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 32)
        Me.btn_save.TabIndex = 11
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'btn_deletebed
        '
        Me.btn_deletebed.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_deletebed.Location = New System.Drawing.Point(344, 281)
        Me.btn_deletebed.Name = "btn_deletebed"
        Me.btn_deletebed.Size = New System.Drawing.Size(75, 32)
        Me.btn_deletebed.TabIndex = 12
        Me.btn_deletebed.Text = "Delete"
        Me.btn_deletebed.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(453, 281)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 32)
        Me.btn_cancle.TabIndex = 13
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'cmb_Editbedtype
        '
        Me.cmb_Editbedtype.FormattingEnabled = True
        Me.cmb_Editbedtype.Location = New System.Drawing.Point(279, 151)
        Me.cmb_Editbedtype.Name = "cmb_Editbedtype"
        Me.cmb_Editbedtype.Size = New System.Drawing.Size(270, 24)
        Me.cmb_Editbedtype.TabIndex = 14
        '
        'cmb_editbedstatus
        '
        Me.cmb_editbedstatus.FormattingEnabled = True
        Me.cmb_editbedstatus.Location = New System.Drawing.Point(279, 196)
        Me.cmb_editbedstatus.Name = "cmb_editbedstatus"
        Me.cmb_editbedstatus.Size = New System.Drawing.Size(270, 24)
        Me.cmb_editbedstatus.TabIndex = 15
        '
        'FormEditBed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmb_editbedstatus)
        Me.Controls.Add(Me.cmb_Editbedtype)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_deletebed)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.cmb_wardname)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormEditBed"
        Me.Text = "FormEditbed"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmb_wardname As ComboBox
    Friend WithEvents btn_save As Button
    Friend WithEvents btn_deletebed As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents cmb_Editbedtype As ComboBox
    Friend WithEvents cmb_editbedstatus As ComboBox
End Class
