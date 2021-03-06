﻿Option Explicit On

Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormCustomerProfile
    Dim ctx As VNDataEntities
    Dim custBindingSource As New BindingSource
    Dim lst As List(Of LabelMaker2.Main.Data.VNDataModel.TableCustomerJobInfo) = New List(Of LabelMaker2.Main.Data.VNDataModel.TableCustomerJobInfo)
    Dim newcustBindingSource As New BindingSource
    Dim lstCust As List(Of LabelMaker2.Main.Data.VNDataModel.ViewCustomerSoldTo) = New List(Of LabelMaker2.Main.Data.VNDataModel.ViewCustomerSoldTo)
    Dim typeBindingSource As New BindingSource
    Dim lstType As List(Of LabelMaker2.Main.Data.VNDataModel.TableJobType) = New List(Of LabelMaker2.Main.Data.VNDataModel.TableJobType)
    Dim printerBindingSource As New BindingSource
    Dim lstPrinters As List(Of LabelMaker2.Main.Data.VNDataModel.TablePrinter) = New List(Of LabelMaker2.Main.Data.VNDataModel.TablePrinter)
    Dim bAddMode As Boolean = False
    Dim log As NLog.Logger


    Private Sub FormCustomerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As String = Globals.GetEFConnectionString
        ctx = New VNDataEntities(conn)
        log = NLog.LogManager.GetLogger("Logfile")
        log.Trace("Customer Profile Form Starting Up....")
        grdCustomerProfiles.AutoGenerateColumns = False


        '  Dim lst2 As List(Of LabelMaker2.Main.Data.VNDataModel.JobType) = New List(Of LabelMaker2.Main.Data.VNDataModel.JobType)
        lst = ctx.TableCustomerJobInfos.Include("JobType").Include("Printer").OrderBy(Function(c) c.CustomerName).ToList()

        custBindingSource.DataSource = lst
        grdCustomerProfiles.ColumnCount = 3
        grdCustomerProfiles.Columns(0).Name = "CustomerName"
        grdCustomerProfiles.Columns(0).HeaderText = "Customer Name"
        grdCustomerProfiles.Columns(0).DataPropertyName = "CustomerName"

        'grdCustomerProfiles.Columns(2).Name = "JobTypeName"
        'grdCustomerProfiles.Columns(2).HeaderText = "Job Type"
        'grdCustomerProfiles.Columns(2).DataPropertyName = "JobTypeName"

        'grdCustomerProfiles.Columns(1).Name = "JobTypeId"
        'grdCustomerProfiles.Columns(1).HeaderText = "Job Type Id"
        'grdCustomerProfiles.Columns(1).DataPropertyName = "JobTypeId"

        grdCustomerProfiles.Columns(1).Name = "CustomerShortName"
        grdCustomerProfiles.Columns(1).HeaderText = "Cust Short Name"
        grdCustomerProfiles.Columns(1).DataPropertyName = "CustomerShortName"


        grdCustomerProfiles.Columns(2).Name = "CustNo"
        grdCustomerProfiles.Columns(2).HeaderText = "Customer No"
        grdCustomerProfiles.Columns(2).DataPropertyName = "CustNo"

        Dim col As New DataGridViewComboBoxColumn
        'lst2 = lst.Select(Function(c) c.JobType).ToList()
        col.DataSource = custBindingSource
        col.ValueMember = "JobTypeId"
        col.DisplayMember = "JobTypeName"
        col.DataPropertyName = "JobTypeId"
        col.HeaderText = "Job Type"
        col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        'grdCustomerProfiles.Columns(2).ValueMember = "JobType.JobTypeName"
        grdCustomerProfiles.Columns.Add(col)
        Dim col2 As New DataGridViewComboBoxColumn
        'lst2 = lst.Select(Function(c) c.JobType).ToList()
        col2.DataSource = custBindingSource
        col2.ValueMember = "PrinterId"
        col2.DisplayMember = "PrinterName"
        col2.DataPropertyName = "PrinterId"
        col2.HeaderText = "Printer"
        col2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        'grdCustomerProfiles.Columns(2).ValueMember = "JobType.JobTypeName"
        grdCustomerProfiles.Columns.Add(col2)
        ' grdCustomerProfiles.Columns(2).DataPropertyName = lst(0).JobType.JobTypeName

        grdCustomerProfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        grdCustomerProfiles.DataSource = custBindingSource

        lstCust = ctx.ViewCustomerSoldTos.OrderBy(Function(c) c.Name).ToList()
        newcustBindingSource.DataSource = lstCust
        lstType = ctx.TableJobTypes.OrderBy(Function(c) c.JobTypeName).ToList()
        typeBindingSource.DataSource = lstType

        lstPrinters = ctx.TablePrinters.ToList()

        printerBindingSource.DataSource = lstPrinters

        cboCustomer.ValueMember = "Id"
        cboCustomer.DisplayMember = "Name"

        cboCustomer.DataSource = newcustBindingSource
        cboJobType.ValueMember = "JobTypeId"
        cboJobType.DisplayMember = "JobTypeName"

        cboJobType.DataSource = typeBindingSource

        cboPrinter.DataSource = printerBindingSource
        cboPrinter.ValueMember = "PrinterId"
        cboPrinter.DisplayMember = "PrinterName"

        ClearForm()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearForm()
        bAddMode = True
    End Sub

    Private Sub cboCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomer.SelectedIndexChanged
        Dim cbo As ComboBox = sender
        If cbo.SelectedIndex <> -1 Then
            txtCustName.Text = cbo.SelectedItem.Name
        Else
            txtCustName.Text = ""
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Dim cust As New LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo()
        Dim cust As TableCustomerJobInfo
        If String.IsNullOrEmpty(txtCustName.Text) Then
            MessageBox.Show("You need to select a customer first", "Error")
            Return
        End If
        If String.IsNullOrEmpty(txtCustomerShortName.Text) Then
            MessageBox.Show("You need to enter a short name for the customer first", "Error")
            Return
        End If
        If cboJobType.SelectedIndex = -1 Then
            MessageBox.Show("You need to select a Job Type first", "Error")
            Return
        End If
        Dim custId As String
        Dim jobType As Integer
        custId = cboCustomer.SelectedValue
        jobType = cboJobType.SelectedValue
        cust = ctx.TableCustomerJobInfos.Where(Function(c) c.KNDY4CustomerC1 = custId And c.JobTypeId = jobType).FirstOrDefault
        If cust Is Nothing Then
               cust = New TableCustomerJobInfo
        lst.Add(cust)
        ctx.TableCustomerJobInfos.Add(cust)
        End If
        cust.JobTypeId = cboJobType.SelectedValue
        cust.KNDY4CustomerC1 = cboCustomer.SelectedValue '"a1B36000001hoHbEAI"
        cust.CustomerName = txtCustName.Text '"Wal-Mart Stores Inc."
        cust.CustomerShortName = txtCustomerShortName.Text
        cust.PrinterId = cboPrinter.SelectedValue
        cust.LabelPerLine = chkPerLineLabel.Checked
        cust.Serialized = chkSerialized.Checked
        cust.CustomerPrintName = txtLabelName.Text
        cust.CustNo = txtCustNo.Text

        'If bAddMode Then
        '    Dim custExists As Int16
        '    custExists = ctx.CustomerJobInfos.Where(Function(c) c.KNDY4CustomerC1 = cust.KNDY4CustomerC1 And c.JobTypeId = cust.JobTypeId).Count
        '    If custExists = 0 Then
        '        lst.Add(cust)
        '        ctx.CustomerJobInfos.Add(cust)
        '    Else
        '        MessageBox.Show("A record with this customer and JobType already exists", "Error")
        '        Return
        '    End If

        'End If
        ctx.SaveChanges()
        custBindingSource.ResetBindings(False)
        ' grdCustomerProfiles.Refresh()


        'ClearForm()
        bAddMode = False
    End Sub
    Sub ClearForm()
        cboCustomer.SelectedIndex = -1
        cboJobType.SelectedIndex = -1
        cboPrinter.SelectedIndex = -1
        txtCustomerShortName.Text = ""
        chkSerialized.Checked = False
        chkPerLineLabel.Checked = False
        txtLabelName.Text = ""
        txtCustNo.Text = ""
        txtNextLabel.Text = ""
        grdCustomerProfiles.Rows(0).Selected = True
    End Sub

    Private Sub grdCustomerProfiles_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grdCustomerProfiles.UserDeletedRow
        'Dim var As LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo = TryCast(e.Row.DataBoundItem, LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo)
        ''custBindingSource
        'ctx.CustomerJobInfos.Remove(var)
        'custBindingSource.ResetBindings(False)
        'ctx.SaveChanges()
    End Sub

    Private Sub grdCustomerProfiles_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles grdCustomerProfiles.UserDeletingRow
        Dim var As LabelMaker2.Main.Data.VNDataModel.TableCustomerJobInfo = TryCast(e.Row.DataBoundItem, LabelMaker2.Main.Data.VNDataModel.TableCustomerJobInfo)

        lst.Remove(var)
        ctx.TableCustomerJobInfos.Remove(var)
        ctx.SaveChanges()
        custBindingSource.ResetBindings(False)

    End Sub

    Private Sub grdCustomerProfiles_SelectionChanged(sender As Object, e As EventArgs) Handles grdCustomerProfiles.SelectionChanged
        Dim s As DataGridView = TryCast(sender, DataGridView)
        If s.SelectedRows.Count > 0 Then
            Dim t As TableCustomerJobInfo = TryCast(s.SelectedRows(0).DataBoundItem, TableCustomerJobInfo)
            cboCustomer.SelectedIndex = cboCustomer.FindString(t.CustomerName)
            cboJobType.SelectedIndex = cboJobType.FindString(t.JobTypeName)
            cboPrinter.SelectedIndex = If(t.PrinterName Is Nothing, -1, cboPrinter.FindString(t.PrinterName))
            txtCustomerShortName.Text = If(t.CustomerShortName = Nothing, "", t.CustomerShortName)
            chkPerLineLabel.Checked = If(t.LabelPerLine Is Nothing, False, t.LabelPerLine)
            chkSerialized.Checked = If(t.Serialized Is Nothing, False, t.Serialized)
            txtLabelName.Text = t.CustomerPrintName
            txtCustNo.Text = t.CustNo
            txtNextLabel.Text = t.NextUniqueLabelNo


            'cboCustomer.SelectedText = t.CustomerName
        End If
    End Sub


End Class