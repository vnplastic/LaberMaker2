Imports System.Data.Entity.Validation
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel


Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Dim ctx As VNDataEntities
    Private m_JobStepInfo As ViewPalletJobInfo
    Private log As NLog.Logger

    Sub New()
        MyBase.New()
        log = LabelMaker2.Infrastructure.Globals.Logger
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess) As Boolean
        Try
            Dim j As ViewPalletJobInfo
            ctx = Context

            j = ctx.ViewPalletJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).FirstOrDefault

            Dim custInfo As TableCustomerJobInfo
            custInfo = ctx.TableCustomerJobInfos.Where(Function(c) c.CustomerJobInfoId = j.CustomerJobInfoId).FirstOrDefault

            PrinterName = j.PrinterName
            JobId = _job.JobId
            ' j = ctx.CartonJobInfos.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList

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

        Catch e As Exception
            MsgBox("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace, MsgBoxStyle.OkOnly)
            Log.Debug("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace)
        End Try



        Return True
    End Function

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

            ctx.InsertNewPalletJob(True)

            If LabelCount > 0 Then
                Dim jobInfo As TablePalletJob
                'ToDo: DO we need Per Line for Pallet????
                'If LineNo = 0 Then
                '    jobInfo = ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label").FirstOrDefault
                'Else
                'ctx.TablePalletJobs.RemoveRange(ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo <> LineNo))
                jobInfo = ctx.TablePalletJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "PalletLabel").FirstOrDefault
                ''  End If
                If Not jobInfo Is Nothing Then
                    jobInfo.PalletLabelCount = LabelCount
                    Dim bh As Boolean = ctx.ChangeTracker.HasChanges()
                    ctx.SaveChanges()
                Else
                    MsgBox("Error occurred creating job" + vbCrLf + "The label details may not have been properly created")
                    log.Debug("Error occurred creating job" + vbCrLf + "The Pallet Job details were not created")
                End If
            Else
                    'Do Nothing...............

                    'If LineNo = 0 Then
                    'Else
                    '    ctx.TablePalletJobs.RemoveRange(ctx.TableCartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label" And c.LineNo <> LineNo))
                    '    ctx.SaveChanges()
                    'End If


                End If
        Catch e As DbEntityValidationException
            MsgBox("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace, MsgBoxStyle.OkOnly)
            Log.Debug("Error occurred creating job" + vbCrLf + e.Message + vbCrLf + e.StackTrace)
        End Try
    End Sub

    Public Overrides Sub RefreshSalesforceData()

        Context.InsertNewPalletJob(False)
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
