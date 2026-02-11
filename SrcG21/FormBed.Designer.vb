<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBed
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
        Me.pnl_bed = New System.Windows.Forms.Panel()
        Me.btn_searchbed = New System.Windows.Forms.Button()
        Me.btn_Editbed = New System.Windows.Forms.Button()
        Me.txtb_searchbed = New System.Windows.Forms.TextBox()
        Me.btn_Addbed = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnl_bed
        '
        Me.pnl_bed.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnl_bed.Location = New System.Drawing.Point(38, 90)
        Me.pnl_bed.Name = "pnl_bed"
        Me.pnl_bed.Size = New System.Drawing.Size(713, 270)
        Me.pnl_bed.TabIndex = 0
        '
        'btn_searchbed
        '
        Me.btn_searchbed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_searchbed.Location = New System.Drawing.Point(663, 50)
        Me.btn_searchbed.Name = "btn_searchbed"
        Me.btn_searchbed.Size = New System.Drawing.Size(75, 23)
        Me.btn_searchbed.TabIndex = 1
        Me.btn_searchbed.Text = "Search"
        Me.btn_searchbed.UseVisualStyleBackColor = True
        '
        'btn_Editbed
        '
        Me.btn_Editbed.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_Editbed.Location = New System.Drawing.Point(663, 366)
        Me.btn_Editbed.Name = "btn_Editbed"
        Me.btn_Editbed.Size = New System.Drawing.Size(75, 30)
        Me.btn_Editbed.TabIndex = 2
        Me.btn_Editbed.Text = "Edit"
        Me.btn_Editbed.UseVisualStyleBackColor = False
        '
        'txtb_searchbed
        '
        Me.txtb_searchbed.Location = New System.Drawing.Point(457, 50)
        Me.txtb_searchbed.Name = "txtb_searchbed"
        Me.txtb_searchbed.Size = New System.Drawing.Size(200, 22)
        Me.txtb_searchbed.TabIndex = 3
        '
        'btn_Addbed
        '
        Me.btn_Addbed.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Addbed.Location = New System.Drawing.Point(560, 366)
        Me.btn_Addbed.Name = "btn_Addbed"
        Me.btn_Addbed.Size = New System.Drawing.Size(75, 30)
        Me.btn_Addbed.TabIndex = 4
        Me.btn_Addbed.Text = "Add"
        Me.btn_Addbed.UseVisualStyleBackColor = False
        '
        'FormBed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 422)
        Me.Controls.Add(Me.btn_Addbed)
        Me.Controls.Add(Me.txtb_searchbed)
        Me.Controls.Add(Me.btn_Editbed)
        Me.Controls.Add(Me.btn_searchbed)
        Me.Controls.Add(Me.pnl_bed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormBed"
        Me.Text = "FormBed"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnl_bed As Panel
    Friend WithEvents btn_searchbed As Button
    Friend WithEvents btn_Editbed As Button
    Friend WithEvents txtb_searchbed As TextBox
    Friend WithEvents btn_Addbed As Button
End Class
