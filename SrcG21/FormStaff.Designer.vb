<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStaff
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnStaffSt = New System.Windows.Forms.Button()
        Me.btnStaffAsm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnStaffSt, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(126, 115)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(208, 187)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnStaffAsm, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(416, 115)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(208, 187)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'btnStaffSt
        '
        Me.btnStaffSt.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnStaffSt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStaffSt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStaffSt.Location = New System.Drawing.Point(3, 3)
        Me.btnStaffSt.Name = "btnStaffSt"
        Me.btnStaffSt.Size = New System.Drawing.Size(202, 181)
        Me.btnStaffSt.TabIndex = 0
        Me.btnStaffSt.Text = "Staff"
        Me.btnStaffSt.UseVisualStyleBackColor = False
        '
        'btnStaffAsm
        '
        Me.btnStaffAsm.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnStaffAsm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStaffAsm.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStaffAsm.Location = New System.Drawing.Point(3, 3)
        Me.btnStaffAsm.Name = "btnStaffAsm"
        Me.btnStaffAsm.Size = New System.Drawing.Size(202, 181)
        Me.btnStaffAsm.TabIndex = 0
        Me.btnStaffAsm.Text = "Staff Assingment"
        Me.btnStaffAsm.UseVisualStyleBackColor = False
        '
        'FormStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormStaff"
        Me.Text = "FormStaff"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnStaffSt As Button
    Friend WithEvents btnStaffAsm As Button
End Class
