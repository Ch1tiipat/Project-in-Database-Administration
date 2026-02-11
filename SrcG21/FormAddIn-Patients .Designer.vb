<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddIn_Patients
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmb_patientID = New System.Windows.Forms.ComboBox()
        Me.cmb_wardnb = New System.Windows.Forms.ComboBox()
        Me.cmb_bednb = New System.Windows.Forms.ComboBox()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.dtp_dateward = New System.Windows.Forms.DateTimePicker()
        Me.dtp_lavedate = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(287, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "In-Patients "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(250, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Admission Information"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(250, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Patient Information"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(250, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Patient.ID :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Location = New System.Drawing.Point(252, 354)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 32)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Expected " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leave Date :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label16.Location = New System.Drawing.Point(252, 321)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Expected Stay :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label15.Location = New System.Drawing.Point(252, 287)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 16)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Date In Ward :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label14.Location = New System.Drawing.Point(252, 252)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 16)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Bed Number :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(252, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 16)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Ward Number :"
        '
        'cmb_patientID
        '
        Me.cmb_patientID.FormattingEnabled = True
        Me.cmb_patientID.Location = New System.Drawing.Point(364, 140)
        Me.cmb_patientID.Name = "cmb_patientID"
        Me.cmb_patientID.Size = New System.Drawing.Size(180, 24)
        Me.cmb_patientID.TabIndex = 26
        '
        'cmb_wardnb
        '
        Me.cmb_wardnb.FormattingEnabled = True
        Me.cmb_wardnb.Location = New System.Drawing.Point(364, 211)
        Me.cmb_wardnb.Name = "cmb_wardnb"
        Me.cmb_wardnb.Size = New System.Drawing.Size(180, 24)
        Me.cmb_wardnb.TabIndex = 35
        '
        'cmb_bednb
        '
        Me.cmb_bednb.FormattingEnabled = True
        Me.cmb_bednb.Location = New System.Drawing.Point(364, 243)
        Me.cmb_bednb.Name = "cmb_bednb"
        Me.cmb_bednb.Size = New System.Drawing.Size(180, 24)
        Me.cmb_bednb.TabIndex = 36
        '
        'btn_Add
        '
        Me.btn_Add.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Add.Location = New System.Drawing.Point(277, 424)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(75, 28)
        Me.btn_Add.TabIndex = 40
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(443, 424)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 28)
        Me.btn_cancle.TabIndex = 41
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'dtp_dateward
        '
        Me.dtp_dateward.Location = New System.Drawing.Point(364, 280)
        Me.dtp_dateward.Name = "dtp_dateward"
        Me.dtp_dateward.Size = New System.Drawing.Size(180, 22)
        Me.dtp_dateward.TabIndex = 42
        '
        'dtp_lavedate
        '
        Me.dtp_lavedate.Location = New System.Drawing.Point(364, 363)
        Me.dtp_lavedate.Name = "dtp_lavedate"
        Me.dtp_lavedate.Size = New System.Drawing.Size(180, 22)
        Me.dtp_lavedate.TabIndex = 43
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(364, 321)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(180, 22)
        Me.DateTimePicker1.TabIndex = 44
        '
        'FormAddIn_Patients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 484)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.dtp_lavedate)
        Me.Controls.Add(Me.dtp_dateward)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.cmb_bednb)
        Me.Controls.Add(Me.cmb_wardnb)
        Me.Controls.Add(Me.cmb_patientID)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormAddIn_Patients"
        Me.Text = "FormAddIn_Patients"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cmb_patientID As ComboBox
    Friend WithEvents cmb_wardnb As ComboBox
    Friend WithEvents cmb_bednb As ComboBox
    Friend WithEvents btn_Add As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents dtp_dateward As DateTimePicker
    Friend WithEvents dtp_lavedate As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
