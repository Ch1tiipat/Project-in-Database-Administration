<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormIn_Patients1
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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.cmb_PatientID = New System.Windows.Forms.ComboBox()
        Me.cmb_wardnb = New System.Windows.Forms.ComboBox()
        Me.cmb_bednb = New System.Windows.Forms.ComboBox()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.dtp_inward = New System.Windows.Forms.DateTimePicker()
        Me.dtp_lave = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(295, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "In-Patients "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(241, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Patient Information"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(241, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Admission Information"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(243, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Patient.ID :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(244, 211)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Ward Number :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label14.Location = New System.Drawing.Point(244, 244)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 16)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Bed Number :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label15.Location = New System.Drawing.Point(244, 279)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Date In Ward :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label16.Location = New System.Drawing.Point(244, 313)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Expected Stay :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Location = New System.Drawing.Point(244, 346)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 32)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Expected " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leave Date :"
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_save.Location = New System.Drawing.Point(236, 428)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 31)
        Me.btn_save.TabIndex = 31
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'btn_Delete
        '
        Me.btn_Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Delete.Location = New System.Drawing.Point(397, 428)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(75, 31)
        Me.btn_Delete.TabIndex = 32
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = False
        '
        'cmb_PatientID
        '
        Me.cmb_PatientID.FormattingEnabled = True
        Me.cmb_PatientID.Location = New System.Drawing.Point(354, 130)
        Me.cmb_PatientID.Name = "cmb_PatientID"
        Me.cmb_PatientID.Size = New System.Drawing.Size(210, 24)
        Me.cmb_PatientID.TabIndex = 34
        '
        'cmb_wardnb
        '
        Me.cmb_wardnb.FormattingEnabled = True
        Me.cmb_wardnb.Location = New System.Drawing.Point(354, 202)
        Me.cmb_wardnb.Name = "cmb_wardnb"
        Me.cmb_wardnb.Size = New System.Drawing.Size(210, 24)
        Me.cmb_wardnb.TabIndex = 35
        '
        'cmb_bednb
        '
        Me.cmb_bednb.FormattingEnabled = True
        Me.cmb_bednb.Location = New System.Drawing.Point(354, 235)
        Me.cmb_bednb.Name = "cmb_bednb"
        Me.cmb_bednb.Size = New System.Drawing.Size(210, 24)
        Me.cmb_bednb.TabIndex = 36
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(563, 428)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 31)
        Me.btn_cancle.TabIndex = 37
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'dtp_inward
        '
        Me.dtp_inward.Location = New System.Drawing.Point(354, 279)
        Me.dtp_inward.Name = "dtp_inward"
        Me.dtp_inward.Size = New System.Drawing.Size(210, 22)
        Me.dtp_inward.TabIndex = 38
        '
        'dtp_lave
        '
        Me.dtp_lave.Location = New System.Drawing.Point(354, 346)
        Me.dtp_lave.Name = "dtp_lave"
        Me.dtp_lave.Size = New System.Drawing.Size(210, 22)
        Me.dtp_lave.TabIndex = 39
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(354, 313)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(210, 22)
        Me.DateTimePicker1.TabIndex = 40
        '
        'FormIn_Patients1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 484)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.dtp_lave)
        Me.Controls.Add(Me.dtp_inward)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.cmb_bednb)
        Me.Controls.Add(Me.cmb_wardnb)
        Me.Controls.Add(Me.cmb_PatientID)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormIn_Patients1"
        Me.Text = "FormIn_Patients1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents btn_save As Button
    Friend WithEvents btn_Delete As Button
    Friend WithEvents cmb_PatientID As ComboBox
    Friend WithEvents cmb_wardnb As ComboBox
    Friend WithEvents cmb_bednb As ComboBox
    Friend WithEvents btn_cancle As Button
    Friend WithEvents dtp_inward As DateTimePicker
    Friend WithEvents dtp_lave As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
