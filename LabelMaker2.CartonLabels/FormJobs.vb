Imports System.Drawing
Imports System.Windows.Forms
Imports LaberMaker2.Main

Public Class FormJobs
    Private Sub FormJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        Dim SqlStr As String
        Dim i As Integer = 0
        'Dim ctrls As List(Of Control) = New List(Of Control)

        oConnection.Open(Vars.DBConnString)
        SqlStr = "SELECT DISTINCT CustomerName, KNDY4__Customer__c FROM VNA057VW01_Job_Not_Printed WHERE JobTypeId=" & Vars.JobTypeID.ToString() & " order by CustomerName DESC"
        oRecordset.Open(SqlStr, oConnection)


        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()
                Do While Not oRecordset.EOF
                    ''            Dim job As JobType = New JobType With {
                    '                    .JobTypeId = oRecordset.Fields("JobTypeId").Value,
                    '                    .JobTypeName = oRecordset.Fields("JobTypeName").Value}

                    '            m_JobTypeList.Add(job)
                    Dim btn As New RadioButton With {
                            .Name = "Button" + i.ToString(),
                            .Text = oRecordset.Fields("CustomerName").Value.ToString(),
                         .Height = 40,
                            .Dock = DockStyle.Top,
                            .Tag = oRecordset.Fields("KNDY4__Customer__c").Value.ToString(),
                            .Appearance = Appearance.Button,
                            .TextAlign = ContentAlignment.MiddleCenter,
                            .Enabled = True}
                    ' 
                    Panel1.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf OnCustomerChanged
                    'ctrls.Add(btn)
                    i = i + 1
                    oRecordset.MoveNext()
                Loop
            End If
        End If


        'Dim b As RadioButton = Me.Controls.Find("Button0", True).FirstOrDefault
        'b.Select()
        'b.Enabled = True
    End Sub

    Private Sub OnCustomerChanged(sender As Object, e As EventArgs)
        'Throw New NotImplementedException
        Dim b As RadioButton = sender
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        Dim SqlStr As String
        Dim i As Integer = 0
        'Dim ctrls As List(Of Control) = New List(Of Control)

        oConnection.Open(Vars.DBConnString)
        SqlStr = "SELECT JobId, CustomerName, KNDY4__Customer__c FROM VNA057VW01_Job_Not_Printed WHERE JobTypeId=" & Vars.JobTypeID.ToString() & " AND KNDY4__Customer__c='" _
                 & b.Tag & "' ORDER BY JobId"
        oRecordset.Open(SqlStr, oConnection)
        CheckedListBox1.Items.Clear()

        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()
                Do While Not oRecordset.EOF
                    CheckedListBox1.Items.Add(oRecordset.Fields("JobId").Value.ToString())

                    oRecordset.MoveNext()
                Loop
            End If
        End If
    End Sub
End Class
