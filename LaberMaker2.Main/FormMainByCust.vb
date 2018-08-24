Imports System.Data.Entity
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel
Imports NLog

Public Class FormMainByCust
    Dim m_JobTypeId = 0
    Dim m_JobTypeList As New List(Of TableJobType)
    Dim m_LoadedJobTypes As Dictionary(Of Integer, IQueueProcessing) = New Dictionary(Of Integer, IQueueProcessing)
    Dim ctx As VNDataEntities
    Dim jobs As List(Of ViewJobNotPrinted)
    Dim jobTypes As List(Of LabelMaker2.Main.Data.VNDataModel.TableJobType)
    Dim log As Logger
    Dim currentCustomer As String
#Region "Job Control"
    Private Sub GetCustomersWithJobs()
        Try
            GroupBox1.Controls.Clear()
            Dim i As Integer = 1
            Dim openJobs = ctx.ViewJobNotPrinteds.AsNoTracking _
                    .Select(Function(c) New With {c.CustomerName, c.KNDY4CustomerC}).OrderBy(Function(c) c.CustomerName).Distinct.ToList()

            For Each j In openJobs

                Dim btn As New RadioButton With {
                    .Name = "Button" + j.KNDY4CustomerC,
                    .Text = j.CustomerName,
                    .Dock = DockStyle.Top,
                    .Height = 40,
                    .Tag = j.KNDY4CustomerC,
                    .Appearance = Appearance.Button,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Enabled = True}
                GroupBox1.Controls.Add(btn)
                AddHandler btn.Click, AddressOf OnCustomerChanged
                i = i + 1
            Next
            'If openJobs.Count > 0 Then
            '    For Each ctrl As Control In Me.Controls
            '        If TypeOf ctrl Is RadioButton Then
            '            ctrl.Select()
            '            Exit For
            '        End If
            '    Next

            '    'Dim b As RadioButton = Me.Controls.Find("Button" + , True).FirstOrDefault
            '    'b.Select()
            '    'SetJobButtons()
            'End If
        Catch ex As Exception
            MessageBox.Show("A serious error occurred when starting up Labelmaker2", "Error")
            log.Debug(ex.Message & vbCrLf & ex.StackTrace)

        End Try
    End Sub

    'Private Sub SetJobButtons()
    '    Dim jobs = New List(Of ViewJobNotPrinted)
    '    'Dim jobs = New List(Of Integer)
    '    jobs = ctx.ViewJobNotPrinteds.Where(Function(c) c.KNDY4CustomerC = .ToList()
    '    For Each j In jobs
    '        Dim b As RadioButton = Me.Controls.Find("Button" & j, True).FirstOrDefault
    '        b.Enabled = True
    '    Next
    'End Sub

    Private Sub OnCustomerChanged(sender As Object, e As EventArgs)
        Dim b As RadioButton = sender
        'Dim cust As String
        'Dim job As New JobToProcess
        ' Dim job As SalesOrdersToProcess
        currentCustomer = b.Tag
        PopulateOrders()
    End Sub

    Private Sub PopulateOrders()

        Dim jobTypesForCust = ctx.TableCustomerJobInfos.AsNoTracking.Where(Function(c) c.KNDY4CustomerC1 = currentCustomer).Include(Function(c) c.JobType) _
                .OrderBy(Function(d) d.JobType.JobTypeName).ToList

        Dim jobsNotPrinted = ctx.ViewJobNotPrinteds.AsNoTracking.Where(Function(c) c.KNDY4CustomerC = currentCustomer) _
                .OrderBy(Function(c) c.SalesOrderName).ToList

        Dim jobs = jobsNotPrinted _
                .Select(Function(m) New With {m.SalesOrder, m.SalesOrderName}) _
                .GroupBy(Function(c) c.SalesOrder) _
                .Select(Function(x) x.FirstOrDefault).ToList

        lstSalesOrders.Items.Clear()


        For Each j In jobs
            Dim job As SalesOrdersToProcess = New SalesOrdersToProcess
            job.SalesOrder = j.SalesOrderName
            job.SOId = j.SalesOrder
            Dim item = lstSalesOrders.Items.Add(job)
            lstSalesOrders.ValueMember = "SOId"
            lstSalesOrders.DisplayMember = "SalesOrder"
        Next
        grpLabeType.Controls.Clear()

        Dim currentTop As Integer = 0
        For Each jt As TableCustomerJobInfo In jobTypesForCust
            If Not m_LoadedJobTypes.ContainsKey(jt.JobTypeId) Then
                Dim instanceDll = ctx.TableJobTypes.AsNoTracking.Where(Function(c) c.JobTypeId = jt.JobTypeId).Select(Function(c) c.DLLName).FirstOrDefault
                Dim tmpDLL = Globals.CreateLabelInstance(instanceDll)
                m_LoadedJobTypes.Add(jt.JobTypeId, tmpDLL.QueueProcessor)
                Debug.WriteLine("Loaded " + instanceDll)
            End If

            Dim chkBox As New CheckBox
            chkBox.Text = jt.JobTypeName
            chkBox.Checked = True
            chkBox.Tag = jt.JobTypeId
            chkBox.Top = currentTop
            currentTop = chkBox.Top + chkBox.Height

            grpLabeType.Controls.Add(chkBox)


            'Int h = lst.ItemHeight * lst.Items.Count; 
            'lst.Height = h + lst.Height - lst.ClientSize.Height; 


        Next
    End Sub


#End Region
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As String = Globals.GetEFConnectionString
        log = NLog.LogManager.GetCurrentClassLogger
        log.Trace("LabelMaker2 starting up")
        Try
            ctx = New VNDataEntities(conn)
            GetCustomersWithJobs()
        Catch ex As Exception
            MessageBox.Show("A serious error occurred when starting up Labelmaker2", "Error")
            log.Debug(ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub JobStepsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobStepsToolStripMenuItem.Click
        Dim frmSTeps As New FormSteps
        frmSTeps.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm As New FormAbout
        frm.Show()
    End Sub

    Private Sub CustomerProfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerProfilesToolStripMenuItem.Click
        Dim frm As New FormCustomerProfile
        frm.Show()
    End Sub

    Private Sub CustomerJobInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerJobInfoToolStripMenuItem.Click
        Dim frm As New FormJobSteps

        frm.Show()
    End Sub

    Private Sub FormMainByCust_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        For Each ctl In Me.Controls
            If TypeOf ctl Is RadioButton Then
                Dim btn As RadioButton = ctl
                RemoveHandler btn.Click, AddressOf OnCustomerChanged
            End If

        Next
    End Sub

    Private Sub btnPrintLabels_Click(sender As Object, e As EventArgs) Handles btnPrintLabels.Click
        Try

            Dim j As New LabelMaker2.Infrastructure.JobToProcess()
            Dim ji As ViewJobNotPrinted
            Dim lTypeId As Integer
            'Dim ji As JobInfo
            Dim so As SalesOrdersToProcess
            Dim SalesOrder As String

            For Ix = 1 To lstSalesOrders.Items.Count
                If lstSalesOrders.GetItemChecked(Ix - 1) = True Then
                    ' ji = lstSalesOrders.Items(Ix - 1)
                    ' Dim jTemp As JobToProcess
                    'j.JobId = ji.JobId
                    'j.SalesOrder = lstSalesOrders.Items(Ix - 1) 'ji.SalesOrderName

                    so = lstSalesOrders.Items(Ix - 1)
                    SalesOrder = so.SalesOrder



                    For Iy = 1 To grpLabeType.Controls.Count
                        If TypeOf grpLabeType.Controls(Iy - 1) Is CheckBox Then
                            Dim chk As CheckBox = grpLabeType.Controls(Iy - 1)
                            If chk.Checked = True Then
                                ' ji = chk.Tag
                                ' Dim jTemp As JobToProcess
                                'j.JobId = ji.JobId
                                'j.SalesOrder = ji.SalesOrderName
                                Dim Proc As IQueueProcessing
                                Proc = m_LoadedJobTypes(chk.Tag)
                                Dim Q = Proc
                                lTypeId = chk.Tag
                                ji = ctx.ViewJobNotPrinteds.Where(Function(c) c.JobTypeId = lTypeId And c.SalesOrderName = SalesOrder).FirstOrDefault
                                j.JobId = ji.JobId
                                j.SalesOrder = so.SalesOrder
                                Q.SetContext(ctx)
                                Q.PrintJob(j)
                                MessageBox.Show("We'll print " & j.SalesOrder & " here") 'Select(Function(c) c.SalesOrderName).FirstOrDefault & " here")
                            End If
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            log.Debug(ex, ex.Message & vbCrLf & ex.StackTrace)
            MessageBox.Show("An error occurred trying to print labels", "Error")
        End Try
        GetCustomersWithJobs()
        PopulateOrders()
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For Ix = 1 To lstSalesOrders.Items.Count
            lstSalesOrders.SetItemChecked(Ix - 1, True)
        Next
    End Sub

    Private Sub btnDeselectAll_Click(sender As Object, e As EventArgs) Handles btnDeselectAll.Click
        For Ix = 1 To lstSalesOrders.Items.Count
            lstSalesOrders.SetItemChecked(Ix - 1, False)
        Next
    End Sub

    Private Sub ReprintLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprintLabelsToolStripMenuItem.Click
        Dim frm As New FormPrintSO

        frm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        Dim frm As New FormPrintSO

        frm.Show()
    End Sub

    Private Sub lstSalesOrders_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstSalesOrders.ItemCheck
        If lstSalesOrders.CheckedItems.Count = 1 And e.NewValue = CheckState.Unchecked Then
            ' The collection Is about to be emptied: there 's just one item checked, and it's being unchecked at this moment
            btnPrintLabels.Enabled = False
            'btnReprint.Enabled = False

        Else
            'The collection will Not be empty once this click Is handled
            btnPrintLabels.Enabled = True
            'btnReprint.Enabled = True

        End If

    End Sub
End Class