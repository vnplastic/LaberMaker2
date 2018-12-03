Imports LabelMaker2.Main.Data.VNDataModel
Imports LabelMaker2.Infrastructure


Public Class FormSalesOrderNumber
    Private m_fsono As Long
    Private m_labelQty As Integer
    Dim ctx As VNDataEntities
    Private m_jobTypeId As Integer = 0


    Public Property LabelQty() As Integer
        Get
            Return m_labelQty
        End Get
        Set(ByVal value As Integer)
            m_labelQty = value
        End Set
    End Property

    Public Property JobTypeId() As Integer
        Get
            Return m_jobTypeId
        End Get
        Set(ByVal value As Integer)
            m_jobTypeId = value
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
        Dim types = ctx.ViewAllJobs.Where(Function(c) c.SalesOrderName.Contains(fsono)).Select(Function(d) New With {d.JobTypeId, d.JobTypeName}).Distinct.ToList
        If types.Count > 0 Then
            For Each t In types
                cboJobTypes.ValueMember = "JobTypeId"
                cboJobTypes.DisplayMember = "JobTypeName"
                cboJobTypes.Items.Add(t)
            Next
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
            'Dim jobTypes As List(Of TableJob)
            'jobTypes = ctx.TableJobs.Where(Function(c) c.SalesOrderName.Contains(fsono)).ToList
            If types.Count > 1 And cboJobTypes.SelectedIndex = -1 Then


                'If jobTypes.Count > 1 Then
                MsgBox("There are multiple labesl types for this sales order, select which labels you are reprinting/deleting from the DropDown", MsgBoxStyle.OkOnly,
                   "LabelMaker:Problem")
                cboJobTypes.Visible = True
                lblJobType.Visible = True
                Return
            Else
                If cboJobTypes.SelectedIndex <> -1 Then
                    JobTypeId = cboJobTypes.SelectedItem.JobTypeId
                Else
                    JobTypeId = types.FirstOrDefault.JobTypeId

                End If
                cboJobTypes.Visible = False
                lblJobType.Visible = False
            End If
        Else
            MsgBox("There are no labesl types for this sales order", MsgBoxStyle.OkOnly,
                   "LabelMaker:Problem")
            Return
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
        'Me.fsono = 0
    End Sub

    Private Sub numLabels_ValueChanged(sender As Object, e As EventArgs) Handles numLabels.ValueChanged

    End Sub

    Private Sub txtFsono_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtFsono.MaskInputRejected

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub FormSalesOrderNumber_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As String = Globals.GetEFConnectionString
        ctx = New VNDataEntities(conn)

    End Sub
End Class