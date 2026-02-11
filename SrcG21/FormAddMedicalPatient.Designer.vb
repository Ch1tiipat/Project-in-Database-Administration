<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddMedicalPatient
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_unitper = New System.Windows.Forms.TextBox()
        Me.btn_med_moa = New System.Windows.Forms.TextBox()
        Me.btn_Addmed = New System.Windows.Forms.Button()
        Me.btn_canclemed = New System.Windows.Forms.Button()
        Me.med_CN_ID = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.med_PID = New System.Windows.Forms.ComboBox()
        Me.med_drugnumED = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(191, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(453, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Form Patient Medication"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(300, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From Patient Medication "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(168, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Patient ID :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(168, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Drug Name :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(168, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "UnitPer :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(168, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Method_of_admin :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(169, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "StartDate :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(169, 310)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "FinishDate :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label9.Location = New System.Drawing.Point(169, 343)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Charge Nurse Name :"
        '
        'btn_unitper
        '
        Me.btn_unitper.Location = New System.Drawing.Point(305, 196)
        Me.btn_unitper.Name = "btn_unitper"
        Me.btn_unitper.Size = New System.Drawing.Size(243, 22)
        Me.btn_unitper.TabIndex = 13
        '
        'btn_med_moa
        '
        Me.btn_med_moa.Location = New System.Drawing.Point(305, 230)
        Me.btn_med_moa.Name = "btn_med_moa"
        Me.btn_med_moa.Size = New System.Drawing.Size(243, 22)
        Me.btn_med_moa.TabIndex = 14
        '
        'btn_Addmed
        '
        Me.btn_Addmed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Addmed.Location = New System.Drawing.Point(290, 415)
        Me.btn_Addmed.Name = "btn_Addmed"
        Me.btn_Addmed.Size = New System.Drawing.Size(75, 30)
        Me.btn_Addmed.TabIndex = 19
        Me.btn_Addmed.Text = "Add"
        Me.btn_Addmed.UseVisualStyleBackColor = False
        '
        'btn_canclemed
        '
        Me.btn_canclemed.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_canclemed.Location = New System.Drawing.Point(452, 415)
        Me.btn_canclemed.Name = "btn_canclemed"
        Me.btn_canclemed.Size = New System.Drawing.Size(75, 30)
        Me.btn_canclemed.TabIndex = 20
        Me.btn_canclemed.Text = "Cancle"
        Me.btn_canclemed.UseVisualStyleBackColor = False
        '
        'med_CN_ID
        '
        Me.med_CN_ID.FormattingEnabled = True
        Me.med_CN_ID.Location = New System.Drawing.Point(305, 334)
        Me.med_CN_ID.Name = "med_CN_ID"
        Me.med_CN_ID.Size = New System.Drawing.Size(243, 24)
        Me.med_CN_ID.TabIndex = 21
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(305, 267)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(243, 22)
        Me.DateTimePicker1.TabIndex = 22
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(305, 303)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(243, 22)
        Me.DateTimePicker2.TabIndex = 23
        '
        'med_PID
        '
        Me.med_PID.FormattingEnabled = True
        Me.med_PID.Location = New System.Drawing.Point(305, 123)
        Me.med_PID.Name = "med_PID"
        Me.med_PID.Size = New System.Drawing.Size(243, 24)
        Me.med_PID.TabIndex = 24
        '
        'med_drugnumED
        '
        Me.med_drugnumED.FormattingEnabled = True
        Me.med_drugnumED.Location = New System.Drawing.Point(305, 156)
        Me.med_drugnumED.Name = "med_drugnumED"
        Me.med_drugnumED.Size = New System.Drawing.Size(243, 24)
        Me.med_drugnumED.TabIndex = 25
        '
        'FormAddMedicalPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 468)
        Me.Controls.Add(Me.med_drugnumED)
        Me.Controls.Add(Me.med_PID)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.med_CN_ID)
        Me.Controls.Add(Me.btn_canclemed)
        Me.Controls.Add(Me.btn_Addmed)
        Me.Controls.Add(Me.btn_med_moa)
        Me.Controls.Add(Me.btn_unitper)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAddMedicalPatient"
        Me.Text = "FormAddMedicalPatient"
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
    Friend WithEvents btn_unitper As TextBox
    Friend WithEvents btn_med_moa As TextBox
    Friend WithEvents btn_Addmed As Button
    Friend WithEvents btn_canclemed As Button
    Friend WithEvents med_CN_ID As ComboBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents med_PID As ComboBox
    Friend WithEvents med_drugnumED As ComboBox
End Class
