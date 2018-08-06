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
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lstSalesOrders = New System.Windows.Forms.CheckedListBox()
        Me.grpLabeType = New System.Windows.Forms.GroupBox()
        Me.btnPrintLabels = New System.Windows.Forms.Button()
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UtilityToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(861, 24)
        Me.MenuStrip1.TabIndex = 23
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
        Me.UtilityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JobStepsToolStripMenuItem, Me.CustomerProfilesToolStripMenuItem, Me.CustomerJobInfoToolStripMenuItem})
        Me.UtilityToolStripMenuItem.Name = "UtilityToolStripMenuItem"
        Me.UtilityToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.UtilityToolStripMenuItem.Text = "&Utility"
        '
        'JobStepsToolStripMenuItem
        '
        Me.JobStepsToolStripMenuItem.Name = "JobStepsToolStripMenuItem"
        Me.JobStepsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.JobStepsToolStripMenuItem.Text = "Job Steps"
        '
        'CustomerProfilesToolStripMenuItem
        '
        Me.CustomerProfilesToolStripMenuItem.Name = "CustomerProfilesToolStripMenuItem"
        Me.CustomerProfilesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CustomerProfilesToolStripMenuItem.Text = "Customer Profiles"
        '
        'CustomerJobInfoToolStripMenuItem
        '
        Me.CustomerJobInfoToolStripMenuItem.Name = "CustomerJobInfoToolStripMenuItem"
        Me.CustomerJobInfoToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CustomerJobInfoToolStripMenuItem.Text = "Customer Job Info"
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(861, 471)
        Me.SplitContainer1.SplitterDistance = 141
        Me.SplitContainer1.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 469)
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.lstSalesOrders)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnPrintLabels)
        Me.SplitContainer2.Panel2.Controls.Add(Me.grpLabeType)
        Me.SplitContainer2.Size = New System.Drawing.Size(714, 469)
        Me.SplitContainer2.SplitterDistance = 126
        Me.SplitContainer2.TabIndex = 0
        '
        'lstSalesOrders
        '
        Me.lstSalesOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSalesOrders.FormattingEnabled = True
        Me.lstSalesOrders.Location = New System.Drawing.Point(0, 0)
        Me.lstSalesOrders.Name = "lstSalesOrders"
        Me.lstSalesOrders.Size = New System.Drawing.Size(126, 469)
        Me.lstSalesOrders.TabIndex = 0
        '
        'grpLabeType
        '
        Me.grpLabeType.Location = New System.Drawing.Point(3, 4)
        Me.grpLabeType.Name = "grpLabeType"
        Me.grpLabeType.Size = New System.Drawing.Size(112, 465)
        Me.grpLabeType.TabIndex = 0
        Me.grpLabeType.TabStop = False
        Me.grpLabeType.Text = "Label Types"
        '
        'btnPrintLabels
        '
        Me.btnPrintLabels.Location = New System.Drawing.Point(157, 20)
        Me.btnPrintLabels.Name = "btnPrintLabels"
        Me.btnPrintLabels.Size = New System.Drawing.Size(176, 34)
        Me.btnPrintLabels.TabIndex = 1
        Me.btnPrintLabels.Text = "Print Labels"
        Me.btnPrintLabels.UseVisualStyleBackColor = True
        '
        'FormMainByCust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 495)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "FormMainByCust"
        Me.Text = "FormMain"
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
    Friend WithEvents lstSalesOrders As CheckedListBox
    Friend WithEvents grpLabeType As GroupBox
    Friend WithEvents btnPrintLabels As Button
End Class
