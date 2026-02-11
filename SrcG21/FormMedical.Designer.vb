<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMedical
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
        Me.btnMedPtn = New System.Windows.Forms.Button()
        Me.btnMedPs = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnMedPtn
        '
        Me.btnMedPtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnMedPtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnMedPtn.Location = New System.Drawing.Point(124, 127)
        Me.btnMedPtn.Name = "btnMedPtn"
        Me.btnMedPtn.Size = New System.Drawing.Size(198, 156)
        Me.btnMedPtn.TabIndex = 0
        Me.btnMedPtn.Text = "Patient Medication"
        Me.btnMedPtn.UseVisualStyleBackColor = False
        '
        'btnMedPs
        '
        Me.btnMedPs.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnMedPs.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnMedPs.Location = New System.Drawing.Point(410, 127)
        Me.btnMedPs.Name = "btnMedPs"
        Me.btnMedPs.Size = New System.Drawing.Size(198, 156)
        Me.btnMedPs.TabIndex = 1
        Me.btnMedPs.Text = "Pharmaceutical Supplie"
        Me.btnMedPs.UseVisualStyleBackColor = False
        '
        'FormMedical
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnMedPs)
        Me.Controls.Add(Me.btnMedPtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormMedical"
        Me.Text = "FormMedical"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnMedPtn As Button
    Friend WithEvents btnMedPs As Button
End Class
