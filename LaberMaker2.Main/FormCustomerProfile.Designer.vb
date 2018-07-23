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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdCustomerProfiles = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(583, 519)
        Me.SplitContainer1.SplitterDistance = 242
        Me.SplitContainer1.TabIndex = 0
        '
        'grdCustomerProfiles
        '
        Me.grdCustomerProfiles.AllowUserToAddRows = False
        Me.grdCustomerProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCustomerProfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCustomerProfiles.Location = New System.Drawing.Point(0, 0)
        Me.grdCustomerProfiles.Name = "grdCustomerProfiles"
        Me.grdCustomerProfiles.Size = New System.Drawing.Size(583, 242)
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
        Me.SplitContainer2.Size = New System.Drawing.Size(583, 273)
        Me.SplitContainer2.SplitterDistance = 221
        Me.SplitContainer2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Printer"
        '
        'cboPrinter
        '
        Me.cboPrinter.FormattingEnabled = True
        Me.cboPrinter.Location = New System.Drawing.Point(136, 176)
        Me.cboPrinter.Name = "cboPrinter"
        Me.cboPrinter.Size = New System.Drawing.Size(278, 21)
        Me.cboPrinter.TabIndex = 9
        '
        'txtCustName
        '
        Me.txtCustName.Location = New System.Drawing.Point(136, 69)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(278, 20)
        Me.txtCustName.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Customer Name"
        '
        'txtCustomerShortName
        '
        Me.txtCustomerShortName.Location = New System.Drawing.Point(136, 138)
        Me.txtCustomerShortName.Name = "txtCustomerShortName"
        Me.txtCustomerShortName.Size = New System.Drawing.Size(119, 20)
        Me.txtCustomerShortName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Customer Short Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Job Type"
        '
        'cboJobType
        '
        Me.cboJobType.FormattingEnabled = True
        Me.cboJobType.Location = New System.Drawing.Point(136, 102)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(121, 21)
        Me.cboJobType.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'cboCustomer
        '
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(136, 25)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(278, 21)
        Me.cboCustomer.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(257, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 46)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save Profile"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(75, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 46)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add Profile"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'FormCustomerProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 519)
        Me.Controls.Add(Me.SplitContainer1)
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
End Class
