<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStaff1
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnl_staffsearch = New System.Windows.Forms.Panel()
        Me.bnt_staffsearch = New System.Windows.Forms.Button()
        Me.bnt_staffEdit = New System.Windows.Forms.Button()
        Me.txtb_searchstaff = New System.Windows.Forms.TextBox()
        Me.bnt_staffadd = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 69)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(70, 69)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Pro73.My.Resources.Resources.logo73
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 63)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'pnl_staffsearch
        '
        Me.pnl_staffsearch.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.pnl_staffsearch.Location = New System.Drawing.Point(81, 130)
        Me.pnl_staffsearch.Name = "pnl_staffsearch"
        Me.pnl_staffsearch.Size = New System.Drawing.Size(641, 275)
        Me.pnl_staffsearch.TabIndex = 1
        '
        'bnt_staffsearch
        '
        Me.bnt_staffsearch.Location = New System.Drawing.Point(646, 101)
        Me.bnt_staffsearch.Name = "bnt_staffsearch"
        Me.bnt_staffsearch.Size = New System.Drawing.Size(75, 23)
        Me.bnt_staffsearch.TabIndex = 2
        Me.bnt_staffsearch.Text = "Search"
        Me.bnt_staffsearch.UseVisualStyleBackColor = True
        '
        'bnt_staffEdit
        '
        Me.bnt_staffEdit.BackColor = System.Drawing.Color.DarkGray
        Me.bnt_staffEdit.Location = New System.Drawing.Point(645, 412)
        Me.bnt_staffEdit.Name = "bnt_staffEdit"
        Me.bnt_staffEdit.Size = New System.Drawing.Size(75, 26)
        Me.bnt_staffEdit.TabIndex = 3
        Me.bnt_staffEdit.Text = "Edit"
        Me.bnt_staffEdit.UseVisualStyleBackColor = False
        '
        'txtb_searchstaff
        '
        Me.txtb_searchstaff.Location = New System.Drawing.Point(463, 101)
        Me.txtb_searchstaff.Name = "txtb_searchstaff"
        Me.txtb_searchstaff.Size = New System.Drawing.Size(177, 22)
        Me.txtb_searchstaff.TabIndex = 4
        '
        'bnt_staffadd
        '
        Me.bnt_staffadd.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bnt_staffadd.Location = New System.Drawing.Point(555, 411)
        Me.bnt_staffadd.Name = "bnt_staffadd"
        Me.bnt_staffadd.Size = New System.Drawing.Size(75, 27)
        Me.bnt_staffadd.TabIndex = 5
        Me.bnt_staffadd.Text = "Add"
        Me.bnt_staffadd.UseVisualStyleBackColor = False
        '
        'FormStaff1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 450)
        Me.Controls.Add(Me.bnt_staffadd)
        Me.Controls.Add(Me.txtb_searchstaff)
        Me.Controls.Add(Me.bnt_staffEdit)
        Me.Controls.Add(Me.bnt_staffsearch)
        Me.Controls.Add(Me.pnl_staffsearch)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormStaff1"
        Me.Text = "FormStaff1"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnl_staffsearch As Panel
    Friend WithEvents bnt_staffsearch As Button
    Friend WithEvents bnt_staffEdit As Button
    Friend WithEvents txtb_searchstaff As TextBox
    Friend WithEvents bnt_staffadd As Button
End Class
