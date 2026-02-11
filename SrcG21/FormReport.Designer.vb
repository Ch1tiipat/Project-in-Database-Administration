<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReport
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
        Me.btnStaffRep = New System.Windows.Forms.Button()
        Me.btn_Reward = New System.Windows.Forms.Button()
        Me.btnReMr = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStaffRep
        '
        Me.btnStaffRep.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnStaffRep.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStaffRep.Location = New System.Drawing.Point(92, 137)
        Me.btnStaffRep.Name = "btnStaffRep"
        Me.btnStaffRep.Size = New System.Drawing.Size(151, 139)
        Me.btnStaffRep.TabIndex = 0
        Me.btnStaffRep.Text = "Staff Report"
        Me.btnStaffRep.UseVisualStyleBackColor = False
        '
        'btn_Reward
        '
        Me.btn_Reward.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn_Reward.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Reward.Location = New System.Drawing.Point(317, 137)
        Me.btn_Reward.Name = "btn_Reward"
        Me.btn_Reward.Size = New System.Drawing.Size(162, 139)
        Me.btn_Reward.TabIndex = 1
        Me.btn_Reward.Text = "WardReport"
        Me.btn_Reward.UseVisualStyleBackColor = False
        '
        'btnReMr
        '
        Me.btnReMr.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnReMr.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReMr.Location = New System.Drawing.Point(552, 137)
        Me.btnReMr.Name = "btnReMr"
        Me.btnReMr.Size = New System.Drawing.Size(158, 139)
        Me.btnReMr.TabIndex = 2
        Me.btnReMr.Text = "MedicationReport"
        Me.btnReMr.UseVisualStyleBackColor = False
        '
        'FormReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnReMr)
        Me.Controls.Add(Me.btn_Reward)
        Me.Controls.Add(Me.btnStaffRep)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormReport"
        Me.Text = "FormReport"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnStaffRep As Button
    Friend WithEvents btn_Reward As Button
    Friend WithEvents btnReMr As Button
End Class
