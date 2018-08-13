<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSalesOrderNumber
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
        Me.txtFsono = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.numLabels = New System.Windows.Forms.NumericUpDown()
        Me.chkLabelQty = New System.Windows.Forms.CheckBox()
        CType(Me.numLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFsono
        '
        Me.txtFsono.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFsono.Location = New System.Drawing.Point(209, 16)
        Me.txtFsono.Mask = "000000"
        Me.txtFsono.Name = "txtFsono"
        Me.txtFsono.Size = New System.Drawing.Size(65, 26)
        Me.txtFsono.TabIndex = 4
        Me.txtFsono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sales Order Number: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(28, 73)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 50)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(171, 73)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(103, 50)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'numLabels
        '
        Me.numLabels.Enabled = False
        Me.numLabels.Location = New System.Drawing.Point(183, 50)
        Me.numLabels.Margin = New System.Windows.Forms.Padding(2)
        Me.numLabels.Name = "numLabels"
        Me.numLabels.Size = New System.Drawing.Size(38, 20)
        Me.numLabels.TabIndex = 28
        '
        'chkLabelQty
        '
        Me.chkLabelQty.AutoSize = True
        Me.chkLabelQty.Location = New System.Drawing.Point(63, 50)
        Me.chkLabelQty.Margin = New System.Windows.Forms.Padding(2)
        Me.chkLabelQty.Name = "chkLabelQty"
        Me.chkLabelQty.Size = New System.Drawing.Size(111, 17)
        Me.chkLabelQty.TabIndex = 27
        Me.chkLabelQty.Text = "Change Label Qty"
        Me.chkLabelQty.UseVisualStyleBackColor = True
        '
        'FormSalesOrderNumber
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(316, 145)
        Me.Controls.Add(Me.numLabels)
        Me.Controls.Add(Me.chkLabelQty)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtFsono)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormSalesOrderNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enter Sales Order Number"
        CType(Me.numLabels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFsono As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents numLabels As NumericUpDown
    Friend WithEvents chkLabelQty As CheckBox
End Class
