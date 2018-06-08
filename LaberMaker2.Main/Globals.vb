Imports System.Data.SqlClient
Imports System.Reflection
Imports IniParser
Imports IniParser.Model

Public Module Globals

    Public ReadOnly Property ConnString() As String
        Get
            Return GetConnString()
        End Get

    End Property
    Function GetConnString() As String
        Dim dsnstring As String
        Dim pubFolder As String
        pubFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
        dsnstring = My.Settings.DB_ODBC

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

            Dim instanceofType As ILabelProperties = Activator.CreateInstance(type)
            Return instanceofType

        Else

            ' Error checking Is needed to help catch instances where
            Throw New NotImplementedException()
        End If
    End Function


End Module
