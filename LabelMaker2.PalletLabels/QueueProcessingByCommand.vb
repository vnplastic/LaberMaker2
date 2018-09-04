Imports System.Data.Entity.Validation
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel


Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Dim ctx As VNDataEntities
    Private m_JobStepInfo As ViewPalletJobInfo
    Private m_UniqueLabelId As Integer
    Private log As NLog.Logger

    Sub New()
        MyBase.New()
        log = LabelMaker2.Infrastructure.Globals.Logger
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess) As Boolean
        Try
            Dim j As TablePalletJob
            ctx = Context

            j = ctx.TablePalletJobs.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).FirstOrDefault
            Dim currentPalletCount As Integer

            Dim custInfo As TableCustomerJobInfo
            custInfo = ctx.TableCustomerJobInfos.Where(Function(c) c.CustomerJobInfoId = j.CustomerJobInfoId).FirstOrDefault

            PrinterName = j.PrinterName
            JobId = _job.JobId
            ' j = ctx.CartonJobInfos.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList
            If j.LabelPerLine = True Then
                LineJob = True
                Dim cJob As List(Of ViewPalletJobLineInfo)
                cJob = ctx.ViewPalletJobLineInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ThenBy(Function(d) d.LineNo).ToList

                Dim t As List(Of String)
                t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.LabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

                For Each f In t
                    TemplateFile = f
                    AddFormat(TemplateFile)
                    Debug.Print(TemplateFile)
                Next
                For Each jInfo As ViewPalletJobLineInfo In cJob
                    currentPalletCount = jInfo.LinePalletCount
                    JobStepLineInfo = jInfo
                    TemplateFile = JobStepLineInfo.FormatName
                    ProcessQueueRecord(JobStepToQType(jInfo.JobStepName))
                    Debug.Print(jInfo.JobStepName)
                    If jInfo.JobStepName = "PalletLabel" Then
                        m_UniqueLabelId = m_UniqueLabelId + jInfo.LinePalletCount
                        custInfo.NextUniqueLabelNo = m_UniqueLabelId
                        ctx.SaveChanges()
                    End If


                Next


                ' ctx.SaveChanges()


            Else
                LineJob = False
                Dim cJob As List(Of ViewPalletJobInfo)
                cJob = ctx.ViewPalletJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList

                Dim t As List(Of String)
                t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.LabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

                For Each f In t
                    TemplateFile = f
                    AddFormat(TemplateFile)
                    Debug.Print(TemplateFile)
                Next
                For Each jInfo As ViewPalletJobInfo In cJob
                    JobStepInfo = jInfo
                    TemplateFile = JobStepInfo.FormatName
                    ProcessQueueRecord(JobStepToQType(jInfo.JobStepName))
                    Debug.Print(jInfo.JobStepName)
                Next
            End If
        Catch e As Exception
            '  MsgBox("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace, MsgBoxStyle.OkOnly)
            log.Debug("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace)

            Throw New Exception("An Error occured trying to print job", e)
        End Try



        Return True
    End Function

    Public Property JobStepLineInfo As ViewPalletJobLineInfo


    Public Overrides Sub CreateReprintJob(SOId As String, LabelCount As Integer, LabelPerLine As Boolean, Optional LineNo As Integer = 0)
        Try
            ctx = Me.Context

            Dim newJob As TableJob
            newJob = ctx.TableJobs.Where(Function(c) c.KNDY4SalesOrderC1 = SOId And c.JobTypeId = 2).FirstOrDefault
            newJob.Printed = 0
            ctx.TableJobs.Add(newJob)
            ctx.SaveChanges()

            Dim inewJob As Integer
            inewJob = newJob.JobId
            If LabelPerLine Then
                ctx.InsertNewPalletJobLine(True)
            Else
                ctx.InsertNewPalletJob(True)
            End If

            If LabelCount > 0 Then
                Dim jobInfo As TablePalletJob

                If LineNo = 0 Then
                    jobInfo = ctx.TablePalletJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label").FirstOrDefault
                Else
                    ctx.TablePalletJobs.RemoveRange(ctx.TablePalletJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo <> LineNo))
                    jobInfo = ctx.TablePalletJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "PalletLabel").FirstOrDefault
                End If
                jobInfo.CartonLabelCount = LabelCount
                Dim bh As Boolean = ctx.ChangeTracker.HasChanges()
                ctx.SaveChanges()

            Else

                If LineNo = 0 Then

                Else
                    ctx.TablePalletJobs.RemoveRange(ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo <> LineNo))
                    ctx.SaveChanges()
                End If


            End If
        Catch e As DbEntityValidationException
            MsgBox("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace, MsgBoxStyle.OkOnly)
            Log.Debug("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Overrides Sub RefreshSalesforceData()

        Context.InsertNewPalletJob(False)
        Context.InsertNewPalletJobLine(False)
    End Sub

    Public Overrides Sub RefreshLabelData(Optional SOId As String = Nothing)
        If String.IsNullOrEmpty(SOId) Then
            Context.UpdatePalletJobInfo("")
        Else
            Context.UpdatePalletJobInfo(SOId)
        End If

    End Sub

    Public Overrides Function JobEnd() As Long
        If Not TestMode Then
            Dim PalletJob As List(Of TablePalletJob)
            PalletJob = ctx.TablePalletJobs.Where(Function(c) c.JobId = JobId).ToList
            For Each cj In PalletJob
                cj.Printed = True
            Next
            ' End If


            ctx.SaveChanges()
        End If

        Return MyBase.JobEnd()
    End Function

    Public Overrides Function Labels() As Long
        Dim erc As Long
        Dim CommandStr As System.String
        Dim PrintByLabel As Boolean       ' True=Print by Label, False=Print by Batch
        Dim LabelBatch As String

        erc = QEnum.QueueConsumerErrorCodes.OK
        PrintByLabel = IsBatchSerialized()
        PrintByLabel = False
        If PrintByLabel Then
            LabelBatch = "      <QueryPrompt Name=""qpLabelId"">" & vbCrLf _
                         & $"        <Value>{Format(LabelId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpJobId"">" & vbCrLf _
                         & $"        <Value>{Format(JobId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        End If
        CommandStr = BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(JobId, "0")}"" /PRN=""{PrinterName}"" /MIN=Taskbar /NOSPLASH " & If(TestMode, "/PD", "/P") &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
        Return MyBase.Labels()
    End Function

    'Overloads Function PrintJob()

    'End Function
    Private Property JobStepInfo As ViewPalletJobInfo
        Get
            Return m_JobStepInfo
        End Get
        Set(value As ViewPalletJobInfo)
            m_JobStepInfo = value
        End Set
    End Property

End Class
