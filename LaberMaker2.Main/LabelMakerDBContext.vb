Imports System.Configuration
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.IO

<DbConfigurationType(GetType(MyDBConfig))>
Public Class LabelMakerDBContext
    Inherits DbContext

    Public Sub New()
        ' MyBase.New(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        MyBase.New(Globals.ConnString)
        Database.SetInitializer(Of LabelMakerDBContext)(Nothing)

    End Sub

    Public Property JobTypes As DbSet(Of JobType)
    Public Property JobSteps As DbSet(Of JobStep)


    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

    End Sub
End Class
Public Class MyDBConfig
    Inherits DbConfiguration

    Public Sub New()
        MyBase.New

        Me.SetModelStore(New DefaultDbModelStore(Directory.GetCurrentDirectory()))
    End Sub

End Class
