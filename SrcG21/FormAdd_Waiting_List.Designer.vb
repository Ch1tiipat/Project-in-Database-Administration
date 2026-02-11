<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddWaitingList
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_addpanid = New System.Windows.Forms.ComboBox()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.cmb_addward = New System.Windows.Forms.ComboBox()
        Me.cmb_addstatus = New System.Windows.Forms.ComboBox()
        Me.dtp_adddate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(278, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Waiting List"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(217, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Status :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(217, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Ward Required :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(217, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Date Added :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(217, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 16)
        Me.Label4.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(217, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Patient.ID :"
        '
        'cmb_addpanid
        '
        Me.cmb_addpanid.FormattingEnabled = True
        Me.cmb_addpanid.Location = New System.Drawing.Point(331, 122)
        Me.cmb_addpanid.Name = "cmb_addpanid"
        Me.cmb_addpanid.Size = New System.Drawing.Size(230, 24)
        Me.cmb_addpanid.TabIndex = 18
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_add.Location = New System.Drawing.Point(265, 343)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 36)
        Me.btn_add.TabIndex = 19
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(475, 343)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 36)
        Me.btn_cancle.TabIndex = 20
        Me.btn_cancle.Text = "Cancel"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'cmb_addward
        '
        Me.cmb_addward.FormattingEnabled = True
        Me.cmb_addward.Location = New System.Drawing.Point(331, 191)
        Me.cmb_addward.Name = "cmb_addward"
        Me.cmb_addward.Size = New System.Drawing.Size(230, 24)
        Me.cmb_addward.TabIndex = 23
        '
        'cmb_addstatus
        '
        Me.cmb_addstatus.FormattingEnabled = True
        Me.cmb_addstatus.Location = New System.Drawing.Point(331, 223)
        Me.cmb_addstatus.Name = "cmb_addstatus"
        Me.cmb_addstatus.Size = New System.Drawing.Size(230, 24)
        Me.cmb_addstatus.TabIndex = 24
        '
        'dtp_adddate
        '
        Me.dtp_adddate.Location = New System.Drawing.Point(331, 158)
        Me.dtp_adddate.Name = "dtp_adddate"
        Me.dtp_adddate.Size = New System.Drawing.Size(230, 22)
        Me.dtp_adddate.TabIndex = 25
        '
        'FormAddWaitingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dtp_adddate)
        Me.Controls.Add(Me.cmb_addstatus)
        Me.Controls.Add(Me.cmb_addward)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.cmb_addpanid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAddWaitingList"
        Me.Text = "FormAddWaitingList"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_addpanid As ComboBox
    Friend WithEvents btn_add As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents cmb_addward As ComboBox
    Friend WithEvents cmb_addstatus As ComboBox
    Friend WithEvents dtp_adddate As DateTimePicker
End Class
