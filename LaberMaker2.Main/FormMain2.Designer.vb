<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain2
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.btnCustomer3 = New System.Windows.Forms.Button()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.btnCustomer4 = New System.Windows.Forms.Button()
        Me.btnPrintLabels = New System.Windows.Forms.Button()
        Me.btnCustomer5 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnCustomer2 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCustomer1 = New System.Windows.Forms.Button()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UtilityToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(801, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'UtilityToolStripMenuItem
        '
        Me.UtilityToolStripMenuItem.Name = "UtilityToolStripMenuItem"
        Me.UtilityToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.UtilityToolStripMenuItem.Text = "&Utility"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblTitle)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPrev)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnMore)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCustomer1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnExit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCustomer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCustomer5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPrintLabels)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCustomer4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnOptions)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCustomer3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDeselectAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNext)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSelectAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckedListBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(801, 418)
        Me.SplitContainer1.SplitterDistance = 132
        Me.SplitContainer1.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(130, 416)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Label Type"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(247, 54)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(148, 319)
        Me.CheckedListBox1.TabIndex = 13
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.Location = New System.Drawing.Point(401, 50)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(206, 36)
        Me.btnSelectAll.TabIndex = 14
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(54, 332)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(185, 36)
        Me.btnNext.TabIndex = 9
        Me.btnNext.Text = "Next Page"
        Me.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeselectAll.Location = New System.Drawing.Point(401, 92)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(206, 36)
        Me.btnDeselectAll.TabIndex = 15
        Me.btnDeselectAll.Text = "Deselect All"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'btnCustomer3
        '
        Me.btnCustomer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer3.Location = New System.Drawing.Point(56, 188)
        Me.btnCustomer3.Name = "btnCustomer3"
        Me.btnCustomer3.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer3.TabIndex = 6
        Me.btnCustomer3.Text = "Quidsi Carton"
        Me.btnCustomer3.UseVisualStyleBackColor = True
        '
        'btnOptions
        '
        Me.btnOptions.Enabled = False
        Me.btnOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOptions.Location = New System.Drawing.Point(401, 155)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(206, 36)
        Me.btnOptions.TabIndex = 16
        Me.btnOptions.Text = "Options"
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'btnCustomer4
        '
        Me.btnCustomer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer4.Location = New System.Drawing.Point(54, 230)
        Me.btnCustomer4.Name = "btnCustomer4"
        Me.btnCustomer4.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer4.TabIndex = 5
        Me.btnCustomer4.Text = "dd's Discounts"
        Me.btnCustomer4.UseVisualStyleBackColor = True
        '
        'btnPrintLabels
        '
        Me.btnPrintLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintLabels.Location = New System.Drawing.Point(401, 204)
        Me.btnPrintLabels.Name = "btnPrintLabels"
        Me.btnPrintLabels.Size = New System.Drawing.Size(206, 36)
        Me.btnPrintLabels.TabIndex = 17
        Me.btnPrintLabels.Text = "Print Labels"
        Me.btnPrintLabels.UseVisualStyleBackColor = True
        '
        'btnCustomer5
        '
        Me.btnCustomer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer5.Location = New System.Drawing.Point(54, 272)
        Me.btnCustomer5.Name = "btnCustomer5"
        Me.btnCustomer5.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer5.TabIndex = 4
        Me.btnCustomer5.Text = "Miles Kimball"
        Me.btnCustomer5.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(401, 332)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(96, 36)
        Me.btnRefresh.TabIndex = 18
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnCustomer2
        '
        Me.btnCustomer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer2.Location = New System.Drawing.Point(56, 146)
        Me.btnCustomer2.Name = "btnCustomer2"
        Me.btnCustomer2.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer2.TabIndex = 3
        Me.btnCustomer2.Text = "Rhode Island Textile"
        Me.btnCustomer2.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(511, 332)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 36)
        Me.btnExit.TabIndex = 19
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnCustomer1
        '
        Me.btnCustomer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer1.Location = New System.Drawing.Point(56, 104)
        Me.btnCustomer1.Name = "btnCustomer1"
        Me.btnCustomer1.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer1.TabIndex = 2
        Me.btnCustomer1.Text = "Walmart"
        Me.btnCustomer1.UseVisualStyleBackColor = True
        '
        'btnMore
        '
        Me.btnMore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMore.Location = New System.Drawing.Point(401, 256)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(206, 36)
        Me.btnMore.TabIndex = 20
        Me.btnMore.Text = "More..."
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Location = New System.Drawing.Point(54, 50)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(185, 36)
        Me.btnPrev.TabIndex = 1
        Me.btnPrev.Text = "Previous Page"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(186, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(300, 20)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Customers with Pending ????? Jobs"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormMain2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 442)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LabelMaker Scheduler"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UtilityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents M2MReports2DataSet11 As M2MReports2DataSet1
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnMore As Button
    Friend WithEvents btnCustomer1 As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCustomer2 As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnCustomer5 As Button
    Friend WithEvents btnPrintLabels As Button
    Friend WithEvents btnCustomer4 As Button
    Friend WithEvents btnOptions As Button
    Friend WithEvents btnCustomer3 As Button
    Friend WithEvents btnDeselectAll As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
End Class
