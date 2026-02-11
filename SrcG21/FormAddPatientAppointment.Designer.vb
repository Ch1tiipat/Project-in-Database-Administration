<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddPatientAppointment
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmb_AddPtnApoint = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_AddAppoint = New System.Windows.Forms.Button()
        Me.btn_CancleAppoint = New System.Windows.Forms.Button()
        Me.dtp_AddAppointDate = New System.Windows.Forms.DateTimePicker()
        Me.cmb_AddWardAppoint = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtb_AddExamRoom = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AddStatusAppoint = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(168, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(483, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Patient Appointment"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(317, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Patient Appointment"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(259, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Patient ID :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label12.Location = New System.Drawing.Point(262, 182)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Ward :"
        '
        'cmb_AddPtnApoint
        '
        Me.cmb_AddPtnApoint.FormattingEnabled = True
        Me.cmb_AddPtnApoint.Location = New System.Drawing.Point(388, 134)
        Me.cmb_AddPtnApoint.Name = "cmb_AddPtnApoint"
        Me.cmb_AddPtnApoint.Size = New System.Drawing.Size(222, 24)
        Me.cmb_AddPtnApoint.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(262, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 32)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Appointment " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Date "
        '
        'btn_AddAppoint
        '
        Me.btn_AddAppoint.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_AddAppoint.Location = New System.Drawing.Point(307, 397)
        Me.btn_AddAppoint.Name = "btn_AddAppoint"
        Me.btn_AddAppoint.Size = New System.Drawing.Size(75, 32)
        Me.btn_AddAppoint.TabIndex = 22
        Me.btn_AddAppoint.Text = "Add"
        Me.btn_AddAppoint.UseVisualStyleBackColor = False
        '
        'btn_CancleAppoint
        '
        Me.btn_CancleAppoint.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_CancleAppoint.Location = New System.Drawing.Point(442, 397)
        Me.btn_CancleAppoint.Name = "btn_CancleAppoint"
        Me.btn_CancleAppoint.Size = New System.Drawing.Size(75, 32)
        Me.btn_CancleAppoint.TabIndex = 23
        Me.btn_CancleAppoint.Text = "Cancle"
        Me.btn_CancleAppoint.UseVisualStyleBackColor = False
        '
        'dtp_AddAppointDate
        '
        Me.dtp_AddAppointDate.Location = New System.Drawing.Point(388, 222)
        Me.dtp_AddAppointDate.Name = "dtp_AddAppointDate"
        Me.dtp_AddAppointDate.Size = New System.Drawing.Size(222, 22)
        Me.dtp_AddAppointDate.TabIndex = 25
        '
        'cmb_AddWardAppoint
        '
        Me.cmb_AddWardAppoint.FormattingEnabled = True
        Me.cmb_AddWardAppoint.Location = New System.Drawing.Point(388, 174)
        Me.cmb_AddWardAppoint.Name = "cmb_AddWardAppoint"
        Me.cmb_AddWardAppoint.Size = New System.Drawing.Size(222, 24)
        Me.cmb_AddWardAppoint.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(264, 298)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Status :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(264, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 32)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Examination " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Room :"
        '
        'txtb_AddExamRoom
        '
        Me.txtb_AddExamRoom.Location = New System.Drawing.Point(388, 254)
        Me.txtb_AddExamRoom.Name = "txtb_AddExamRoom"
        Me.txtb_AddExamRoom.Size = New System.Drawing.Size(222, 22)
        Me.txtb_AddExamRoom.TabIndex = 29
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(388, 336)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(222, 24)
        Me.ComboBox1.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(264, 339)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Staff ID"
        '
        'AddStatusAppoint
        '
        Me.AddStatusAppoint.FormattingEnabled = True
        Me.AddStatusAppoint.Location = New System.Drawing.Point(388, 295)
        Me.AddStatusAppoint.Name = "AddStatusAppoint"
        Me.AddStatusAppoint.Size = New System.Drawing.Size(222, 24)
        Me.AddStatusAppoint.TabIndex = 33
        '
        'FormAddPatientAppointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.AddStatusAppoint)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.txtb_AddExamRoom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmb_AddWardAppoint)
        Me.Controls.Add(Me.dtp_AddAppointDate)
        Me.Controls.Add(Me.btn_CancleAppoint)
        Me.Controls.Add(Me.btn_AddAppoint)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmb_AddPtnApoint)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAddPatientAppointment"
        Me.Text = "FormAddPatientAppointment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmb_AddPtnApoint As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btn_AddAppoint As Button
    Friend WithEvents btn_CancleAppoint As Button
    Friend WithEvents dtp_AddAppointDate As DateTimePicker
    Friend WithEvents cmb_AddWardAppoint As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtb_AddExamRoom As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents AddStatusAppoint As ComboBox
End Class
