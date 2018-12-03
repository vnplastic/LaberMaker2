<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomerProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCustomerProfile))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdCustomerProfiles = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.txtNextLabel = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCustNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLabelName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkPerLineLabel = New System.Windows.Forms.CheckBox()
        Me.chkSerialized = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPrinter = New System.Windows.Forms.ComboBox()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustomerShortName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdCustomerProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdCustomerProfiles)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(804, 531)
        Me.SplitContainer1.SplitterDistance = 245
        Me.SplitContainer1.TabIndex = 0
        '
        'grdCustomerProfiles
        '
        Me.grdCustomerProfiles.AllowUserToAddRows = False
        Me.grdCustomerProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustomerProfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCustomerProfiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdCustomerProfiles.Location = New System.Drawing.Point(0, 0)
        Me.grdCustomerProfiles.Name = "grdCustomerProfiles"
        Me.grdCustomerProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdCustomerProfiles.ShowEditingIcon = False
        Me.grdCustomerProfiles.Size = New System.Drawing.Size(804, 245)
        Me.grdCustomerProfiles.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtNextLabel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtCustNo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtLabelName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkPerLineLabel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkSerialized)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboPrinter)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtCustName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtCustomerShortName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboJobType)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboCustomer)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnAdd)
        Me.SplitContainer2.Size = New System.Drawing.Size(804, 282)
        Me.SplitContainer2.SplitterDistance = 226
        Me.SplitContainer2.TabIndex = 0
        '
        'txtNextLabel
        '
        Me.txtNextLabel.Location = New System.Drawing.Point(635, 168)
        Me.txtNextLabel.Name = "txtNextLabel"
        Me.txtNextLabel.Size = New System.Drawing.Size(119, 20)
        Me.txtNextLabel.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(509, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Next Unique Label"
        '
        'txtCustNo
        '
        Me.txtCustNo.Location = New System.Drawing.Point(635, 34)
        Me.txtCustNo.Name = "txtCustNo"
        Me.txtCustNo.Size = New System.Drawing.Size(119, 20)
        Me.txtCustNo.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(509, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Customer No"
        '
        'txtLabelName
        '
        Me.txtLabelName.Location = New System.Drawing.Point(635, 133)
        Me.txtLabelName.Name = "txtLabelName"
        Me.txtLabelName.Size = New System.Drawing.Size(119, 20)
        Me.txtLabelName.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(509, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Name on Label"
        '
        'chkPerLineLabel
        '
        Me.chkPerLineLabel.AutoSize = True
        Me.chkPerLineLabel.Location = New System.Drawing.Point(512, 104)
        Me.chkPerLineLabel.Name = "chkPerLineLabel"
        Me.chkPerLineLabel.Size = New System.Drawing.Size(122, 17)
        Me.chkPerLineLabel.TabIndex = 12
        Me.chkPerLineLabel.Text = "Per Line Item Labels"
        Me.chkPerLineLabel.UseVisualStyleBackColor = True
        '
        'chkSerialized
        '
        Me.chkSerialized.AutoSize = True
        Me.chkSerialized.Location = New System.Drawing.Point(512, 70)
        Me.chkSerialized.Name = "chkSerialized"
        Me.chkSerialized.Size = New System.Drawing.Size(71, 17)
        Me.chkSerialized.TabIndex = 11
        Me.chkSerialized.Text = "Serialized"
        Me.chkSerialized.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Printer"
        '
        'cboPrinter
        '
        Me.cboPrinter.FormattingEnabled = True
        Me.cboPrinter.Location = New System.Drawing.Point(136, 167)
        Me.cboPrinter.Name = "cboPrinter"
        Me.cboPrinter.Size = New System.Drawing.Size(278, 21)
        Me.cboPrinter.TabIndex = 9
        '
        'txtCustName
        '
        Me.txtCustName.Enabled = False
        Me.txtCustName.Location = New System.Drawing.Point(136, 67)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(278, 20)
        Me.txtCustName.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Customer Name"
        '
        'txtCustomerShortName
        '
        Me.txtCustomerShortName.Location = New System.Drawing.Point(136, 134)
        Me.txtCustomerShortName.Name = "txtCustomerShortName"
        Me.txtCustomerShortName.Size = New System.Drawing.Size(119, 20)
        Me.txtCustomerShortName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Customer Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Job Type"
        '
        'cboJobType
        '
        Me.cboJobType.FormattingEnabled = True
        Me.cboJobType.Location = New System.Drawing.Point(136, 100)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(121, 21)
        Me.cboJobType.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(136, 33)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(278, 21)
        Me.cboCustomer.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(532, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 50)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save Profile"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(147, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 50)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add Profile"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'FormCustomerProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 531)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCustomerProfile"
        Me.Text = "Customer Profiles"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdCustomerProfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grdCustomerProfiles As DataGridView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCustomerShortName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboPrinter As ComboBox
    Friend WithEvents txtLabelName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkPerLineLabel As CheckBox
    Friend WithEvents chkSerialized As CheckBox
    Friend WithEvents txtNextLabel As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCustNo As TextBox
    Friend WithEvents Label7 As Label
End Class
