<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPatientRegistration
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
        Me.btn_EditPtnRegis = New System.Windows.Forms.Button()
        Me.txtb_SearchPtnRegis = New System.Windows.Forms.TextBox()
        Me.btn_SearchPtnRegis = New System.Windows.Forms.Button()
        Me.btn_AddPtnRegis = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_EditPtnRegis
        '
        Me.btn_EditPtnRegis.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_EditPtnRegis.Location = New System.Drawing.Point(390, 79)
        Me.btn_EditPtnRegis.Name = "btn_EditPtnRegis"
        Me.btn_EditPtnRegis.Size = New System.Drawing.Size(75, 27)
        Me.btn_EditPtnRegis.TabIndex = 0
        Me.btn_EditPtnRegis.Text = "Edit"
        Me.btn_EditPtnRegis.UseVisualStyleBackColor = False
        '
        'txtb_SearchPtnRegis
        '
        Me.txtb_SearchPtnRegis.Location = New System.Drawing.Point(471, 84)
        Me.txtb_SearchPtnRegis.Name = "txtb_SearchPtnRegis"
        Me.txtb_SearchPtnRegis.Size = New System.Drawing.Size(236, 22)
        Me.txtb_SearchPtnRegis.TabIndex = 1
        '
        'btn_SearchPtnRegis
        '
        Me.btn_SearchPtnRegis.Location = New System.Drawing.Point(713, 81)
        Me.btn_SearchPtnRegis.Name = "btn_SearchPtnRegis"
        Me.btn_SearchPtnRegis.Size = New System.Drawing.Size(75, 27)
        Me.btn_SearchPtnRegis.TabIndex = 2
        Me.btn_SearchPtnRegis.Text = "Search"
        Me.btn_SearchPtnRegis.UseVisualStyleBackColor = True
        '
        'btn_AddPtnRegis
        '
        Me.btn_AddPtnRegis.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_AddPtnRegis.Location = New System.Drawing.Point(309, 79)
        Me.btn_AddPtnRegis.Name = "btn_AddPtnRegis"
        Me.btn_AddPtnRegis.Size = New System.Drawing.Size(75, 27)
        Me.btn_AddPtnRegis.TabIndex = 4
        Me.btn_AddPtnRegis.Text = "Add"
        Me.btn_AddPtnRegis.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(29, 114)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(759, 296)
        Me.DataGridView1.TabIndex = 5
        '
        'FormEditPatientRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_AddPtnRegis)
        Me.Controls.Add(Me.btn_SearchPtnRegis)
        Me.Controls.Add(Me.txtb_SearchPtnRegis)
        Me.Controls.Add(Me.btn_EditPtnRegis)
        Me.Name = "FormEditPatientRegistration"
        Me.Text = "FormPatientRegistration"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_EditPtnRegis As Button
    Friend WithEvents txtb_SearchPtnRegis As TextBox
    Friend WithEvents btn_SearchPtnRegis As Button
    Friend WithEvents btn_AddPtnRegis As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
