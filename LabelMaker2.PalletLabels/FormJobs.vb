Imports System.Drawing
Imports System.Windows.Forms
Imports LaberMaker2.Main
Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormJobs
    Dim ctx As VNDataEntities
    Dim jobs As List(Of ViewPalletJobsNotPrinted)


    Private Sub FormJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ctx = New VNDataEntities(Vars.ConnString)
        Dim i As Integer = 0
        jobs = ctx.ViewPalletJobsNotPrinteds.Where(Function(c) c.JobTypeId = Vars.JobTypeID).OrderBy(Function(c) c.CustomerName).ToList()

        For Each j In jobs



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
            If Not j.ShipmentData.HasValue Then
                j.SalesOrderName = "**" & j.SalesOrderName
            End If


            Dim item = CheckedListBox1.Items.Add(j)
            CheckedListBox1.ValueMember = "JobId"
            CheckedListBox1.DisplayMember = "SalesOrderName"
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.ParentForm.Close()
    End Sub


    Public ReadOnly Property CanPrint() As String
        Get
            For Ix = 1 To CheckedListBox1.Items.Count
                If CheckedListBox1.GetItemChecked(Ix - 1) = True Then
                    If CheckedListBox1.Items(Ix - 1).SalesOrderName.ToString.Contains("**") Then
                        Dim so As String
                        Dim i As Integer
                        i = Ix - 1
                        so = jobs.Find(Function(c) c.SalesOrderName = CheckedListBox1.Items(i).SalesOrderName).SalesOrderName
                        so = so.Replace("**", "")
                        If _
                            MessageBox.Show(
                                "This order: " & so &
                                " does not have a shipment date, the label may not be correct", "Proceed?",
                                MessageBoxButtons.YesNo) = DialogResult.No Then
                            Return "No Shipment"
                        End If
                    End If
                End If
            Next
            'Dim result = ctx.CustomerJobInfos.Where(Function(c) c.KNDY4CustomerC1 =)
            Return "OK"

        End Get
    End Property

    Private Sub btnPrintLabels_Click(sender As Object, e As EventArgs) Handles btnPrintLabels.Click
        If CanPrint = "OK" Then
            Dim Q As New QueueProcessingByCommand()

            Dim j As List(Of JobInfo)
            Dim ji As ViewPalletJobsNotPrinted
            For Ix = 1 To CheckedListBox1.Items.Count
                If CheckedListBox1.GetItemChecked(Ix - 1) = True Then
                    ji = CheckedListBox1.Items(Ix - 1)
                    j = ctx.JobInfos.Where(Function(c) c.JobId = ji.JobId).OrderBy(Function(c) c.JobStepOrder).ToList
                    Q.PrintJob(j)
                    MessageBox.Show("We'll print " & j.Select(Function(c) c.SalesOrderName).FirstOrDefault & " here")
                End If
            Next
        Else
            MessageBox.Show("We won't print here")
        End If
    End Sub
End Class
