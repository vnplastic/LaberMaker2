Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormPrintSO
    Dim ctx As VNDataEntities
    Private Sub FormPrintSO_Load(sender As Object, e As EventArgs) Handles Me.Load
        ctx = New VNDataEntities
    End Sub
    Private Sub btnNewJob_Click(sender As System.Object, e As System.EventArgs) Handles btnNewJob.Click
        Dim m_fsono As String
        ' Dim Sql As New SqlStatement
        Dim OldCaption As String
        'Dim iLables as Integer
        Dim m_labelQty As Integer
        Dim m_lineNo As Integer
        Dim jobType As String
        Dim jobToReprint As JobInfo

        m_fsono = "000000"
        FormSalesOrderNumber.fsono = m_fsono
        FormSalesOrderNumber.Show(Me)
        Do While FormSalesOrderNumber.Visible
            My.Application.DoEvents()

        Loop

        'jobType = FormSalesOrderNumber.JobType

        m_fsono = FormSalesOrderNumber.fsono
        m_labelQty = FormSalesOrderNumber.LabelQty
        m_labelQty = 2
        'MsgBox("Debug: Sales Order Number: " & m_fsono)
        If m_fsono = "000000" Then
            ' Do nothing - No Sales Order Number entered
        Else
            ' Is this Sales Order still pending?

            Dim job = ctx.JobInfos.AsNoTracking.Where(Function(c) c.SalesOrderName.Contains(m_fsono)).ToList

            'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
            '            "SELECT fsono, JobId, ProfileId, ProfileName, PrinterId, PrinterName FROM VNA042VW1O_JobInfo WHERE fsono='" &
            '            m_fsono & "' AND Printed=0 AND Destroyed=0 ANd JobTypeId=" & CStr(jobType) & " ORDER BY SalesOrderNo")


            'RecordCount always -1 for forward only cursor so check for BOF and EOF
            'If Sql.ResultSet.RecordCount > 0 Then
            If job Is Nothing Then
                MsgBox("This Sales Order is not for an active LabelMaker Customer or is the wrong label type (Pallet/Carton).", MsgBoxStyle.OkOnly,
                       "LabelMaker: Create Print Job")
                Exit Sub
            Else
                Dim jobTypes As New List(Of String)
                'Todo: Need to handle mutliple types
                jobTypes = job.Select(Function(c) c.JobTypeName).Distinct.ToList
                If jobTypes.Count > 1 Then
                    Dim frm As New FormSelectLabelTypes
                    frm.LabelTypes = jobTypes
                    If frm.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                        jobTypes = frm.SelectedLabelTypes
                    End If
                Else
                    jobType = jobTypes.FirstOrDefault
                    'jobType = job.Where(Function(c) c.JobTypeName = jobTypes.FirstOrDefault).Select(Function(c) c.JobTypeId).FirstOrDefault
                End If
                ' jobType = 1
                'jobType = jobTypes.FirstOrDefault
                jobToReprint = job.Where(Function(c) c.JobTypeName = jobType).FirstOrDefault
                If job.Any(Function(c) c.Printed = 0) Then
                    Dim sMessage As String
                    If jobType = 1 Then
                        sMessage = "This Sales Order is already waiting to be printed or did you mean to print Pallet Labels?"
                    Else
                        sMessage = "This Sales Order is already waiting to be printed or did you mean to print Carton Labels?."
                    End If


                    MsgBox(sMessage, MsgBoxStyle.OkOnly,
                           "LabelMaker: Create Print Job")

                    Exit Sub

                Else

                    If jobToReprint.LabelPerLine = True And m_labelQty > 0 Then
                        Debug.Print("Line Item Batch")
                        MsgBox(
                                    "A product/ line number needs to be selected for this order to reprint a specific quantity")
                        FormLineSelection.fsono = m_fsono
                        FormLineSelection.Show(Me)
                        Do While FormLineSelection.Visible
                            My.Application.DoEvents()

                        Loop
                        m_lineNo = FormLineSelection.lineNo
                    End If

                    'MsgBox("Debug: Sales Order: " & Sql.ResultSet.Fields("fsono").Value.ToString & ", Customer: " & Sql.ResultSet.Fields("CompanyName").Value.ToString, MsgBoxStyle.OkOnly, "LabelMaker: Debug")
                End If

            End If


            ' Create the job for the Sales Order Entered.
            'MsgBox("Debug: Creating Label Print Job: " & m_fsono, MsgBoxStyle.OkOnly, "LabelMaker: Debug")
            'Sql.Execute("M2MReports2", "EXEC dbo.VNA042SP10_Populate_BySalesOrder '" & m_fsono & "'")
            OldCaption = Me.Text ' "More..."
            'ToDo: Generate Reprint Jobs
            If jobType = "Carton" Then
                If m_labelQty > 0 Then
                    Me.Text = "Creating Job"
                    Dim newJob As New Job
                    newJob.JobTypeId = 1
                    newJob.KNDY4CustomerC1 = jobToReprint.SoldToCustId
                    newJob.KNDY4SalesOrderC1 = jobToReprint.SOId
                    newJob.Printed = 0
                    newJob.SalesOrderName = jobToReprint.SalesOrderName
                    ctx.Jobs.Add(newJob)
                    ctx.SaveChanges()
                    ctx.InsertNewCartonJob()
                    Dim inewJob As Integer
                    inewJob = newJob.JobId
                    Dim jobInfo = ctx.CartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label").FirstOrDefault
                    jobInfo.CartonLabelCount = m_labelQty
                    Dim bh As Boolean = ctx.ChangeTracker.HasChanges()
                    ctx.SaveChanges()
                    'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                    '        "EXEC dbo.VNA042SP0X_Job_Populate_BySalesOrder '" & m_fsono & "'")
                    'Me.Text = "Creating Batches"
                    'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                    '        "EXEC dbo.VNA042SP21_Batch_Populate_BySalesOrder_With_Qty '" & m_fsono & "'," &
                    '        m_labelQty & "," & m_lineNo)
                    'Me.Text = "Creating Labels"

                    'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                    '        "EXEC dbo.VNA042SP22_Label_Populate_BySalesOrder_With_Qty '" & m_fsono & "'," &
                    '        m_labelQty)
                Else
                    Dim newJob As New Job
                    newJob.JobTypeId = 1
                    newJob.KNDY4CustomerC1 = jobToReprint.SoldToCustId
                    newJob.KNDY4SalesOrderC1 = jobToReprint.SOId
                    newJob.Printed = 0
                    newJob.SalesOrderName = jobToReprint.SalesOrderName
                    ctx.Jobs.Add(newJob)
                    ctx.SaveChanges()
                    ctx.InsertNewCartonJob()
                    'Dim inewJob As Integer
                    'inewJob = newJob.JobId
                    'Dim jobInfo = ctx.CartonJobs.Where(Function(c) c.JobId = inewJob And c.JobStepName = "Label").FirstOrDefault
                    'jobInfo.CartonLabelCount = m_labelQty
                    'ctx.SaveChanges()

                    'Me.Text = "Creating Job"
                    'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                    '        "EXEC dbo.VNA042SP0X_Job_Populate_BySalesOrder '" & m_fsono & "'")
                    'Me.Text = "Creating Batches"
                    'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                    '        "EXEC dbo.VNA042SP0Y_Batch_Populate_BySalesOrder '" & m_fsono & "'")
                    'Me.Text = "Creating Labels"
                    'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                    '        "EXEC dbo.VNA042SP0Z_Label_Populate_BySalesOrder '" & m_fsono & "'")
                End If
            Else 'Pallet Labels
                'ToDO need to add ability to print only a few pallet labels????

                Me.Text = "Creating Job"
                'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                '            "EXEC dbo.VNA042SP31_Job_Populate_PalletLabels_BySalesOrder_With_Qty '" & m_fsono & "'," & CStr(m_labelQty))
                'Me.Text = "Creating Batches"
                'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                '            "EXEC dbo.VNA042SP32_Batch_Populate_PalletLabels_BySalesOrder '" & m_fsono & "'")
                'Me.Text = "Creating Labels"
                'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
                '            "EXEC dbo.VNA042SP33_Label_Populate_PalletLabels_BySalesOrder '" & m_fsono & "'")

            End If
            Me.Text = "Generated"
            '  Sql.Execute("FileDSN=" + My.Settings.DB_ODBC, "EXEC dbo.VNA042SP05_Job_GeneratedUpdate")
            'If jobType = 2 Then
            '    Me.Text = "Update Shipment"
            '    Sql.Execute("FileDSN=" + My.Settings.DB_ODBC, "EXEC dbo.VNA042SP06_PalletLabels_UpdateShipmentInfo")
            'End If
            'Me.Text = "Printed"
            'Sql.Execute("FileDSN=" + My.Settings.DB_ODBC, "EXEC dbo.VNA042SP07_Job_PrintedUpdate")
            'Me.Text = OldCaption
            'Sql.Close()
            MsgBox("Label Print Job Created Successfully.", MsgBoxStyle.OkOnly, "LabelMaker: Create Label Print Job")
            ''Me.btnDone.PerformClick()
        End If
    End Sub

    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        ' FormMain.RefreshForm(False)
        'ToDo:Refresh Main Form List
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        'ToDo:Remove a Job???

        MsgBox("Not Implemented Yet", MsgBoxStyle.OkOnly)
        'Dim m_fsono As String
        'Dim Sql As New SqlStatement
        'Dim mbYesNo As MsgBoxResult
        ''Dim erc As Integer

        'm_fsono = "000000"
        'FormSalesOrderNumber.fsono = m_fsono
        'FormSalesOrderNumber.chkLabelQty.Visible = False
        'FormSalesOrderNumber.numLabels.Visible = False
        'FormSalesOrderNumber.Show(Me)
        'Do While FormSalesOrderNumber.Visible
        '    My.Application.DoEvents()
        'Loop

        'm_fsono = FormSalesOrderNumber.fsono
        ''MsgBox("Debug: Sales Order Number: " & m_fsono)
        'If m_fsono = "000000" Then
        '    ' Do nothing - No Sales Order Number entered
        'Else
        '    ' Is this Sales Order still pending?
        '    'MsgBox("Debug: Pending Sales Order Check: " & m_fsono, MsgBoxStyle.OkOnly, "LabelMaker: Debug")
        '    Sql.Execute("FileDSN=" + My.Settings.DB_ODBC,
        '                "SELECT fsono, JobId, ProfileId, ProfileName, PrinterId, PrinterName FROM VNA042VW1O_JobInfo WHERE fsono='" &
        '                m_fsono & "' AND Printed=0 AND Destroyed=0 ORDER BY SalesOrderNo")
        '    If Sql.ErrorCode = 0 Then
        '        If Not Sql.ResultSet.EOF Then
        '            mbYesNo = MsgBox("Are you sure you want to remove Sales Order " & m_fsono & "?", MsgBoxStyle.YesNo,
        '                             "LabelMaker: Remove Label Print Job")
        '            If mbYesNo = MsgBoxResult.Yes Then
        '                'RunSql("EXEC VNA042SP12_DestroyPendingJobs_BySalesOrder '" & m_fsono & "'")
        '                MsgBox("Sales Order '" & m_fsono & "' has been removed successfully.", MsgBoxStyle.OkOnly,
        '                       "LabelMaker: Remove Label Print Job")
        '                FormMain.btnRefresh.PerformClick()
        '            End If
        '        Else
        '            MsgBox("Sales Order '" & m_fsono & "' is not waiting to be printed.", MsgBoxStyle.OkOnly,
        '                   "LabelMaker: Remove Label Print Job")
        '        End If
        '    Else
        '        MsgBox(
        '            "There was an error trying to find the Job to remove.  Try again, and if the error persists, contact your IT Administrator.")
        '    End If
        '    Sql.Close()
        'End If
    End Sub


End Class