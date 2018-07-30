Imports LabelMaker2.Main.Data.VNDataModel
Imports LaberMaker2.Main

Public Class QueueProcessingByCommand
    Inherits LaberMaker2.Main.QueueProcessingByCommandBase
    Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function PrintJob(_job As JobToProcess, context As VNDataEntities) As Boolean
        Throw New NotImplementedException()
    End Function

    'Overloads Function PrintJob()

    'End Function

End Class
