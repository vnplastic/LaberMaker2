Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormJobs
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnMore = New System.Windows.Forms.Button()
        Me.btnCustomer1 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCustomer2 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnCustomer5 = New System.Windows.Forms.Button()
        Me.btnPrintLabels = New System.Windows.Forms.Button()
        Me.btnCustomer4 = New System.Windows.Forms.Button()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.btnCustomer3 = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(170, 27)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(353, 20)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "Customers with Pending Carton Label Jobs"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPrev
        '
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Location = New System.Drawing.Point(38, 54)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(185, 36)
        Me.btnPrev.TabIndex = 22
        Me.btnPrev.Text = "Previous Page"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnMore
        '
        Me.btnMore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMore.Location = New System.Drawing.Point(385, 260)
        Me.btnMore.Name = "btnMore"
        Me.btnMore.Size = New System.Drawing.Size(206, 36)
        Me.btnMore.TabIndex = 36
        Me.btnMore.Text = "More..."
        Me.btnMore.UseVisualStyleBackColor = True
        '
        'btnCustomer1
        '
        Me.btnCustomer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer1.Location = New System.Drawing.Point(40, 108)
        Me.btnCustomer1.Name = "btnCustomer1"
        Me.btnCustomer1.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer1.TabIndex = 23
        Me.btnCustomer1.Text = "Walmart"
        Me.btnCustomer1.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(495, 336)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 36)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnCustomer2
        '
        Me.btnCustomer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer2.Location = New System.Drawing.Point(40, 150)
        Me.btnCustomer2.Name = "btnCustomer2"
        Me.btnCustomer2.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer2.TabIndex = 24
        Me.btnCustomer2.Text = "Rhode Island Textile"
        Me.btnCustomer2.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(385, 336)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(96, 36)
        Me.btnRefresh.TabIndex = 34
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnCustomer5
        '
        Me.btnCustomer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer5.Location = New System.Drawing.Point(38, 276)
        Me.btnCustomer5.Name = "btnCustomer5"
        Me.btnCustomer5.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer5.TabIndex = 25
        Me.btnCustomer5.Text = "Miles Kimball"
        Me.btnCustomer5.UseVisualStyleBackColor = True
        '
        'btnPrintLabels
        '
        Me.btnPrintLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintLabels.Location = New System.Drawing.Point(385, 208)
        Me.btnPrintLabels.Name = "btnPrintLabels"
        Me.btnPrintLabels.Size = New System.Drawing.Size(206, 36)
        Me.btnPrintLabels.TabIndex = 33
        Me.btnPrintLabels.Text = "Print Labels"
        Me.btnPrintLabels.UseVisualStyleBackColor = True
        '
        'btnCustomer4
        '
        Me.btnCustomer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer4.Location = New System.Drawing.Point(38, 234)
        Me.btnCustomer4.Name = "btnCustomer4"
        Me.btnCustomer4.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer4.TabIndex = 26
        Me.btnCustomer4.Text = "dd's Discounts"
        Me.btnCustomer4.UseVisualStyleBackColor = True
        '
        'btnOptions
        '
        Me.btnOptions.Enabled = False
        Me.btnOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOptions.Location = New System.Drawing.Point(385, 159)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(206, 36)
        Me.btnOptions.TabIndex = 32
        Me.btnOptions.Text = "Options"
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'btnCustomer3
        '
        Me.btnCustomer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer3.Location = New System.Drawing.Point(40, 192)
        Me.btnCustomer3.Name = "btnCustomer3"
        Me.btnCustomer3.Size = New System.Drawing.Size(185, 36)
        Me.btnCustomer3.TabIndex = 27
        Me.btnCustomer3.Text = "Quidsi Carton"
        Me.btnCustomer3.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeselectAll.Location = New System.Drawing.Point(385, 96)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(206, 36)
        Me.btnDeselectAll.TabIndex = 31
        Me.btnDeselectAll.Text = "Deselect All"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(38, 336)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(185, 36)
        Me.btnNext.TabIndex = 28
        Me.btnNext.Text = "Next Page"
        Me.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.Location = New System.Drawing.Point(385, 54)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(206, 36)
        Me.btnSelectAll.TabIndex = 30
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(231, 58)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(148, 319)
        Me.CheckedListBox1.TabIndex = 29
        '
        'FormJobs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnMore)
        Me.Controls.Add(Me.btnCustomer1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCustomer2)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnCustomer5)
        Me.Controls.Add(Me.btnPrintLabels)
        Me.Controls.Add(Me.btnCustomer4)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.btnCustomer3)
        Me.Controls.Add(Me.btnDeselectAll)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Name = "FormJobs"
        Me.Size = New System.Drawing.Size(626, 411)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
