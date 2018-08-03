Public Class QEnum
#Region "Enums"
    Public Enum QueueConsumerErrorCodes As Long
        OK = &H0
        NoPrinterSpecified = -1
        InvalidPrinterName = -2
        InvalidPrinterId = -3
        NoPrinterAttached = -4
        EmptyQueue = -5
        InvalidProcessMode = -6
        WaitForUserResponse = 1
    End Enum


    Public Enum QueueLabelType
        JobStart = 100
        JobBeforePause = 110
        JobBeforeBlanks = 120
        JobBeforeHeader = 130
        BatchStart = 200
        BatchBeforePause = 210
        BatchBeforeBlanks = 220
        BatchBeforeHeader = 230
        Labels = 300
        Extras = 400
        PalletLabels = 450
        BatchAfterFooter = 500
        BatchAfterBlanks = 510
        BatchAfterPause = 520
        BatchEnd = 599
        JobAfterFooter = 600
        JobAfterBlanks = 610
        JobAfterPause = 620
        JobEnd = 699
    End Enum

    Public Enum QueueStatus
        Pending = 0
        Processing = 1
        Done = 2
    End Enum

    Public Enum QueueProcessMode
        XML = 1
        CommandLine = 2
        Internal = 3
    End Enum
#End Region

End Class
