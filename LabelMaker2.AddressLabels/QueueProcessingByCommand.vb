﻿Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel
Imports LaberMaker2.Main

Public Class QueueProcessingByCommand
    Inherits QueueProcessingByCommandBase
    Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Sub CreateReprintJob(SOId As String, LabelCount As Integer, LabelPerLine As Boolean, Optional LineNo As Integer = 0)
        Throw New NotImplementedException
    End Sub

    Public Overrides Sub RefreshSalesforceData()

        'ToDo: Implement 
    End Sub

    Public Overrides Sub RefreshLabelData(Optional SOId As String = Nothing)
        'ToDo: Implement 
    End Sub

    'Overloads Function PrintJob()

    'End Function

End Class
