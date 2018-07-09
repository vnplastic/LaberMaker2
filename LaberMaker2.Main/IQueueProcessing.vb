Imports LabelMaker2.Main.Data.VNDataModel

Public Interface IQueueProcessing
#Region "Properties"
    Property QueueId() As Long
    Property ProfileId() As Long
    Property JobId() As Long
    Property BatchId() As Long
    Property LabelId() As Long
    Property LabelType() As Long
    Property CopiesPerLabel() As Long
    Property TemplateId() As Long
    Property TemplateFile() As String
    Property PrinterId() As Long
    Property PrinterName() As String
    Property Status() As Long
    Property JobStepInfo As JobInfo
#End Region
    Function PrintJob(_job As List(Of JobInfo)) As Boolean
    Function AttachPrinter(Optional pPrinterId As System.UInt32 = 0, Optional pPrinterName As System.String = "") As Long
    Function PrinterIsAttached() As Boolean
    Function DetachPrinter() As Long
    Function OpenQueue() As Long
    Function ProcessQueueRecord(jobStep As QEnum.QueueLabelType) As Long
    Function EOQ() As Long
    Function CloseQueue() As Long
    Function JobStart() As Long
    Function JobBeforePause() As Long
    Function JobBeforeBlanks() As Long
    Function JobBeforeHeader() As Long
    Function BatchStart() As Long
    Function BatchBeforePause() As Long
    Function BatchBeforeBlanks() As Long
    Function BatchBeforeHeader() As Long
    Function Labels() As Long
    Function PalletLabels() As Long
    'TODO: Replace Label Step with Generic and Override in Implementations???
    Function Extras() As Long
    Function BatchAfterFooter() As Long
    Function BatchAfterBlanks() As Long
    Function BatchAfterPause() As Long
    Function BatchEnd() As Long
    Function JobAfterFooter() As Long
    Function JobAfterBlanks() As Long
    Function JobAfterPause() As Long
    Function JobEnd() As Long
    Function ReadFirstRecordByPrinter(ByVal pPrinterName As String) As Long
    Function ReadFirstRecordByJob(ByVal pJobId As Long) As Long
    Function ReadRecordByQueueId(ByVal pQueueId As Long) As Long
    Function ReadRecord() As Long
    Function RunStep() As Long
    Function WaitForUserResponse() As Long
    Function WriteRecord() As Long
    Function WriteStatusPending() As Long
    Function WriteStatusProcessing() As Long
    Function WriteStatusComplete() As Long
    Function ClearFormats() As Long
    Function AddFormat(ByVal pFormatName As String) As Long
End Interface