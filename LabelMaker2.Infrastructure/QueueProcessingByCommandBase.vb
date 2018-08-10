Option Explicit On

Imports System.Data.SqlClient
Imports System.IO
Imports LabelMaker2.Main.Data.VNDataModel

Public MustInherit Class QueueProcessingByCommandBase
    Implements IQueueProcessing
#Region "Fields"
    Private m_QueueId As Long
    Private m_ProfileId As Long
    Private m_JobId As Long
    '  Private m_BatchId As Long
    Private m_LabelId As Long
    Private m_LabelType As Long
    Private m_CopiesPerLabel As Long
    Private m_TemplateId As Long
    Private m_TemplateFile As String
    Private m_PrinterId As Long
    Private m_PrinterName As String
    Private m_Status As Long
    Private m_AttachedPrinterId As Long
    Private m_AttachedPrinterName As System.String
    'Private m_QueueRecord As New VNA042VW2Q
    Private m_QueueProcessMode As QEnum.QueueProcessMode
    Private m_BTCommandFile As String
    Private m_BTCommandHandle As Long
    'Private m_BTE As New Seagull.BarTender.Print.Engine
    'Private m_BTD As Seagull.BarTender.Print.Documents
    Private m_BTExe As String
    Private m_WaitForUserReponse As Boolean
    Private m_SalesOrderNo As String
    Private m_Cancel As Boolean
    Private ctx As VNDataEntities
    'Dim m_JobStepInfo As T
#End Region
    Sub New()
        m_QueueProcessMode = QEnum.QueueProcessMode.CommandLine
        m_Cancel = False
        ctx = New VNDataEntities

    End Sub

    Public MustOverride Function PrintJob(_job As JobToProcess, context As VNDataEntities) As Boolean Implements IQueueProcessing.PrintJob

    'Function GetFormat(f As String) As String
    '    Dim r As String
    '    r = j.FormatName
    '    Return r
    'End Function
    Function BTCommandOpen() As Long
        Dim erc As Long
        erc = QEnum.QueueConsumerErrorCodes.OK

        If m_BTCommandHandle = 0 Then
            m_BTCommandHandle = FreeFile()
            m_BTCommandFile = My.Settings.BatchPath & "\Job" & Format(m_JobId, "000000")
            'm_BTExe = """" & My.Settings.BartendExe & """"
            m_BTCommandFile &= ".cmd"
            FileOpen(m_BTCommandHandle, m_BTCommandFile, OpenMode.Output, OpenAccess.Default, OpenShare.Default)
        End If
        Return erc
    End Function

    Function BTCommandAdd(ByVal pCommandStr As System.String) As Long
        Dim erc As Long
        Dim CommandStr As String

        erc = QEnum.QueueConsumerErrorCodes.OK

        If m_BTCommandHandle = 0 Then
            erc = BTCommandOpen()
        End If

        If erc = QEnum.QueueConsumerErrorCodes.OK Then
            CommandStr = pCommandStr ' ResolveMacros(pCommandStr)
            If Right$(CommandStr, Len(vbCrLf)) <> vbCrLf Then CommandStr &= vbCrLf
            Print(m_BTCommandHandle, CommandStr)
            Dim args As String() = Environment.GetCommandLineArgs
            If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then
            Else
                Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
            End If
        End If

        Return erc
    End Function

    Function BTCommandExecute() As Long
        Dim erc As Long
        Dim CommandStr As String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe & " /CLOSE"
        Dim args As String() = Environment.GetCommandLineArgs
        If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then

        Else
            Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
        End If
        Return erc
    End Function

    Function BTCommandClose() As Long
        Dim erc As Long
        erc = QEnum.QueueConsumerErrorCodes.OK
        FileClose(m_BTCommandHandle)
        m_BTCommandHandle = 0
        Return erc
    End Function

    Function ProcessBatchCommand(ByVal pCommandStr As System.String) As Long
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Function ProcessLineCommand(ByVal pCommandStr As System.String) As Long
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Function ProcessInternalCommand(ByVal pCommandStr As System.String) As Long
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Function GetFormatFileNameFromTemplateFile(ByVal pTemplateFile As String) As String
        Dim Result As String
        Dim WorkFile As String
        Dim AppSettings As New My.MySettings

        Result = ""

        For Each WorkFile In
            Directory.GetFiles(AppSettings.DocumentPath, pTemplateFile & "_*.btw", SearchOption.TopDirectoryOnly)
            'My.Computer.FileSystem.GetFiles(AppSettings.DocumentPath,
            '                                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
            '                                pTemplateFile & "_*.btw")
            If WorkFile > Result Then
                Result = WorkFile
            End If
        Next

        If Len(Result) = 0 Then
            For Each WorkFile In
                Directory.GetFiles(AppSettings.DocumentPath, "_DEFAULT" & Mid(pTemplateFile, 9) & "_*.btw", SearchOption.TopDirectoryOnly)
                'My.Computer.FileSystem.GetFiles(AppSettings.DocumentPath,
                '                                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                '                                "_DEFAULT" & Mid(pTemplateFile, 9) & "_*.btw")
                If WorkFile > Result Then
                    Result = WorkFile
                End If
            Next
        End If

        Return Result
    End Function

    Function GetFormatFileName() As String
        Return GetFormatFileNameFromTemplateFile(m_TemplateFile)

    End Function




    ''' <summary>
    ''' Attach a printer to this QueueConsumer to begin processing
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <componentid></componentid>
    ''' <author></author>
    ''' <revision></revision>
    ''' <history></history>
    Public Function AttachPrinter(Optional pPrinterId As System.UInt32 = 0, Optional pPrinterName As System.String = "") _
        As Long Implements IQueueProcessing.AttachPrinter
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        'm_QueueProcessMode = QueueProcessMode.Batch

        If pPrinterId = 0 Then
            If Len(Trim(pPrinterName)) = 0 Then
                erc = QEnum.QueueConsumerErrorCodes.NoPrinterSpecified
            Else
                m_AttachedPrinterName = pPrinterName
                m_AttachedPrinterId = LookupPrinterByName(m_AttachedPrinterName)

                If m_AttachedPrinterId = 0 Then
                    m_AttachedPrinterName = ""
                    erc = QEnum.QueueConsumerErrorCodes.InvalidPrinterName
                End If

            End If
        Else
            m_AttachedPrinterId = pPrinterId
            m_AttachedPrinterName = LookupPrinterById(pPrinterId)

            If Len(Trim(m_AttachedPrinterName)) = 0 Then
                m_AttachedPrinterId = 0
                erc = QEnum.QueueConsumerErrorCodes.InvalidPrinterId
            End If

        End If

        m_PrinterId = m_AttachedPrinterId
        m_PrinterName = m_AttachedPrinterName

        Return erc
    End Function

    ''' <summary>
    ''' Prints blank labels after the batch
    ''' </summary>
    ''' <returns>
    ''' QueueConsumerErrorCodes value indicating success or failure of function
    ''' </returns>
    ''' <remarks></remarks>
    ''' <componentid></componentid>
    ''' <author>Anthony W. J. Giambalvo</author>
    ''' <revision></revision>
    ''' <history></history>
    Public Function BatchAfterBlanks() As Long Implements IQueueProcessing.BatchAfterBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        If erc = QEnum.QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function BatchAfterFooter() As Long Implements IQueueProcessing.BatchAfterFooter
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        If erc = QEnum.QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function BatchAfterPause() As Long Implements IQueueProcessing.BatchAfterPause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = $"Batch {Format(m_JobId, "0")} has finished printing on {m_PrinterName}. Click OK to continue."
        PauseWithMessage(CommandStr)
        Return erc
    End Function

    Public Function BatchBeforeBlanks() As Long Implements IQueueProcessing.BatchBeforeBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function BatchBeforeHeader() As Long Implements IQueueProcessing.BatchBeforeHeader
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{Format(m_JobId, "0")}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        If erc = QEnum.QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function BatchBeforePause() As Long Implements IQueueProcessing.BatchBeforePause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = $"Batch { Format(m_JobId, "0")} is ready to print on {m_PrinterName}. Click OK to continue."
        PauseWithMessage(CommandStr) 'ResolveMacros(CommandStr))
        'erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function BatchEnd() As Long Implements IQueueProcessing.BatchEnd
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        ' this function will possibly print the job, waiting for it to finish, then reinitialize the BTCommand file and continue processing the queue

        Return erc
    End Function

    Public Function BatchStart() As Long Implements IQueueProcessing.BatchStart
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function CloseQueue() As Long Implements IQueueProcessing.CloseQueue
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function DetachPrinter() As Long Implements IQueueProcessing.DetachPrinter
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        m_AttachedPrinterId = 0
        m_AttachedPrinterName = ""

        Return erc
    End Function

    Public Function EOQ() As Long Implements IQueueProcessing.EOQ
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function


    Public Function Extras() As Long Implements IQueueProcessing.Extras
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
        vbCrLf
        erc = BTCommandAdd(CommandStr)
        If erc = QEnum.QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function JobAfterBlanks() As Long Implements IQueueProcessing.JobAfterBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function JobAfterFooter() As Long Implements IQueueProcessing.JobAfterFooter
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function JobAfterPause() As Long Implements IQueueProcessing.JobAfterPause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = $"Job {Format(m_JobId, "0")} is finished printing on {m_PrinterName}. Click OK to continue."
        PauseWithMessage(CommandStr) 'ResolveMacros(CommandStr))
        Return erc
    End Function

    Public Function JobBeforeBlanks() As Long Implements IQueueProcessing.JobBeforeBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function JobBeforeHeader() As Long Implements IQueueProcessing.JobBeforeHeader
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function JobBeforePause() As Long Implements IQueueProcessing.JobBeforePause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        CommandStr = $"Job {Format(m_JobId, "0")} is ready to print on {m_PrinterName}. Click OK to continue."
        CommandStr = $"Order {m_SalesOrderNo} is ready to print on {m_PrinterName}. Click OK to continue."
        PauseWithMessage(CommandStr)
        Return erc
    End Function

    Public Function JobEnd() As Long Implements IQueueProcessing.JobEnd
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QEnum.QueueConsumerErrorCodes.OK
        erc = BTCommandClose()
        erc = BTCommandExecute()
        ' Mark all batches in the job as Printed
        Dim args As String() = Environment.GetCommandLineArgs
        If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then

        Else
            erc = BTCommandClose()
            erc = BTCommandExecute()
            'CommandStr = "UPDATE VNA042TB05_Batch SET Printed = 1 WHERE JobId=" & Format(m_JobId, "0")
            Dim job As Job = ctx.Jobs.Find(m_JobId)
            job.Printed = True
            ctx.SaveChanges()

            ''MsgBox(CommandStr)
            'erc = RunSql(CommandStr)
            'CommandStr = "UPDATE VNA042TB04_Job SET Printed = 1 WHERE JobId=" & Format(m_JobId, "0")
            ''MsgBox(CommandStr)
            'erc = RunSql(CommandStr)
        End If

        Return erc
    End Function

    Public Function JobStart() As Long Implements IQueueProcessing.JobStart
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        ' This process should create the command file, open it, and write the file header.
        erc = BTCommandOpen()
        Return erc
    End Function

    Function IsBatchSerialized() As Boolean
        Dim erc As Long

        Dim Result As Boolean

        erc = QEnum.QueueConsumerErrorCodes.OK
        Result = False   ' The default response is that batch is not serialized
        Dim isSerialized = ctx.JobInfos.Where(Function(c) c.JobId = JobId).Select(Function(c) c.Serialized).FirstOrDefault
        If isSerialized Is Nothing Then
            Return Result
        End If
        Return isSerialized
    End Function
    Public Function PalletLabels() As Long Implements IQueueProcessing.PalletLabels
        Dim erc As Long
        Dim CommandStr As System.String
        Dim PrintByLabel As Boolean       ' True=Print by Label, False=Print by Batch
        Dim LabelBatch As String

        erc = QEnum.QueueConsumerErrorCodes.OK
        PrintByLabel = IsBatchSerialized()
        PrintByLabel = False
        If PrintByLabel Then
            LabelBatch = "      <QueryPrompt Name=""qpLabelId"">" & vbCrLf _
                         & $"        <Value>{Format(m_LabelId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                         & $"        <Value>{Format(m_JobId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        End If
        CommandStr = m_BTExe &
                    $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function
    Public Overridable Function Labels() As Long Implements IQueueProcessing.Labels
        Dim erc As Long
        Dim CommandStr As System.String
        Dim PrintByLabel As Boolean       ' True=Print by Label, False=Print by Batch
        Dim LabelBatch As String

        erc = QEnum.QueueConsumerErrorCodes.OK
        PrintByLabel = IsBatchSerialized()
        PrintByLabel = False
        If PrintByLabel Then
            LabelBatch = "      <QueryPrompt Name=""qpLabelId"">" & vbCrLf _
                         & $"        <Value>{Format(m_LabelId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                         & $"        <Value>{Format(m_JobId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        End If
        CommandStr = m_BTExe &
                     $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                     vbCrLf
        erc = BTCommandAdd(CommandStr)
        Return erc
    End Function

    Public Function OpenQueue() As Long Implements IQueueProcessing.OpenQueue
        Dim erc As Long


        ' Make sure BarTender is running before opening the queue.
        m_BTExe = """" & My.Settings.BartendExe & """"
        Shell(m_BTExe & " /MIN", AppWinStyle.MinimizedNoFocus, False, -1)

        erc = QEnum.QueueConsumerErrorCodes.OK
        If Not PrinterIsAttached() Then
            erc = QEnum.QueueConsumerErrorCodes.NoPrinterAttached
        Else
            erc = ReadRecord()

        End If

        Return erc
    End Function

    Public Function PrinterIsAttached() As Boolean Implements IQueueProcessing.PrinterIsAttached
        Return (m_AttachedPrinterId > 0)
    End Function

    Public Function ProcessQueueRecord(jobStep As QEnum.QueueLabelType) As Long Implements IQueueProcessing.ProcessQueueRecord
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        'm_WaitForUserReponse = False

        'Select Case m_Status
        '    Case QEnum.QueueStatus.Pending
        '        erc = WriteStatusProcessing()
        '    Case QEnum.QueueStatus.Processing
        Select Case jobStep
            Case QEnum.QueueLabelType.JobStart
                erc = JobStart()
            Case QEnum.QueueLabelType.JobBeforePause
                erc = JobBeforePause()
            Case QEnum.QueueLabelType.JobBeforeBlanks
                erc = JobBeforeBlanks()
            Case QEnum.QueueLabelType.JobBeforeHeader
                erc = JobBeforeHeader()
            Case QEnum.QueueLabelType.BatchStart
                erc = BatchStart()
            Case QEnum.QueueLabelType.BatchBeforePause
                erc = BatchBeforePause()
            Case QEnum.QueueLabelType.BatchBeforeBlanks
                erc = BatchBeforeBlanks()
            Case QEnum.QueueLabelType.BatchBeforeHeader
                erc = BatchBeforeHeader()
            Case QEnum.QueueLabelType.Labels
                erc = Labels()
            Case QEnum.QueueLabelType.Extras
                erc = Extras()
            Case QEnum.QueueLabelType.PalletLabels
                erc = PalletLabels()
            Case QEnum.QueueLabelType.BatchAfterFooter
                erc = BatchAfterFooter()
            Case QEnum.QueueLabelType.BatchAfterBlanks
                erc = BatchAfterBlanks()
            Case QEnum.QueueLabelType.BatchAfterPause
                erc = BatchAfterPause()
            Case QEnum.QueueLabelType.BatchEnd
                erc = BatchEnd()
            Case QEnum.QueueLabelType.JobAfterFooter
                erc = JobAfterFooter()
            Case QEnum.QueueLabelType.JobAfterBlanks
                erc = JobAfterBlanks()
            Case QEnum.QueueLabelType.JobAfterPause
                erc = JobAfterPause()
            Case QEnum.QueueLabelType.JobEnd
                erc = JobEnd()
        End Select
        If erc = QEnum.QueueConsumerErrorCodes.OK Then
            erc = WriteStatusComplete()
        End If
        'Case QEnum.QueueStatus.Done
        '' This should never happen because completed steps should not show in this view.
        'End Select

        ' Check for the Cancel flag to be set.
        If m_Cancel Then
            CancelJob()
        End If

        Return erc
    End Function

    Private Sub CancelJob()
        'Dim erc As Long

        'erc = RunSql("DELETE FROM VNA042TB07_Queue WHERE JobId=" & Strings.Format(m_JobId, "0") & " AND Status < 2")
    End Sub
    Public Function WriteRecord() As Long Implements IQueueProcessing.WriteRecord
        Dim erc As Long
        ''Dim Ix As Long
        'Dim SqlConnection As New ADODB.Connection
        'Dim SqlProc As New ADODB.Command
        ''Dim SqlStr As System.String
        'Dim ResultSet As New ADODB.Recordset

        erc = QEnum.QueueConsumerErrorCodes.OK
        'SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        'SqlConnection.Open()
        'SqlProc.ActiveConnection = SqlConnection

        'SqlProc.CommandText = "UPDATE VNA042TB07_Queue SET Status = " & Format(m_Status, "0") & " WHERE QueueId = " &
        '                      Format(m_QueueId, "0")
        'SqlProc.Execute()

        Return erc
    End Function

    Public Function WriteStatusComplete() As Long Implements IQueueProcessing.WriteStatusComplete
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        m_Status = QEnum.QueueStatus.Done
        erc = WriteRecord()

        Return erc
    End Function

    Public Function WriteStatusPending() As Long Implements IQueueProcessing.WriteStatusPending
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        m_Status = QEnum.QueueStatus.Pending
        erc = WriteRecord()

        Return erc
    End Function

    Public Function WriteStatusProcessing() As Long Implements IQueueProcessing.WriteStatusProcessing
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK
        m_Status = QEnum.QueueStatus.Processing
        erc = WriteRecord()

        Return erc
    End Function

    Public Function ReadFirstRecordByJob(pJobId As Long) As Long Implements IQueueProcessing.ReadFirstRecordByJob
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function ReadFirstRecordByPrinter(pPrinterName As String) As Long _
        Implements IQueueProcessing.ReadFirstRecordByPrinter
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function ReadRecord() As Long Implements IQueueProcessing.ReadRecord
        Dim erc As Long
        ''Dim Ix As Long
        'Dim SqlConnection As New ADODB.Connection
        'Dim SqlProc As New ADODB.Command
        'Dim ResultSet As New ADODB.Recordset

        erc = QEnum.QueueConsumerErrorCodes.OK
        'SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        'SqlConnection.Open()
        'SqlProc.ActiveConnection = SqlConnection

        ''SqlProc.CommandText = "SELECT Top 1 * FROM VNA042VW2X_Queue_JobInfo WHERE QStatus < 2 ORDER BY QueueId"
        ''SqlProc.CommandText = "SELECT * FROM VNA042VW36_Profile_WithUnprintedJobs WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0")
        'SqlProc.CommandText = "SELECT Top 1 * FROM VNA042VW2X_Queue_JobInfo WHERE PrinterId = " &
        '                      Strings.Format(m_AttachedPrinterId, "0") & " AND QStatus < 2 ORDER BY QueueId"
        'ResultSet = SqlProc.Execute()
        ''ResultSet.MoveFirst()

        'If ResultSet.EOF Then
        '    erc = QEnum.QueueConsumerErrorCodes.EmptyQueue
        '    m_QueueId = 0
        '    m_JobId = 0
        '    m_BatchId = 0
        '    m_LabelId = 0
        '    m_CopiesPerLabel = 0
        '    m_LabelType = 0
        '    m_TemplateId = 0
        '    m_TemplateFile = ""
        '    m_SalesOrderNo = ""
        'Else
        '    ResultSet.MoveFirst()
        '    m_QueueId = ResultSet.Fields("QueueId").Value
        '    m_JobId = ResultSet.Fields("JobId").Value
        '    m_BatchId = ResultSet.Fields("BatchId").Value
        '    m_LabelId = ResultSet.Fields("LabelId").Value
        '    m_CopiesPerLabel = ResultSet.Fields("CopiesPerLabel").Value
        '    m_LabelType = ResultSet.Fields("QStep").Value
        '    m_TemplateId = ResultSet.Fields("TemplateId").Value
        '    m_TemplateFile = ResultSet.Fields("TemplateFile").Value.ToString() & ""
        '    m_Status = ResultSet.Fields("QStatus").Value
        '    m_SalesOrderNo = ResultSet.Fields("SalesOrderNo").Value
        'End If

        'ResultSet.Close()

        Return erc
    End Function

    Public Function ReadRecordByQueueId(pQueueId As Long) As Long Implements IQueueProcessing.ReadRecordByQueueId
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function RunStep() As Long Implements IQueueProcessing.RunStep
        Dim erc As Long

        erc = QEnum.QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Function WaitForUserResponse() As Long Implements IQueueProcessing.WaitForUserResponse
        MsgBox("Printing paused. Click OK to continue.")
        Return QEnum.QueueConsumerErrorCodes.OK
    End Function

    Private Sub PauseWithMessage(ByVal pMessage As String)
        Dim CommandStr As String
        Dim mbOkCancel As Integer
        Dim mbYesNo As Integer

        CommandStr = "LabelMaker_Pause """ & pMessage & """"
        Print(m_BTCommandHandle, CommandStr & vbCrLf)
        Do
            mbOkCancel = MsgBox(pMessage, MsgBoxStyle.OkCancel, "LabelMaker")
            Select Case mbOkCancel
                Case MsgBoxResult.Ok
                    ' Do nothing, proceed normally.
                Case MsgBoxResult.Cancel
                    ' Verify cancellation
                    mbYesNo = MsgBox("You have chosen to stop printing labels.  Is that correct?", MsgBoxStyle.YesNo,
                                     "LabelMaker: Cancel Print Job")
                    Select Case mbYesNo
                        Case MsgBoxResult.Yes
                        Case MsgBoxResult.No
                            ' Continue printing labels
                        Case Else

                    End Select
                Case Else

            End Select
        Loop _
            Until _
                (mbOkCancel = MsgBoxResult.Ok) OrElse
                ((mbOkCancel = MsgBoxResult.Cancel) And (mbYesNo = MsgBoxResult.Yes))
    End Sub

    Function ClearFormats() As Long Implements IQueueProcessing.ClearFormats
        Dim erc As Long
        Dim CommandStr As String

        erc = QEnum.QueueConsumerErrorCodes.OK
        If Len(m_BTExe) < 3 Then
            m_BTExe = """" & My.Settings.BartendExe & """"
        End If

        CommandStr = m_BTExe & " /CLOSE /MIN"
        BTCommandAdd(CommandStr)
        'Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
        Return erc
    End Function

    Function AddFormat(ByVal pFormatName As String) As Long Implements IQueueProcessing.AddFormat
        Dim erc As Long
        Dim CommandStr As String

        erc = QEnum.QueueConsumerErrorCodes.OK
        If Len(m_BTExe) < 3 Then
            m_BTExe = """" & My.Settings.BartendExe & """"
        End If

        CommandStr = m_BTExe & " /F=""" & GetFormatFileNameFromTemplateFile(pFormatName) & """ /MIN"
        BTCommandAdd(CommandStr)
        'Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
        Return erc
    End Function
#Region "Properties"
    'Public Property BatchId As Long Implements IQueueProcessing.BatchId
    '    Get
    '        Return m_BatchId
    '    End Get
    '    Set(value As Long)
    '        m_BatchId = value
    '    End Set
    'End Property

    Public Property CopiesPerLabel As Long Implements IQueueProcessing.CopiesPerLabel
        Get
            Return m_CopiesPerLabel
        End Get
        Set(value As Long)
            m_CopiesPerLabel = value
        End Set
    End Property

    Public Property JobId As Long Implements IQueueProcessing.JobId
        Get
            Return m_JobId
        End Get
        Set(value As Long)
            m_JobId = value
        End Set
    End Property

    Public Property LabelId As Long Implements IQueueProcessing.LabelId
        Get
            Return m_LabelId
        End Get
        Set(value As Long)
            m_LabelId = value
        End Set
    End Property

    Public Property LabelType As Long Implements IQueueProcessing.LabelType
        Get
            Return m_LabelType
        End Get
        Set(value As Long)
            m_LabelType = value
        End Set
    End Property

    Public Property PrinterId As Long Implements IQueueProcessing.PrinterId
        Get
            Return m_PrinterId
        End Get
        Set(value As Long)
            m_PrinterId = value
        End Set
    End Property

    Public Property PrinterName As String Implements IQueueProcessing.PrinterName
        Get
            Return m_PrinterName
        End Get
        Set(value As String)
            m_PrinterName = value
        End Set
    End Property

    Public Property ProfileId As Long Implements IQueueProcessing.ProfileId
        Get
            Return m_ProfileId
        End Get
        Set(value As Long)
            m_ProfileId = value
        End Set
    End Property

    Public Property QueueId As Long Implements IQueueProcessing.QueueId
        Get
            Return m_QueueId
        End Get
        Set(value As Long)
            m_QueueId = value
        End Set
    End Property

    Public Property Status As Long Implements IQueueProcessing.Status
        Get
            Return m_Status
        End Get
        Set(value As Long)
            Select Case value
                Case QEnum.QueueStatus.Pending, QEnum.QueueStatus.Processing, QEnum.QueueStatus.Done
                    m_Status = value
                Case Else
                    ' Invalid value, no change made
            End Select
        End Set
    End Property


    Public Property TemplateFile As String Implements IQueueProcessing.TemplateFile
        Get
            Return m_TemplateFile
        End Get
        Set(value As String)
            m_TemplateFile = value
        End Set
    End Property

    Public Property TemplateId As Long Implements IQueueProcessing.TemplateId
        Get
            Return m_TemplateId
        End Get
        Set(value As Long)
            m_TemplateId = value
        End Set
    End Property
    Public Property BTExe As String Implements IQueueProcessing.BTExe
        Get
            Return m_BTExe
        End Get
        Set(value As String)
            m_BTExe = value
        End Set
    End Property
    'Public Property JobStepInfo As T Implements IQueueProcessing.JobStepInfo
    '    Get

    '        Return m_JobStepInfo
    '    End Get
    '    Set(value As T)
    '        m_JobStepInfo = value
    '    End Set
    'End Property

    Public JobStepToQType As Dictionary(Of String, QEnum.QueueLabelType) = New Dictionary(Of String, QEnum.QueueLabelType) From
        {
        {"JobStart", QEnum.QueueLabelType.JobStart},
        {"JobBeforePause", QEnum.QueueLabelType.JobBeforePause},
        {"JobBeforeBlanks", QEnum.QueueLabelType.JobBeforeBlanks},
        {"JobBeforeHeader", QEnum.QueueLabelType.JobBeforeHeader},
        {"BatchStart", QEnum.QueueLabelType.BatchStart},
        {"BatchBeforePause", QEnum.QueueLabelType.BatchBeforePause},
        {"BatchBeforeBlanks", QEnum.QueueLabelType.BatchBeforeBlanks},
        {"BatchBeforeHeader", QEnum.QueueLabelType.BatchBeforeHeader},
        {"Label", QEnum.QueueLabelType.Labels},
        {"ExtraLabel", QEnum.QueueLabelType.Extras},
        {"PalletLabel", QEnum.QueueLabelType.PalletLabels},
        {"BatchAfterFooter", QEnum.QueueLabelType.BatchAfterFooter},
        {"BatchAfterBlanks", QEnum.QueueLabelType.BatchAfterBlanks},
        {"BatchAfterPause", QEnum.QueueLabelType.BatchAfterPause},
        {"BatchEnd", QEnum.QueueLabelType.BatchEnd},
        {"JobAfterFooter", QEnum.QueueLabelType.JobAfterFooter},
        {"JobAfterBlanks", QEnum.QueueLabelType.JobAfterBlanks},
        {"JobAfterPause", QEnum.QueueLabelType.JobAfterPause},
        {"JobEnd", QEnum.QueueLabelType.JobEnd}
        }

#End Region
End Class
