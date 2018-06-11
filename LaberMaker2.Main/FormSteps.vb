Public Class FormSteps
    Public jobSteps As List(Of JobStep) = New List(Of JobStep)
    Dim jobBindingSource As New BindingSource
    Dim dbContext As New LabelMakerDBContext

    Private Sub FormSteps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oConnection As New ADODB.Connection
        Dim oRecordset As New ADODB.Recordset
        Dim SqlStr As String

        'grdSteps.Columns.Add("JobStepId", "StepId")
        'Dim jobTypes As List(Of JobType) = dbContext.JobTypes.ToList()
        'Dim jobSteps As List(Of JobStep) = dbContext.JobSteps.ToList()



        'Dim var = From j In jobSteps Select j.JobType.JobTypeName, j.JobStepName, j.JobStepOrder, j.JobTypeId Order By JobTypeId, JobStepOrder

        grdSteps.Columns.Add("JobTypeName", "Job Type Name")
        grdSteps.Columns("JobTypeName").DataPropertyName = "JobTypeName"

        'grdSteps.Columns("JobTypeName").Dis
        grdSteps.Columns.Add("JobStepName", "Step Name")
        grdSteps.Columns("JobStepName").DataPropertyName = "JobStepName"

        grdSteps.Columns.Add("JobStepOrder", "Step Order")
        grdSteps.Columns("JobStepOrder").DataPropertyName = "JobStepOrder"
        grdSteps.Columns.Add("JobTypeId", "Job Type Id")
        grdSteps.Columns("JobTypeId").DataPropertyName = "JobTypeId"
        grdSteps.Columns("JobTypeId").Visible = False

        oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
        SqlStr = "SELECT JobStepId, JobTypeName, JobStepName, JobStepOrder FROM VNA057TB03_Job_Step JOIN VNA057TB01_JobType " _
            & "ON VNA057TB03_Job_Step.JobTypeId=VNA057TB01_JobType.JobTypeId order by VNA057TB03_Job_Step.JobTypeId,JobStepOrder"
        oRecordset.Open(SqlStr, oConnection)


        If oRecordset.State = 1 Then
            If Not (oRecordset.EOF) Then
                oRecordset.MoveFirst()
                Do While Not oRecordset.EOF
                    Dim job As JobStep = New JobStep With {
                            .JobTypeName = oRecordset.Fields("JobTypeName").Value,
                            .JobStepId = oRecordset.Fields("JobStepId").Value,
                            .JobStepName = oRecordset.Fields("JobStepName").Value.ToString(),
                            .JobStepOrder = oRecordset.Fields("JobStepOrder").Value}

                    jobSteps.Add(job)

                    'AddHandler btn.CheckedChanged, AddressOf OnJobTypeChanged
                    oRecordset.MoveNext()
                Loop
            End If
        End If


        'jobBindingSource.DataSource = var 'jobSteps

        jobBindingSource.DataSource = jobSteps

        grdSteps.DataSource = jobBindingSource
        grdSteps.Refresh()

    End Sub
End Class