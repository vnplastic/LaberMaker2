Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel
Imports LaberMaker2.Main

Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Dim ctx As VNDataEntities
    ' Private m_JobStepInfo As ViewLabelJobInfo
    'Private m_JobStepLineInfo As ViewLabelJobLineInfo
    Private m_UniqueLabelId As Integer
    'Private m_LineJob As Boolean
    Private log As NLog.Logger
    Sub New()
        MyBase.New()
        Log = LabelMaker2.Infrastructure.Globals.Logger
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Sub CreateReprintJob(SOId As String, LabelCount As Integer, LabelPerLine As Boolean, Optional LineNo As Integer = 0)
        Throw New NotImplementedException
    End Sub

    Public Overrides Sub RefreshSalesforceData()

        'ToDo: Implement 
        'Context.InsertNewAddressJob(False)
        'Context.InsertNewAddressJobLine(False)
    End Sub

    Public Overrides Sub RefreshLabelData(Optional SOId As String = Nothing)
        'ToDo: Implement 
        'Nothing to do in this module at the moment
    End Sub

    Public Overrides Sub RemoveJob(viewJobInfo As ViewJobInfo)
        Throw New NotImplementedException
        'Dim job As TableJob
        '' Dim addressJob As TableAddressJob
        'Dim JobId As Integer
        'Dim jobTypeID As Integer

        'JobId = viewJobInfo.JobId
        'jobTypeID = viewJobInfo.JobTypeId
        'job = Context.TableJobs.Where(Function(c) c.JobId = JobId And c.JobTypeId = jobTypeID).FirstOrDefault
        'addressJob = Context.TableAddressJobs.Where(Function(c) c.JobId = JobId).FirstOrDefault
        'If Not job Is Nothing Then
        '    Context.TableJobs.Remove(job)

        'End If
        'If Not addressJob Is Nothing Then
        '    Context.TableCartonJobs.Remove(addressJob)

        'End If
        'Context.SaveChanges()
    End Sub

    'Overloads Function PrintJob()

    'End Function

End Class
