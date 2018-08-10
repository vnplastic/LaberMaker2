Imports System.Windows.Forms
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel


Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Dim ctx As VNDataEntities
    Private m_JobStepInfo As CartonJobInfo
    Private m_JobStepLineInfo As CartonJobLineInfo
    Private m_UniqueLabelId As Integer
    Private m_LineJob As Boolean



    Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess, context As VNDataEntities) As Boolean 'Implements IQueueProcessing.PrintJob
        Try
            ctx = context
        Dim j As CartonJobInfo
        Dim currentCartonCount As Integer

        j = ctx.CartonJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).FirstOrDefault
        If j.Serialized Then m_UniqueLabelId = j.NextUniqueLabelNo
        Dim custInfo As CustomerJobInfo
        custInfo = ctx.CustomerJobInfos.Where(Function(c) c.CustomerJobInfoId = j.CustomerJobInfoId).FirstOrDefault

        PrinterName = j.PrinterName
        JobId = _job.JobId
        ' j = ctx.CartonJobInfos.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList
        If j.LabelPerLine = True Then
            LineJob = True
            Dim cJob As List(Of CartonJobLineInfo)
            cJob = ctx.CartonJobLineInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ThenBy(Function(d) d.LineNo).ToList

            Dim t As List(Of String)
            t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.CartonLabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

            For Each f In t
                TemplateFile = f
                AddFormat(TemplateFile)
                Debug.Print(TemplateFile)
            Next
            For Each jInfo As CartonJobLineInfo In cJob
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
            Dim cJob As List(Of CartonJobInfo)
            cJob = ctx.CartonJobInfos.AsNoTracking.Where(Function(c) c.JobId = _job.JobId).OrderBy(Function(c) c.JobStepOrder).ToList

            Dim t As List(Of String)
            t = cJob.Where(Function(c) Not c.FormatName Is Nothing And c.CartonLabelCount > 0).Select(Function(c) c.FormatName).Distinct.ToList()

            For Each f In t
                TemplateFile = f
                AddFormat(TemplateFile)
                Debug.Print(TemplateFile)
            Next
            For Each jInfo As CartonJobInfo In cJob
                JobStepInfo = jInfo
                TemplateFile = JobStepInfo.FormatName
                ProcessQueueRecord(JobStepToQType(jInfo.JobStepName))
                Debug.Print(jInfo.JobStepName)
            Next

        End If

        Catch ex As Exception
            Debug.WriteLine(ex, ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("An error occurred trying to print Carton labels", "Error")
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
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(JobId, "0")}""  /?qpLineNo=""{Format(JobStepLineInfo.LineNo, "0")}"" /PRN=""{PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                     & $"        <Value>{Format(JobId, "0")}</Value>" & vbCrLf _
                     & "      </QueryPrompt>" & vbCrLf
            CommandStr = BTExe &
                         $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(JobId, "0")}"" /PRN=""{PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                         vbCrLf
        End If

        erc = BTCommandAdd(CommandStr)
    Return erc
                End Function
    Private Property JobStepInfo As CartonJobInfo
        Get
            Return m_JobStepInfo
        End Get
        Set(value As CartonJobInfo)
            m_JobStepInfo = value
        End Set
    End Property
    Private Property JobStepLineInfo As CartonJobLineInfo
        Get
            Return m_JobStepLineInfo
        End Get
        Set(value As CartonJobLineInfo)
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
