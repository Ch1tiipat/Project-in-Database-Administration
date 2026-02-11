<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditRequisition
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
        Me.txtb_editrequan = New System.Windows.Forms.TextBox()
        Me.btn_saveeidt = New System.Windows.Forms.Button()
        Me.btn_Deleteedit = New System.Windows.Forms.Button()
        Me.btn_cancleedit = New System.Windows.Forms.Button()
        Me.cmb_editnuid = New System.Windows.Forms.ComboBox()
        Me.cmb_editnum = New System.Windows.Forms.ComboBox()
        Me.cmb_editrenum = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(228, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(322, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Requisition"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(199, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ward Requisition"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(204, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Requisition date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(204, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Ward number :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(204, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Charge Nurse ID :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(211, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 25)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Requisition Items"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(213, 285)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Drug number :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(213, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Quantity requested :"
        '
        'txtb_editrequan
        '
        Me.txtb_editrequan.Location = New System.Drawing.Point(359, 313)
        Me.txtb_editrequan.Name = "txtb_editrequan"
        Me.txtb_editrequan.Size = New System.Drawing.Size(205, 22)
        Me.txtb_editrequan.TabIndex = 16
        '
        'btn_saveeidt
        '
        Me.btn_saveeidt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_saveeidt.Location = New System.Drawing.Point(136, 401)
        Me.btn_saveeidt.Name = "btn_saveeidt"
        Me.btn_saveeidt.Size = New System.Drawing.Size(75, 37)
        Me.btn_saveeidt.TabIndex = 17
        Me.btn_saveeidt.Text = "Save"
        Me.btn_saveeidt.UseVisualStyleBackColor = False
        '
        'btn_Deleteedit
        '
        Me.btn_Deleteedit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Deleteedit.Location = New System.Drawing.Point(349, 401)
        Me.btn_Deleteedit.Name = "btn_Deleteedit"
        Me.btn_Deleteedit.Size = New System.Drawing.Size(75, 37)
        Me.btn_Deleteedit.TabIndex = 18
        Me.btn_Deleteedit.Text = "Delete"
        Me.btn_Deleteedit.UseVisualStyleBackColor = False
        '
        'btn_cancleedit
        '
        Me.btn_cancleedit.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancleedit.Location = New System.Drawing.Point(554, 401)
        Me.btn_cancleedit.Name = "btn_cancleedit"
        Me.btn_cancleedit.Size = New System.Drawing.Size(75, 37)
        Me.btn_cancleedit.TabIndex = 19
        Me.btn_cancleedit.Text = "cancle"
        Me.btn_cancleedit.UseVisualStyleBackColor = False
        '
        'cmb_editnuid
        '
        Me.cmb_editnuid.FormattingEnabled = True
        Me.cmb_editnuid.Location = New System.Drawing.Point(363, 197)
        Me.cmb_editnuid.Name = "cmb_editnuid"
        Me.cmb_editnuid.Size = New System.Drawing.Size(205, 24)
        Me.cmb_editnuid.TabIndex = 20
        '
        'cmb_editnum
        '
        Me.cmb_editnum.FormattingEnabled = True
        Me.cmb_editnum.Location = New System.Drawing.Point(363, 169)
        Me.cmb_editnum.Name = "cmb_editnum"
        Me.cmb_editnum.Size = New System.Drawing.Size(205, 24)
        Me.cmb_editnum.TabIndex = 21
        '
        'cmb_editrenum
        '
        Me.cmb_editrenum.FormattingEnabled = True
        Me.cmb_editrenum.Location = New System.Drawing.Point(359, 282)
        Me.cmb_editrenum.Name = "cmb_editrenum"
        Me.cmb_editrenum.Size = New System.Drawing.Size(205, 24)
        Me.cmb_editrenum.TabIndex = 23
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(364, 134)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker1.TabIndex = 24
        '
        'FormEditRequisition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.cmb_editrenum)
        Me.Controls.Add(Me.cmb_editnum)
        Me.Controls.Add(Me.cmb_editnuid)
        Me.Controls.Add(Me.btn_cancleedit)
        Me.Controls.Add(Me.btn_Deleteedit)
        Me.Controls.Add(Me.btn_saveeidt)
        Me.Controls.Add(Me.txtb_editrequan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormEditRequisition"
        Me.Text = "FormEditRequisition"
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
    Friend WithEvents txtb_editrequan As TextBox
    Friend WithEvents btn_saveeidt As Button
    Friend WithEvents btn_Deleteedit As Button
    Friend WithEvents btn_cancleedit As Button
    Friend WithEvents cmb_editnuid As ComboBox
    Friend WithEvents cmb_editnum As ComboBox
    Friend WithEvents cmb_editrenum As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
