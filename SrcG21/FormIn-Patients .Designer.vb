<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIn_Patients
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
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.txtb_search = New System.Windows.Forms.TextBox()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_edit
        '
        Me.btn_edit.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_edit.Location = New System.Drawing.Point(394, 63)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(75, 32)
        Me.btn_edit.TabIndex = 0
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = False
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(713, 63)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 32)
        Me.btn_search.TabIndex = 1
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'txtb_search
        '
        Me.txtb_search.Location = New System.Drawing.Point(475, 68)
        Me.txtb_search.Name = "txtb_search"
        Me.txtb_search.Size = New System.Drawing.Size(232, 22)
        Me.txtb_search.TabIndex = 2
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_add.Location = New System.Drawing.Point(313, 63)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 32)
        Me.btn_add.TabIndex = 4
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(14, 115)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(762, 302)
        Me.DataGridView1.TabIndex = 5
        '
        'FormIn_Patients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txtb_search)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.btn_edit)
        Me.Name = "FormIn_Patients"
        Me.Text = "FormIn_Patients"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_edit As Button
    Friend WithEvents btn_search As Button
    Friend WithEvents txtb_search As TextBox
    Friend WithEvents btn_add As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
