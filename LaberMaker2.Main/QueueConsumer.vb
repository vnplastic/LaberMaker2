Option Explicit On

Public Interface IQueueConsumer
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
    'Property WaitForUserReponse() As Boolean
    Function AttachPrinter(Optional pPrinterId As System.UInt32 = 0, Optional pPrinterName As System.String = "") _
        As Long

    Function PrinterIsAttached() As Boolean
    Function DetachPrinter() As Long
    Function OpenQueue() As Long
    Function ProcessQueueRecord() As Long
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

#Const CLSID_QueueConsumer = "{00000000-010b-11e2-8000-0026b9825f00}"
#Const IID_IQueueConsumer0 = "{00000000-010b-11e2-8001-0026b9825f00}"
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
    Batch = 1
    CommandLine = 2
    Internal = 3
End Enum
#End Region


Public Class QueueConsumer
    Implements IQueueConsumer
#Region "Fields"
    Private m_QueueId As Long
    Private m_ProfileId As Long
    Private m_JobId As Long
    Private m_BatchId As Long
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
    Private m_QueueProcessMode As QueueProcessMode
    Private m_BTCommandFile As String
    Private m_BTCommandHandle As Long
    'Private m_BTE As New Seagull.BarTender.Print.Engine
    'Private m_BTD As Seagull.BarTender.Print.Documents
    Private m_BTExe As String
    Private m_WaitForUserReponse As Boolean
    Private m_SalesOrderNo As String
    Private m_Cancel As Boolean
#End Region
    Sub New()
        m_QueueProcessMode = QueueProcessMode.CommandLine
        m_Cancel = False
    End Sub

    Private Function MacroValueStr(ByVal pMacroName As System.String, ByRef pResult As System.String) As Long
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Private Function MacroValueLong(ByVal pMacroName As System.String, ByRef pResult As System.Int64) As Long
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    'Private Function ResolveMacros(ByVal pInStr As String) As String
    '    Dim Result As String
    '    Dim P1 As Integer
    '    Dim P2 As Integer
    '    Dim MacroName As String
    '    Dim MacroValue As String

    '    Result = pInStr
    '    P1 = InStr(Result, "{$")
    '    Do While P1 > 0
    '        P2 = InStr(P1 + 2, Result, "$}")
    '        If P2 > 0 Then
    '            MacroName = Mid$(Result, P1 + 2, P2 - (P1 + 2))
    '            Select Case UCase$(MacroName)
    '                Case "QUEUEID"
    '                    MacroValue = Format(m_QueueId, "0")
    '                Case "PROFILEID"
    '                    MacroValue = Format(m_ProfileId, "0")
    '                Case "JOBID"
    '                    MacroValue = Format(m_JobId, "0")
    '                Case "BATCHID"
    '                    MacroValue = Format(m_BatchId, "0")
    '                Case "LABELID"
    '                    MacroValue = Format(m_LabelId, "0")
    '                Case "LABELTYPE"
    '                    MacroValue = Format(m_LabelType, "0")
    '                Case "COPIESPERLABEL"
    '                    MacroValue = Format(m_CopiesPerLabel, "0")
    '                Case "TEMPLATEID"
    '                    MacroValue = Format(m_TemplateId, "0")
    '                Case "TEMPLATEFILE"
    '                    MacroValue = m_TemplateFile
    '                Case "PRINTERID"
    '                    MacroValue = Format(m_PrinterId, "0")
    '                Case "PRINTERNAME"
    '                    MacroValue = m_PrinterName
    '                Case "STATUS"
    '                    MacroValue = Format(m_Status, "0")
    '                Case "ATTACHEDPRINTERID"
    '                    MacroValue = Format(m_AttachedPrinterId, "0")
    '                Case "ATTACHEDPRINTERNAME"
    '                    MacroValue = m_AttachedPrinterName
    '                Case "FORMATPATH"
    '                    MacroValue = "V:\LabelMaker\Format"
    '                Case "BATCHPATH"
    '                    MacroValue = "V:\LabelMaker\Batch"
    '                Case "FORMATNAME"
    '                    MacroValue = GetFormatFileName()
    '                Case "SALESORDERNO", "FSONO"
    '                    MacroValue = m_SalesOrderNo
    '                Case Else
    '                    MacroValue = ""
    '            End Select
    '            Result = Left(Result, P1 - 1) & MacroValue & Mid(Result, P2 + 2)
    '            P1 = InStr(Result, "{$")
    '        Else
    '            P1 = 0
    '        End If
    '        System.Windows.Forms.Application.DoEvents()
    '    Loop

    '    Return Result
    'End Function


    Private Function BTCommandOpen() As Long
        Dim erc As Long
        Dim CommandStr As String

        erc = QueueConsumerErrorCodes.OK
        'm_QueueProcessMode = QueueProcessMode.Batch
        m_QueueProcessMode = QueueProcessMode.CommandLine

        If m_BTCommandHandle = 0 Then
            m_BTCommandHandle = FreeFile()
            m_BTCommandFile = My.Settings.BatchPath & "\Job" & Format(m_JobId, "000000")
            Select Case m_QueueProcessMode
                Case QueueProcessMode.Batch
                    m_BTCommandFile &= ".btbat"
                    'MsgBox("Opening Command File: " & m_BTCommandFile)
                    FileOpen(m_BTCommandHandle, m_BTCommandFile, OpenMode.Output, OpenAccess.Default, OpenShare.Default)
                    'Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileWriter(m_BTCommandFile, False)
                    CommandStr = "<?xml version=""1.0""?>" & vbCrLf & "<XMLScript Version=""2.0"">" & vbCrLf &
                                 "  <Command>" & vbCrLf
                    erc = BTCommandAdd(CommandStr)
                Case QueueProcessMode.CommandLine
                    'm_BTExe = """" & My.Settings.BartendExe & """"
                    m_BTCommandFile &= ".cmd"
                    FileOpen(m_BTCommandHandle, m_BTCommandFile, OpenMode.Output, OpenAccess.Default, OpenShare.Default)
                    'CommandStr = "@echo off" & vbCrLf
                    'erc = BTCommandAdd(CommandStr)
                Case QueueProcessMode.Internal
                    m_BTCommandFile = ""
                Case Else
                    erc = QueueConsumerErrorCodes.InvalidProcessMode
            End Select
        End If

        Return erc
    End Function

    Private Function BTCommandAdd(ByVal pCommandStr As System.String) As Long
        Dim erc As Long
        Dim CommandStr As String

        erc = QueueConsumerErrorCodes.OK

        If m_BTCommandHandle = 0 Then
            erc = BTCommandOpen()
        End If

        If erc = QueueConsumerErrorCodes.OK Then
            Select Case m_QueueProcessMode
                Case QueueProcessMode.Batch
                    Print(m_BTCommandHandle, pCommandStr)' ResolveMacros(pCommandStr))
                Case QueueProcessMode.CommandLine
                    CommandStr = pCommandStr ' ResolveMacros(pCommandStr)
                    If Right$(CommandStr, Len(vbCrLf)) <> vbCrLf Then CommandStr &= vbCrLf
                    Print(m_BTCommandHandle, CommandStr)
                    Dim args As String() = Environment.GetCommandLineArgs
                    If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then

                    Else

                        Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
                    End If
                Case QueueProcessMode.Internal
                    '
                Case Else
                    erc = QueueConsumerErrorCodes.InvalidProcessMode
            End Select
        End If

        Return erc
    End Function

    'Private Function BTCommandBuild()
    'End Function

    Private Function BTCommandExecute() As Long
        Dim erc As Long
        Dim CommandStr As String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                'MsgBox("Executing BTBatch: " & m_BTCommandFile)
                'erc = CLng(Shell("btbatch " & m_BTCommandFile, AppWinStyle.Hide, True, -1))
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe & " /CLOSE"
                Dim args As String() = Environment.GetCommandLineArgs
                If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then

                Else
                    Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
                End If
                'erc = CLng(Shell(m_BTCommandFile, AppWinStyle.Hide, False, -1))
            Case QueueProcessMode.Internal
                '
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Private Function BTCommandClose() As Long
        Dim erc As Long
        Dim CommandStr As String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                'MsgBox("Closing '" & m_BTCommandFile & "'")
                CommandStr = "  </Command>" & vbCrLf & "</XMLScript>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
                FileClose(m_BTCommandHandle)
                m_BTCommandHandle = 0
            Case QueueProcessMode.CommandLine
                FileClose(m_BTCommandHandle)
                m_BTCommandHandle = 0
            Case QueueProcessMode.Internal
                '
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Private Function ProcessBatchCommand(ByVal pCommandStr As System.String) As Long
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Private Function ProcessLineCommand(ByVal pCommandStr As System.String) As Long
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Private Function ProcessInternalCommand(ByVal pCommandStr As System.String) As Long
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Private Function GetFormatFileNameFromTemplateFile(ByVal pTemplateFile As String) As String
        Dim Result As String
        Dim WorkFile As String
        Dim AppSettings As New My.MySettings

        Result = ""

        For Each WorkFile In
            My.Computer.FileSystem.GetFiles(AppSettings.DocumentPath,
                                            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                            pTemplateFile & "_*.btw")
            If WorkFile > Result Then
                Result = WorkFile
            End If
        Next

        If Len(Result) = 0 Then
            For Each WorkFile In
                My.Computer.FileSystem.GetFiles(AppSettings.DocumentPath,
                                                Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                                "_DEFAULT" & Mid(pTemplateFile, 9) & "_*.btw")
                If WorkFile > Result Then
                    Result = WorkFile
                End If
            Next
        End If

        Return Result
    End Function

    Private Function GetFormatFileName() As String
        Return GetFormatFileNameFromTemplateFile(m_TemplateFile)

        'Dim Result As String
        'Dim WorkFile As String
        'Dim AppSettings As New My.MySettings

        'Result = ""

        'For Each WorkFile In My.Computer.FileSystem.GetFiles(AppSettings.DocumentPath, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, m_TemplateFile & "_*.btw")
        '  If WorkFile > Result Then
        '    Result = WorkFile
        '  End If
        'Next

        'If Len(Result) = 0 Then
        '  For Each WorkFile In My.Computer.FileSystem.GetFiles(AppSettings.DocumentPath, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "_DEFAULT" & Mid(m_TemplateFile, 9) & "_*.btw")
        '    If WorkFile > Result Then
        '      Result = WorkFile
        '    End If
        '  Next
        'End If

        'Return Result
    End Function

    Private Function LookupPrinterByName(ByVal pPrinterName As System.String) As System.UInt32
        Dim Result As System.UInt32
        'Dim PrinterTable As New LabelMaker.M2MReports2DataSet1.VNA042VW1E_ActivePrintersDataTable
        'Dim PrinterRow As LabelMaker.M2MReports2DataSet1.VNA042VW1E_ActivePrintersRow
        'Dim PrinterCount As System.UInt32
        'Dim Ix As Integer
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim ResultSet As New ADODB.Recordset
        Dim erc As Long

        Result = 0
        erc = QueueConsumerErrorCodes.OK

        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        'SqlProc.CommandText = "SELECT * FROM VNA042VW36_Profile_WithUnprintedJobs WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0")
        SqlProc.CommandText = "SELECT PrinterId FROM VNA042TB01_Printer WHERE PrinterName = '" & pPrinterName & "'"
        ResultSet = SqlProc.Execute()

        ResultSet.MoveFirst()
        'If ResultSet.RecordCount < 1 Then
        'erc = QueueConsumerErrorCodes.InvalidPrinterName
        'Result = 0
        'Else
        Result = ResultSet.Fields("PrinterId").Value
        'End If

        '    PrinterTable.Load(PrinterTable.CreateDataReader())
        '    PrinterTable
        '    PrinterCount = PrinterTable.Count
        '    Result = 0
        '
        '    For Ix = 1 To PrinterCount
        ' PrinterRow = PrinterTable.Item(Ix)
        ' If UCase(PrinterRow.PrinterName) = UCase(pPrinterName) Then
        ' Result = PrinterRow.PrinterID
        ' Exit For
        ' End If
        ' Next

        Return Result
    End Function

    Private Function LookupPrinterById(ByVal pPrinterId As System.UInt32) As System.String
        Dim Result As System.String
        'Dim PrinterTable As New LabelMaker.M2MReports2DataSet1.VNA042VW1E_ActivePrintersDataTable
        'Dim PrinterRow As LabelMaker.M2MReports2DataSet1.VNA042VW1E_ActivePrintersRow
        'Dim PrinterCount As System.UInt32
        'Dim Ix As Integer
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim ResultSet As New ADODB.Recordset
        Dim erc As Long

        Result = 0
        erc = QueueConsumerErrorCodes.OK

        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        'SqlProc.CommandText = "SELECT * FROM VNA042VW36_Profile_WithUnprintedJobs WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0")
        SqlProc.CommandText = "SELECT PrinterName FROM VNA042TB01_Printer WHERE PrinterId = " & pPrinterId
        ResultSet = SqlProc.Execute()

        If ResultSet.State = 1 Then
            ResultSet.MoveFirst()
            Result = ResultSet.Fields("PrinterName").Value
        End If

        'PrinterCount = PrinterTable.Count
        'Result = ""

        'For Ix = 1 To PrinterCount
        '  PrinterRow = PrinterTable.Item(Ix)
        '  If PrinterRow.PrinterID = pPrinterId Then
        '    Result = PrinterRow.PrinterName
        '    Exit For
        '  End If
        'Next

        Return Result
    End Function

    Private Function RunSql(ByVal pCommand As String) As Long
        Dim erc As Long
        'Dim Ix As Long
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        'Dim SqlStr As System.String
        'Dim ResultSet As New ADODB.Recordset

        erc = QueueConsumerErrorCodes.OK
        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        SqlProc.CommandText = pCommand _
        ' "UPDATE VNA042TB07_Queue SET Status = " & Format(m_Status, "0") & " WHERE QueueId = " & Format(m_QueueId, "0")
        SqlProc.Execute()
        SqlConnection.Close()

        Return erc
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
        As Long Implements IQueueConsumer.AttachPrinter
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        'm_QueueProcessMode = QueueProcessMode.Batch

        If pPrinterId = 0 Then
            If Len(Trim(pPrinterName)) = 0 Then
                erc = QueueConsumerErrorCodes.NoPrinterSpecified
            Else
                m_AttachedPrinterName = pPrinterName
                m_AttachedPrinterId = LookupPrinterByName(m_AttachedPrinterName)

                If m_AttachedPrinterId = 0 Then
                    m_AttachedPrinterName = ""
                    erc = QueueConsumerErrorCodes.InvalidPrinterName
                End If

            End If
        Else
            m_AttachedPrinterId = pPrinterId
            m_AttachedPrinterName = LookupPrinterById(pPrinterId)

            If Len(Trim(m_AttachedPrinterName)) = 0 Then
                m_AttachedPrinterId = 0
                erc = QueueConsumerErrorCodes.InvalidPrinterId
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
    Public Function BatchAfterBlanks() As Long Implements IQueueConsumer.BatchAfterBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                             & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine

                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        If erc = QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function BatchAfterFooter() As Long Implements IQueueConsumer.BatchAfterFooter
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                             & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine

                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        If erc = QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function BatchAfterPause() As Long Implements IQueueConsumer.BatchAfterPause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                ' This process should write the end of the command file, close the command file and cause it to be printed.
                erc = BTCommandClose()
                erc = BTCommandExecute()
                MsgBox(
                    "Job " & String.Format(m_JobId, "0") & ", Batch " & String.Format(m_BatchId, "0") &
                    " has finished processing. Click OK to continue.")
                erc = BTCommandOpen()
            Case QueueProcessMode.CommandLine

                CommandStr = $"Batch {Format(m_BatchId, "0")} has finished printing on {m_PrinterName}. Click OK to continue."
                PauseWithMessage(CommandStr)
                'erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function BatchBeforeBlanks() As Long Implements IQueueConsumer.BatchBeforeBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                             & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine

                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function BatchBeforeHeader() As Long Implements IQueueConsumer.BatchBeforeHeader
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                             & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{Format(m_BatchId, "0")}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine

                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{Format(m_BatchId, "0")}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        If erc = QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function BatchBeforePause() As Long Implements IQueueConsumer.BatchBeforePause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                ' This process should write the end of the command file, close the command file and cause it to be printed.
                erc = BTCommandClose()
                erc = BTCommandExecute()
                MsgBox(
                    "Job " & String.Format(m_JobId, "0") & ", Batch " & String.Format(m_BatchId, "0") &
                    " is ready to print. Click OK to continue.")
                erc = BTCommandOpen()
            Case QueueProcessMode.CommandLine
                CommandStr = $"Batch { Format(m_BatchId, "0")} is ready to print on {m_PrinterName}. Click OK to continue."
                PauseWithMessage(CommandStr)'ResolveMacros(CommandStr))
                'erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function BatchEnd() As Long Implements IQueueConsumer.BatchEnd
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        ' this function will possibly print the job, waiting for it to finish, then reinitialize the BTCommand file and continue processing the queue

        Return erc
    End Function

    Public Function BatchStart() As Long Implements IQueueConsumer.BatchStart
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function CloseQueue() As Long Implements IQueueConsumer.CloseQueue
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function DetachPrinter() As Long Implements IQueueConsumer.DetachPrinter
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        m_AttachedPrinterId = 0
        m_AttachedPrinterName = ""

        Return erc
    End Function

    Public Function EOQ() As Long Implements IQueueConsumer.EOQ
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function


    Public Function Extras() As Long Implements IQueueConsumer.Extras
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                             & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        If erc = QueueConsumerErrorCodes.OK Then
        End If

        Return erc
    End Function

    Public Function JobAfterBlanks() As Long Implements IQueueConsumer.JobAfterBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpJobId"">" & vbCrLf _
                             & $"        <Value>{Format(m_JobId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)

            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function JobAfterFooter() As Long Implements IQueueConsumer.JobAfterFooter
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpJobId"">" & vbCrLf _
                             & $"        <Value>{Format(m_JobId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function JobAfterPause() As Long Implements IQueueConsumer.JobAfterPause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                ' This process should write the end of the command file, close the command file and cause it to be printed.
                erc = BTCommandClose()
                erc = BTCommandExecute()
                MsgBox("Job " & String.Format(m_JobId, "0") & " is finished processing. Click OK to continue.")
                erc = BTCommandOpen()
            Case QueueProcessMode.CommandLine
                'CommandStr = "Job {$JobId$} is finished printing on {$PrinterName$}. Click OK to continue."
                CommandStr = $"Job {Format(m_JobId, "0")} is finished printing on {m_PrinterName}. Click OK to continue."
                PauseWithMessage(CommandStr)'ResolveMacros(CommandStr))
                'erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function JobBeforeBlanks() As Long Implements IQueueConsumer.JobBeforeBlanks
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpJobId"">" & vbCrLf _
                             & $"        <Value>{Format(m_JobId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function JobBeforeHeader() As Long Implements IQueueConsumer.JobBeforeHeader
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & "      <QueryPrompt Name=""qpJobId"">" & vbCrLf _
                             & $"        <Value>{Format(m_JobId, "0")}</Value>" & vbCrLf _
                             & "      </QueryPrompt>" & vbCrLf _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpJobId=""{Format(m_JobId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function JobBeforePause() As Long Implements IQueueConsumer.JobBeforePause
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                ' This process should write the end of the command file, close the command file and cause it to be printed.
                erc = BTCommandClose()
                erc = BTCommandExecute()
                MsgBox("Job " & String.Format(m_JobId, "0") & " is ready to print. Click OK to continue.")
                erc = BTCommandOpen()
            Case QueueProcessMode.CommandLine
                CommandStr = $"Job {Format(m_JobId, "0")} is ready to print on {m_PrinterName}. Click OK to continue."
                CommandStr = $"Order {m_SalesOrderNo} is ready to print on {m_PrinterName}. Click OK to continue."
                PauseWithMessage(CommandStr)
                'erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function JobEnd() As Long Implements IQueueConsumer.JobEnd
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                ' This process should write the end of the command file, close the command file and cause it to be printed.
                erc = BTCommandClose()
                erc = BTCommandExecute()
            Case QueueProcessMode.CommandLine
                erc = BTCommandClose()
                erc = BTCommandExecute()
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        ' Mark all batches in the job as Printed
        Dim args As String() = Environment.GetCommandLineArgs
        If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then

        Else
            CommandStr = "UPDATE VNA042TB05_Batch SET Printed = 1 WHERE JobId=" & Format(m_JobId, "0")
            'MsgBox(CommandStr)
            erc = RunSql(CommandStr)
            CommandStr = "UPDATE VNA042TB04_Job SET Printed = 1 WHERE JobId=" & Format(m_JobId, "0")
            'MsgBox(CommandStr)
            erc = RunSql(CommandStr)
        End If

        Return erc
    End Function

    Public Function JobStart() As Long Implements IQueueConsumer.JobStart
        Dim erc As Long
        Dim CommandStr As System.String

        erc = QueueConsumerErrorCodes.OK

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                ' This process should create the command file, open it, and write the file header.
                erc = BTCommandOpen()
            Case QueueProcessMode.CommandLine
                ' This process should create the command file, open it, and write the file header.
                erc = BTCommandOpen()
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Private Function IsBatchSerialized() As Boolean
        Dim erc As Long
        'Dim Ix As Long
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        'Dim SqlStr As System.String
        Dim ResultSet As New ADODB.Recordset
        Dim Result As Boolean

        erc = QueueConsumerErrorCodes.OK
        Result = False   ' The default response is that batch is not serialized

        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        SqlProc.CommandText = "SELECT [Serialized] FROM VNA042TB05_Batch WHERE BatchId=" & String.Format(m_BatchId, "0")
        ResultSet = SqlProc.Execute()
        If Not ResultSet.EOF Then
            ResultSet.MoveFirst()
            If ResultSet.Fields("Serialized").Value = True Then
                Result = True
            Else
                Result = False
            End If
        End If
        ResultSet.Close()
        SqlConnection.Close()

        Return Result
    End Function
    Public Function PalletLabels() As Long Implements IQueueConsumer.PalletLabels
        Dim erc As Long
        Dim CommandStr As System.String
        Dim PrintByLabel As Boolean       ' True=Print by Label, False=Print by Batch
        Dim LabelBatch As String

        erc = QueueConsumerErrorCodes.OK
        PrintByLabel = IsBatchSerialized()
        PrintByLabel = False
        If PrintByLabel Then
            LabelBatch = "      <QueryPrompt Name=""qpLabelId"">" & vbCrLf _
                         & $"        <Value>{Format(m_LabelId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                         & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        End If

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch

                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & LabelBatch _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                            $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function
    Public Function Labels() As Long Implements IQueueConsumer.Labels
        Dim erc As Long
        Dim CommandStr As System.String
        Dim PrintByLabel As Boolean       ' True=Print by Label, False=Print by Batch
        Dim LabelBatch As String

        erc = QueueConsumerErrorCodes.OK
        PrintByLabel = IsBatchSerialized()
        PrintByLabel = False
        If PrintByLabel Then
            LabelBatch = "      <QueryPrompt Name=""qpLabelId"">" & vbCrLf _
                         & $"        <Value>{Format(m_LabelId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        Else
            LabelBatch = "      <QueryPrompt Name=""qpBatchId"">" & vbCrLf _
                         & $"        <Value>{Format(m_BatchId, "0")}</Value>" & vbCrLf _
                         & "      </QueryPrompt>" & vbCrLf
        End If

        Select Case m_QueueProcessMode
            Case QueueProcessMode.Batch
                CommandStr = "    <Print ReturnPrintData=""false"">" & vbCrLf _
                             & $"      <Format CloseAtEndOfJob=""true"" SaveAtEndOfJob=""false"">{GetFormatFileName()}</Format>" &
                             vbCrLf _
                             & LabelBatch _
                             & "      <PrintSetup>" & vbCrLf _
                             & $"        <Printer>{m_PrinterName}</Printer>" & vbCrLf _
                             & "        <UseDatabase>true</UseDatabase>" & vbCrLf _
                             & "      </PrintSetup>" & vbCrLf _
                             & "    </Print>" & vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.CommandLine
                CommandStr = m_BTExe &
                             $" /AF=""{GetFormatFileName()}"" /?qpBatchId=""{Format(m_BatchId, "0")}"" /PRN=""{m_PrinterName}"" /MIN=Taskbar /NOSPLASH /P" &
                             vbCrLf
                erc = BTCommandAdd(CommandStr)
            Case QueueProcessMode.Internal
                CommandStr = ""
                erc = BTCommandAdd(CommandStr)
            Case Else
                erc = QueueConsumerErrorCodes.InvalidProcessMode
        End Select

        Return erc
    End Function

    Public Function OpenQueue() As Long Implements IQueueConsumer.OpenQueue
        Dim erc As Long
        'Dim Ix As Long
        'Dim SqlConnection As New ADODB.Connection
        'Dim SqlProc As New ADODB.Command
        'Dim ResultSet As New ADODB.Recordset

        ' Make sure BarTender is running before opening the queue.
        m_BTExe = """" & My.Settings.BartendExe & """"
        Shell(m_BTExe & " /MIN", AppWinStyle.MinimizedNoFocus, False, -1)

        erc = QueueConsumerErrorCodes.OK
        If Not PrinterIsAttached() Then
            erc = QueueConsumerErrorCodes.NoPrinterAttached
        Else
            erc = ReadRecord()
            'SqlConnection.ConnectionString = "M2MReports2"
            'SqlConnection.Open()
            'SqlProc.ActiveConnection = SqlConnection

            ''SqlProc.CommandText = "SELECT * FROM VNA042VW36_Profile_WithUnprintedJobs WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0")
            ''SqlProc.CommandText = "SELECT * FROM VNA042VW2X_Queue_JobInfo WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0")
            'SqlProc.CommandText = "SELECT Top 1 * FROM VNA042VW2X_Queue_JobInfo WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0") & " AND QStatus < 2 ORDER BY QueueId"
            'ResultSet = SqlProc.Execute()
            'ResultSet.MoveFirst()
            'If ResultSet.EOF Then
            '  erc = QueueConsumerErrorCodes.EmptyQueue
            '  m_QueueId = 0
            '  m_JobId = 0
            '  m_BatchId = 0
            '  m_LabelId = 0
            '  m_CopiesPerLabel = 0
            '  m_LabelType = 0
            '  m_TemplateId = 0
            '  m_TemplateFile = ""
            'Else
            '  ResultSet.MoveFirst()
            '  m_QueueId = ResultSet.Fields("QueueId").Value
            '  m_JobId = ResultSet.Fields("JobId").Value
            '  m_BatchId = ResultSet.Fields("BatchId").Value
            '  m_LabelId = ResultSet.Fields("LabelId").Value
            '  m_CopiesPerLabel = ResultSet.Fields("CopiesPerLabel").Value
            '  m_LabelType = ResultSet.Fields("QStep").Value
            '  m_TemplateId = ResultSet.Fields("TemplateId").Value
            '  m_TemplateFile = ResultSet.Fields("TemplateFile").Value.ToString() & ""
            '  m_Status = ResultSet.Fields("QStatus").Value
            'End If

            'ResultSet.Close()
        End If

        Return erc
    End Function

    Public Function PrinterIsAttached() As Boolean Implements IQueueConsumer.PrinterIsAttached
        Return (m_AttachedPrinterId > 0)
    End Function

    Public Function ProcessQueueRecord() As Long Implements IQueueConsumer.ProcessQueueRecord
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        m_WaitForUserReponse = False

        Select Case m_Status
            Case QueueStatus.Pending
                erc = WriteStatusProcessing()
            Case QueueStatus.Processing
                Select Case m_LabelType
                    Case QueueLabelType.JobStart
                        erc = JobStart()
                    Case QueueLabelType.JobBeforePause
                        erc = JobBeforePause()
                    Case QueueLabelType.JobBeforeBlanks
                        erc = JobBeforeBlanks()
                    Case QueueLabelType.JobBeforeHeader
                        erc = JobBeforeHeader()
                    Case QueueLabelType.BatchStart
                        erc = BatchStart()
                    Case QueueLabelType.BatchBeforePause
                        erc = BatchBeforePause()
                    Case QueueLabelType.BatchBeforeBlanks
                        erc = BatchBeforeBlanks()
                    Case QueueLabelType.BatchBeforeHeader
                        erc = BatchBeforeHeader()
                    Case QueueLabelType.Labels
                        erc = Labels()
                    Case QueueLabelType.Extras
                        erc = Extras()
                    Case QueueLabelType.PalletLabels
                        erc = PalletLabels()
                    Case QueueLabelType.BatchAfterFooter
                        erc = BatchAfterFooter()
                    Case QueueLabelType.BatchAfterBlanks
                        erc = BatchAfterBlanks()
                    Case QueueLabelType.BatchAfterPause
                        erc = BatchAfterPause()
                    Case QueueLabelType.BatchEnd
                        erc = BatchEnd()
                    Case QueueLabelType.JobAfterFooter
                        erc = JobAfterFooter()
                    Case QueueLabelType.JobAfterBlanks
                        erc = JobAfterBlanks()
                    Case QueueLabelType.JobAfterPause
                        erc = JobAfterPause()
                    Case QueueLabelType.JobEnd
                        erc = JobEnd()
                End Select
                If erc = QueueConsumerErrorCodes.OK Then
                    erc = WriteStatusComplete()
                End If
            Case QueueStatus.Done
                ' This should never happen because completed steps should not show in this view.
        End Select

        ' Check for the Cancel flag to be set.
        If m_Cancel Then
            CancelJob()
        End If

        Return erc
    End Function

    Private Sub CancelJob()
        Dim erc As Long

        erc = RunSql("DELETE FROM VNA042TB07_Queue WHERE JobId=" & Strings.Format(m_JobId, "0") & " AND Status < 2")
    End Sub

    Private Function FindPrinterName(ByVal PrinterId As Long) As String
        FindPrinterName = ""
    End Function

    Public Property BatchId As Long Implements IQueueConsumer.BatchId
        Get
            Return m_BatchId
        End Get
        Set(value As Long)
            m_BatchId = value
        End Set
    End Property

    Public Property CopiesPerLabel As Long Implements IQueueConsumer.CopiesPerLabel
        Get
            Return m_CopiesPerLabel
        End Get
        Set(value As Long)
            m_CopiesPerLabel = value
        End Set
    End Property

    Public Property JobId As Long Implements IQueueConsumer.JobId
        Get
            Return m_JobId
        End Get
        Set(value As Long)
            m_JobId = value
        End Set
    End Property

    Public Property LabelId As Long Implements IQueueConsumer.LabelId
        Get
            Return m_LabelId
        End Get
        Set(value As Long)
            m_LabelId = value
        End Set
    End Property

    Public Property LabelType As Long Implements IQueueConsumer.LabelType
        Get
            Return m_LabelType
        End Get
        Set(value As Long)
            m_LabelType = value
        End Set
    End Property

    Public Property PrinterId As Long Implements IQueueConsumer.PrinterId
        Get
            Return m_PrinterId
        End Get
        Set(value As Long)
            m_PrinterId = value
        End Set
    End Property

    Public Property PrinterName As String Implements IQueueConsumer.PrinterName
        Get
            Return m_PrinterName
        End Get
        Set(value As String)
            m_PrinterName = value
        End Set
    End Property

    Public Property ProfileId As Long Implements IQueueConsumer.ProfileId
        Get
            Return m_ProfileId
        End Get
        Set(value As Long)
            m_ProfileId = value
        End Set
    End Property

    Public Property QueueId As Long Implements IQueueConsumer.QueueId
        Get
            Return m_QueueId
        End Get
        Set(value As Long)
            m_QueueId = value
        End Set
    End Property

    Public Property Status As Long Implements IQueueConsumer.Status
        Get
            Return m_Status
        End Get
        Set(value As Long)
            Select Case value
                Case QueueStatus.Pending, QueueStatus.Processing, QueueStatus.Done
                    m_Status = value
                Case Else
                    ' Invalid value, no change made
            End Select
        End Set
    End Property

    'Public ReadOnly Property WaitForUserReponse As Boolean Implements IQueueConsumer.WaitForUserResponse
    '  Get
    '    Return m_WaitForUserReponse
    '  End Get
    'End Property

    Public Property TemplateFile As String Implements IQueueConsumer.TemplateFile
        Get
            Return m_TemplateFile
        End Get
        Set(value As String)
            m_TemplateFile = value
        End Set
    End Property

    Public Property TemplateId As Long Implements IQueueConsumer.TemplateId
        Get
            Return m_TemplateId
        End Get
        Set(value As Long)
            m_TemplateId = value
        End Set
    End Property

    Public Function WriteRecord() As Long Implements IQueueConsumer.WriteRecord
        Dim erc As Long
        'Dim Ix As Long
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        'Dim SqlStr As System.String
        Dim ResultSet As New ADODB.Recordset

        erc = QueueConsumerErrorCodes.OK
        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        SqlProc.CommandText = "UPDATE VNA042TB07_Queue SET Status = " & Format(m_Status, "0") & " WHERE QueueId = " &
                              Format(m_QueueId, "0")
            SqlProc.Execute()


        Return erc
    End Function

    Public Function WriteStatusComplete() As Long Implements IQueueConsumer.WriteStatusComplete
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        m_Status = QueueStatus.Done
        erc = WriteRecord()

        Return erc
    End Function

    Public Function WriteStatusPending() As Long Implements IQueueConsumer.WriteStatusPending
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        m_Status = QueueStatus.Pending
        erc = WriteRecord()

        Return erc
    End Function

    Public Function WriteStatusProcessing() As Long Implements IQueueConsumer.WriteStatusProcessing
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK
        m_Status = QueueStatus.Processing
        erc = WriteRecord()

        Return erc
    End Function

    Public Function ReadFirstRecordByJob(pJobId As Long) As Long Implements IQueueConsumer.ReadFirstRecordByJob
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function ReadFirstRecordByPrinter(pPrinterName As String) As Long _
        Implements IQueueConsumer.ReadFirstRecordByPrinter
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function ReadRecord() As Long Implements IQueueConsumer.ReadRecord
        Dim erc As Long
        'Dim Ix As Long
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim ResultSet As New ADODB.Recordset

        erc = QueueConsumerErrorCodes.OK
        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        'SqlProc.CommandText = "SELECT Top 1 * FROM VNA042VW2X_Queue_JobInfo WHERE QStatus < 2 ORDER BY QueueId"
        'SqlProc.CommandText = "SELECT * FROM VNA042VW36_Profile_WithUnprintedJobs WHERE PrinterId = " & Strings.Format(m_AttachedPrinterId, "0")
        SqlProc.CommandText = "SELECT Top 1 * FROM VNA042VW2X_Queue_JobInfo WHERE PrinterId = " &
                              Strings.Format(m_AttachedPrinterId, "0") & " AND QStatus < 2 ORDER BY QueueId"
        ResultSet = SqlProc.Execute()
        'ResultSet.MoveFirst()

        If ResultSet.EOF Then
            erc = QueueConsumerErrorCodes.EmptyQueue
            m_QueueId = 0
            m_JobId = 0
            m_BatchId = 0
            m_LabelId = 0
            m_CopiesPerLabel = 0
            m_LabelType = 0
            m_TemplateId = 0
            m_TemplateFile = ""
            m_SalesOrderNo = ""
        Else
            ResultSet.MoveFirst()
            m_QueueId = ResultSet.Fields("QueueId").Value
            m_JobId = ResultSet.Fields("JobId").Value
            m_BatchId = ResultSet.Fields("BatchId").Value
            m_LabelId = ResultSet.Fields("LabelId").Value
            m_CopiesPerLabel = ResultSet.Fields("CopiesPerLabel").Value
            m_LabelType = ResultSet.Fields("QStep").Value
            m_TemplateId = ResultSet.Fields("TemplateId").Value
            m_TemplateFile = ResultSet.Fields("TemplateFile").Value.ToString() & ""
            m_Status = ResultSet.Fields("QStatus").Value
            m_SalesOrderNo = ResultSet.Fields("SalesOrderNo").Value
        End If

        ResultSet.Close()

        Return erc
    End Function

    Public Function ReadRecordByQueueId(pQueueId As Long) As Long Implements IQueueConsumer.ReadRecordByQueueId
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Public Function RunStep() As Long Implements IQueueConsumer.RunStep
        Dim erc As Long

        erc = QueueConsumerErrorCodes.OK

        Return erc
    End Function

    Function WaitForUserResponse() As Long Implements IQueueConsumer.WaitForUserResponse
        MsgBox("Printing paused. Click OK to continue.")
        Return QueueConsumerErrorCodes.OK
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

    Function ClearFormats() As Long Implements IQueueConsumer.ClearFormats
        Dim erc As Long
        Dim CommandStr As String

        erc = QueueConsumerErrorCodes.OK
        If Len(m_BTExe) < 3 Then
            m_BTExe = """" & My.Settings.BartendExe & """"
        End If

        CommandStr = m_BTExe & " /CLOSE /MIN"
        BTCommandAdd(CommandStr)
        'Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
        Return erc
    End Function

    Function AddFormat(ByVal pFormatName As String) As Long Implements IQueueConsumer.AddFormat
        Dim erc As Long
        Dim CommandStr As String

        erc = QueueConsumerErrorCodes.OK
        If Len(m_BTExe) < 3 Then
            m_BTExe = """" & My.Settings.BartendExe & """"
        End If

        CommandStr = m_BTExe & " /F=""" & GetFormatFileNameFromTemplateFile(pFormatName) & """ /MIN"
        BTCommandAdd(CommandStr)
        'Shell(CommandStr, AppWinStyle.MinimizedNoFocus, False, -1)
        Return erc
    End Function


End Class
