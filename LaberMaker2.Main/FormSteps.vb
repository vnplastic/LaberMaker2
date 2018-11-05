Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormSteps
    Public jobSteps As List(Of LabelMaker2.Main.Data.VNDataModel.TableJobStep) = New List(Of LabelMaker2.Main.Data.VNDataModel.TableJobStep)
    Dim jobBindingSource As New BindingSource
    Dim dbContext As New VNDataEntities

    Private Sub FormSteps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        jobSteps = dbContext.TableJobSteps.Include("JobType").ToList()

        Dim var = From j In jobSteps Select j.JobType.JobTypeName, j.JobStepName, j.JobStepOrder, j.JobTypeId Order By JobTypeId, JobStepOrder

        'grdSteps.Columns.Add("JobTypeName", "Job Type Name")
        'grdSteps.Columns("JobTypeName").DataPropertyName = "JobTypeName"
        'grdSteps.Columns.Add("JobStepName", "Step Name")
        'grdSteps.Columns("JobStepName").DataPropertyName = "JobStepName"

        'grdSteps.Columns.Add("JobStepOrder", "Step Order")
        'grdSteps.Columns("JobStepOrder").DataPropertyName = "JobStepOrder"
        'grdSteps.Columns.Add("JobTypeId", "Job Type Id")
        'grdSteps.Columns("JobTypeId").DataPropertyName = "JobTypeId"
        'grdSteps.Columns("JobTypeId").Visible = False

        jobBindingSource.DataSource = var 'jobSteps

        grdSteps.DataSource = jobBindingSource
        grdSteps.Refresh()

    End Sub
End Class