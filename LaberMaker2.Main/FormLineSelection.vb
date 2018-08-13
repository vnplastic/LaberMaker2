Public Class FormLineSelection
    public Property fsono As string
    public Property lineNo As Integer
    Private Class LineItems
        Private m_lineNo As Integer
        Public Property lineNo() As Integer
            Get
                Return m_lineNo
            End Get
            Set(ByVal value As Integer)
                m_lineNo = value
            End Set
        End Property
        Private m_fpartno As String
        Public Property fpartno() As String
            Get
                Return m_fpartno
            End Get
            Set(ByVal value As String)
                m_fpartno = value
            End Set
        End Property
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        lineNo=lstLineItems.SelectedValue
        
        Me.Hide
    End Sub


    Private Sub FormLineSelection_Load(sender As Object, e As EventArgs) Handles Me.Load
            Dim oConnection As New ADODB.Connection
    Dim oRecordset As New ADODB.Recordset
    Dim SqlStr As String
    

    oConnection.Open("FileDSN=" + My.Settings.DB_ODBC)
    SqlStr = "SELECT * FROM VNA042VW06_Items_Line  WHERE fsono='" & fsono & "'"
    oRecordset.Open(SqlStr, oConnection)



        
        oRecordset.MoveFirst
        Dim lst As New List(Of LineItems)

        While Not oRecordset.EOF
            Dim ln As New LineItems
            ln.lineNo=oRecordset.Fields("KNDY4__Line__c").Value
            ln.fpartno=oRecordset.Fields("fpartno").Value
            lst.Add(ln)
            oRecordset.MoveNext
        End While

        lstLineItems.DataSource=lst
        
        lstLineItems.DisplayMember = "fpartno"
        lstLineItems.ValueMember="lineNo"
        lstLineItems.SelectedIndex=0

        '  Sql.ResultSet.MoveFirst()
    End Sub
End Class