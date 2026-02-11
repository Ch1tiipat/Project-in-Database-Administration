<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMedicalPatient1
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.unitperEDIT = New System.Windows.Forms.TextBox()
        Me.med_moaEDIT = New System.Windows.Forms.TextBox()
        Me.btn_AddFrPtnMed = New System.Windows.Forms.Button()
        Me.btn_DeleteFrPtnMed = New System.Windows.Forms.Button()
        Me.btn_CancleFrPtnMed = New System.Windows.Forms.Button()
        Me.med_CN_ID_EDIT = New System.Windows.Forms.ComboBox()
        Me.med_PIDEDIT = New System.Windows.Forms.ComboBox()
        Me.med_drugnumEDIT = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker11 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker22 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(185, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(453, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Patient Medication"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(271, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From Patient Medication "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(190, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Patient ID :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(190, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Drug Name :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(190, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "UnitPer :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(190, 231)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Method_of_admin :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(190, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "StartDate :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(190, 292)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "FinishDate :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(188, 324)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Charge Nurse ID :"
        '
        'unitperEDIT
        '
        Me.unitperEDIT.Location = New System.Drawing.Point(331, 195)
        Me.unitperEDIT.Name = "unitperEDIT"
        Me.unitperEDIT.Size = New System.Drawing.Size(208, 22)
        Me.unitperEDIT.TabIndex = 12
        '
        'med_moaEDIT
        '
        Me.med_moaEDIT.Location = New System.Drawing.Point(331, 224)
        Me.med_moaEDIT.Name = "med_moaEDIT"
        Me.med_moaEDIT.Size = New System.Drawing.Size(208, 22)
        Me.med_moaEDIT.TabIndex = 13
        '
        'btn_AddFrPtnMed
        '
        Me.btn_AddFrPtnMed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_AddFrPtnMed.Location = New System.Drawing.Point(225, 403)
        Me.btn_AddFrPtnMed.Name = "btn_AddFrPtnMed"
        Me.btn_AddFrPtnMed.Size = New System.Drawing.Size(75, 35)
        Me.btn_AddFrPtnMed.TabIndex = 18
        Me.btn_AddFrPtnMed.Text = "Save"
        Me.btn_AddFrPtnMed.UseVisualStyleBackColor = False
        '
        'btn_DeleteFrPtnMed
        '
        Me.btn_DeleteFrPtnMed.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_DeleteFrPtnMed.Location = New System.Drawing.Point(390, 403)
        Me.btn_DeleteFrPtnMed.Name = "btn_DeleteFrPtnMed"
        Me.btn_DeleteFrPtnMed.Size = New System.Drawing.Size(75, 35)
        Me.btn_DeleteFrPtnMed.TabIndex = 19
        Me.btn_DeleteFrPtnMed.Text = "Delete"
        Me.btn_DeleteFrPtnMed.UseVisualStyleBackColor = False
        '
        'btn_CancleFrPtnMed
        '
        Me.btn_CancleFrPtnMed.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_CancleFrPtnMed.Location = New System.Drawing.Point(545, 403)
        Me.btn_CancleFrPtnMed.Name = "btn_CancleFrPtnMed"
        Me.btn_CancleFrPtnMed.Size = New System.Drawing.Size(75, 35)
        Me.btn_CancleFrPtnMed.TabIndex = 20
        Me.btn_CancleFrPtnMed.Text = "Cancle"
        Me.btn_CancleFrPtnMed.UseVisualStyleBackColor = False
        '
        'med_CN_ID_EDIT
        '
        Me.med_CN_ID_EDIT.FormattingEnabled = True
        Me.med_CN_ID_EDIT.Location = New System.Drawing.Point(331, 315)
        Me.med_CN_ID_EDIT.Name = "med_CN_ID_EDIT"
        Me.med_CN_ID_EDIT.Size = New System.Drawing.Size(208, 24)
        Me.med_CN_ID_EDIT.TabIndex = 21
        '
        'med_PIDEDIT
        '
        Me.med_PIDEDIT.FormattingEnabled = True
        Me.med_PIDEDIT.Location = New System.Drawing.Point(331, 130)
        Me.med_PIDEDIT.Name = "med_PIDEDIT"
        Me.med_PIDEDIT.Size = New System.Drawing.Size(208, 24)
        Me.med_PIDEDIT.TabIndex = 22
        '
        'med_drugnumEDIT
        '
        Me.med_drugnumEDIT.FormattingEnabled = True
        Me.med_drugnumEDIT.Location = New System.Drawing.Point(331, 161)
        Me.med_drugnumEDIT.Name = "med_drugnumEDIT"
        Me.med_drugnumEDIT.Size = New System.Drawing.Size(208, 24)
        Me.med_drugnumEDIT.TabIndex = 23
        '
        'DateTimePicker11
        '
        Me.DateTimePicker11.Location = New System.Drawing.Point(331, 252)
        Me.DateTimePicker11.Name = "DateTimePicker11"
        Me.DateTimePicker11.Size = New System.Drawing.Size(208, 22)
        Me.DateTimePicker11.TabIndex = 24
        '
        'DateTimePicker22
        '
        Me.DateTimePicker22.Location = New System.Drawing.Point(331, 285)
        Me.DateTimePicker22.Name = "DateTimePicker22"
        Me.DateTimePicker22.Size = New System.Drawing.Size(208, 22)
        Me.DateTimePicker22.TabIndex = 25
        '
        'FormMedicalPatient1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DateTimePicker22)
        Me.Controls.Add(Me.DateTimePicker11)
        Me.Controls.Add(Me.med_drugnumEDIT)
        Me.Controls.Add(Me.med_PIDEDIT)
        Me.Controls.Add(Me.med_CN_ID_EDIT)
        Me.Controls.Add(Me.btn_CancleFrPtnMed)
        Me.Controls.Add(Me.btn_DeleteFrPtnMed)
        Me.Controls.Add(Me.btn_AddFrPtnMed)
        Me.Controls.Add(Me.med_moaEDIT)
        Me.Controls.Add(Me.unitperEDIT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormMedicalPatient1"
        Me.Text = "FormMedicalPatient1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents unitperEDIT As TextBox
    Friend WithEvents med_moaEDIT As TextBox
    Friend WithEvents btn_DeleteFrPtnMed As Button
    Friend WithEvents btn_CancleFrPtnMed As Button
    Friend WithEvents med_CN_ID_EDIT As ComboBox
    Friend WithEvents med_PIDEDIT As ComboBox
    Friend WithEvents med_drugnumEDIT As ComboBox
    Friend WithEvents DateTimePicker11 As DateTimePicker
    Friend WithEvents DateTimePicker22 As DateTimePicker
    Friend WithEvents btn_AddFrPtnMed As Button
End Class
