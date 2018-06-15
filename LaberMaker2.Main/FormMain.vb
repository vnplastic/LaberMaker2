Imports System.Data.Entity

Public Class FormMain
    Dim m_JobTypeId = 0
    Dim m_JobTypeList As New List(Of JobType)
    Dim m_LoadedJobTypes As Dictionary(Of Integer, UserControl) = New Dictionary(Of Integer, UserControl)
#Region "Job Control"
    Private Sub GetJobTypes()
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        Dim SqlStr As String

        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        SqlStr = "SELECT JobTypeId,JobTypeName FROM VNA057TB01_JobType order by JobTypeName DESC"
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
        ' lblTitle.Text = $"Customers with Pending {b.Text} Jobs"
        SetJobButtons()
    End Sub

    Private Sub SetJobButtons()
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        'Dim Sql As New SqlStatement
        Dim SqlStr As String


        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        SqlStr = "SELECT DISTINCT JobTypeId FROM VNA057VW01_Job_Not_Printed "

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

    Private Sub OnJobTypeChanged(sender As Object, e As EventArgs)
        Dim b As RadioButton = sender

        Dim tmpDLL As ILabelProperties

        If m_JobTypeId <> b.Tag Then
            m_JobTypeId = b.Tag
            'lblTitle.Text = $"Customers with Pending {b.Text} Jobs"
            ' LoadCustomers()
            ' m_CustomerButton = 0
            ' FillListBox()
            ' ShowButtons()
            If SplitContainer1.Panel2.Controls.Count > 0 Then SplitContainer1.Panel2.Controls.RemoveAt(SplitContainer1.Panel2.Controls.Count - 1)
            Select Case m_JobTypeId
                Case 1
                    tmpDLL = Globals.CreateLabelInstance("LabelMaker2.CartonLabels.dll")
                    For Each c As Control In SplitContainer1.Panel2.Controls
                        c.Visible = False
                    Next
                    If m_LoadedJobTypes.ContainsKey(m_JobTypeId) Then
                        SplitContainer1.Panel2.Controls.Add(m_LoadedJobTypes(m_JobTypeId))
                    Else
                        SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
                        m_LoadedJobTypes.Add(m_JobTypeId, tmpDLL.FormPrint)
                    End If

                Case 2

                    tmpDLL = Globals.CreateLabelInstance("LabelMaker2.PalletLabels.dll")
                    For Each c As Control In SplitContainer1.Panel2.Controls
                        c.Visible = False
                    Next
                    If m_LoadedJobTypes.ContainsKey(m_JobTypeId) Then
                        SplitContainer1.Panel2.Controls.Add(m_LoadedJobTypes(m_JobTypeId))
                    Else
                        SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
                        m_LoadedJobTypes.Add(m_JobTypeId, tmpDLL.FormPrint)
                    End If


                Case 3
                    tmpDLL = Globals.CreateLabelInstance("LabelMaker2.AddressLabels.dll")
                    For Each c As Control In SplitContainer1.Panel2.Controls
                        c.Visible = False
                    Next
                    If m_LoadedJobTypes.ContainsKey(m_JobTypeId) Then
                        SplitContainer1.Panel2.Controls.Add(m_LoadedJobTypes(m_JobTypeId))
                    Else
                        SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
                        m_LoadedJobTypes.Add(m_JobTypeId, tmpDLL.FormPrint)
                    End If
                Case Else



            End Select
            If Not tmpDLL Is Nothing Then tmpDLL.DBConnString = "FileDSN=" + My.Settings.DB_ODBC
            'If m_JobTypeId = 2 Then
            '    Dim tmpDLL As ILabelProperties = Globals.CreateLabelInstance("LabelMaker2.PalletLabels.dll")
            '    For Each c As Control In SplitContainer1.Panel2.Controls
            '        c.Visible = False
            '    Next
            '    SplitContainer1.Panel2.Controls.Add(tmpDLL.FormPrint)
            'Else
            'SplitContainer1.Panel2.Controls.RemoveAt(SplitContainer1.Panel2.Controls.Count - 1)
            For Each c As Control In SplitContainer1.Panel2.Controls
                ' c.Visible = True
                Debug.Print(c.Name)
            Next
            'End If
        End If
    End Sub
#End Region
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        GetJobTypes()
    End Sub

    Private Sub JobStepsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobStepsToolStripMenuItem.Click
        Dim frmSTeps As New FormSteps
        frmSTeps.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm As New FormAbout
        frm.Show()
    End Sub
End Class