<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FromReportMedication
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
        Me.btn_me = New System.Windows.Forms.Button()
        Me.textb_me = New System.Windows.Forms.TextBox()
        Me.pnl_Medi = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btn_me
        '
        Me.btn_me.Location = New System.Drawing.Point(720, 36)
        Me.btn_me.Name = "btn_me"
        Me.btn_me.Size = New System.Drawing.Size(75, 30)
        Me.btn_me.TabIndex = 1
        Me.btn_me.Text = "Search"
        Me.btn_me.UseVisualStyleBackColor = True
        '
        'textb_me
        '
        Me.textb_me.Location = New System.Drawing.Point(482, 43)
        Me.textb_me.Name = "textb_me"
        Me.textb_me.Size = New System.Drawing.Size(232, 22)
        Me.textb_me.TabIndex = 2
        '
        'pnl_Medi
        '
        Me.pnl_Medi.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pnl_Medi.Location = New System.Drawing.Point(13, 84)
        Me.pnl_Medi.Name = "pnl_Medi"
        Me.pnl_Medi.Size = New System.Drawing.Size(775, 354)
        Me.pnl_Medi.TabIndex = 3
        '
        'FromReportMedication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnl_Medi)
        Me.Controls.Add(Me.textb_me)
        Me.Controls.Add(Me.btn_me)
        Me.Name = "FromReportMedication"
        Me.Text = "FromReportMedication"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_me As Button
    Friend WithEvents textb_me As TextBox
    Friend WithEvents pnl_Medi As Panel
End Class
