Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormPrintSO
    Dim ctx As VNDataEntities
    Private Sub FormPrintSO_Load(sender As Object, e As EventArgs) Handles Me.Load
        ctx = New VNDataEntities
    End Sub
    Private Sub btnNewJob_Click(sender As System.Object, e As System.EventArgs) Handles btnNewJob.Click
        Dim m_fsono As String
        ' Dim Sql As New SqlStatement
        Dim OldCaption As String
        'Dim iLables as Integer
        Dim m_labelQty As Integer
        Dim m_lineNo As Integer
        Dim jobType As String
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
        m_labelQty = 2
        'MsgBox("Debug: Sales Order Number: " & m_fsono)
        If m_fsono = "000000" Then
            ' Do nothing - No Sales Order Number entered
        Else
            ' Is this Sales Order still pending?

            Dim job = ctx.ViewJobInfos.AsNoTracking.Where(Function(c) c.SalesOrderName.Contains(m_fsono)).ToList

            If job.Count = 0 Then
                MsgBox("This Sales Order is not for an active LabelMaker Customer or is the wrong label type (Pallet/Carton).", MsgBoxStyle.OkOnly,
                       "LabelMaker: Create Print Job")
                Exit Sub

            Else

                If jobTypeId = 0 Then
                    jobs = job
                Else
                    jobs = job.Where(Function(c) c.JobTypeId = jobTypeId).ToList
                End If
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
                    If MsgBox("If you want to print a specific line item, select ok, Otherwise ALL labels for ALL line items will be printed", MsgBoxStyle.OkCancel) _
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


                OldCaption = Me.Text ' "More..."
#Region "Cartons"
                    'ToDo: Generate Reprint Jobs
                    If jobType = "Carton" Then
                    NewCartonJob(jobToReprint.SOId, m_labelQty, m_lineNo)
#End Region
                Else 'Pallet Labels
                        'ToDO need to add ability to print only a few pallet labels????

                        Me.Text = "Creating Job"

                End If
                    Me.Text = "Generated"
                MsgBox("Label Print Job Created Successfully.", MsgBoxStyle.OkOnly, "LabelMaker: Create Label Print Job")

            End If
            End If



    End Sub

    Private Sub NewCartonJob(SOId As String, m_labelQty As Integer, Optional LineNo As Integer = 0)
        Me.Text = "Creating Job"
        Dim newJob As TableJob
        newJob = ctx.TableJobs.Where(Function(c) c.KNDY4SalesOrderC1 = SOId And c.JobTypeId = 1).FirstOrDefault
        If m_labelQty > 0 Then


            newJob.Printed = 0
            ctx.TableJobs.Add(newJob)
            ctx.SaveChanges()
            ctx.InsertNewCartonJob()
            Dim inewJob As Integer
            inewJob = newJob.JobId
            Dim jobInfo As TableCartonJob
            If LineNo = 0 Then
                jobInfo = ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label").FirstOrDefault
            Else
                ctx.TableCartonJobs.RemoveRange(ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo <> LineNo))
                jobInfo = ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo = LineNo).FirstOrDefault
            End If

            jobInfo.CartonLabelCount = m_labelQty
            Dim bh As Boolean = ctx.ChangeTracker.HasChanges()
            ctx.SaveChanges()
        Else
            newJob.Printed = 0
            ctx.TableJobs.Add(newJob)
            ctx.SaveChanges()
            ctx.InsertNewCartonJob()
            Dim inewJob As Integer
            inewJob = newJob.JobId
            'Dim jobInfo As TableCartonJob
            If LineNo = 0 Then
                'jobInfo = ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label").FirstOrDefault
            Else
                ctx.TableCartonJobs.RemoveRange(ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo <> LineNo))
                ctx.SaveChanges()
                'jobInfo = ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo = LineNo).FirstOrDefault
            End If


        End If
    End Sub

    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        ' FormMain.RefreshForm(False)
        'ToDo:Refresh Main Form List
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        'ToDo:Remove a Job???

        MsgBox("Not Implemented Yet", MsgBoxStyle.OkOnly)
        'Dim m_fsono As String
        'Dim Sql As New SqlStatement
        'Dim mbYesNo As MsgBoxResult
        ''Dim erc As Integer

        'm_fsono = "000000"
        'FormSalesOrderNumber.fsono = m_fsono
        'FormSalesOrderNumber.chkLabelQty.Visible = False
        'FormSalesOrderNumber.numLabels.Visible = False
        'FormSalesOrderNumber.Show(Me)
        'Do While FormSalesOrderNumber.Visible
        '    My.Application.DoEvents()
        'Loop

        'm_fsono = FormSalesOrderNumber.fsono
        ''MsgBox("Debug: Sales Order Number: " & m_fsono)
        'If m_fsono = "000000" Then
        '    ' Do nothing - No Sales Order Number entered
        'Else
        '    ' Is this Sales Order still pending?
        '    'MsgBox("Debug: Pending Sales Order Check: " & m_fsono, MsgBoxStyle.OkOnly, "LabelMaker: Debug")
        '    Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
        '                "SELECT fsono, JobId, ProfileId, ProfileName, PrinterId, PrinterName FROM VNA042VW1O_JobInfo WHERE fsono='" &
        '                m_fsono & "' AND Printed=0 AND Destroyed=0 ORDER BY SalesOrderNo")
        '    If Sql.ErrorCode = 0 Then
        '        If Not Sql.ResultSet.EOF Then
        '            mbYesNo = MsgBox("Are you sure you want to remove Sales Order " & m_fsono & "?", MsgBoxStyle.YesNo,
        '                             "LabelMaker: Remove Label Print Job")
        '            If mbYesNo = MsgBoxResult.Yes Then
        '                'RunSql("EXEC VNA042SP12_DestroyPendingJobs_BySalesOrder '" & m_fsono & "'")
        '                MsgBox("Sales Order '" & m_fsono & "' has been removed successfully.", MsgBoxStyle.OkOnly,
        '                       "LabelMaker: Remove Label Print Job")
        '                FormMain.btnRefresh.PerformClick()
        '            End If
        '        Else
        '            MsgBox("Sales Order '" & m_fsono & "' is not waiting to be printed.", MsgBoxStyle.OkOnly,
        '                   "LabelMaker: Remove Label Print Job")
        '        End If
        '    Else
        '        MsgBox(
        '            "There was an error trying to find the Job to remove.  Try again, and if the error persists, contact your IT Administrator.")
        '    End If
        '    Sql.Close()
        'End If
    End Sub


End Class