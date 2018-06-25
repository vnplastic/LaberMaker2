Imports System.Drawing
Imports System.Windows.Forms
Imports LaberMaker2.Main
Imports System.Data.Entity
Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormJobs
    Dim ctx As VNDataEntities
    Dim jobs As List(Of ViewJobNotPrinted)
    Private Sub FormJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ctx = New VNDataEntities(Vars.ConnString)
        Dim i As Integer = 0

        jobs = ctx.ViewJobNotPrinteds.Where(Function(c) c.JobTypeId = Vars.JobTypeID).OrderBy(Function(c) c.CustomerName).ToList()

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
            CheckedListBox1.Items.Add(j.JobId)
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.ParentForm.Close()
    End Sub
End Class
