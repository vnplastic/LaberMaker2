Public Class FormSalesOrderNumber
    Private m_fsono As Long
    Private m_labelQty As Integer


    Public Property LabelQty() As Integer
        Get
            Return m_labelQty
        End Get
        Set(ByVal value As Integer)
            m_labelQty = value
        End Set
    End Property

    Public Property fsono As String
        Get
            Dim WorkStr As String

            WorkStr = Strings.Format(m_fsono, "000000")
            Return WorkStr
        End Get
        Set(value As String)
            Dim WorkNum As Long

            WorkNum = CLng(Val(value))
            If WorkNum > 0 And WorkNum <= 999999 Then
                m_fsono = WorkNum
                Me.txtFsono.Text = Strings.Format(m_fsono, "#")
            Else
                Me.txtFsono.Text = ""
            End If
        End Set
    End Property

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Me.fsono = Me.txtFsono.Text
        If chkLabelQty.Checked = True Then
            'MsgBox("Printing less than the full number of labels for the order is not implemented yet",
            '       MsgBoxStyle.OkOnly, "LabelMaker: ERROR")
            If numLabels.Value = 0 Then
                MsgBox("You need to enter a number greater than 0 to print any labels or uncheck the quantity checkbox", MsgBoxStyle.OkOnly,
                       "LabelMaker: ERROR")
                Exit Sub
            Else
                LabelQty = numLabels.Value

            End If
        Else
            LabelQty = 0


        End If
        Me.Hide()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.fsono = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        'Me.fsono = "0"
        Me.Hide()
    End Sub

    Private Sub chkLabelQty_CheckedChanged(sender As Object, e As EventArgs) Handles chkLabelQty.CheckedChanged
        numLabels.Enabled = chkLabelQty.Checked
    End Sub

    Private Sub FormSalesOrderNumber_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.fsono = 0
    End Sub
End Class