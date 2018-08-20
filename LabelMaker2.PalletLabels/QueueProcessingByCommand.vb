Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel


Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Dim ctx As VNDataEntities
    Private m_JobStepInfo As ViewPalletJobInfo

    Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess, context As VNDataEntities) As Boolean
        ctx = context
        Dim j As ViewPalletJobInfo

        j = ctx.ViewPalletJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).FirstOrDefault

        Dim custInfo As TableCustomerJobInfo
        custInfo = ctx.TableCustomerJobInfos.Where(Function(c) c.CustomerJobInfoId = j.CustomerJobInfoId).FirstOrDefault

        PrinterName = j.PrinterName
        JobId = _job.JobId
        ' j = ctx.CartonJobInfos.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList

        Dim cJob As List(Of ViewPalletJobInfo)
        cJob = ctx.ViewPalletJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList

        Dim t As List(Of String)
            t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.CartonLabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

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





        Return True
    End Function

    Public Overrides Sub CreateReprintJob(SOId As String, LabelCount As Integer, Optional LineNo As Integer = 0)
        Throw New NotImplementedException()
    End Sub

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
