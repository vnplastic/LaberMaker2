<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMainByCust
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobStepsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerProfilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerJobInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReprintLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.btnRefreshData = New System.Windows.Forms.Button()
        Me.btnRefreshSF = New System.Windows.Forms.Button()
        Me.btnReprint = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnPrintLabels = New System.Windows.Forms.Button()
        Me.tabsLabelTypes = New System.Windows.Forms.TabControl()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UtilityToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(633, 25)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(39, 21)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'UtilityToolStripMenuItem
        '
        Me.UtilityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JobStepsToolStripMenuItem, Me.CustomerProfilesToolStripMenuItem, Me.CustomerJobInfoToolStripMenuItem, Me.ReprintLabelsToolStripMenuItem})
        Me.UtilityToolStripMenuItem.Name = "UtilityToolStripMenuItem"
        Me.UtilityToolStripMenuItem.Size = New System.Drawing.Size(52, 21)
        Me.UtilityToolStripMenuItem.Text = "&Utility"
        '
        'JobStepsToolStripMenuItem
        '
        Me.JobStepsToolStripMenuItem.Name = "JobStepsToolStripMenuItem"
        Me.JobStepsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.JobStepsToolStripMenuItem.Text = "Job Steps"
        '
        'CustomerProfilesToolStripMenuItem
        '
        Me.CustomerProfilesToolStripMenuItem.Name = "CustomerProfilesToolStripMenuItem"
        Me.CustomerProfilesToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CustomerProfilesToolStripMenuItem.Text = "Customer Profiles"
        '
        'CustomerJobInfoToolStripMenuItem
        '
        Me.CustomerJobInfoToolStripMenuItem.Name = "CustomerJobInfoToolStripMenuItem"
        Me.CustomerJobInfoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CustomerJobInfoToolStripMenuItem.Text = "Customer Job Info"
        '
        'ReprintLabelsToolStripMenuItem
        '
        Me.ReprintLabelsToolStripMenuItem.Name = "ReprintLabelsToolStripMenuItem"
        Me.ReprintLabelsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ReprintLabelsToolStripMenuItem.Text = "Reprint Labels"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(55, 21)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(633, 470)
        Me.SplitContainer1.SplitterDistance = 103
        Me.SplitContainer1.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(101, 468)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tabsLabelTypes)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnRefreshData)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnRefreshSF)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnReprint)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnDeselectAll)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnSelectAll)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnPrintLabels)
        Me.SplitContainer2.Size = New System.Drawing.Size(524, 468)
        Me.SplitContainer2.SplitterDistance = 251
        Me.SplitContainer2.TabIndex = 0
        '
        'btnRefreshData
        '
        Me.btnRefreshData.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshData.Location = New System.Drawing.Point(49, 328)
        Me.btnRefreshData.Name = "btnRefreshData"
        Me.btnRefreshData.Size = New System.Drawing.Size(176, 34)
        Me.btnRefreshData.TabIndex = 6
        Me.btnRefreshData.Text = "Refresh Label Data"
        Me.btnRefreshData.UseVisualStyleBackColor = True
        '
        'btnRefreshSF
        '
        Me.btnRefreshSF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshSF.Location = New System.Drawing.Point(49, 270)
        Me.btnRefreshSF.Name = "btnRefreshSF"
        Me.btnRefreshSF.Size = New System.Drawing.Size(176, 34)
        Me.btnRefreshSF.TabIndex = 5
        Me.btnRefreshSF.Text = "Refresh Salesforce Date"
        Me.btnRefreshSF.UseVisualStyleBackColor = True
        '
        'btnReprint
        '
        Me.btnReprint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprint.Location = New System.Drawing.Point(49, 209)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(176, 34)
        Me.btnReprint.TabIndex = 4
        Me.btnReprint.Text = "Reprint Labels"
        Me.btnReprint.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeselectAll.Location = New System.Drawing.Point(49, 144)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(176, 34)
        Me.btnDeselectAll.TabIndex = 3
        Me.btnDeselectAll.Text = "Deselect All"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.Location = New System.Drawing.Point(49, 85)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(176, 34)
        Me.btnSelectAll.TabIndex = 2
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnPrintLabels
        '
        Me.btnPrintLabels.Enabled = False
        Me.btnPrintLabels.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintLabels.Location = New System.Drawing.Point(49, 25)
        Me.btnPrintLabels.Name = "btnPrintLabels"
        Me.btnPrintLabels.Size = New System.Drawing.Size(176, 34)
        Me.btnPrintLabels.TabIndex = 1
        Me.btnPrintLabels.Text = "Print Labels"
        Me.btnPrintLabels.UseVisualStyleBackColor = True
        '
        'tabsLabelTypes
        '
        Me.tabsLabelTypes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabsLabelTypes.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabsLabelTypes.Location = New System.Drawing.Point(0, 0)
        Me.tabsLabelTypes.Name = "tabsLabelTypes"
        Me.tabsLabelTypes.SelectedIndex = 0
        Me.tabsLabelTypes.Size = New System.Drawing.Size(251, 468)
        Me.tabsLabelTypes.TabIndex = 0
        '
        'FormMainByCust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 495)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "FormMainByCust"
        Me.Text = "Labels By Customer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UtilityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents JobStepsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerProfilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerJobInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer2 As SplitContainer

    Friend WithEvents btnPrintLabels As Button
    Friend WithEvents btnDeselectAll As Button
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents ReprintLabelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnReprint As Button
    Friend WithEvents btnRefreshData As Button
    Friend WithEvents btnRefreshSF As Button
    Friend WithEvents tabsLabelTypes As TabControl
End Class
