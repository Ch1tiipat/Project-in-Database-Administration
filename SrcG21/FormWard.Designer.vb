<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWard
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
        Me.pnl_ward = New System.Windows.Forms.Panel()
        Me.btn_ward = New System.Windows.Forms.Button()
        Me.btn_Addward = New System.Windows.Forms.Button()
        Me.txtb_ward = New System.Windows.Forms.TextBox()
        Me.btn_Editward = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnl_ward
        '
        Me.pnl_ward.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pnl_ward.Location = New System.Drawing.Point(12, 74)
        Me.pnl_ward.Name = "pnl_ward"
        Me.pnl_ward.Size = New System.Drawing.Size(720, 318)
        Me.pnl_ward.TabIndex = 0
        '
        'btn_ward
        '
        Me.btn_ward.Location = New System.Drawing.Point(657, 45)
        Me.btn_ward.Name = "btn_ward"
        Me.btn_ward.Size = New System.Drawing.Size(75, 23)
        Me.btn_ward.TabIndex = 1
        Me.btn_ward.Text = "Search"
        Me.btn_ward.UseVisualStyleBackColor = True
        '
        'btn_Addward
        '
        Me.btn_Addward.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Addward.Location = New System.Drawing.Point(566, 398)
        Me.btn_Addward.Name = "btn_Addward"
        Me.btn_Addward.Size = New System.Drawing.Size(71, 29)
        Me.btn_Addward.TabIndex = 2
        Me.btn_Addward.Text = "Add"
        Me.btn_Addward.UseVisualStyleBackColor = False
        '
        'txtb_ward
        '
        Me.txtb_ward.Location = New System.Drawing.Point(426, 45)
        Me.txtb_ward.Name = "txtb_ward"
        Me.txtb_ward.Size = New System.Drawing.Size(230, 22)
        Me.txtb_ward.TabIndex = 3
        '
        'btn_Editward
        '
        Me.btn_Editward.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_Editward.Location = New System.Drawing.Point(657, 398)
        Me.btn_Editward.Name = "btn_Editward"
        Me.btn_Editward.Size = New System.Drawing.Size(75, 29)
        Me.btn_Editward.TabIndex = 4
        Me.btn_Editward.Text = "Edit"
        Me.btn_Editward.UseVisualStyleBackColor = False
        '
        'FormWard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 474)
        Me.Controls.Add(Me.btn_Editward)
        Me.Controls.Add(Me.txtb_ward)
        Me.Controls.Add(Me.btn_Addward)
        Me.Controls.Add(Me.btn_ward)
        Me.Controls.Add(Me.pnl_ward)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormWard"
        Me.Text = "FormWard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnl_ward As Panel
    Friend WithEvents btn_ward As Button
    Friend WithEvents btn_Addward As Button
    Friend WithEvents txtb_ward As TextBox
    Friend WithEvents btn_Editward As Button
End Class
