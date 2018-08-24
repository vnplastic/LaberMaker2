
Imports System.Drawing
Imports System.Windows.Forms
Imports LabelMaker2.Main.Data.VNDataModel
Imports LabelMaker2.Infrastructure

Public Class FormJobs
    Dim ctx As VNDataEntities
    Dim jobs As List(Of ViewJobNotPrinted)
    'Dim q As QueueProcessingByCommand
    Dim log As NLog.Logger
    Private Sub FormJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ctx = New VNDataEntities(Vars.ConnString)
        log = LabelMaker2.Infrastructure.Globals.Logger
        Dim i As Integer = 0
        log.Trace("Carton Label Module Starting Up.....")
        jobs = ctx.ViewJobNotPrinteds.AsNoTracking.Where(Function(c) c.JobTypeId = Vars.JobTypeID).OrderBy(Function(c) c.CustomerName).ToList()

        Dim jobsToPrint = jobs.Select(Function(c) New With {c.CustomerName, c.KNDY4CustomerC}).GroupBy(Function(c) c.CustomerName) _
            .Select(Function(x) x.FirstOrDefault).ToList
        For Each j In jobsToPrint



            Dim btn As New RadioButton With {
                .Name = "Button" + i.ToString(),
                .Text = j.CustomerName,
                .Height = 40,
                .Dock = DockStyle.Top,
                .Tag = j.KNDY4CustomerC,
                .Appearance = Appearance.Button,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Enabled = True}
            ' 
            Me.Panel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf OnCustomerChanged
            i = i + 1
        Next
    End Sub

    Private Sub OnCustomerChanged(sender As Object, e As EventArgs)

        Dim b As RadioButton = sender
        CheckedListBox1.Items.Clear()


        For Each j In jobs.Where(Function(c) c.KNDY4CustomerC = b.Tag).OrderBy(Function(c) c.JobId).ToList()

            Dim item = CheckedListBox1.Items.Add(j)
            CheckedListBox1.ValueMember = "JobId"
            CheckedListBox1.DisplayMember = "SalesOrderName"
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.ParentForm.Close()
    End Sub

    Private Sub btnPrintLabels_Click(sender As Object, e As EventArgs) Handles btnPrintLabels.Click
        If CanPrint = "OK" Then
            Try
                Dim Q As New QueueProcessingByCommand()
                Q.SetContext(ctx)

                Dim j As New JobToProcess()
                Dim ji As ViewJobNotPrinted
                For Ix = 1 To CheckedListBox1.Items.Count
                    If CheckedListBox1.GetItemChecked(Ix - 1) = True Then
                        ji = CheckedListBox1.Items(Ix - 1)
                        ' Dim jTemp As JobToProcess
                        j.JobId = ji.JobId
                        j.SalesOrder = ji.SalesOrderName

                        'j = ctx.CartonJobInfos.Where(Function(c) c.JobId = ji.JobId).OrderBy(Function(c) c.JobStepOrder).ToList
                        Q.PrintJob(j)
                        MessageBox.Show("We'll print " & j.SalesOrder & " here") 'Select(Function(c) c.SalesOrderName).FirstOrDefault & " here")
                    End If
                Next
            Catch ex As Exception
                log.Debug(ex, ex.Message & vbCrLf & ex.StackTrace)
                MessageBox.Show("An error occurred trying to print labels", "Error")
            End Try
        Else
            MessageBox.Show("We won't print here")
        End If
    End Sub

    Public ReadOnly Property CanPrint As String
        Get
            Return "OK"
        End Get
    End Property

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For Ix = 1 To CheckedListBox1.Items.Count
            CheckedListBox1.SetItemChecked(Ix - 1, True)
        Next
    End Sub

    Private Sub btnDeselectAll_Click(sender As Object, e As EventArgs) Handles btnDeselectAll.Click
        For Ix = 1 To CheckedListBox1.Items.Count
            CheckedListBox1.SetItemChecked(Ix - 1, False)
        Next
    End Sub

    Private Sub btnMore_Click(sender As Object, e As EventArgs) Handles btnMore.Click

    End Sub
End Class
