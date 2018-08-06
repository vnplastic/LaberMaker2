
Imports System.Windows.Forms

Public Interface ILabelProperties
    Property JobTypeId As Integer
    Property FormPrint As UserControl
    Property DBConnString As String
    Function CanPrintJob() As Boolean
    Property QueueProcessor As IQueueProcessing

End Interface
