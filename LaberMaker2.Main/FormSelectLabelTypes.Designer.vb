<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSelectLabelTypes
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpLabeType = New System.Windows.Forms.GroupBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lstLabelType = New System.Windows.Forms.CheckedListBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpLabeType.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpLabeType)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnOk)
        Me.SplitContainer1.Size = New System.Drawing.Size(154, 433)
        Me.SplitContainer1.SplitterDistance = 365
        Me.SplitContainer1.TabIndex = 0
        '
        'grpLabeType
        '
        Me.grpLabeType.Controls.Add(Me.lstLabelType)
        Me.grpLabeType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpLabeType.Location = New System.Drawing.Point(0, 0)
        Me.grpLabeType.Name = "grpLabeType"
        Me.grpLabeType.Size = New System.Drawing.Size(154, 365)
        Me.grpLabeType.TabIndex = 1
        Me.grpLabeType.TabStop = False
        Me.grpLabeType.Text = "Label Types"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(42, 19)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lstLabelType
        '
        Me.lstLabelType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLabelType.FormattingEnabled = True
        Me.lstLabelType.Location = New System.Drawing.Point(3, 16)
        Me.lstLabelType.Name = "lstLabelType"
        Me.lstLabelType.Size = New System.Drawing.Size(148, 346)
        Me.lstLabelType.TabIndex = 1
        '
        'FormSelectLabelTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(154, 433)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormSelectLabelTypes"
        Me.Text = "FormSelectLabelTypes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpLabeType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grpLabeType As GroupBox
    Friend WithEvents btnOk As Button
    Friend WithEvents lstLabelType As CheckedListBox
End Class
