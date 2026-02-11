<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddward
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtb_editwardid = New System.Windows.Forms.TextBox()
        Me.txtb_name = New System.Windows.Forms.TextBox()
        Me.txtb_exnum = New System.Windows.Forms.TextBox()
        Me.txtb_location = New System.Windows.Forms.TextBox()
        Me.btn_Addward = New System.Windows.Forms.Button()
        Me.btn_cancle = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.totalbed = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(186, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ward ID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cordia New", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(325, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 46)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "FormAddward"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(186, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Ward Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(186, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "ExtensionNumber :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(186, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Location :"
        '
        'txtb_editwardid
        '
        Me.txtb_editwardid.Location = New System.Drawing.Point(322, 117)
        Me.txtb_editwardid.Name = "txtb_editwardid"
        Me.txtb_editwardid.Size = New System.Drawing.Size(226, 22)
        Me.txtb_editwardid.TabIndex = 15
        '
        'txtb_name
        '
        Me.txtb_name.Location = New System.Drawing.Point(322, 156)
        Me.txtb_name.Name = "txtb_name"
        Me.txtb_name.Size = New System.Drawing.Size(226, 22)
        Me.txtb_name.TabIndex = 16
        '
        'txtb_exnum
        '
        Me.txtb_exnum.Location = New System.Drawing.Point(322, 233)
        Me.txtb_exnum.Name = "txtb_exnum"
        Me.txtb_exnum.Size = New System.Drawing.Size(226, 22)
        Me.txtb_exnum.TabIndex = 19
        '
        'txtb_location
        '
        Me.txtb_location.Location = New System.Drawing.Point(322, 273)
        Me.txtb_location.Name = "txtb_location"
        Me.txtb_location.Size = New System.Drawing.Size(226, 22)
        Me.txtb_location.TabIndex = 20
        '
        'btn_Addward
        '
        Me.btn_Addward.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Addward.Location = New System.Drawing.Point(588, 382)
        Me.btn_Addward.Name = "btn_Addward"
        Me.btn_Addward.Size = New System.Drawing.Size(75, 33)
        Me.btn_Addward.TabIndex = 21
        Me.btn_Addward.Text = "Add"
        Me.btn_Addward.UseVisualStyleBackColor = False
        '
        'btn_cancle
        '
        Me.btn_cancle.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_cancle.Location = New System.Drawing.Point(681, 382)
        Me.btn_cancle.Name = "btn_cancle"
        Me.btn_cancle.Size = New System.Drawing.Size(75, 33)
        Me.btn_cancle.TabIndex = 22
        Me.btn_cancle.Text = "Cancle"
        Me.btn_cancle.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(186, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Total Bed"
        '
        'totalbed
        '
        Me.totalbed.Location = New System.Drawing.Point(322, 196)
        Me.totalbed.Name = "totalbed"
        Me.totalbed.Size = New System.Drawing.Size(220, 22)
        Me.totalbed.TabIndex = 24
        '
        'FormAddward
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.totalbed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_cancle)
        Me.Controls.Add(Me.btn_Addward)
        Me.Controls.Add(Me.txtb_location)
        Me.Controls.Add(Me.txtb_exnum)
        Me.Controls.Add(Me.txtb_name)
        Me.Controls.Add(Me.txtb_editwardid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FormAddward"
        Me.Text = "FormAddward"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtb_editwardid As TextBox
    Friend WithEvents txtb_name As TextBox
    Friend WithEvents txtb_exnum As TextBox
    Friend WithEvents txtb_location As TextBox
    Friend WithEvents btn_Addward As Button
    Friend WithEvents btn_cancle As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents totalbed As TextBox
End Class
