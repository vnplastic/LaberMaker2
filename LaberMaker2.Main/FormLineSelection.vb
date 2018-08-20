Imports LabelMaker2.Main.Data.VNDataModel

Public Class FormLineSelection
    Public Property fsono As String
    Public Property SOId As String
    Public Property lineNo As Integer
    Dim lines As List(Of ViewSalesOrder)
    Private ctx As VNDataEntities
    Private Class LineItems
        Private m_lineNo As Integer
        Public Property LineNo() As Integer
            Get
                Return m_lineNo
            End Get
            Set(ByVal value As Integer)
                m_lineNo = value
            End Set
        End Property
        Private m_fpartno As String
        Public Property Partno() As String
            Get
                Return m_fpartno
            End Get
            Set(ByVal value As String)
                m_fpartno = value
            End Set
        End Property
    End Class




    Private Sub FormLineSelection_Load(sender As Object, e As EventArgs) Handles Me.Load
        ctx = New VNDataEntities


        lines = ctx.ViewSalesOrders.AsNoTracking.Where(Function(c) c.SalesOrderId = SOId).ToList



        '    Dim lst As New List(Of LineItems)



        lstLineItems.DataSource = lines

        lstLineItems.DisplayMember = "ProductName"
        lstLineItems.ValueMember = "LineNo"
        lstLineItems.SelectedIndex = -1

        '  Sql.ResultSet.MoveFirst()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        lineNo = lstLineItems.SelectedValue

        Me.Hide()
    End Sub
End Class