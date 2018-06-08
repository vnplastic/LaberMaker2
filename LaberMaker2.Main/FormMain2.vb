Imports System.Data.SqlClient

Public Class FormMain2
    Structure CustomerInfo_Struct
        Public JobTypeId As Integer
        Public ProfileId As Integer
        Public ProfileName As String
    End Structure

    Structure JobInfo_Struct
        Public JobId As Integer
        Public JobTypeId As Integer
        Public ProfileId As Integer
        Public ProfileName As String
        Public SalesOrderNo As String
        Public PrinterId As Integer
        Public PrinterName As String
        Public HasShipmentDate As Boolean
    End Structure

    Dim m_CustomerList As New List(Of CustomerInfo_Struct)
    Dim m_CustomerCount As Integer
    Dim m_CustomerPage As Integer
    Dim m_CustomerButton As Integer   ' 0=no customer selected, 1-5=The customer button for the selected customer
    Dim m_JobList As New List(Of JobInfo_Struct)
    Dim m_FormatsList As New List(Of String)
    Dim boolFirstLoad = False
    Dim m_JobTypeId = 1
    Dim m_JobTypeList As New List(Of JobType)

    Private Function GetFirstRow() As Integer
        Dim FirstRow As Integer

        FirstRow = ((m_CustomerPage - 1) * 5) + 1
        If FirstRow < 1 Or FirstRow > m_CustomerCount Then
            FirstRow = 0
        End If

        GetFirstRow = FirstRow
    End Function

    Private Function GetCustomerListRow() As Integer
        Dim Result As Integer

        If m_CustomerButton = 0 Then
            Result = 0
        Else
            If m_CustomerCount = 0 Then
                Result = 0
            Else
                Result = GetFirstRow() + m_CustomerButton - 1
                If Result < 1 Then Result = 0
                If Result > 5 Then Result = 0
            End If
        End If

        GetCustomerListRow = Result
    End Function

    Private Sub GetCustomerJobList()
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        ' Dim ProfileId As Integer
        Dim CustomerListRow As Integer
        Dim SqlStr As String
        Dim WorkObj As New JobInfo_Struct

        CustomerListRow = GetCustomerListRow()
        If CustomerListRow > 0 Then
            SqlStr =
                "SELECT fsono, JobId, ProfileId, ProfileName, PrinterId, PrinterName, JobTypeId, IsShipmentDate FROM VNA042VW1O_JobInfo WHERE ProfileId=" &
                m_CustomerList(CustomerListRow - 1).ProfileId.ToString &
                " AND Printed=0 AND Destroyed=0 AND JobTypeId=" & m_JobTypeId.ToString() & " ORDER BY SalesOrderNo"
            'SqlStr = "SELECT fsono, JobId, ProfileId, ProfileName, PrinterId, PrinterName FROM VNA042VW1C_Job_NotPrinted WHERE ProfileId=" & m_CustomerList(CustomerListRow - 1).ProfileId.ToString & " AND Printed=0 AND Destroyed=0 ORDER BY SalesOrderNo"
            oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
            oRecordset.Open(SqlStr, oConnection)
            m_JobList.Clear()
            'If chkPalletLabels.Checked = True Then
            '    m_JobTypeId = 2
            'Else
            '    m_JobTypeId = 1
            'End If
            oRecordset.MoveFirst()
            Do While Not oRecordset.EOF
                'If oRecordset.Fields("JobTypeId").Value = m_JobTypeId Then
                WorkObj.JobId = oRecordset.Fields("JobId").Value
                WorkObj.JobTypeId = oRecordset.Fields("JobTypeId").Value
                WorkObj.ProfileId = oRecordset.Fields("ProfileId").Value
                WorkObj.ProfileName = oRecordset.Fields("ProfileName").Value
                WorkObj.SalesOrderNo = oRecordset.Fields("fsono").Value
                WorkObj.PrinterId = oRecordset.Fields("PrinterId").Value
                WorkObj.PrinterName = oRecordset.Fields("PrinterName").Value
                WorkObj.HasShipmentDate = oRecordset.Fields("IsShipmentDate").Value
                m_JobList.Add(WorkObj)
                'End If
                oRecordset.MoveNext()
            Loop
        End If
    End Sub

    Private Sub RefreshForm()
        If Not boolFirstLoad Then RefreshKenandy()


        LoadCustomers()
        m_CustomerButton = 0
        FillListBox()
        ShowButtons()
        Me.Refresh()
    End Sub

    Private Sub RefreshKenandy()
        'ToDoL Remove return
        Return
        Cursor.Current = Cursors.WaitCursor
        Dim oConnection As New ADODB.Connection
        Dim oCommand As New ADODB.Command
        Try

            oCommand.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc
            oCommand.CommandText = "VNA000SP02_Refresh_SalesForce "
            oCommand.Parameters.Append(oCommand.CreateParameter("@AppName", ADODB.DataTypeEnum.adVarChar,
                                                                ADODB.ParameterDirectionEnum.adParamInput, 50, "VNA042"))
            oCommand.CommandTimeout = 120

            oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
            oCommand.ActiveConnection = oConnection
            oCommand.Execute()
            oConnection.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred refreshing Kenandy Data", "Error")
        End Try
        Try
            oCommand.Parameters.Delete("@AppName")
            oCommand.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc
            oCommand.CommandText = "VNA042SP00_Generate_Jobs"


            oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
            oCommand.ActiveConnection = oConnection
            oCommand.Execute()
        Catch ex As Exception
            MessageBox.Show("An error occurred refreshing the label jobs", "Error")
        End Try


        Cursor.Current = Cursors.Default
    End Sub

    Private Sub LoadCustomers()
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        'Dim Sql As New SqlStatement
        Dim SqlStr As String
        Dim WorkStr As String
        Dim WorkObj As New CustomerInfo_Struct

        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        'SqlStr = "SELECT DISTINCT ProfileId, ProfileName FROM VNA042VW37_Profile_UnqueuedJobs ORDER BY ProfileId"
        'SqlStr = "SELECT DISTINCT ProfileId, ProfileName FROM VNA042VW1O_JobInfo ORDER BY ProfileId"
        SqlStr =
            $"SELECT DISTINCT ProfileId, CompanyName, JobTypeId FROM VNA042VW1C_Job_NotPrinted WHERE JobTypeId={ _
                m_JobTypeId} ORDER BY ProfileId"
        'SqlStr = "SELECT DISTINCT ProfileId, CompanyName FROM VNA042VW1C_Job_NotPrinted ORDER BY ProfileId"
        oRecordset.Open(SqlStr, oConnection, ADODB.CursorTypeEnum.adOpenStatic)
        m_CustomerList.Clear()
        'If chkPalletLabels.Checked = True Then
        '    m_JobTypeId = 2
        'Else
        '    m_JobTypeId = 1
        'End If
        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()
                Do While Not oRecordset.EOF
                    '  If (oRecordset.Fields("JobTypeId").Value = m_JobTypeId) Then
                    WorkStr = oRecordset.Fields("CompanyName").ToString & vbTab &
                              oRecordset.Fields("ProfileId").ToString
                    WorkObj.JobTypeId = oRecordset.Fields("JobTypeId").Value
                    WorkObj.ProfileId = oRecordset.Fields("ProfileId").Value
                    WorkObj.ProfileName = oRecordset.Fields("CompanyName").Value
                    m_CustomerList.Add(WorkObj)

                    ' End If
                    oRecordset.MoveNext()
                Loop
            End If
        End If
        ' WorkObj = m_CustomerList.Where(Function(s) s.ProfileId = 1).FirstOrDefault

        m_CustomerCount = m_CustomerList.Count
        m_CustomerPage = 1
    End Sub

    Private Sub SetJobButtons()
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        'Dim Sql As New SqlStatement
        Dim SqlStr As String


        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        SqlStr = "SELECT DISTINCT JobTypeId FROM VNA042VW1C_Job_NotPrinted "

        oRecordset.Open(SqlStr, oConnection, ADODB.CursorTypeEnum.adOpenStatic)
        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()

                Do While Not oRecordset.EOF
                    Dim b As RadioButton = Me.Controls.Find("Button" & oRecordset.Fields("JobTypeId").Value, True).FirstOrDefault
                    b.Enabled = True
                    oRecordset.MoveNext()
                Loop
            End If
        End If


    End Sub

    Private Sub LoadFormats(ByVal pJobId As Integer)
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        Dim SqlStr As String
        Dim WorkStr As String
        Dim WorkObj As New CustomerInfo_Struct

        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        SqlStr = "SELECT DISTINCT TemplateFile FROM VNA042TB07_Queue WHERE JobId=" & pJobId.ToString &
                 " AND TemplateId > 0"
        oRecordset.Open(SqlStr, oConnection)
        m_FormatsList.Clear()

        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()
                Do While Not oRecordset.EOF
                    WorkStr = oRecordset.Fields("TemplateFile").Value
                    m_FormatsList.Add(WorkStr)
                    oRecordset.MoveNext()
                Loop
            End If
        End If
    End Sub

    Private Sub SendFormats()
        Dim Ix As Integer

        For Ix = 1 To m_FormatsList.Count

        Next
    End Sub

    Private Sub FillListBox()
        Dim FirstRow As Integer
        Dim Ix As Integer
        Dim RowIndex As Integer

        'CheckedListBox1.ClearSelected()
        CheckedListBox1.Items.Clear()

        FirstRow = GetFirstRow()
        If m_CustomerButton >= 1 And m_CustomerButton <= 5 Then
            GetCustomerJobList()
            CheckedListBox1.DisplayMember = "SalesOrderNo"
            For Ix = 1 To m_JobList.Count

                If m_JobTypeId = 2 Then
                    If m_JobList(Ix - 1).HasShipmentDate = False Then
                        RowIndex = CheckedListBox1.Items.Add("**" & m_JobList(Ix - 1).SalesOrderNo)
                    Else
                        RowIndex =
                            CheckedListBox1.Items.Add(
                                m_JobList(Ix - 1).SalesOrderNo & "(" & m_JobList(Ix - 1).JobTypeId & ")")
                    End If

                Else
                    RowIndex =
                        CheckedListBox1.Items.Add(
                            m_JobList(Ix - 1).SalesOrderNo & "(" & m_JobList(Ix - 1).JobTypeId & ")")
                End If
            Next
        End If
        CheckedListBox1.Refresh()
        If CheckedListBox1.CheckedItems.Count > 0 Then
            btnPrintLabels.Enabled = True
        Else
            btnPrintLabels.Enabled = False
        End If
    End Sub

    Private Sub ShowButtons()
        Dim FirstRow As Integer

        ' btnPrev
        If m_CustomerPage < 2 Then
            btnPrev.Enabled = False
        Else
            btnPrev.Enabled = True
        End If

        ' btnCustomer1
        If m_CustomerPage = 0 Then
            If m_CustomerCount = 0 Then
                m_CustomerPage = 1
                FirstRow = 1
            Else
                m_CustomerPage = 1
                FirstRow = 1
            End If
        Else
            FirstRow = ((m_CustomerPage - 1) * 5) + 1
        End If

        If m_CustomerCount >= FirstRow Then
            btnCustomer1.Enabled = True
            btnCustomer1.Text = m_CustomerList.Item(FirstRow - 1).ProfileName
        Else
            btnCustomer1.Enabled = False
            btnCustomer1.Text = ""
        End If

        ' btnCustomer2
        If m_CustomerCount >= (FirstRow + 1) Then
            btnCustomer2.Enabled = True
            btnCustomer2.Text = m_CustomerList.Item((FirstRow + 1) - 1).ProfileName
        Else
            btnCustomer2.Enabled = False
            btnCustomer2.Text = ""
        End If

        ' btnCustomer3
        If m_CustomerCount >= (FirstRow + 2) Then
            btnCustomer3.Enabled = True
            btnCustomer3.Text = m_CustomerList.Item((FirstRow + 2) - 1).ProfileName
        Else
            btnCustomer3.Enabled = False
            btnCustomer3.Text = ""
        End If

        ' btnCustomer4
        If m_CustomerCount >= (FirstRow + 3) Then
            btnCustomer4.Enabled = True
            btnCustomer4.Text = m_CustomerList.Item((FirstRow + 3) - 1).ProfileName
        Else
            btnCustomer4.Enabled = False
            btnCustomer4.Text = ""
        End If

        ' btnCustomer5
        If m_CustomerCount >= (FirstRow + 4) Then
            btnCustomer5.Enabled = True
            btnCustomer5.Text = m_CustomerList.Item((FirstRow + 4) - 1).ProfileName
        Else
            btnCustomer5.Enabled = False
            btnCustomer5.Text = ""
        End If

        ' btnNext
        If m_CustomerCount < (FirstRow + 5) Then
            btnNext.Enabled = False
        Else
            btnNext.Enabled = True
        End If

        ' btnSelectAll
        If m_CustomerButton = 0 Then
            btnSelectAll.Enabled = False
        Else
            btnSelectAll.Enabled = True
        End If

        ' btnDeselectAll
        If m_CustomerButton = 0 Then
            btnDeselectAll.Enabled = False
        Else
            btnDeselectAll.Enabled = True
        End If

        ' btnOptions
        If m_CustomerButton = 0 Then
            btnOptions.Enabled = False
        Else
            btnOptions.Enabled = False
        End If

        ' btnPrintLabels
        If m_CustomerButton = 0 Then
            btnPrintLabels.Enabled = False
        Else
            btnPrintLabels.Enabled = False
        End If

        ' btnRefresh
        btnRefresh.Enabled = True

        ' btnExit
        btnExit.Enabled = True

        Me.Refresh()
    End Sub

    Private Sub Form2_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolFirstLoad = True
        GetJobTypes()
        m_CustomerButton = 0
        m_CustomerCount = 0
        m_CustomerPage = 0
        RefreshForm()
        boolFirstLoad = False

    End Sub

    Private Sub GetJobTypes()
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        Dim SqlStr As String

        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        SqlStr = "SELECT JobTypeId,JobTypeName FROM VNA042TB08_JobType order by JobTypeName DESC"
        oRecordset.Open(SqlStr, oConnection)


        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()
                Do While Not oRecordset.EOF
                    Dim job As JobType = New JobType With {
                            .JobTypeId = oRecordset.Fields("JobTypeId").Value,
                            .JobTypeName = oRecordset.Fields("JobTypeName").Value}

                    m_JobTypeList.Add(job)
                    Dim btn As New RadioButton With {
                            .Name = "Button" + job.JobTypeId.ToString(),
                            .Text = job.JobTypeName,
                            .Dock = DockStyle.Top,
                            .Height = 40,
                            .Tag = job.JobTypeId,
                            .Appearance = Appearance.Button,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Enabled = False}
                    GroupBox1.Controls.Add(btn)
                    AddHandler btn.CheckedChanged, AddressOf OnJobTypeChanged
                    oRecordset.MoveNext()
                Loop
            End If
        End If
        Dim b As RadioButton = Me.Controls.Find("Button1", True).FirstOrDefault
        b.Select()
        lblTitle.Text = $"Customers with Pending {b.Text} Jobs"
        SetJobButtons()
    End Sub

    Private Sub OnJobTypeChanged(sender As Object, e As EventArgs)
        Dim b As RadioButton = sender



        If m_JobTypeId <> b.Tag Then
            m_JobTypeId = b.Tag
            lblTitle.Text = $"Customers with Pending {b.Text} Jobs"
            LoadCustomers()
            m_CustomerButton = 0
            FillListBox()
            ShowButtons()
            If m_JobTypeId = 2 Then
                Dim tmpDLL As ILabelProperties = Globals.CreateLabelInstance("LabelMaker.AddressLabels.dll")
                For Each c As Control In SplitContainer1.Panel2.Controls
                    c.Visible = False
                Next
                SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
            Else
                SplitContainer1.Panel2.Controls.RemoveAt(SplitContainer1.Panel2.Controls.Count - 1)
                For Each c As Control In SplitContainer1.Panel2.Controls
                    c.Visible = True
                Next
            End If
        End If
    End Sub

    Private Sub SelectCustomer(ByVal CustomerNumber As Integer)
        m_CustomerButton = CustomerNumber
        FillListBox()
        ShowButtons()
    End Sub

    Private Sub btnCustomer1_Click(sender As Object, e As System.EventArgs) Handles btnCustomer1.Click
        SelectCustomer(1)
    End Sub

    Private Sub btnCustomer2_Click(sender As Object, e As System.EventArgs) Handles btnCustomer2.Click
        SelectCustomer(2)
    End Sub

    Private Sub btnCustomer3_Click(sender As Object, e As System.EventArgs) Handles btnCustomer3.Click
        SelectCustomer(3)
    End Sub

    Private Sub btnCustomer4_Click(sender As Object, e As System.EventArgs) Handles btnCustomer4.Click
        SelectCustomer(4)
    End Sub

    Private Sub btnCustomer5_Click(sender As Object, e As System.EventArgs) Handles btnCustomer5.Click
        SelectCustomer(5)
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As System.EventArgs) Handles btnPrev.Click
        SelectCustomer(0)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As System.EventArgs) Handles btnNext.Click
        SelectCustomer(0)
    End Sub

    Private Sub CheckedListBox1_Click(sender As Object, e As System.EventArgs) Handles CheckedListBox1.Click
        'MsgBox(CheckedListBox1.SelectedItems(0).ToString)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Function GetSqlOptionSet(ByRef IsUpdate As Boolean, ByVal OptionFieldName As String,
                                     ByVal OptionValue As OptionFlagValue) As String
        Dim Result As String

        Result = ""

        Select Case OptionValue
            Case OptionFlagValue.Yes
                Result = IIf(IsUpdate, ", ", "") & OptionFieldName & "=1"
                IsUpdate = True
            Case OptionFlagValue.No
                Result = IIf(IsUpdate, ", ", "") & OptionFieldName & "=0"
                IsUpdate = True
        End Select

        Return Result
    End Function

    Private Function GetSqlTemplateSet(ByRef IsUpdate As Boolean, ByVal OptionFieldName As String,
                                       ByVal OptionValue As OptionFlagValue) As String
        Dim Result As String

        Result = ""

        Select Case OptionValue
            Case OptionFlagValue.Yes
                Result = IIf(IsUpdate, ", ", "") & OptionFieldName & "=LabelTemplateId"
                IsUpdate = True
            Case OptionFlagValue.No
                Result = IIf(IsUpdate, ", ", "") & OptionFieldName & "=0"
                IsUpdate = True
        End Select

        Return Result
    End Function

    Private Function GetSqlNumberSet(ByRef IsUpdate As Boolean, ByVal OptionFieldName As String, ByVal Value As Integer) _
        As String
        Dim Result As String

        Result = IIf(IsUpdate, ", ", "") & OptionFieldName & "=" & Format$(Value, "0")
        IsUpdate = True

        Return Result
    End Function

    Private Sub btnOptions_Click(sender As Object, e As System.EventArgs) Handles btnOptions.Click
        Dim l_Options As New Options
        Dim SqlStr_Job As String
        Dim SqlStr_Batch As String
        Dim SqlStr_Where As String
        Dim UpdateJob As Boolean
        Dim UpdateBatch As Boolean
        Dim UpdateWhere As Boolean
        Dim Ix As Integer

        MsgBox("Options not yet implemented.")
        Exit Sub

        If CheckedListBox1.CheckedItems.Count = 0 Then
            MsgBox(
                "There are no orders for which to set the options.  Please check one or more orders, then click the Options button.")
            Exit Sub
        Else
            SetOptionsFromProfile(l_Options, m_CustomerList(GetCustomerListRow() - 1).ProfileId)
            FormOptions.Options = l_Options
            FormOptions.Show()
        End If
        ' Set Job Options
        UpdateJob = False
        SqlStr_Job = "UPDATE VNA042TB04_Job SET " _
                     & GetSqlOptionSet(UpdateJob, "PauseBefore", l_Options.PauseBeforeJob) _
                     & GetSqlOptionSet(UpdateJob, "BlankBeforeJob", l_Options.BlanksBeforeJob) _
                     & GetSqlTemplateSet(UpdateJob, "JobHeaderTemplateId", l_Options.JobHeader) _
                     & GetSqlTemplateSet(UpdateJob, "JobFooterTemplateId", l_Options.JobFooter) _
                     & GetSqlOptionSet(UpdateJob, "BlanksAfterJob", l_Options.BlanksAfterJob) _
                     & GetSqlOptionSet(UpdateJob, "PauseAfter", l_Options.PauseAfterJob) _
                     & GetSqlNumberSet(UpdateJob, "PrinterId", l_Options.PrinterId)

        ' Set Batch Options
        UpdateBatch = False
        SqlStr_Batch = "UPDATE VNA042TB05_Batch SET " _
                       & GetSqlOptionSet(UpdateBatch, "PauseBefore", l_Options.PauseBeforeBatch) _
                       & GetSqlOptionSet(UpdateBatch, "BlanksBefore", l_Options.BlanksBeforeBatch) _
                       & GetSqlTemplateSet(UpdateBatch, "BatchHeaderTemplateId", l_Options.BatchHeader) _
                       & GetSqlTemplateSet(UpdateBatch, "BatchFooterTemplateId", l_Options.BatchFooter) _
                       & GetSqlOptionSet(UpdateBatch, "BlanksAfter", l_Options.BlanksAfterBatch) _
                       & GetSqlOptionSet(UpdateBatch, "PauseAfter", l_Options.PauseAfterBatch) _
                       & GetSqlNumberSet(UpdateBatch, "PrinterId", l_Options.PrinterId)

        ' Build WHERE clause
        UpdateWhere = False
        SqlStr_Where = "WHERE fsono IN ("
        For Ix = 1 To CheckedListBox1.CheckedItems.Count
            SqlStr_Where &= IIf(UpdateWhere, ", ", "") & "'" & CheckedListBox1.CheckedItems(Ix - 1).ToString & "'"
            UpdateWhere = True
        Next
        SqlStr_Batch &= ")"

        If UpdateWhere Then
            SqlStr_Job &= " " & SqlStr_Where
            SqlStr_Batch &= " " & SqlStr_Where
        End If

        RunSql(SqlStr_Job)
        RunSql(SqlStr_Batch)
    End Sub

    Private Sub btnPrintLabels_Click(sender As Object, e As System.EventArgs) Handles btnPrintLabels.Click
        '    MsgBox("Printing Labels coming soon!")
        'Exit Sub

        Dim Erc As Long
        Dim Ix As Integer
        Dim Iy As Integer
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim QC As New QueueConsumer

        ' --------------------------
        ' IssueId: IR00001.001 BEGIN
        Me.btnRefresh.Enabled = False
        ' IssueId: IR00001.001 END
        ' --------------------------
        If CheckedListBox1.CheckedItems.Count = 0 Then
            MsgBox("There are no orders selected.  Please check one or more orders, then click the Print Labels button.")
            Exit Sub
        End If

        'ToDo: FIx Connection String
        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        For Ix = 1 To CheckedListBox1.Items.Count
            If CheckedListBox1.GetItemChecked(Ix - 1) = True Then
                If CheckedListBox1.Items(Ix - 1).ToString.Contains("**") Then
                    If _
                        MessageBox.Show(
                            "This order " & m_JobList(Ix - 1).SalesOrderNo &
                            " does not have a shipment date, the label may not be correct", "Proceed?",
                            MessageBoxButtons.YesNo) = DialogResult.No Then
                        Return
                    End If
                End If

                SqlProc.CommandText = "VNA042SP0T_JobToQueue(" & m_JobList(Ix - 1).JobId.ToString & ")"
                SqlProc.Execute()
                LoadFormats(m_JobList(Ix - 1).JobId)

                QC.AttachPrinter(pPrinterId:=m_JobList(Ix - 1).PrinterId)
                Erc = QC.OpenQueue()

                For Iy = 1 To m_FormatsList.Count
                    QC.AddFormat(m_FormatsList.Item(Iy - 1))
                Next

                Do While Erc = QueueConsumerErrorCodes.OK
                    Erc = QC.ReadRecord()
                    If Erc = QueueConsumerErrorCodes.OK Then
                        Erc = QC.ProcessQueueRecord()
                        'If QC.WaitForUserResponse Then
                        ' MsgBox("Printing Paused. Click OK to continue.")
                        'End If
                    End If
                Loop

                'Erc = QC.ClearFormats
                Erc = QC.CloseQueue
                Erc = QC.DetachPrinter
                Dim args As String() = Environment.GetCommandLineArgs
                If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then

                    SqlProc.CommandText = "Update vna042tb07_Queue set status=0 where JobId=" &
                                          m_JobList(Ix - 1).JobId.ToString
                    SqlProc.Execute()

                End If
            End If
        Next
        SqlConnection.Close()

        'MsgBox("Selected Jobs have been printed.")
        m_CustomerButton = 0

        ' --------------------------
        ' IssueId: IR00000.000 BEGIN
        Me.btnRefresh.Enabled = True
        ' IssueId: IR00000.000 END
        ' --------------------------

        Me.RefreshForm()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As System.EventArgs) Handles btnRefresh.Click
        RefreshForm()
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As System.EventArgs) Handles btnSelectAll.Click
        Dim Ix As Integer
        Dim ItemCount As Integer

        ItemCount = CheckedListBox1.Items.Count - 1

        For Ix = 0 To ItemCount
            CheckedListBox1.SetItemChecked(Ix, True)
        Next Ix

        Me.Refresh()
    End Sub

    Private Sub btnDeselectAll_Click(sender As Object, e As System.EventArgs) Handles btnDeselectAll.Click
        Dim Ix As Integer
        Dim ItemCount As Integer

        ItemCount = CheckedListBox1.Items.Count - 1

        For Ix = 0 To ItemCount
            CheckedListBox1.SetItemChecked(Ix, False)
        Next Ix
        Me.Refresh()
    End Sub

    Private Sub btnMore_Click(sender As System.Object, e As System.EventArgs) Handles btnMore.Click
        'MsgBox("More... not yet implemented.")
        FormPrintSO.Show(Me)
    End Sub

    Private Sub RunSql(ByVal pCommand As String)
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim ResultSet As New ADODB.Recordset

        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        SqlProc.CommandText = pCommand _
        ' "UPDATE VNA042TB07_Queue SET Status = " & Format(m_Status, "0") & " WHERE QueueId = " & Format(m_QueueId, "0")
        SqlProc.Execute()
        SqlConnection.Close()
    End Sub

    Private Sub SetOptionsFromProfile(TheOptions As Options, ProfileId As Integer)
        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim ResultSet As New ADODB.Recordset
        Dim pCommand As String

        SqlConnection.ConnectionString = "FileDSN=" + My.Settings.DB_ODBC
        SqlConnection.Open()
        SqlProc.ActiveConnection = SqlConnection

        pCommand =
            "SELECT PauseBefore, BlanksBeforeJob, JobHeader, JobFooter, BlanksAfterJob, PauseAfter, PrinterId FROM VNA042TB04_Job WHERE ProfileId=" &
            m_CustomerList(GetCustomerListRow() - 1).ProfileId.ToString

        SqlProc.CommandText = pCommand _
        ' "UPDATE VNA042TB07_Queue SET Status = " & Format(m_Status, "0") & " WHERE QueueId = " & Format(m_QueueId, "0")
        ResultSet = SqlProc.Execute()
        If ResultSet.State = 1 Then
            ResultSet.MoveFirst()
            TheOptions.PauseBeforeJob = ResultSet.Fields("PauseBefore").Value
            TheOptions.BlanksBeforeJob = (ResultSet.Fields("BlanksBeforeJob").Value > 0)
            TheOptions.BlanksBeforeJobCount = ResultSet.Fields("BlanksBeforeJob").Value
            TheOptions.JobHeader = (ResultSet.Fields("JobHeader").Value > 0)
            TheOptions.JobFooter = (ResultSet.Fields("JobFooter").Value > 0)
            TheOptions.BlanksAfterJobCount = ResultSet.Fields("BlanksAfterJob").Value
            TheOptions.BlanksAfterJob = (ResultSet.Fields("BlanksAfterJob").Value > 0)
            TheOptions.PauseAfterJob = ResultSet.Fields("PauseAfter").Value
            TheOptions.PrinterId = ResultSet.Fields("PrinterId").Value
        End If

        SqlProc.CommandText =
            "SELECT PauseBefore, BlanksBefore, BatchHeader, BatchFooter, BlanksAfter, PauseAfter FROM VNA042TB05_Batch WHERE ProfileId=" &
            m_CustomerList(GetCustomerListRow() - 1).ProfileId.ToString
        ResultSet = SqlProc.Execute()
        If ResultSet.State = 1 Then
            ResultSet.MoveFirst()
            TheOptions.PauseBeforeBatch = ResultSet.Fields("PauseBefore").Value
            TheOptions.BlanksBeforeBatch = (ResultSet.Fields("BlanksBefore").Value > 0)
            TheOptions.BlanksBeforeBatchCount = ResultSet.Fields("BlanksBefore").Value
            TheOptions.BatchHeader = (ResultSet.Fields("BatchHeader").Value > 0)
            TheOptions.BatchFooter = (ResultSet.Fields("BatchFooter").Value > 0)
            TheOptions.BlanksAfterBatchCount = ResultSet.Fields("BlanksAfter").Value
            TheOptions.BlanksAfterBatch = (ResultSet.Fields("BlanksAfter").Value > 0)
            TheOptions.PauseAfterBatch = ResultSet.Fields("PauseAfter").Value
        End If
        SqlConnection.Close()
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        If (CheckedListBox1.CheckedItems.Count = 1 And e.NewValue = CheckState.Unchecked) Then
            btnPrintLabels.Enabled = False
            Exit Sub
        End If
        If (CheckedListBox1.CheckedItems.Count = 0 And e.NewValue = CheckState.Checked) Then
            btnPrintLabels.Enabled = True
            Exit Sub
        End If
        If CheckedListBox1.CheckedItems.Count > 0 Then
            btnPrintLabels.Enabled = True
        End If
    End Sub

    Private Sub btnPrintLabels_ClientSizeChanged(sender As Object, e As EventArgs) Handles btnPrintLabels.ClientSizeChanged

    End Sub

    'Private Sub chkPalletLabels_CheckStateChanged(sender As Object, e As EventArgs)

    '    If chkPalletLabels.Checked Then
    '        m_JobTypeId = 2
    '        lblTitle.Text = "Customers with Pending Pallet Label Jobs"
    '    Else
    '        m_JobTypeId = 1
    '        lblTitle.Text = "Customers with Pending Label Jobs"
    '    End If
    '    LoadCustomers()
    '    m_CustomerButton = 0
    '    FillListBox()
    '    ShowButtons()
    'End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class