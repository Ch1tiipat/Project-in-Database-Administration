<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FromEditPatientAppointment1
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
        Me.btn_EditPtnApoint = New System.Windows.Forms.Button()
        Me.btn_SearchApoint = New System.Windows.Forms.Button()
        Me.txtb_SeacrhPtnApoint = New System.Windows.Forms.TextBox()
        Me.btn_AddPtnApoint = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_EditPtnApoint
        '
        Me.btn_EditPtnApoint.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_EditPtnApoint.Location = New System.Drawing.Point(391, 47)
        Me.btn_EditPtnApoint.Name = "btn_EditPtnApoint"
        Me.btn_EditPtnApoint.Size = New System.Drawing.Size(75, 29)
        Me.btn_EditPtnApoint.TabIndex = 0
        Me.btn_EditPtnApoint.Text = "Edit"
        Me.btn_EditPtnApoint.UseVisualStyleBackColor = False
        '
        'btn_SearchApoint
        '
        Me.btn_SearchApoint.Location = New System.Drawing.Point(713, 47)
        Me.btn_SearchApoint.Name = "btn_SearchApoint"
        Me.btn_SearchApoint.Size = New System.Drawing.Size(75, 29)
        Me.btn_SearchApoint.TabIndex = 1
        Me.btn_SearchApoint.Text = "Search"
        Me.btn_SearchApoint.UseVisualStyleBackColor = True
        '
        'txtb_SeacrhPtnApoint
        '
        Me.txtb_SeacrhPtnApoint.Location = New System.Drawing.Point(472, 53)
        Me.txtb_SeacrhPtnApoint.Name = "txtb_SeacrhPtnApoint"
        Me.txtb_SeacrhPtnApoint.Size = New System.Drawing.Size(235, 22)
        Me.txtb_SeacrhPtnApoint.TabIndex = 2
        '
        'btn_AddPtnApoint
        '
        Me.btn_AddPtnApoint.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_AddPtnApoint.Location = New System.Drawing.Point(310, 47)
        Me.btn_AddPtnApoint.Name = "btn_AddPtnApoint"
        Me.btn_AddPtnApoint.Size = New System.Drawing.Size(75, 29)
        Me.btn_AddPtnApoint.TabIndex = 4
        Me.btn_AddPtnApoint.Text = "Add"
        Me.btn_AddPtnApoint.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 118)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(771, 290)
        Me.DataGridView1.TabIndex = 5
        '
        'FromEditPatientAppointment1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_AddPtnApoint)
        Me.Controls.Add(Me.txtb_SeacrhPtnApoint)
        Me.Controls.Add(Me.btn_SearchApoint)
        Me.Controls.Add(Me.btn_EditPtnApoint)
        Me.Name = "FromEditPatientAppointment1"
        Me.Text = "FromEditPatientAppointment1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_EditPtnApoint As Button
    Friend WithEvents btn_SearchApoint As Button
    Friend WithEvents txtb_SeacrhPtnApoint As TextBox
    Friend WithEvents btn_AddPtnApoint As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
