<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPharmaceuticalSupplie
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
        Me.EditPhama = New System.Windows.Forms.Button()
        Me.SrcPhama = New System.Windows.Forms.Button()
        Me.TextBoxPhama = New System.Windows.Forms.TextBox()
        Me.AddFromPharSup = New System.Windows.Forms.Button()
        Me.DataGridViewPhama = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewPhama, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EditPhama
        '
        Me.EditPhama.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.EditPhama.Location = New System.Drawing.Point(713, 411)
        Me.EditPhama.Name = "EditPhama"
        Me.EditPhama.Size = New System.Drawing.Size(75, 30)
        Me.EditPhama.TabIndex = 0
        Me.EditPhama.Text = "Edit"
        Me.EditPhama.UseVisualStyleBackColor = False
        '
        'SrcPhama
        '
        Me.SrcPhama.Location = New System.Drawing.Point(713, 39)
        Me.SrcPhama.Name = "SrcPhama"
        Me.SrcPhama.Size = New System.Drawing.Size(75, 30)
        Me.SrcPhama.TabIndex = 1
        Me.SrcPhama.Text = "Search"
        Me.SrcPhama.UseVisualStyleBackColor = True
        '
        'TextBoxPhama
        '
        Me.TextBoxPhama.Location = New System.Drawing.Point(445, 47)
        Me.TextBoxPhama.Name = "TextBoxPhama"
        Me.TextBoxPhama.Size = New System.Drawing.Size(262, 22)
        Me.TextBoxPhama.TabIndex = 2
        '
        'AddFromPharSup
        '
        Me.AddFromPharSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AddFromPharSup.Location = New System.Drawing.Point(632, 411)
        Me.AddFromPharSup.Name = "AddFromPharSup"
        Me.AddFromPharSup.Size = New System.Drawing.Size(75, 30)
        Me.AddFromPharSup.TabIndex = 4
        Me.AddFromPharSup.Text = "Add"
        Me.AddFromPharSup.UseVisualStyleBackColor = False
        '
        'DataGridViewPhama
        '
        Me.DataGridViewPhama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPhama.Location = New System.Drawing.Point(66, 92)
        Me.DataGridViewPhama.Name = "DataGridViewPhama"
        Me.DataGridViewPhama.RowHeadersWidth = 51
        Me.DataGridViewPhama.RowTemplate.Height = 24
        Me.DataGridViewPhama.Size = New System.Drawing.Size(688, 279)
        Me.DataGridViewPhama.TabIndex = 5
        '
        'FormPharmaceuticalSupplie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 473)
        Me.Controls.Add(Me.DataGridViewPhama)
        Me.Controls.Add(Me.AddFromPharSup)
        Me.Controls.Add(Me.TextBoxPhama)
        Me.Controls.Add(Me.SrcPhama)
        Me.Controls.Add(Me.EditPhama)
        Me.Name = "FormPharmaceuticalSupplie"
        Me.Text = "FormPharmaceuticalSupplie"
        CType(Me.DataGridViewPhama, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EditPhama As Button
    Friend WithEvents SrcPhama As Button
    Friend WithEvents TextBoxPhama As TextBox
    Friend WithEvents AddFromPharSup As Button
    Friend WithEvents DataGridViewPhama As DataGridView
End Class
