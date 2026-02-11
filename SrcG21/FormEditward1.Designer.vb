<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditward1
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
        Me.txtb_Editward = New System.Windows.Forms.TextBox()
        Me.txtb_editwardname = New System.Windows.Forms.TextBox()
        Me.txtb_editnum = New System.Windows.Forms.TextBox()
        Me.txtb_location = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.btn_EditDelete = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ttbedinward = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cordia New", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(319, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FormEditward"
        '
        'txtb_Editward
        '
        Me.txtb_Editward.Location = New System.Drawing.Point(343, 99)
        Me.txtb_Editward.Name = "txtb_Editward"
        Me.txtb_Editward.Size = New System.Drawing.Size(244, 22)
        Me.txtb_Editward.TabIndex = 1
        '
        'txtb_editwardname
        '
        Me.txtb_editwardname.Location = New System.Drawing.Point(343, 141)
        Me.txtb_editwardname.Name = "txtb_editwardname"
        Me.txtb_editwardname.Size = New System.Drawing.Size(244, 22)
        Me.txtb_editwardname.TabIndex = 2
        '
        'txtb_editnum
        '
        Me.txtb_editnum.Location = New System.Drawing.Point(343, 219)
        Me.txtb_editnum.Name = "txtb_editnum"
        Me.txtb_editnum.Size = New System.Drawing.Size(244, 22)
        Me.txtb_editnum.TabIndex = 5
        '
        'txtb_location
        '
        Me.txtb_location.Location = New System.Drawing.Point(343, 257)
        Me.txtb_location.Name = "txtb_location"
        Me.txtb_location.Size = New System.Drawing.Size(244, 22)
        Me.txtb_location.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(214, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ward ID :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(214, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ward Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(214, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ExtensionNumber :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(214, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Location :"
        '
        'btn_Save
        '
        Me.btn_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Save.Location = New System.Drawing.Point(168, 375)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 29)
        Me.btn_Save.TabIndex = 13
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(589, 375)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 29)
        Me.btn_cancle.TabIndex = 14
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'btn_EditDelete
        '
        Me.btn_EditDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_EditDelete.Location = New System.Drawing.Point(375, 375)
        Me.btn_EditDelete.Name = "btn_EditDelete"
        Me.btn_EditDelete.Size = New System.Drawing.Size(75, 29)
        Me.btn_EditDelete.TabIndex = 15
        Me.btn_EditDelete.Text = "Delete"
        Me.btn_EditDelete.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(214, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Total Bed"
        '
        'ttbedinward
        '
        Me.ttbedinward.Location = New System.Drawing.Point(343, 186)
        Me.ttbedinward.Name = "ttbedinward"
        Me.ttbedinward.Size = New System.Drawing.Size(244, 22)
        Me.ttbedinward.TabIndex = 17
        '
        'FormEditward1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ttbedinward)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_EditDelete)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtb_location)
        Me.Controls.Add(Me.txtb_editnum)
        Me.Controls.Add(Me.txtb_editwardname)
        Me.Controls.Add(Me.txtb_Editward)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormEditward1"
        Me.Text = "FormEditward1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtb_Editward As TextBox
    Friend WithEvents txtb_editwardname As TextBox
    Friend WithEvents txtb_editnum As TextBox
    Friend WithEvents txtb_location As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btn_Save As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents btn_EditDelete As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ttbedinward As TextBox
End Class
