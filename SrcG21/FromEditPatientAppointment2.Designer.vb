<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FromEditPatientAppointment2
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btn_SaveEditAppoint = New System.Windows.Forms.Button()
        Me.btn_EditCancleAppoint = New System.Windows.Forms.Button()
        Me.cmb_EditPtnApoint = New System.Windows.Forms.ComboBox()
        Me.btn_EditDeleteAppoint = New System.Windows.Forms.Button()
        Me.cmb_EditWardAppoint = New System.Windows.Forms.ComboBox()
        Me.dtp_EditAppointDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtb_EditExamRoom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.EditStatusAppoint = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(171, 22)
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
        Me.Label2.Location = New System.Drawing.Point(330, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Patient Appointment"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(251, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Patient ID :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(254, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 32)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Appointment " & Global.Microsoft.VisualBasic.ChrW(10) & "Date "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label12.Location = New System.Drawing.Point(254, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Ward :"
        '
        'btn_SaveEditAppoint
        '
        Me.btn_SaveEditAppoint.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_SaveEditAppoint.Location = New System.Drawing.Point(271, 387)
        Me.btn_SaveEditAppoint.Name = "btn_SaveEditAppoint"
        Me.btn_SaveEditAppoint.Size = New System.Drawing.Size(75, 37)
        Me.btn_SaveEditAppoint.TabIndex = 22
        Me.btn_SaveEditAppoint.Text = "Save"
        Me.btn_SaveEditAppoint.UseVisualStyleBackColor = False
        '
        'btn_EditCancleAppoint
        '
        Me.btn_EditCancleAppoint.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_EditCancleAppoint.Location = New System.Drawing.Point(516, 387)
        Me.btn_EditCancleAppoint.Name = "btn_EditCancleAppoint"
        Me.btn_EditCancleAppoint.Size = New System.Drawing.Size(75, 37)
        Me.btn_EditCancleAppoint.TabIndex = 23
        Me.btn_EditCancleAppoint.Text = "Cancle"
        Me.btn_EditCancleAppoint.UseVisualStyleBackColor = False
        '
        'cmb_EditPtnApoint
        '
        Me.cmb_EditPtnApoint.FormattingEnabled = True
        Me.cmb_EditPtnApoint.Location = New System.Drawing.Point(362, 134)
        Me.cmb_EditPtnApoint.Name = "cmb_EditPtnApoint"
        Me.cmb_EditPtnApoint.Size = New System.Drawing.Size(229, 24)
        Me.cmb_EditPtnApoint.TabIndex = 25
        '
        'btn_EditDeleteAppoint
        '
        Me.btn_EditDeleteAppoint.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_EditDeleteAppoint.Location = New System.Drawing.Point(393, 387)
        Me.btn_EditDeleteAppoint.Name = "btn_EditDeleteAppoint"
        Me.btn_EditDeleteAppoint.Size = New System.Drawing.Size(75, 37)
        Me.btn_EditDeleteAppoint.TabIndex = 26
        Me.btn_EditDeleteAppoint.Text = "Delete"
        Me.btn_EditDeleteAppoint.UseVisualStyleBackColor = False
        '
        'cmb_EditWardAppoint
        '
        Me.cmb_EditWardAppoint.FormattingEnabled = True
        Me.cmb_EditWardAppoint.Location = New System.Drawing.Point(362, 176)
        Me.cmb_EditWardAppoint.Name = "cmb_EditWardAppoint"
        Me.cmb_EditWardAppoint.Size = New System.Drawing.Size(229, 24)
        Me.cmb_EditWardAppoint.TabIndex = 27
        '
        'dtp_EditAppointDate
        '
        Me.dtp_EditAppointDate.Location = New System.Drawing.Point(362, 217)
        Me.dtp_EditAppointDate.Name = "dtp_EditAppointDate"
        Me.dtp_EditAppointDate.Size = New System.Drawing.Size(229, 22)
        Me.dtp_EditAppointDate.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(254, 255)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 32)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Examination " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Room :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(254, 300)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Status :"
        '
        'txtb_EditExamRoom
        '
        Me.txtb_EditExamRoom.Location = New System.Drawing.Point(362, 255)
        Me.txtb_EditExamRoom.Name = "txtb_EditExamRoom"
        Me.txtb_EditExamRoom.Size = New System.Drawing.Size(229, 22)
        Me.txtb_EditExamRoom.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(254, 336)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Staff iD"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(362, 336)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(236, 24)
        Me.ComboBox1.TabIndex = 35
        '
        'EditStatusAppoint
        '
        Me.EditStatusAppoint.FormattingEnabled = True
        Me.EditStatusAppoint.Location = New System.Drawing.Point(362, 297)
        Me.EditStatusAppoint.Name = "EditStatusAppoint"
        Me.EditStatusAppoint.Size = New System.Drawing.Size(229, 24)
        Me.EditStatusAppoint.TabIndex = 36
        '
        'FromEditPatientAppointment2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.EditStatusAppoint)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtb_EditExamRoom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtp_EditAppointDate)
        Me.Controls.Add(Me.cmb_EditWardAppoint)
        Me.Controls.Add(Me.btn_EditDeleteAppoint)
        Me.Controls.Add(Me.cmb_EditPtnApoint)
        Me.Controls.Add(Me.btn_EditCancleAppoint)
        Me.Controls.Add(Me.btn_SaveEditAppoint)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FromEditPatientAppointment2"
        Me.Text = "FromEditPatientAppointment2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btn_SaveEditAppoint As Button
    Friend WithEvents btn_EditCancleAppoint As Button
    Friend WithEvents cmb_EditPtnApoint As ComboBox
    Friend WithEvents btn_EditDeleteAppoint As Button
    Friend WithEvents cmb_EditWardAppoint As ComboBox
    Friend WithEvents dtp_EditAppointDate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtb_EditExamRoom As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents EditStatusAppoint As ComboBox
End Class
