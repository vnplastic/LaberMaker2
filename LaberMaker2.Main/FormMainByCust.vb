﻿Imports System.Data.Entity
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel
Imports NLog

Public Class FormMainByCust
    Dim m_JobTypeId = 0
    Dim m_JobTypeList As New List(Of JobType)
    Dim m_LoadedJobTypes As Dictionary(Of Integer, UserControl) = New Dictionary(Of Integer, UserControl)
    Dim ctx As VNDataEntities
    Dim jobs As List(Of ViewJobNotPrinted)
    Dim jobTypes As List(Of LabelMaker2.Main.Data.VNDataModel.JobType)
    Dim log As Logger
#Region "Job Control"
    Private Sub GetCustomersWithJobs()
        Try
            Dim i As Integer = 1
            Dim openJobs = ctx.ViewJobNotPrinteds _
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
        Dim cust As String
        cust = b.Tag
        Dim jobTypesForCust = ctx.CustomerJobInfos.Where(Function(c) c.KNDY4CustomerC1 = cust).ToList
        Dim jobsNotPrinted = ctx.ViewJobNotPrinteds.Where(Function(c) c.KNDY4CustomerC = cust) _
                .OrderBy(Function(c) c.SalesOrderName).ToList
        Dim jobs = jobsNotPrinted _
            .Select(Function(c) New With {c.SalesOrder, c.SalesOrderName}).OrderBy(Function(c) c.SalesOrderName).Distinct.ToList
        lstSalesOrders.Items.Clear()


        For Each j In jobs

            Dim item = lstSalesOrders.Items.Add(j)
            lstSalesOrders.ValueMember = "SalesOrder"
            lstSalesOrders.DisplayMember = "SalesOrderName"
        Next

        For Each jt As CustomerJobInfo In jobTypesForCust

            Dim instanceDll = ctx.JobTypes.Where(Function(c) c.JobTypeId = jt.JobTypeId).Select(Function(c) c.DLLName).FirstOrDefault
            Dim tmpDLL = Globals.CreateLabelInstance(instanceDll)
            Debug.WriteLine("Loaded " + instanceDll)

        Next
        'Dim instanceDll As String
        'Dim tmpDLL As ILabelProperties

        'If m_JobTypeId <> b.Tag Then
        '    Try
        '        m_JobTypeId = b.Tag
        '        instanceDll = jobTypes.Where(Function(c) c.JobTypeId = m_JobTypeId).Select(Function(c) c.DLLName).FirstOrDefault
        '        If SplitContainer1.Panel2.Controls.Count > 0 Then SplitContainer1.Panel2.Controls.RemoveAt(SplitContainer1.Panel2.Controls.Count - 1)
        '        tmpDLL = Globals.CreateLabelInstance(instanceDll)
        '        'Select Case m_JobTypeId
        '        '    Case 1

        '        '        tmpDLL = Globals.CreateLabelInstance("LabelMaker2.CartonLabels.dll")
        '        For Each c As Control In SplitContainer1.Panel2.Controls
        '            c.Visible = False
        '        Next
        '        If m_LoadedJobTypes.ContainsKey(m_JobTypeId) Then
        '            SplitContainer1.Panel2.Controls.Add(m_LoadedJobTypes(m_JobTypeId))
        '        Else
        '            SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
        '            m_LoadedJobTypes.Add(m_JobTypeId, tmpDLL.FormPrint)
        '        End If

        '        ' If Not tmpDLL Is Nothing Then tmpDLL.DBConnString = "FileDSN=" + My.Settings.DB_ODBC

        '        For Each c As Control In SplitContainer1.Panel2.Controls
        '            Debug.Print(c.Name)
        '        Next
        '    Catch ex As Exception
        '        MessageBox.Show("A serious error occurred when loading Job Types", "Error")
        '        log.Debug(ex, ex.Message & vbCrLf & ex.StackTrace)
        '    End Try

        'End If
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
End Class