<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FromReportWardReport
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
        Me.btn_search = New System.Windows.Forms.Button()
        Me.txtb_searchward = New System.Windows.Forms.TextBox()
        Me.Pnl_ward = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(719, 35)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 26)
        Me.btn_search.TabIndex = 1
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'txtb_searchward
        '
        Me.txtb_searchward.Location = New System.Drawing.Point(449, 37)
        Me.txtb_searchward.Name = "txtb_searchward"
        Me.txtb_searchward.Size = New System.Drawing.Size(264, 22)
        Me.txtb_searchward.TabIndex = 2
        '
        'Pnl_ward
        '
        Me.Pnl_ward.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Pnl_ward.Location = New System.Drawing.Point(13, 69)
        Me.Pnl_ward.Name = "Pnl_ward"
        Me.Pnl_ward.Size = New System.Drawing.Size(781, 378)
        Me.Pnl_ward.TabIndex = 3
        '
        'FromReportWardReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Pnl_ward)
        Me.Controls.Add(Me.txtb_searchward)
        Me.Controls.Add(Me.btn_search)
        Me.Name = "FromReportWardReport"
        Me.Text = "FromReportWardReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_search As Button
    Friend WithEvents txtb_searchward As TextBox
    Friend WithEvents Pnl_ward As Panel
End Class
