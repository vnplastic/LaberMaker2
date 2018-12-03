<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormJobSteps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormJobSteps))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdCustomerJobInfo = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboLabelOrientation = New System.Windows.Forms.ComboBox()
        Me.numLabelCount = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDeliveryType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSourceType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboLabelSize = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPrinterCompatibility = New System.Windows.Forms.ComboBox()
        Me.btnMoveToAvailable = New System.Windows.Forms.Button()
        Me.btnMoveToCurrent = New System.Windows.Forms.Button()
        Me.lstCurrentSteps = New System.Windows.Forms.ListBox()
        Me.lstAvailableSteps = New System.Windows.Forms.ListBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdCustomerJobInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLabelCount, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdCustomerJobInfo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboLabelOrientation)
        Me.SplitContainer1.Panel2.Controls.Add(Me.numLabelCount)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboDeliveryType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboSourceType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboLabelSize)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboPrinterCompatibility)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnMoveToAvailable)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnMoveToCurrent)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lstCurrentSteps)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lstAvailableSteps)
        Me.SplitContainer1.Size = New System.Drawing.Size(896, 506)
        Me.SplitContainer1.SplitterDistance = 177
        Me.SplitContainer1.TabIndex = 0
        '
        'grdCustomerJobInfo
        '
        Me.grdCustomerJobInfo.AllowUserToAddRows = False
        Me.grdCustomerJobInfo.AllowUserToDeleteRows = False
        Me.grdCustomerJobInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustomerJobInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCustomerJobInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCustomerJobInfo.Name = "grdCustomerJobInfo"
        Me.grdCustomerJobInfo.Size = New System.Drawing.Size(896, 177)
        Me.grdCustomerJobInfo.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(499, 290)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(619, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Label Orientation"
        '
        'cboLabelOrientation
        '
        Me.cboLabelOrientation.FormattingEnabled = True
        Me.cboLabelOrientation.Location = New System.Drawing.Point(719, 197)
        Me.cboLabelOrientation.Name = "cboLabelOrientation"
        Me.cboLabelOrientation.Size = New System.Drawing.Size(121, 21)
        Me.cboLabelOrientation.TabIndex = 15
        '
        'numLabelCount
        '
        Me.numLabelCount.Location = New System.Drawing.Point(720, 238)
        Me.numLabelCount.Name = "numLabelCount"
        Me.numLabelCount.Size = New System.Drawing.Size(120, 20)
        Me.numLabelCount.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(643, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Label Count"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(635, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Delivery Type"
        '
        'cboDeliveryType
        '
        Me.cboDeliveryType.FormattingEnabled = True
        Me.cboDeliveryType.Location = New System.Drawing.Point(720, 152)
        Me.cboDeliveryType.Name = "cboDeliveryType"
        Me.cboDeliveryType.Size = New System.Drawing.Size(121, 21)
        Me.cboDeliveryType.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(639, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Source Type"
        '
        'cboSourceType
        '
        Me.cboSourceType.FormattingEnabled = True
        Me.cboSourceType.Location = New System.Drawing.Point(720, 110)
        Me.cboSourceType.Name = "cboSourceType"
        Me.cboSourceType.Size = New System.Drawing.Size(121, 21)
        Me.cboSourceType.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(651, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label Size"
        '
        'cboLabelSize
        '
        Me.cboLabelSize.FormattingEnabled = True
        Me.cboLabelSize.Location = New System.Drawing.Point(720, 65)
        Me.cboLabelSize.Name = "cboLabelSize"
        Me.cboLabelSize.Size = New System.Drawing.Size(121, 21)
        Me.cboLabelSize.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(609, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Printer Compatibility"
        '
        'cboPrinterCompatibility
        '
        Me.cboPrinterCompatibility.FormattingEnabled = True
        Me.cboPrinterCompatibility.Location = New System.Drawing.Point(720, 25)
        Me.cboPrinterCompatibility.Name = "cboPrinterCompatibility"
        Me.cboPrinterCompatibility.Size = New System.Drawing.Size(121, 21)
        Me.cboPrinterCompatibility.TabIndex = 4
        '
        'btnMoveToAvailable
        '
        Me.btnMoveToAvailable.Location = New System.Drawing.Point(201, 131)
        Me.btnMoveToAvailable.Name = "btnMoveToAvailable"
        Me.btnMoveToAvailable.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveToAvailable.TabIndex = 3
        Me.btnMoveToAvailable.Text = "<<"
        Me.btnMoveToAvailable.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnMoveToAvailable.UseVisualStyleBackColor = True
        '
        'btnMoveToCurrent
        '
        Me.btnMoveToCurrent.Location = New System.Drawing.Point(201, 62)
        Me.btnMoveToCurrent.Name = "btnMoveToCurrent"
        Me.btnMoveToCurrent.Size = New System.Drawing.Size(75, 23)
        Me.btnMoveToCurrent.TabIndex = 2
        Me.btnMoveToCurrent.Text = ">>"
        Me.btnMoveToCurrent.UseVisualStyleBackColor = True
        '
        'lstCurrentSteps
        '
        Me.lstCurrentSteps.FormattingEnabled = True
        Me.lstCurrentSteps.Location = New System.Drawing.Point(282, 20)
        Me.lstCurrentSteps.Name = "lstCurrentSteps"
        Me.lstCurrentSteps.Size = New System.Drawing.Size(120, 238)
        Me.lstCurrentSteps.TabIndex = 1
        '
        'lstAvailableSteps
        '
        Me.lstAvailableSteps.FormattingEnabled = True
        Me.lstAvailableSteps.Location = New System.Drawing.Point(65, 25)
        Me.lstAvailableSteps.Name = "lstAvailableSteps"
        Me.lstAvailableSteps.Size = New System.Drawing.Size(120, 238)
        Me.lstAvailableSteps.TabIndex = 0
        '
        'FormJobSteps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 506)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormJobSteps"
        Me.Text = "FormJobSteps"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdCustomerJobInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLabelCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grdCustomerJobInfo As DataGridView
    Friend WithEvents lstCurrentSteps As ListBox
    Friend WithEvents lstAvailableSteps As ListBox
    Friend WithEvents btnMoveToAvailable As Button
    Friend WithEvents btnMoveToCurrent As Button
    Friend WithEvents numLabelCount As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboDeliveryType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboSourceType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboLabelSize As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPrinterCompatibility As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboLabelOrientation As ComboBox
    Friend WithEvents btnSave As Button
End Class
