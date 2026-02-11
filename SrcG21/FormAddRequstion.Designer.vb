<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddRequstion
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtb_addrequan = New System.Windows.Forms.TextBox()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.cmb_addnum = New System.Windows.Forms.ComboBox()
        Me.cmb_addnurseid = New System.Windows.Forms.ComboBox()
        Me.cmb_addrenum = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(221, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(382, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "FormAddRequisition"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(261, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ward Requisition"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(263, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Requisition date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(263, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Ward number :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(263, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Charge Nurse ID :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(261, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 25)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Requisition Items"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(263, 284)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Drug number :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(263, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Quantity requested :"
        '
        'txtb_addrequan
        '
        Me.txtb_addrequan.Location = New System.Drawing.Point(403, 318)
        Me.txtb_addrequan.Name = "txtb_addrequan"
        Me.txtb_addrequan.Size = New System.Drawing.Size(178, 22)
        Me.txtb_addrequan.TabIndex = 21
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_add.Location = New System.Drawing.Point(282, 389)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 34)
        Me.btn_add.TabIndex = 22
        Me.btn_add.Text = "add"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(482, 389)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 34)
        Me.btn_cancle.TabIndex = 23
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'cmb_addnum
        '
        Me.cmb_addnum.FormattingEnabled = True
        Me.cmb_addnum.Location = New System.Drawing.Point(403, 166)
        Me.cmb_addnum.Name = "cmb_addnum"
        Me.cmb_addnum.Size = New System.Drawing.Size(178, 24)
        Me.cmb_addnum.TabIndex = 25
        '
        'cmb_addnurseid
        '
        Me.cmb_addnurseid.FormattingEnabled = True
        Me.cmb_addnurseid.Location = New System.Drawing.Point(403, 205)
        Me.cmb_addnurseid.Name = "cmb_addnurseid"
        Me.cmb_addnurseid.Size = New System.Drawing.Size(178, 24)
        Me.cmb_addnurseid.TabIndex = 26
        '
        'cmb_addrenum
        '
        Me.cmb_addrenum.FormattingEnabled = True
        Me.cmb_addrenum.Location = New System.Drawing.Point(403, 276)
        Me.cmb_addrenum.Name = "cmb_addrenum"
        Me.cmb_addrenum.Size = New System.Drawing.Size(178, 24)
        Me.cmb_addrenum.TabIndex = 27
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(402, 130)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(179, 22)
        Me.DateTimePicker1.TabIndex = 28
        '
        'FormAddRequstion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 474)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.cmb_addrenum)
        Me.Controls.Add(Me.cmb_addnurseid)
        Me.Controls.Add(Me.cmb_addnum)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txtb_addrequan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAddRequstion"
        Me.Text = "FormAddRequstion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtb_addrequan As TextBox
    Friend WithEvents btn_add As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents cmb_addnum As ComboBox
    Friend WithEvents cmb_addnurseid As ComboBox
    Friend WithEvents cmb_addrenum As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
