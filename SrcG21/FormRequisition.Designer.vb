<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRequisition
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
        Me.btn_EditReq = New System.Windows.Forms.Button()
        Me.btn_SearchReq = New System.Windows.Forms.Button()
        Me.txtb_search = New System.Windows.Forms.TextBox()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_EditReq
        '
        Me.btn_EditReq.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_EditReq.Location = New System.Drawing.Point(688, 361)
        Me.btn_EditReq.Name = "btn_EditReq"
        Me.btn_EditReq.Size = New System.Drawing.Size(75, 37)
        Me.btn_EditReq.TabIndex = 0
        Me.btn_EditReq.Text = "Edit"
        Me.btn_EditReq.UseVisualStyleBackColor = False
        '
        'btn_SearchReq
        '
        Me.btn_SearchReq.Location = New System.Drawing.Point(688, 37)
        Me.btn_SearchReq.Name = "btn_SearchReq"
        Me.btn_SearchReq.Size = New System.Drawing.Size(75, 29)
        Me.btn_SearchReq.TabIndex = 1
        Me.btn_SearchReq.Text = "Search"
        Me.btn_SearchReq.UseVisualStyleBackColor = True
        '
        'txtb_search
        '
        Me.txtb_search.Location = New System.Drawing.Point(389, 40)
        Me.txtb_search.Name = "txtb_search"
        Me.txtb_search.Size = New System.Drawing.Size(279, 22)
        Me.txtb_search.TabIndex = 2
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_add.Location = New System.Drawing.Point(593, 364)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 34)
        Me.btn_add.TabIndex = 4
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeight = 29
        Me.DataGridView1.Location = New System.Drawing.Point(43, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(719, 259)
        Me.DataGridView1.TabIndex = 5
        '
        'FormRequisition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txtb_search)
        Me.Controls.Add(Me.btn_SearchReq)
        Me.Controls.Add(Me.btn_EditReq)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormRequisition"
        Me.Text = "FormRequisition"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_EditReq As Button
    Friend WithEvents btn_SearchReq As Button
    Friend WithEvents txtb_search As TextBox
    Friend WithEvents btn_add As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
