Imports System.Configuration
Imports System.Data.Entity

Public Class LabelMakerDBContext
    Inherits DbContext

    Public Sub New()
        ' MyBase.New(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        MyBase.New(Globals.ConnString)
    End Sub

    Public Property JobTypes As DbSet(Of JobType)
    Public Property JobSteps As DbSet(Of JobStep)


    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        Database.SetInitializer(Of LabelMakerDBContext)(Nothing)
    End Sub
End Class
