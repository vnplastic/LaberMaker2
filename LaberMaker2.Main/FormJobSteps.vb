Imports System.ComponentModel
Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormJobSteps
    Dim ctx As New VNDataEntities
    Dim lst As BindingList(Of TableCustomerJobInfo)
    Dim blstStepsIncluded As BindingList(Of TableJobStep)
    Dim blstStepsAvailable As BindingList(Of TableJobStep)
    Dim icurrentCustJob As Integer
    Dim lstStepsIncluded As List(Of TableJobStep)
    Dim lstStepsAvailable As List(Of TableJobStep)

    Dim isDirty As Boolean
    Dim currentStep As New TableCustomerJobStep
    Dim custJobSteps As New BindingList(Of TableCustomerJobStep)
    Dim frmLoading As Boolean

    Private Sub FormJobSteps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmLoading = True
        lst = New BindingList(Of TableCustomerJobInfo)(ctx.TableCustomerJobInfos.Include("JobType").OrderBy(Function(c) c.CustomerName).ThenBy(Function(d) d.JobType.JobTypeName).ToList())
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
        Dim lstPrinterCompatibility As New List(Of ViewTypesWithName)
        Dim lstSourceType As New List(Of ViewTypesWithName)
        Dim lstDeliveryType As New List(Of ViewTypesWithName)
        Dim lstLabelOrientation As New List(Of ViewTypesWithName)
        Dim lstLabelSize As New List(Of ViewTypesWithName)
        lstPrinterCompatibility = ctx.ViewTypesWithNames.Where(Function(c) c.TypeName = "Printer Compatibility").ToList()
        lstSourceType = ctx.ViewTypesWithNames.Where(Function(c) c.TypeName = "Source Type").ToList()
        lstDeliveryType = ctx.ViewTypesWithNames.Where(Function(c) c.TypeName = "Delivery Type").ToList()
        lstLabelOrientation = ctx.ViewTypesWithNames.Where(Function(c) c.TypeName = "Label Orientation").ToList()
        lstLabelSize = ctx.ViewTypesWithNames.Where(Function(c) c.TypeName = "Label Size").ToList()

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
        frmLoading = True

        Dim iJobType As Integer = lst(e.RowIndex).JobTypeId
        Dim iCustomerInfo As Integer = lst(e.RowIndex).CustomerJobInfoId
        ' Dim lstSteps As New List(Of JobStep)
        lstStepsIncluded = ctx.TableCustomerJobSteps.Where(Function(c) c.CustomerJobInfoId = iCustomerInfo).Select(Function(d) d.JobStep).OrderBy(Function(d) d.JobStepOrder).ToList()

        Dim lst2 As New List(Of Integer)
        lst2 = lstStepsIncluded.Select(Function(d) d.JobStepId).ToList()
        blstStepsIncluded = New BindingList(Of TableJobStep)(lstStepsIncluded)
        lstStepsAvailable = New List(Of TableJobStep)(ctx.TableJobSteps.Where(Function(c) c.JobTypeId = iJobType And Not lst2.Contains(c.JobStepId)).OrderBy(Function(d) d.JobStepOrder).ToList())
        blstStepsAvailable = New BindingList(Of TableJobStep)(lstStepsAvailable)




        lstCurrentSteps.DataSource = blstStepsIncluded ' New BindingList(Of JobStep)(blstStepsIncluded.Select(Function(c) c.JobStep).ToList())
        lstCurrentSteps.DisplayMember = "JobStepName"
        lstCurrentSteps.ValueMember = "JobStepOrder"


        lstAvailableSteps.DataSource = blstStepsAvailable
        lstAvailableSteps.DisplayMember = "JobStepName"
        lstAvailableSteps.ValueMember = "JobStepOrder"
        'lstCurrentSteps.Items.Clear()
        'lstAvailableSteps.Items.Clear()
        'For Each s In blstStepsIncluded
        '    lstCurrentSteps.Items.Add(s)
        '    lstCurrentSteps.DisplayMember = "JobStepName"
        '    lstCurrentSteps.ValueMember = "JobStepOrder"

        'Next
        'lstAvailableSteps.Items.Clear()
        'For Each s In blstStepsAvailable
        '    lstAvailableSteps.Items.Add(s)
        '    lstAvailableSteps.DisplayMember = "JobStepName"
        '    lstAvailableSteps.ValueMember = "JobStepOrder"

        'Next
        icurrentCustJob = e.RowIndex
        ClearForm()
        frmLoading = False
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
        Dim currentAvaialble As TableJobStep
        Dim iCustInfoId As Integer = lst(icurrentCustJob).CustomerJobInfoId

        If lstAvailableSteps.SelectedIndex <> -1 Then
            frmLoading = True
            currentAvaialble = blstStepsAvailable(lstAvailableSteps.SelectedIndex)

            blstStepsIncluded.Add(currentAvaialble)
            blstStepsAvailable.Remove(currentAvaialble)
            ' isDirty = True

            lstStepsAvailable.Sort(Function(x As TableJobStep, y As TableJobStep)
                                       Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                   End Function)


            lstStepsIncluded.Sort(Function(x As TableJobStep, y As TableJobStep)
                                      Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                  End Function)

            blstStepsAvailable.ResetBindings()
            blstStepsIncluded.ResetBindings()
            lstCurrentSteps.SelectedIndex = lstCurrentSteps.FindString(currentAvaialble.JobStepName)
            Dim changedStep = New TableCustomerJobStep
            changedStep.JobStepId = currentAvaialble.JobStepId
            changedStep.CustomerJobInfoId = iCustInfoId
            ctx.TableCustomerJobSteps.Add(changedStep)
            ' ctx.CustomerJobSteps.Where(Function(c) c.CustomerJobInfoId = iCustInfoId And c.JobStepId = currentAvaialble.JobStepId)

            ctx.SaveChanges()
            isDirty = False
        End If
        frmLoading = False
    End Sub

    Private Sub btnMoveToAvailable_Click(sender As Object, e As EventArgs) Handles btnMoveToAvailable.Click
        Dim currentInclude As TableJobStep
        Dim iCustInfoId As Integer = lst(icurrentCustJob).CustomerJobInfoId
        If lstCurrentSteps.SelectedIndex <> -1 Then
            frmLoading = True

            'isDirty = True
            currentInclude = blstStepsIncluded(lstCurrentSteps.SelectedIndex)
            blstStepsIncluded.Remove(currentInclude)
            blstStepsAvailable.Add(currentInclude)


            lstStepsIncluded.Sort(Function(x As TableJobStep, y As TableJobStep)
                                      Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                  End Function)
            lstStepsAvailable.Sort(Function(x As TableJobStep, y As TableJobStep)
                                       Return x.JobStepOrder.CompareTo(y.JobStepOrder)
                                   End Function)
            blstStepsAvailable.ResetBindings()
            blstStepsIncluded.ResetBindings()
            Dim changedStep = ctx.TableCustomerJobSteps.Where(Function(c) c.CustomerJobInfoId = iCustInfoId And c.JobStepId = currentInclude.JobStepId).FirstOrDefault
            ctx.TableCustomerJobSteps.Remove(changedStep)
            ctx.SaveChanges()
            isDirty = False
        End If
        frmLoading = False
    End Sub

    Private Sub lstCurrentSteps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCurrentSteps.SelectedIndexChanged
        If frmLoading = False Then
            If isDirty = True Then
                If MessageBox.Show("You have not saved the last change in steps, do you wish the save first?", "Save?", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                    SaveChanges()
                End If
                isDirty = False
            End If
            If lstCurrentSteps.SelectedIndex <> -1 Then

                Dim iJobStepId As Integer = lstCurrentSteps.Items(lstCurrentSteps.SelectedIndex).JobStepId
                Dim iCustInfoId As Integer = lst(icurrentCustJob).CustomerJobInfoId
                Dim newStep As New TableCustomerJobStep
                newStep = ctx.TableCustomerJobSteps.Where(Function(c) c.JobStepId = iJobStepId And
                                                                       c.CustomerJobInfoId = iCustInfoId).FirstOrDefault()


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

        'ctx.SaveChanges()
    End Sub


    Private Sub SettingChanged(sender As Object, e As EventArgs) Handles cboPrinterCompatibility.ValueMemberChanged, numLabelCount.ValueChanged, cboSourceType.ValueMemberChanged, cboLabelSize.ValueMemberChanged, cboLabelOrientation.ValueMemberChanged, cboDeliveryType.ValueMemberChanged, cboPrinterCompatibility.SelectedIndexChanged, cboLabelSize.SelectedIndexChanged, cboSourceType.SelectedIndexChanged, cboLabelOrientation.SelectedIndexChanged, cboDeliveryType.SelectedIndexChanged
        isDirty = If(frmLoading, False, True)
    End Sub
    Private Sub SaveChanges()
        Dim iCustInfoId As Integer = lst(icurrentCustJob).CustomerJobInfoId
        ' Dim original = ctx.CustomerJobSteps.Find(iCustInfoId)
        Dim original = ctx.TableCustomerJobSteps.Where(Function(c) c.CustomerJobInfoId = iCustInfoId And c.JobStepId = currentStep.JobStepId).FirstOrDefault

        If isDirty = True Then
            If Not original Is Nothing Then
                ' ctx.Entry(original).CurrentValues.SetValues(currentStep)
                original.LabelOrientationId = cboLabelOrientation.SelectedValue
                original.DeliveryTypeId = cboDeliveryType.SelectedValue
                original.LabelSizeId = cboLabelSize.SelectedValue
                original.PrinterCompatibilityID = cboPrinterCompatibility.SelectedValue
                original.SourceTypeId = cboSourceType.SelectedValue
                original.LabelCount = numLabelCount.Value

                ctx.SaveChanges()
                'Else
                '    currentStep.LabelOrientationId = cboLabelOrientation.SelectedValue
                'currentStep.DeliveryTypeId = cboDeliveryType.SelectedValue
                'currentStep.LabelSizeId = cboLabelSize.SelectedValue
                'currentStep.PrinterCompatibilityID = cboPrinterCompatibility.SelectedValue
                'currentStep.SourceTypeId = cboSourceType.SelectedValue
                'currentStep.LabelCount = numLabelCount.Value
                'currentStep.CustomerJobInfoId = iCustInfoId
                'currentStep.JobStepId = lstCurrentSteps.Items(lstCurrentSteps.SelectedIndex).JobStepId

                'Dim original = ctx.CustomerJobSteps.Where(Function(c) c.JobStepId = currentStep.JobStepId And c.CustomerJobInfoId = iCustInfoId).FirstOrDefault


                '    ctx.CustomerJobSteps.Add(currentStep)
                'ctx.SaveChanges()

            End If
        End If

        'isDirty = ctx.CustomerJobSteps
        isDirty = False
    End Sub
End Class