<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStaffAssingment
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
        Me.bnt_staffassedit = New System.Windows.Forms.Button()
        Me.txtb_searchstaffass = New System.Windows.Forms.TextBox()
        Me.bnt_staffass = New System.Windows.Forms.Button()
        Me.bnt_addstaffass = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bnt_staffassedit
        '
        Me.bnt_staffassedit.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.bnt_staffassedit.Location = New System.Drawing.Point(713, 409)
        Me.bnt_staffassedit.Name = "bnt_staffassedit"
        Me.bnt_staffassedit.Size = New System.Drawing.Size(75, 29)
        Me.bnt_staffassedit.TabIndex = 0
        Me.bnt_staffassedit.Text = "Edit"
        Me.bnt_staffassedit.UseVisualStyleBackColor = False
        '
        'txtb_searchstaffass
        '
        Me.txtb_searchstaffass.Location = New System.Drawing.Point(483, 49)
        Me.txtb_searchstaffass.Name = "txtb_searchstaffass"
        Me.txtb_searchstaffass.Size = New System.Drawing.Size(224, 22)
        Me.txtb_searchstaffass.TabIndex = 1
        '
        'bnt_staffass
        '
        Me.bnt_staffass.Location = New System.Drawing.Point(713, 46)
        Me.bnt_staffass.Name = "bnt_staffass"
        Me.bnt_staffass.Size = New System.Drawing.Size(75, 29)
        Me.bnt_staffass.TabIndex = 2
        Me.bnt_staffass.Text = "Search"
        Me.bnt_staffass.UseVisualStyleBackColor = True
        '
        'bnt_addstaffass
        '
        Me.bnt_addstaffass.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bnt_addstaffass.Location = New System.Drawing.Point(629, 409)
        Me.bnt_addstaffass.Name = "bnt_addstaffass"
        Me.bnt_addstaffass.Size = New System.Drawing.Size(75, 29)
        Me.bnt_addstaffass.TabIndex = 4
        Me.bnt_addstaffass.Text = "Add"
        Me.bnt_addstaffass.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(36, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(741, 285)
        Me.DataGridView1.TabIndex = 5
        '
        'FormStaffAssingment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.bnt_addstaffass)
        Me.Controls.Add(Me.bnt_staffass)
        Me.Controls.Add(Me.txtb_searchstaffass)
        Me.Controls.Add(Me.bnt_staffassedit)
        Me.Name = "FormStaffAssingment"
        Me.Text = "FormStaffAssingment"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bnt_staffassedit As Button
    Friend WithEvents txtb_searchstaffass As TextBox
    Friend WithEvents bnt_staffass As Button
    Friend WithEvents bnt_addstaffass As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
