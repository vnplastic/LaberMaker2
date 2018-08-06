Imports System.Data.Entity
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel
Imports NLog

Public Class FormMain
    Dim m_JobTypeId = 0
    Dim m_JobTypeList As New List(Of JobType)
    Dim m_LoadedJobTypes As Dictionary(Of Integer, UserControl) = New Dictionary(Of Integer, UserControl)
    Dim ctx As VNDataEntities
    Dim jobTypes As List(Of LabelMaker2.Main.Data.VNDataModel.JobType)
    Dim log As Logger
#Region "Job Control"
    Private Sub GetJobTypes()
        Try
            jobTypes = ctx.JobTypes.OrderByDescending(Function(c) c.JobTypeName).ToList()
            For Each j In jobTypes
                Dim job As JobType = New JobType With {
                    .JobTypeId = j.JobTypeId,
                    .JobTypeName = j.JobTypeName}

                m_JobTypeList.Add(job)
                Dim btn As New RadioButton With {
                    .Name = "Button" + j.JobTypeId.ToString(),
                    .Text = j.JobTypeName,
                    .Dock = DockStyle.Top,
                    .Height = 40,
                    .Tag = j.JobTypeId,
                    .Appearance = Appearance.Button,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Enabled = False}
                GroupBox1.Controls.Add(btn)
                AddHandler btn.CheckedChanged, AddressOf OnJobTypeChanged
            Next
            If jobTypes.Count > 0 Then
                Dim b As RadioButton = Me.Controls.Find("Button1", True).FirstOrDefault
                b.Select()
                SetJobButtons()
            End If
        Catch ex As Exception
            MessageBox.Show("A serious error occurred when starting up Labelmaker2", "Error")
            log.Debug(ex.Message & vbCrLf & ex.StackTrace)

        End Try
    End Sub

    Private Sub SetJobButtons()
        ' Dim jobs = New List(Of ViewJobNotPrinted)
        Dim jobs = New List(Of Integer)
        jobs = ctx.ViewJobNotPrinteds.Select(Function(c) c.JobTypeId).Distinct().ToList()
        For Each j In jobs
            Dim b As RadioButton = Me.Controls.Find("Button" & j, True).FirstOrDefault
            b.Enabled = True
        Next
    End Sub

    Private Sub OnJobTypeChanged(sender As Object, e As EventArgs)
        Dim b As RadioButton = sender
        Dim instanceDll As String
        Dim tmpDLL As ILabelProperties

        If m_JobTypeId <> b.Tag Then
            Try
                m_JobTypeId = b.Tag
                instanceDll = jobTypes.Where(Function(c) c.JobTypeId = m_JobTypeId).Select(Function(c) c.DLLName).FirstOrDefault
                If SplitContainer1.Panel2.Controls.Count > 0 Then SplitContainer1.Panel2.Controls.RemoveAt(SplitContainer1.Panel2.Controls.Count - 1)
                tmpDLL = Globals.CreateLabelInstance(instanceDll)
                'Select Case m_JobTypeId
                '    Case 1

                '        tmpDLL = Globals.CreateLabelInstance("LabelMaker2.CartonLabels.dll")
                For Each c As Control In SplitContainer1.Panel2.Controls
                    c.Visible = False
                Next
                If m_LoadedJobTypes.ContainsKey(m_JobTypeId) Then
                    SplitContainer1.Panel2.Controls.Add(m_LoadedJobTypes(m_JobTypeId))
                Else
                    SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
                    m_LoadedJobTypes.Add(m_JobTypeId, tmpDLL.FormPrint)
                End If

                ' If Not tmpDLL Is Nothing Then tmpDLL.DBConnString = "FileDSN=" + My.Settings.DB_ODBC

                For Each c As Control In SplitContainer1.Panel2.Controls
                    Debug.Print(c.Name)
                Next
            Catch ex As Exception
                MessageBox.Show("A serious error occurred when loading Job Types", "Error")
                log.Debug(ex, ex.Message & vbCrLf & ex.StackTrace)
            End Try

        End If
    End Sub
#End Region
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As String = Globals.GetEFConnectionString
        log = NLog.LogManager.GetCurrentClassLogger
        log.Trace("LabelMaker2 starting up")
        Try
            ctx = New VNDataEntities(conn)
            GetJobTypes()
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

    Private Sub FormMain_CursorChanged(sender As Object, e As EventArgs) Handles Me.CursorChanged
        For Each ctl In Me.Controls
            If TypeOf ctl Is RadioButton Then
                Dim btn As RadioButton = ctl
                RemoveHandler btn.Click, AddressOf OnJobTypeChanged
            End If

        Next
    End Sub
End Class