Imports System.Windows.Forms
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel


Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Dim ctx As VNDataEntities
    Private m_JobStepInfo As ViewCartonJobInfo
    Private m_JobStepLineInfo As ViewCartonJobLineInfo
    Private m_UniqueLabelId As Integer
    Private m_LineJob As Boolean
    Private log As NLog.Logger



    Sub New()
        MyBase.New()
        log = LabelMaker2.Infrastructure.Globals.Logger
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess, context As VNDataEntities) As Boolean 'Implements IQueueProcessing.PrintJob
        Try
            ctx = context
        Dim j As ViewCartonJobInfo
        Dim currentCartonCount As Integer

        j = ctx.ViewCartonJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).FirstOrDefault
        If j.Serialized Then m_UniqueLabelId = j.NextUniqueLabelNo
        Dim custInfo As TableCustomerJobInfo
        custInfo = ctx.TableCustomerJobInfos.Where(Function(c) c.CustomerJobInfoId = j.CustomerJobInfoId).FirstOrDefault

        PrinterName = j.PrinterName
        JobId = _job.JobId
        ' j = ctx.CartonJobInfos.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList
        If j.LabelPerLine = True Then
            LineJob = True
            Dim cJob As List(Of ViewCartonJobLineInfo)
            cJob = ctx.ViewCartonJobLineInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ThenBy(Function(d) d.LineNo).ToList

            Dim t As List(Of String)
            t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.CartonLabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

            For Each f In t
                TemplateFile = f
                AddFormat(TemplateFile)
                Debug.Print(TemplateFile)
            Next
            For Each jInfo As ViewCartonJobLineInfo In cJob
                currentCartonCount = jInfo.LineCartonCount
                JobStepLineInfo = jInfo
                TemplateFile = JobStepLineInfo.FormatName
                ProcessQueueRecord(JobStepToQType(jInfo.JobStepName))
                Debug.Print(jInfo.JobStepName)
                If jInfo.JobStepName = "Label" Then
                    m_UniqueLabelId = m_UniqueLabelId + jInfo.LineCartonCount
                    custInfo.NextUniqueLabelNo = m_UniqueLabelId
                    ctx.SaveChanges()
                End If


            Next


            ' ctx.SaveChanges()


        Else
            LineJob = False
            Dim cJob As List(Of ViewCartonJobInfo)
            cJob = ctx.ViewCartonJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList

            Dim t As List(Of String)
            t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.CartonLabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

            For Each f In t
                TemplateFile = f
                AddFormat(TemplateFile)
                Debug.Print(TemplateFile)
            Next
            For Each jInfo As ViewCartonJobInfo In cJob
                JobStepInfo = jInfo
                TemplateFile = JobStepInfo.FormatName
                ProcessQueueRecord(JobStepToQType(jInfo.JobStepName))
                Debug.Print(jInfo.JobStepName)
            Next

        End If

        Catch ex As Exception
            Debug.WriteLine(ex, ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("An error occurred trying to print Carton labels", "Error")
            Log.Debug(ex.Message & vbCrLf & ex.StackTrace)
        End Try



        Return True
    End Function
    Public Overrides Function Labels() As Long
        Dim erc As Long
        Dim CommandStr As System.String
        Dim PrintByLabel As Boolean       ' True=Print by Label, False=Print by Batch
        Dim LabelBatch As String
        'End Function
        erc = QEnum.QueueConsumerErrorCodes.OK
    PrintByLabel = IsBatchSerialized()
        'PrintByLabel = False
        If PrintByLabel And LineJob Then
            LabelBatch = "      <QueryPrompt Name=""qpLabelId"">" & vbCrLf _
                     & $"        <Value>{Format(LabelId, "0")}</Value>" & vbCrLf _
                     & "      </QueryPrompt>" & vbCrLf
            CommandStr = BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(JobId, "0")}""  /?qpLineNo=""{Format(JobStepLineInfo.LineNo, "0")}"" /PRN=""{PrinterName}"" /MIN=Taskbar /NOSPLASH " & If(TestMode, "/PD", "/P") &
                     vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                     & $"        <Value>{Format(JobId, "0")}</Value>" & vbCrLf _
                     & "      </QueryPrompt>" & vbCrLf
            CommandStr = BTExe &
                         $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(JobId, "0")}"" /PRN=""{PrinterName}"" /MIN=Taskbar /NOSPLASH " & If(TestMode, "/PD", "/P") &
                         vbCrLf
        End If

        erc = BTCommandAdd(CommandStr)
    Return erc
                End Function

    Public Overrides Function JobEnd() As Long
        'If LineJob Then
        '    Dim CartonJobLine As List(Of TableCartonJob)
        '    CartonJobLine = ctx.TableCartonJobs.Where(Function(c) c.JobId = JobId).ToList
        '    For Each cj In CartonJobLine
        '        cj.Printed = True
        '    Next
        'Else
        'Todo:Is there a bug from converting to single Job Table?????
        Dim CartonJob As List(Of TableCartonJob)
            CartonJob = ctx.TableCartonJobs.Where(Function(c) c.JobId = JobId).ToList
            For Each cj In CartonJob
                cj.Printed = True
            Next
        ' End If


        ctx.SaveChanges()
        Return MyBase.JobEnd()

    End Function

    Public Overrides Sub CreateReprintJob(SOId As String, LabelCount As Integer, Optional LineNo As Integer = 0)
        Throw New NotImplementedException()
    End Sub

    Private Property JobStepInfo As ViewCartonJobInfo
        Get
            Return m_JobStepInfo
        End Get
        Set(value As ViewCartonJobInfo)
            m_JobStepInfo = value
        End Set
    End Property
    Private Property JobStepLineInfo As ViewCartonJobLineInfo
        Get
            Return m_JobStepLineInfo
        End Get
        Set(value As ViewCartonJobLineInfo)
            m_JobStepLineInfo = value
        End Set
    End Property
    Private Property LineJob As Boolean
        Get
            Return m_LineJob
        End Get
        Set(value As Boolean)
            m_LineJob = value
        End Set
    End Property

End Class
