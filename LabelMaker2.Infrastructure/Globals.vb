Imports System.Data.Entity.Core.EntityClient
Imports System.Data.SqlClient
Imports System.Reflection
Imports IniParser
Imports IniParser.Model

Public Module Globals
    Private _logger As NLog.Logger
    Private _mode As String
    Private _btLogin As String

    Public ReadOnly Property ConnString() As String
        Get
            Return GetConnString()
        End Get

    End Property

    Public ReadOnly Property FormatPath() As String
        Get

            Return GetConnString()
        End Get

    End Property
    Private DB_ODBCValue As String
    Public Property DB_ODBC() As String
        Get
            Return DB_ODBCValue
        End Get
        Set(ByVal value As String)
            DB_ODBCValue = value
        End Set
    End Property
    Private batendExeValue As String
    Public Property BartendExe() As String
        Get
            Return batendExeValue
        End Get
        Set(ByVal value As String)
            batendExeValue = value
        End Set
    End Property
    Private templatePathValue As String
    Public Property TemplatePath() As String
        Get
            Return templatePathValue
        End Get
        Set(ByVal value As String)
            templatePathValue = value
        End Set
    End Property
    Private batchPathValue As String
    Public Property BatchPath() As String
        Get
            Return batchPathValue
        End Get
        Set(ByVal value As String)
            batchPathValue = value
        End Set
    End Property
    Public ReadOnly Property Logger() As NLog.Logger
        Get
            If _logger Is Nothing Then
                Return NLog.LogManager.GetCurrentClassLogger
            Else
                Return _logger
            End If

        End Get

    End Property
    Public ReadOnly Property Mode() As String
        Get
            Dim args As String() = Environment.GetCommandLineArgs
            If args.Count > 1 AndAlso args(1).ToUpper = "TEST" Then _mode = "Test"
            If args.Count > 1 AndAlso args(1).ToUpper = "PRODTEST" Then _mode = "PRODTEST"
            If args.Count > 1 AndAlso args(1).ToUpper = "LOCALTEST" Then _mode = "LOCALTEST"
            Return _mode
        End Get

    End Property
    Public ReadOnly Property BTLogin() As String
        Get
            If Mode = "PRODTEST" Then
                _btLogin = "/UID=sa /PWD=400BrightonRoad"
            Else _btLogin = ""
            End If
            Return _btLogin
        End Get

    End Property
    Function GetConnString() As String
        Dim dsnstring As String
        Dim pubFolder As String
        pubFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
        dsnstring = Globals.DB_ODBC 'My.Settings.DB_ODBC

        Dim Parser = New FileIniDataParser()
        Dim Data As IniData
        Data = Parser.ReadFile(pubFolder + "\\" + dsnstring.Replace("FILEDSN=", "") + ".dsn")
        Dim connSQL As SqlConnectionStringBuilder
        connSQL = New SqlConnectionStringBuilder()
        connSQL.DataSource = Data("ODBC")("SERVER")
        connSQL.InitialCatalog = Data("ODBC")("DATABASE")
        If Data("ODBC")("Trusted_Connection") = "Yes" Then

            connSQL.IntegratedSecurity = True

        Else

            connSQL.UserID = "sa"
            connSQL.Password = "400BrightonRoad"
        End If
        GetConnString = connSQL.ConnectionString



    End Function

    Function CreateLabelInstance(assemblyInfo As String) As ILabelProperties

        Dim assembly As Assembly = Assembly.LoadFrom(assemblyInfo)

        If (assembly <> Nothing) Then
            Dim types() As Type = assembly.GetTypes()

            'Dim type As Type = assembly.GetType("LabelMaker.AddressLabels.LabelProperties")
            Dim type = types.Where(Function(t) GetType(ILabelProperties).IsAssignableFrom(t)).FirstOrDefault

            'Dim instanceofType As ILabelProperties = Activator.CreateInstance(type, "FileDSN=" + My.Settings.DB_ODBC)
            Dim instanceofType As ILabelProperties = Activator.CreateInstance(type, GetEFConnectionString)
            Return instanceofType

        Else

            ' Error checking Is needed to help catch instances where
            Throw New NotImplementedException()
        End If
    End Function
    Function GetEFConnectionString() As String
        Dim sqlBuilder As New SqlConnectionStringBuilder()
        Dim EFBuilder As New EntityConnectionStringBuilder()
        Dim providerString As String = GetConnString()

        EFBuilder.Provider = "System.Data.SqlClient"
        EFBuilder.ProviderConnectionString = providerString
        EFBuilder.Metadata = "res://LabelMaker2.Infrastructure/DataModel1.csdl|res://LabelMaker2.Infrastructure/DataModel1.ssdl|res://LabelMaker2.Infrastructure/DataModel1.msl"



        'Dim conn As String
        'conn = "metadata=res://*/DataModel1.csdl|res://*/DataModel1.ssdl|res://*/DataModel1.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source="
        'conn = conn & GetConnString() 'M4800;Initial Catalog=VNData;Integrated Security=True;Persist Security Info=True&quot;"
        'conn = conn & " providerName = ""System.Data.EntityClient"""
        'Return conn
        Return EFBuilder.ToString()
    End Function
End Module
