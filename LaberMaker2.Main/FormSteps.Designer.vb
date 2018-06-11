<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSteps
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
        Me.grdSteps = New System.Windows.Forms.DataGridView()
        CType(Me.grdSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSteps
        '
        Me.grdSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSteps.Location = New System.Drawing.Point(-2, 13)
        Me.grdSteps.Name = "grdSteps"
        Me.grdSteps.Size = New System.Drawing.Size(486, 154)
        Me.grdSteps.TabIndex = 0
        '
        'FormSteps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 263)
        Me.Controls.Add(Me.grdSteps)
        Me.Name = "FormSteps"
        Me.Text = "FormSteps"
        CType(Me.grdSteps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grdSteps As DataGridView
End Class
