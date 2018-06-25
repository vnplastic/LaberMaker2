Imports System.ComponentModel
Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormJobSteps
    Dim ctx As New VNDataEntities
    Dim lst As BindingList(Of CustomerJobInfo)
    Dim lstStepsIncluded As List(Of JobStep)
    Dim lstStepsAvailable As List(Of JobStep)
    Dim icurrentCustJob As Integer
    Dim isDirty As Boolean
    Dim currentStep As New CustomerJobStep
    Dim frmLoading As Boolean

    Private Sub FormJobSteps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmLoading = True
        lst = New BindingList(Of CustomerJobInfo)(ctx.CustomerJobInfos.Include("JobType").OrderBy(Function(c) c.CustomerName).ThenBy(Function(d) d.JobType.JobTypeName).ToList())
        grdCustomerJobInfo.AutoGenerateColumns = False
        grdCustomerJobInfo.ColumnCount = 1
        grdCustomerJobInfo.Columns(0).Name = "CustomerName"
        grdCustomerJobInfo.Columns(0).HeaderText = "Customer Name"
        grdCustomerJobInfo.Columns(0).DataPropertyName = "CustomerName"
        grdCustomerJobInfo.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Dim col As New DataGridViewComboBoxColumn
        'lst2 = lst.Select(Function(c) c.JobType).ToList()
        col.DataSource = lst
        col.ValueMember = "JobTypeId"
        col.DisplayMember = "JobTypeName"
        col.DataPropertyName = "JobTypeId"
        col.HeaderText = "Job Type"
        col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        'grdCustomerProfiles.Columns(2).ValueMember = "JobType.JobTypeName"
        grdCustomerJobInfo.Columns.Add(col)

        grdCustomerJobInfo.DataSource = lst
        FillComboBoxes()

        frmLoading = False
    End Sub

    Private Sub FillComboBoxes()
        frmLoading = True
        Dim lstPrinterCompatibility As New List(Of TypesWithName)
        Dim lstSourceType As New List(Of TypesWithName)
        Dim lstDeliveryType As New List(Of TypesWithName)
        Dim lstLabelOrientation As New List(Of TypesWithName)
        Dim lstLabelSize As New List(Of TypesWithName)
        lstPrinterCompatibility = ctx.TypesWithNames.Where(Function(c) c.TypeName = "Printer Compatibility").ToList()
        lstSourceType = ctx.TypesWithNames.Where(Function(c) c.TypeName = "Source Type").ToList()
        lstDeliveryType = ctx.TypesWithNames.Where(Function(c) c.TypeName = "Delivery Type").ToList()
        lstLabelOrientation = ctx.TypesWithNames.Where(Function(c) c.TypeName = "Label Orientation").ToList()
        lstLabelSize = ctx.TypesWithNames.Where(Function(c) c.TypeName = "Label Size").ToList()

        cboLabelSize.DataSource = lstLabelSize
        cboLabelSize.DisplayMember = "TypeCodeName"
        cboLabelSize.ValueMember = "TypeCodeId"

        cboDeliveryType.DataSource = lstDeliveryType
        cboDeliveryType.DisplayMember = "TypeCodeName"
        cboDeliveryType.ValueMember = "TypeCodeId"

        cboPrinterCompatibility.DataSource = lstPrinterCompatibility
        cboPrinterCompatibility.DisplayMember = "TypeCodeName"
        cboPrinterCompatibility.ValueMember = "TypeCodeId"

        cboSourceType.DataSource = lstSourceType
        cboSourceType.DisplayMember = "TypeCodeName"
        cboSourceType.ValueMember = "TypeCodeId"

        cboLabelOrientation.DataSource = lstLabelOrientation
        cboLabelOrientation.DisplayMember = "TypeCodeName"
        cboLabelOrientation.ValueMember = "TypeCodeId"
        frmLoading = False

    End Sub


    Private Sub grdCustomerJobInfo_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdCustomerJobInfo.RowEnter
        ' MessageBox.Show(lst(e.RowIndex).CustomerShortName)

        Dim iJobType As Integer = lst(e.RowIndex).JobTypeId
        Dim iCustomerInfo As Integer = lst(e.RowIndex).CustomerJobInfoId
        Dim lstSteps As New List(Of JobStep)
        lstSteps = ctx.CustomerJobSteps.Where(Function(c) c.CustomerJobInfoId = iCustomerInfo).Select(Function(d) d.JobStep).OrderBy(Function(d) d.JobStepOrder).ToList()

        Dim lst2 As New List(Of Integer)
        lst2 = lstSteps.Select(Function(d) d.JobStepId).ToList()
        lstStepsIncluded = New List(Of JobStep)(lstSteps)
        lstStepsAvailable = New List(Of JobStep)(ctx.JobSteps.Where(Function(c) c.JobTypeId = iJobType And Not lst2.Contains(c.JobStepId)).OrderBy(Function(d) d.JobStepOrder).ToList())
        ' lstStepsAvailable = ctx.CustomerJobSteps.Include("JobStep").Where(Function(c) c.CustomerJobInfoId = i).ToList()
        'lstCurrentSteps.DataSource = lstStepsIncluded ' New BindingList(Of JobStep)(lstStepsIncluded.Select(Function(c) c.JobStep).ToList())
        'lstCurrentSteps.DisplayMember = "JobStepName"
        'lstCurrentSteps.ValueMember = "JobStepOrder"


        'lstAvailableSteps.DataSource = lstStepsAvailable
        'lstAvailableSteps.DisplayMember = "JobStepName"
        'lstAvailableSteps.ValueMember = "JobStepOrder"
        lstCurrentSteps.Items.Clear()
        lstAvailableSteps.Items.Clear()
        For Each s In lstStepsIncluded
            lstCurrentSteps.Items.Add(s)
            lstCurrentSteps.DisplayMember = "JobStepName"
            lstCurrentSteps.ValueMember = "JobStepOrder"

        Next
        lstAvailableSteps.Items.Clear()
        For Each s In lstStepsAvailable
            lstAvailableSteps.Items.Add(s)
            lstAvailableSteps.DisplayMember = "JobStepName"
            lstAvailableSteps.ValueMember = "JobStepOrder"

        Next
        icurrentCustJob = e.RowIndex
        ClearForm()
    End Sub

    Private Sub ClearForm()
        numLabelCount.Value = Nothing
        cboDeliveryType.SelectedIndex = -1
        cboLabelSize.SelectedIndex = -1
        cboSourceType.SelectedIndex = -1
        cboPrinterCompatibility.SelectedIndex = -1
        cboLabelOrientation.SelectedIndex = -1
    End Sub

    Private Sub btnMoveToCurrent_Click(sender As Object, e As EventArgs) Handles btnMoveToCurrent.Click
        Dim currentAvaialble As JobStep
        If lstAvailableSteps.SelectedIndex <> -1 Then
            currentAvaialble = lstStepsAvailable(lstAvailableSteps.SelectedIndex)
            lstStepsIncluded.Add(currentAvaialble)
            lstStepsAvailable.Remove(currentAvaialble)
            lstCurrentSteps.Items.Clear()
            lstAvailableSteps.Items.Clear()
            lstStepsIncluded.Sort(Function(x As JobStep, y As JobStep)
                                      Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                  End Function)
            lstStepsAvailable.Sort(Function(x As JobStep, y As JobStep)
                                       Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                   End Function)
            For Each s In lstStepsIncluded
                lstCurrentSteps.Items.Add(s)
                lstCurrentSteps.DisplayMember = "JobStepName"
                lstCurrentSteps.ValueMember = "JobStepOrder"

            Next
            lstAvailableSteps.Items.Clear()
            For Each s In lstStepsAvailable
                lstAvailableSteps.Items.Add(s)
                lstAvailableSteps.DisplayMember = "JobStepName"
                lstAvailableSteps.ValueMember = "JobStepOrder"

            Next
            'ctx.SaveChanges()
        End If

    End Sub

    Private Sub btnMoveToAvailable_Click(sender As Object, e As EventArgs) Handles btnMoveToAvailable.Click
        Dim currentInclude As JobStep
        If lstCurrentSteps.SelectedIndex <> -1 Then
            currentInclude = lstStepsIncluded(lstCurrentSteps.SelectedIndex)
            lstStepsIncluded.Remove(currentInclude)
            lstStepsAvailable.Add(currentInclude)

            lstCurrentSteps.Items.Clear()
            lstAvailableSteps.Items.Clear()
            lstStepsIncluded.Sort(Function(x As JobStep, y As JobStep)
                                      Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                  End Function)
            lstStepsAvailable.Sort(Function(x As JobStep, y As JobStep)
                                       Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                   End Function)

            For Each s In lstStepsIncluded
                lstCurrentSteps.Items.Add(s)
                lstCurrentSteps.DisplayMember = "JobStepName"
                lstCurrentSteps.ValueMember = "JobStepOrder"

            Next
            lstAvailableSteps.Items.Clear()
            For Each s In lstStepsAvailable
                lstAvailableSteps.Items.Add(s)
                lstAvailableSteps.DisplayMember = "JobStepName"
                lstAvailableSteps.ValueMember = "JobStepOrder"

            Next
            'ctx.SaveChanges()



        End If
    End Sub

    Private Sub lstCurrentSteps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCurrentSteps.SelectedIndexChanged

        If lstCurrentSteps.SelectedIndex <> -1 Then

            Dim iJobStepId As Integer = lstCurrentSteps.Items(lstCurrentSteps.SelectedIndex).JobStepId
            Dim iCustInfoId As Integer = lst(icurrentCustJob).CustomerJobInfoId
            Dim newStep As New CustomerJobStep
            newStep = ctx.CustomerJobSteps.Where(Function(c) c.JobStepId = iJobStepId And
                                                                   c.CustomerJobInfoId = iCustInfoId).FirstOrDefault()
            If currentStep.CustomerJobStepsId <> newStep.CustomerJobStepsId And isDirty Then
                SaveChanges()
            End If
            ' lstCurrentSteps.Items(lstCurrentSteps.SelectedIndex)
            If newStep Is Nothing Then 'New Record
                currentStep = New CustomerJobStep
                isDirty = True
                ClearForm()
            Else
                If newStep.LabelOrientationId Is Nothing Then cboLabelOrientation.SelectedIndex = -1 Else cboLabelOrientation.SelectedValue = newStep.LabelOrientationId
                If newStep.DeliveryTypeId Is Nothing Then cboDeliveryType.SelectedIndex = -1 Else cboDeliveryType.SelectedValue = newStep.DeliveryTypeId
                If newStep.LabelSizeId Is Nothing Then cboLabelSize.SelectedIndex = -1 Else cboLabelSize.SelectedValue = newStep.LabelSizeId
                If newStep.PrinterCompatibilityID Is Nothing Then cboPrinterCompatibility.SelectedIndex = -1 Else cboPrinterCompatibility.SelectedValue = newStep.PrinterCompatibilityID
                If newStep.SourceTypeId Is Nothing Then cboSourceType.SelectedIndex = -1 Else cboSourceType.SelectedValue = newStep.SourceTypeId
                If newStep.LabelCount Is Nothing Then numLabelCount.Value = 0 Else numLabelCount.Value = newStep.LabelCount
                currentStep = newStep

            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveChanges()
    End Sub


    Private Sub SettingChanged(sender As Object, e As EventArgs) Handles cboPrinterCompatibility.ValueMemberChanged, numLabelCount.ValueChanged, cboSourceType.ValueMemberChanged, cboLabelSize.ValueMemberChanged, cboLabelOrientation.ValueMemberChanged, cboDeliveryType.ValueMemberChanged, cboPrinterCompatibility.SelectedIndexChanged, cboLabelSize.SelectedIndexChanged, cboSourceType.SelectedIndexChanged, cboLabelOrientation.SelectedIndexChanged, cboDeliveryType.SelectedIndexChanged
        isDirty = If(frmLoading, False, True)
    End Sub
    Private Sub SaveChanges()
        Dim iCustInfoId As Integer = lst(icurrentCustJob).CustomerJobInfoId
        currentStep.LabelOrientationId = cboLabelOrientation.SelectedValue
        currentStep.DeliveryTypeId = cboDeliveryType.SelectedValue
        currentStep.LabelSizeId = cboLabelSize.SelectedValue
        currentStep.PrinterCompatibilityID = cboPrinterCompatibility.SelectedValue
        currentStep.SourceTypeId = cboSourceType.SelectedValue
        currentStep.LabelCount = numLabelCount.Value
        currentStep.CustomerJobInfoId = iCustInfoId
        currentStep.JobStepId = lstCurrentSteps.Items(lstCurrentSteps.SelectedIndex).JobStepId
        Dim original = ctx.CustomerJobSteps.Find(currentStep.CustomerJobStepsId)
        If Not original Is Nothing Then
            ctx.Entry(original).CurrentValues.SetValues(currentStep)
            ctx.SaveChanges()
        Else
            ctx.CustomerJobSteps.Add(currentStep)
            ctx.SaveChanges()

        End If

        'isDirty = ctx.CustomerJobSteps
        isDirty = False
    End Sub
End Class