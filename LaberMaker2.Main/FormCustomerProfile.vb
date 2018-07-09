Option Explicit On
Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormCustomerProfile
    Dim ctx As New VNDataEntities
    Dim custBindingSource As New BindingSource
    Dim lst As List(Of LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo) = New List(Of LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo)
    Dim newcustBindingSource As New BindingSource
    Dim lstCust As List(Of LabelMaker2.Main.Data.VNDataModel.CustomerSoldTo) = New List(Of LabelMaker2.Main.Data.VNDataModel.CustomerSoldTo)
    Dim typeBindingSource As New BindingSource
    Dim lstType As List(Of LabelMaker2.Main.Data.VNDataModel.JobType) = New List(Of LabelMaker2.Main.Data.VNDataModel.JobType)
    Dim printerBindingSource As New BindingSource
    Dim lstPrinters As List(Of LabelMaker2.Main.Data.VNDataModel.Printer) = New List(Of LabelMaker2.Main.Data.VNDataModel.Printer)


    Private Sub FormCustomerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdCustomerProfiles.AutoGenerateColumns = False


        '  Dim lst2 As List(Of LabelMaker2.Main.Data.VNDataModel.JobType) = New List(Of LabelMaker2.Main.Data.VNDataModel.JobType)
        lst = ctx.CustomerJobInfos.Include("JobType").Include("Printer").ToList()

        custBindingSource.DataSource = lst
        grdCustomerProfiles.ColumnCount = 2
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

        lstCust = ctx.CustomerSoldTos.AsNoTracking.OrderBy(Function(c) c.Name).ToList()
        newcustBindingSource.DataSource = lstCust
        lstType = ctx.JobTypes.AsNoTracking.OrderBy(Function(c) c.JobTypeName).ToList()
        typeBindingSource.DataSource = lstType

        lstPrinters = ctx.Printers.AsNoTracking.ToList()

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
        Dim cust As New LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo()
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

        cust.JobTypeId = cboJobType.SelectedValue
        cust.KNDY4CustomerC1 = cboCustomer.SelectedValue '"a1B36000001hoHbEAI"
        cust.CustomerName = txtCustName.Text '"Wal-Mart Stores Inc."
        cust.CustomerShortName = txtCustomerShortName.Text
        'lst.Add(cust)
        ctx.CustomerJobInfos.Add(cust)
        lst.Add(cust)
        custBindingSource.ResetBindings(False)
        ' grdCustomerProfiles.Refresh()

        ctx.SaveChanges()
        ClearForm()
    End Sub
    Sub ClearForm()
        cboCustomer.SelectedIndex = -1
        cboJobType.SelectedIndex = -1
        cboPrinter.SelectedIndex = -1
        txtCustomerShortName.Text = ""
    End Sub

    Private Sub grdCustomerProfiles_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grdCustomerProfiles.UserDeletedRow
        'Dim var As LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo = TryCast(e.Row.DataBoundItem, LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo)
        ''custBindingSource
        'ctx.CustomerJobInfos.Remove(var)
        'custBindingSource.ResetBindings(False)
        'ctx.SaveChanges()
    End Sub

    Private Sub grdCustomerProfiles_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles grdCustomerProfiles.UserDeletingRow
        Dim var As LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo = TryCast(e.Row.DataBoundItem, LabelMaker2.Main.Data.VNDataModel.CustomerJobInfo)

        lst.Remove(var)
        ctx.CustomerJobInfos.Remove(var)
        ctx.SaveChanges()
        custBindingSource.ResetBindings(False)

    End Sub
End Class