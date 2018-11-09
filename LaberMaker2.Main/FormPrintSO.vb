Imports System.Data.Entity.Validation
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel
Imports NLog

Public Class FormPrintSO
    Dim ctx As VNDataEntities
    Dim log As Logger
    Public Property q As IQueueProcessing
    Private Sub FormPrintSO_Load(sender As Object, e As EventArgs) Handles Me.Load
        ctx = New VNDataEntities
        log = NLog.LogManager.GetCurrentClassLogger
    End Sub
    Private Sub btnNewJob_Click(sender As System.Object, e As System.EventArgs) Handles btnNewJob.Click
        Dim m_fsono As String
        ' Dim Sql As New SqlStatement
        Dim OldCaption As String
        'Dim iLables as Integer
        Dim m_labelQty As Integer
        Dim m_lineNo As Integer
        'Dim jobType As String
        Dim jobTypeId As Integer
        Dim jobToReprint As ViewJobInfo
        Dim jobs As List(Of ViewJobInfo)

        m_fsono = "000000"
        FormSalesOrderNumber.fsono = m_fsono
        FormSalesOrderNumber.Show(Me)
        Do While FormSalesOrderNumber.Visible
            My.Application.DoEvents()

        Loop

        'jobType = FormSalesOrderNumber.JobType

        m_fsono = FormSalesOrderNumber.fsono
        m_labelQty = FormSalesOrderNumber.LabelQty
        jobTypeId = FormSalesOrderNumber.JobTypeId
        ' m_labelQty = 2
        'MsgBox("Debug: Sales Order Number: " & m_fsono)
        If m_fsono = "000000" Then
            ' Do nothing - No Sales Order Number entered
        Else
            ' Is this Sales Order still pending?

            Dim job = ctx.ViewJobInfos.AsNoTracking.Where(Function(c) c.SalesOrderName.Contains(m_fsono)).ToList

            If job.Count = 0 Then
                MsgBox("This Sales Order is not for an active LabelMaker Customer or is the wrong label type.", MsgBoxStyle.OkOnly,
                       "LabelMaker: Create Print Job")
                Exit Sub

            Else

                '
                jobs = job.Where(Function(c) c.JobTypeId = jobTypeId).ToList
                '  End If
                If jobs.Any(Function(c) c.Printed = 0) Then
                    Dim sMessage As String

                    sMessage = "This Sales Order is already waiting to be printed.."


                    MsgBox(sMessage, MsgBoxStyle.OkOnly,
                           "LabelMaker: Create Print Job")

                    Exit Sub
                End If
                jobToReprint = jobs.FirstOrDefault
                If jobToReprint.LabelPerLine = True Then
                    Debug.Print("Line Item Batch")
                    If MsgBox("If you want to print a specific line item, select ok, Otherwise select cancel for printing ALL line items", MsgBoxStyle.OkCancel) _
                        = MsgBoxResult.Ok Then

                        FormLineSelection.SOId = jobToReprint.SOId
                        FormLineSelection.fsono = m_fsono

                        FormLineSelection.Show(Me)
                        Do While FormLineSelection.Visible
                            My.Application.DoEvents()

                        Loop
                        m_lineNo = FormLineSelection.lineNo
                        If m_lineNo = 0 Then
                            MsgBox(
                                "A product/ line number needs to be selected if you don't want to print the entire order")
                            Exit Sub
                        End If
                        'Else

                    End If
                End If

                Dim instanceDll = ctx.TableJobTypes.AsNoTracking.Where(Function(c) c.JobTypeId = jobTypeId).Select(Function(c) c.DLLName).FirstOrDefault
                Dim q = Globals.CreateLabelInstance(instanceDll).QueueProcessor

                q.SetContext(ctx)


                OldCaption = Me.Text ' "More..."


                q.CreateReprintJob(jobToReprint.SOId, m_labelQty, jobToReprint.LabelPerLine, m_lineNo)

                Me.Text = "Generated"
                MsgBox("Label Print Job Created Successfully.", MsgBoxStyle.OkOnly, "LabelMaker: Create Label Print Job")

            End If

        End If

    End Sub




    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        ' FormMain.RefreshForm(False)
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click

        ' MsgBox("Not Implemented Yet", MsgBoxStyle.OkOnly)
        ' Return
        Dim m_fsono As String
        Dim OldCaption As String
        Dim m_labelQty As Integer
        Dim m_lineNo As Integer

        Dim jobTypeId As Integer
        Dim jobToRemove As ViewJobInfo
        Dim jobs As List(Of ViewJobInfo)

        m_fsono = "000000"
        FormSalesOrderNumber.fsono = m_fsono
        FormSalesOrderNumber.Show(Me)
        Do While FormSalesOrderNumber.Visible
            My.Application.DoEvents()

        Loop


        m_fsono = FormSalesOrderNumber.fsono
        m_labelQty = FormSalesOrderNumber.LabelQty
        jobTypeId = FormSalesOrderNumber.JobTypeId

        If m_fsono = "000000" Then
            ' Do nothing - No Sales Order Number entered
        Else
            Try

                ' Is this Sales Order still pending?
                Dim job = ctx.ViewJobInfos.AsNoTracking.Where(Function(c) c.SalesOrderName.Contains(m_fsono) And c.Printed = 0 And c.JobTypeId = jobTypeId).FirstOrDefault
                If Not job Is Nothing Then

                    If MsgBox("Are you sure you want to remove Sales Order " & m_fsono & "?", MsgBoxStyle.YesNo,
                                         "LabelMaker: Remove Label Print Job") = MsgBoxResult.Yes Then
                        Dim instanceDll = ctx.TableJobTypes.AsNoTracking.Where(Function(c) c.JobTypeId = jobTypeId).Select(Function(c) c.DLLName).FirstOrDefault
                        Dim q = Globals.CreateLabelInstance(instanceDll).QueueProcessor

                        q.SetContext(ctx)
                        q.RemoveJob(job)

                        'RunSql("EXEC VNA042SP12_DestroyPendingJobs_BySalesOrder '" & m_fsono & "'")
                        MsgBox("Sales Order '" & m_fsono & "' has been removed successfully.", MsgBoxStyle.OkOnly,
                                   "LabelMaker: Remove Label Print Job")
                    Else
                        MsgBox("Sales Order '" & m_fsono & "' is not waiting to be printed.", MsgBoxStyle.OkOnly,
                               "LabelMaker: Remove Label Print Job")
                    End If
                End If
            Catch ex As Exception
                log.Debug(ex.Message + vbCrLf + ex.StackTrace)
                MsgBox("An error occurred removing the job", MsgBoxStyle.OkOnly,
                       "LabelMaker: Remove Label Print Job")
            End Try

        End If

    End Sub


End Class