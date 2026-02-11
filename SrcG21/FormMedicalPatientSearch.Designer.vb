<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMedicalPatientSearch
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
        Me.btn_Addmp = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_searchMP = New System.Windows.Forms.Button()
        Me.txtb_Medical = New System.Windows.Forms.TextBox()
        Me.DataGridViewMP = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Addmp
        '
        Me.btn_Addmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Addmp.Location = New System.Drawing.Point(605, 387)
        Me.btn_Addmp.Name = "btn_Addmp"
        Me.btn_Addmp.Size = New System.Drawing.Size(75, 30)
        Me.btn_Addmp.TabIndex = 1
        Me.btn_Addmp.Text = "Add"
        Me.btn_Addmp.UseVisualStyleBackColor = False
        '
        'btn_edit
        '
        Me.btn_edit.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_edit.Location = New System.Drawing.Point(691, 387)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 30)
        Me.btn_edit.TabIndex = 2
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = False
        '
        'btn_searchMP
        '
        Me.btn_searchMP.Location = New System.Drawing.Point(691, 67)
        Me.btn_searchMP.Name = "btn_searchMP"
        Me.btn_searchMP.Size = New System.Drawing.Size(75, 23)
        Me.btn_searchMP.TabIndex = 3
        Me.btn_searchMP.Text = "Search"
        Me.btn_searchMP.UseVisualStyleBackColor = True
        '
        'txtb_Medical
        '
        Me.txtb_Medical.Location = New System.Drawing.Point(477, 67)
        Me.txtb_Medical.Name = "txtb_Medical"
        Me.txtb_Medical.Size = New System.Drawing.Size(203, 22)
        Me.txtb_Medical.TabIndex = 4
        '
        'DataGridViewMP
        '
        Me.DataGridViewMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMP.Location = New System.Drawing.Point(60, 118)
        Me.DataGridViewMP.Name = "DataGridViewMP"
        Me.DataGridViewMP.RowHeadersWidth = 51
        Me.DataGridViewMP.RowTemplate.Height = 24
        Me.DataGridViewMP.Size = New System.Drawing.Size(705, 247)
        Me.DataGridViewMP.TabIndex = 5
        '
        'FormMedicalPatientSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridViewMP)
        Me.Controls.Add(Me.txtb_Medical)
        Me.Controls.Add(Me.btn_searchMP)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_Addmp)
        Me.Name = "FormMedicalPatientSearch"
        Me.Text = "FormMedicalPatientSearch"
        CType(Me.DataGridViewMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Addmp As Button
    Friend WithEvents btn_edit As Button
    Friend WithEvents btn_searchMP As Button
    Friend WithEvents txtb_Medical As TextBox
    Friend WithEvents DataGridViewMP As DataGridView
End Class
