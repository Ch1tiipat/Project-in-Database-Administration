<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportStaff
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
        Me.btn_staff = New System.Windows.Forms.Button()
        Me.txtb_searchstaff = New System.Windows.Forms.TextBox()
        Me.pnl_staff = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btn_staff
        '
        Me.btn_staff.Location = New System.Drawing.Point(713, 29)
        Me.btn_staff.Name = "btn_staff"
        Me.btn_staff.Size = New System.Drawing.Size(75, 28)
        Me.btn_staff.TabIndex = 1
        Me.btn_staff.Text = "Search"
        Me.btn_staff.UseVisualStyleBackColor = True
        '
        'txtb_searchstaff
        '
        Me.txtb_searchstaff.Location = New System.Drawing.Point(447, 34)
        Me.txtb_searchstaff.Name = "txtb_searchstaff"
        Me.txtb_searchstaff.Size = New System.Drawing.Size(260, 22)
        Me.txtb_searchstaff.TabIndex = 2
        '
        'pnl_staff
        '
        Me.pnl_staff.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pnl_staff.Location = New System.Drawing.Point(13, 74)
        Me.pnl_staff.Name = "pnl_staff"
        Me.pnl_staff.Size = New System.Drawing.Size(775, 364)
        Me.pnl_staff.TabIndex = 3
        '
        'FormReportStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnl_staff)
        Me.Controls.Add(Me.txtb_searchstaff)
        Me.Controls.Add(Me.btn_staff)
        Me.Name = "FormReportStaff"
        Me.Text = "FormReportStaff"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_staff As Button
    Friend WithEvents txtb_searchstaff As TextBox
    Friend WithEvents pnl_staff As Panel
End Class
