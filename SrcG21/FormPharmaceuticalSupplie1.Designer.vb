<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPharmaceuticalSupplie1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtDosage = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtReorder = New System.Windows.Forms.TextBox()
        Me.SaveFrPhrSup = New System.Windows.Forms.Button()
        Me.CancleFrPhrSup = New System.Windows.Forms.Button()
        Me.DeletephamaED = New System.Windows.Forms.Button()
        Me.TextBox1E = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(147, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(544, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Pharmaceutical Supplie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(292, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pharmaceutical Supplie "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(179, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "DrugName :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(179, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Description :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(179, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Dosage :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(179, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Qty_in_stock :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(179, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Reorder_level :"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(306, 165)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(252, 22)
        Me.txtDescription.TabIndex = 10
        '
        'txtDosage
        '
        Me.txtDosage.Location = New System.Drawing.Point(306, 197)
        Me.txtDosage.Name = "txtDosage"
        Me.txtDosage.Size = New System.Drawing.Size(252, 22)
        Me.txtDosage.TabIndex = 11
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(306, 238)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(252, 22)
        Me.txtQty.TabIndex = 12
        '
        'txtReorder
        '
        Me.txtReorder.Location = New System.Drawing.Point(306, 275)
        Me.txtReorder.Name = "txtReorder"
        Me.txtReorder.Size = New System.Drawing.Size(252, 22)
        Me.txtReorder.TabIndex = 13
        '
        'SaveFrPhrSup
        '
        Me.SaveFrPhrSup.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SaveFrPhrSup.Location = New System.Drawing.Point(264, 386)
        Me.SaveFrPhrSup.Name = "SaveFrPhrSup"
        Me.SaveFrPhrSup.Size = New System.Drawing.Size(75, 29)
        Me.SaveFrPhrSup.TabIndex = 14
        Me.SaveFrPhrSup.Text = "Save"
        Me.SaveFrPhrSup.UseVisualStyleBackColor = False
        '
        'CancleFrPhrSup
        '
        Me.CancleFrPhrSup.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.CancleFrPhrSup.Location = New System.Drawing.Point(535, 386)
        Me.CancleFrPhrSup.Name = "CancleFrPhrSup"
        Me.CancleFrPhrSup.Size = New System.Drawing.Size(75, 29)
        Me.CancleFrPhrSup.TabIndex = 16
        Me.CancleFrPhrSup.Text = "Cancle"
        Me.CancleFrPhrSup.UseVisualStyleBackColor = False
        '
        'DeletephamaED
        '
        Me.DeletephamaED.BackColor = System.Drawing.Color.Crimson
        Me.DeletephamaED.Location = New System.Drawing.Point(393, 386)
        Me.DeletephamaED.Name = "DeletephamaED"
        Me.DeletephamaED.Size = New System.Drawing.Size(83, 26)
        Me.DeletephamaED.TabIndex = 19
        Me.DeletephamaED.Text = "Delete"
        Me.DeletephamaED.UseVisualStyleBackColor = False
        '
        'TextBox1E
        '
        Me.TextBox1E.Location = New System.Drawing.Point(306, 124)
        Me.TextBox1E.Name = "TextBox1E"
        Me.TextBox1E.Size = New System.Drawing.Size(256, 22)
        Me.TextBox1E.TabIndex = 20
        '
        'FormPharmaceuticalSupplie1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBox1E)
        Me.Controls.Add(Me.DeletephamaED)
        Me.Controls.Add(Me.CancleFrPhrSup)
        Me.Controls.Add(Me.SaveFrPhrSup)
        Me.Controls.Add(Me.txtReorder)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtDosage)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormPharmaceuticalSupplie1"
        Me.Text = "FormPharmaceuticalSupplie1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtDosage As TextBox
    Friend WithEvents txtQty As TextBox
    Friend WithEvents txtReorder As TextBox
    Friend WithEvents SaveFrPhrSup As Button
    Friend WithEvents CancleFrPhrSup As Button
    Friend WithEvents DeletephamaED As Button
    Friend WithEvents TextBox1E As TextBox
End Class
