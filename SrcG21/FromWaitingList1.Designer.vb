<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FromWaitingList1
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.cmb_panid = New System.Windows.Forms.ComboBox()
        Me.cmb_ward = New System.Windows.Forms.ComboBox()
        Me.cmb_status = New System.Windows.Forms.ComboBox()
        Me.dtp_date = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(274, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Waiting List"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(204, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Patient.ID :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(204, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Date Added :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(204, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Ward Required :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(204, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Status :"
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_save.Location = New System.Drawing.Point(187, 383)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 30)
        Me.btn_save.TabIndex = 12
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'btn_Delete
        '
        Me.btn_Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_Delete.Location = New System.Drawing.Point(345, 383)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(75, 30)
        Me.btn_Delete.TabIndex = 13
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(514, 383)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 30)
        Me.btn_cancle.TabIndex = 14
        Me.btn_cancle.Text = "Cancel"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'cmb_panid
        '
        Me.cmb_panid.FormattingEnabled = True
        Me.cmb_panid.Location = New System.Drawing.Point(316, 132)
        Me.cmb_panid.Name = "cmb_panid"
        Me.cmb_panid.Size = New System.Drawing.Size(236, 24)
        Me.cmb_panid.TabIndex = 15
        '
        'cmb_ward
        '
        Me.cmb_ward.FormattingEnabled = True
        Me.cmb_ward.Location = New System.Drawing.Point(316, 203)
        Me.cmb_ward.Name = "cmb_ward"
        Me.cmb_ward.Size = New System.Drawing.Size(236, 24)
        Me.cmb_ward.TabIndex = 18
        '
        'cmb_status
        '
        Me.cmb_status.FormattingEnabled = True
        Me.cmb_status.Location = New System.Drawing.Point(316, 243)
        Me.cmb_status.Name = "cmb_status"
        Me.cmb_status.Size = New System.Drawing.Size(236, 24)
        Me.cmb_status.TabIndex = 19
        '
        'dtp_date
        '
        Me.dtp_date.Location = New System.Drawing.Point(316, 176)
        Me.dtp_date.Name = "dtp_date"
        Me.dtp_date.Size = New System.Drawing.Size(236, 22)
        Me.dtp_date.TabIndex = 20
        '
        'FromWaitingList1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dtp_date)
        Me.Controls.Add(Me.cmb_status)
        Me.Controls.Add(Me.cmb_ward)
        Me.Controls.Add(Me.cmb_panid)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FromWaitingList1"
        Me.Text = "FromWaitingList1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_save As Button
    Friend WithEvents btn_Delete As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents cmb_panid As ComboBox
    Friend WithEvents cmb_ward As ComboBox
    Friend WithEvents cmb_status As ComboBox
    Friend WithEvents dtp_date As DateTimePicker
End Class
