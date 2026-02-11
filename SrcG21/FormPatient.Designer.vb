<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPatient
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
        Me.btnPtnRe = New System.Windows.Forms.Button()
        Me.btnPtnApp = New System.Windows.Forms.Button()
        Me.btnPtnInptn = New System.Windows.Forms.Button()
        Me.btnPtnWal = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPtnRe
        '
        Me.btnPtnRe.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnPtnRe.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPtnRe.Location = New System.Drawing.Point(131, 56)
        Me.btnPtnRe.Name = "btnPtnRe"
        Me.btnPtnRe.Size = New System.Drawing.Size(140, 125)
        Me.btnPtnRe.TabIndex = 0
        Me.btnPtnRe.Text = "Patient Registration"
        Me.btnPtnRe.UseVisualStyleBackColor = False
        '
        'btnPtnApp
        '
        Me.btnPtnApp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnPtnApp.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPtnApp.Location = New System.Drawing.Point(462, 56)
        Me.btnPtnApp.Name = "btnPtnApp"
        Me.btnPtnApp.Size = New System.Drawing.Size(144, 125)
        Me.btnPtnApp.TabIndex = 1
        Me.btnPtnApp.Text = "Patient Appointment"
        Me.btnPtnApp.UseVisualStyleBackColor = False
        '
        'btnPtnInptn
        '
        Me.btnPtnInptn.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnPtnInptn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPtnInptn.Location = New System.Drawing.Point(131, 219)
        Me.btnPtnInptn.Name = "btnPtnInptn"
        Me.btnPtnInptn.Size = New System.Drawing.Size(140, 120)
        Me.btnPtnInptn.TabIndex = 2
        Me.btnPtnInptn.Text = "In-Patients "
        Me.btnPtnInptn.UseVisualStyleBackColor = False
        '
        'btnPtnWal
        '
        Me.btnPtnWal.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnPtnWal.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPtnWal.Location = New System.Drawing.Point(462, 219)
        Me.btnPtnWal.Name = "btnPtnWal"
        Me.btnPtnWal.Size = New System.Drawing.Size(144, 120)
        Me.btnPtnWal.TabIndex = 3
        Me.btnPtnWal.Text = " Waiting List"
        Me.btnPtnWal.UseVisualStyleBackColor = False
        '
        'FormPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnPtnWal)
        Me.Controls.Add(Me.btnPtnInptn)
        Me.Controls.Add(Me.btnPtnApp)
        Me.Controls.Add(Me.btnPtnRe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormPatient"
        Me.Text = "FormPatient"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPtnRe As Button
    Friend WithEvents btnPtnApp As Button
    Friend WithEvents btnPtnInptn As Button
    Friend WithEvents btnPtnWal As Button
End Class
