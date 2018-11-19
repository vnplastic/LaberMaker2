﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 11/19/2018 11:18:38 AM
'
' Changes to this file may cause incorrect behavior and will be lost if
' the code is regenerated.
'------------------------------------------------------------------------------

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Data
Imports System.Data.Common
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.ModelConfiguration
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.Xml.Serialization
Imports System.Data.Entity.Core.EntityClient
Imports System.Data.Entity.Core.Objects
Imports System.Data.Entity.Core.Objects.DataClasses

Namespace VNDataModel

    Public Partial Class VNDataEntities
      Inherits DbContext
        #Region "Constructors"
        ''' <summary>
        ''' Initialize a new VNDataEntities object.
        ''' </summary>
        Public Sub New()            
            MyBase.New("name=VNDataEntitiesConnectionString")
            Configure()
        End Sub

        ''' <summary>
        ''' Initializes a new VNDataEntities object using the connection string found in the 'VNDataEntities' section of the application configuration file.
        ''' </summary>
        Public Sub New(connectionString As String)
            MyBase.New(connectionString)
            Configure()
        End Sub

        Private Sub Configure()
            Configuration.AutoDetectChangesEnabled = True
            Configuration.LazyLoadingEnabled = False
            Configuration.ProxyCreationEnabled = True
            Configuration.ValidateOnSaveEnabled = True
        End Sub

        #End Region

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

            Throw New UnintentionalCodeFirstException()
        End Sub

        #Region "DbSet Properties"
        ''' <summary>
        ''' There are no comments for TableJobType in the schema.
        ''' </summary>
        Public Overridable Property TableJobTypes() As DbSet(Of TableJobType)
        ''' <summary>
        ''' There are no comments for TableJob in the schema.
        ''' </summary>
        Public Overridable Property TableJobs() As DbSet(Of TableJob)
        ''' <summary>
        ''' There are no comments for TableJobStep in the schema.
        ''' </summary>
        Public Overridable Property TableJobSteps() As DbSet(Of TableJobStep)
        ''' <summary>
        ''' There are no comments for TableCustomerJobInfo in the schema.
        ''' </summary>
        Public Overridable Property TableCustomerJobInfos() As DbSet(Of TableCustomerJobInfo)
        ''' <summary>
        ''' There are no comments for TableCustomerJobStep in the schema.
        ''' </summary>
        Public Overridable Property TableCustomerJobSteps() As DbSet(Of TableCustomerJobStep)
        ''' <summary>
        ''' A filtered View of only "SoldTo" customers with their Ids
        ''' </summary>
        Public Overridable Property ViewCustomerSoldTos() As DbSet(Of ViewCustomerSoldTo)
        ''' <summary>
        ''' There are no comments for TableType in the schema.
        ''' </summary>
        Public Overridable Property TableTypes() As DbSet(Of TableType)
        ''' <summary>
        ''' There are no comments for TableTypeCode in the schema.
        ''' </summary>
        Public Overridable Property TypeCodes() As DbSet(Of TableTypeCode)
        ''' <summary>
        ''' There are no comments for ViewJobNotPrinted in the schema.
        ''' </summary>
        Public Overridable Property ViewJobNotPrinteds() As DbSet(Of ViewJobNotPrinted)
        ''' <summary>
        ''' There are no comments for ViewTypesWithName in the schema.
        ''' </summary>
        Public Overridable Property ViewTypesWithNames() As DbSet(Of ViewTypesWithName)
        ''' <summary>
        ''' There are no comments for ViewPalletJobsNotPrinted in the schema.
        ''' </summary>
        Public Overridable Property ViewPalletJobsNotPrinteds() As DbSet(Of ViewPalletJobsNotPrinted)
        ''' <summary>
        ''' There are no comments for ViewPrinter in the schema.
        ''' </summary>
        Public Overridable Property ViewPrinters() As DbSet(Of ViewPrinter)
        ''' <summary>
        ''' There are no comments for TablePrinter in the schema.
        ''' </summary>
        Public Overridable Property TablePrinters() As DbSet(Of TablePrinter)
        ''' <summary>
        ''' There are no comments for ViewJobInfo in the schema.
        ''' </summary>
        Public Overridable Property ViewJobInfos() As DbSet(Of ViewJobInfo)
        ''' <summary>
        ''' There are no comments for ViewCartonJobInfo in the schema.
        ''' </summary>
        Public Overridable Property ViewCartonJobInfos() As DbSet(Of ViewCartonJobInfo)
        ''' <summary>
        ''' There are no comments for ViewPalletJobInfo in the schema.
        ''' </summary>
        Public Overridable Property ViewPalletJobInfos() As DbSet(Of ViewPalletJobInfo)
        ''' <summary>
        ''' There are no comments for ViewAddressJobInfo in the schema.
        ''' </summary>
        Public Overridable Property ViewAddressJobInfos() As DbSet(Of ViewAddressJobInfo)
        ''' <summary>
        ''' There are no comments for ViewCartonJobLineInfo in the schema.
        ''' </summary>
        Public Overridable Property ViewCartonJobLineInfos() As DbSet(Of ViewCartonJobLineInfo)
        ''' <summary>
        ''' There are no comments for TableCartonJob in the schema.
        ''' </summary>
        Public Overridable Property TableCartonJobs() As DbSet(Of TableCartonJob)
        ''' <summary>
        ''' There are no comments for TablePalletJob in the schema.
        ''' </summary>
        Public Overridable Property TablePalletJobs() As DbSet(Of TablePalletJob)
        ''' <summary>
        ''' There are no comments for ViewAllJob in the schema.
        ''' </summary>
        Public Overridable Property ViewAllJobs() As DbSet(Of ViewAllJob)
        ''' <summary>
        ''' There are no comments for ViewSalesOrder in the schema.
        ''' </summary>
        Public Overridable Property ViewSalesOrders() As DbSet(Of ViewSalesOrder)
        ''' <summary>
        ''' There are no comments for ViewPalletJobLineInfo in the schema.
        ''' </summary>
        Public Overridable Property ViewPalletJobLineInfos() As DbSet(Of ViewPalletJobLineInfo)
        #End Region
        #Region "Methods"

        ''' <summary>
        ''' There are no comments for InsertNewCartonJobLine in the schema.
        ''' </summary>

        Public Overridable Sub InsertNewCartonJobLine (ByVal Reprint As Boolean?) 
            Dim connection As EntityConnection = DirectCast(DirectCast(Me, IObjectContextAdapter).ObjectContext.Connection, EntityConnection)
            Dim needClose As Boolean = False
            If (connection.State <> System.Data.ConnectionState.Open) Then
              connection.Open()
              needClose = True
            End If

            Try
              Using command As EntityCommand = New EntityCommand()
                If DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.HasValue Then
                  command.CommandTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.Value
                End If
                command.CommandType = System.Data.CommandType.StoredProcedure
                command.CommandText = "VNDataEntities.InsertNewCartonJobLine"
                command.Connection = connection
                Dim ReprintParameter As EntityParameter = New EntityParameter("Reprint", System.Data.DbType.Boolean)
				ReprintParameter.Direction = ParameterDirection.Input
                If (Reprint.HasValue) Then
                  ReprintParameter.Value = Reprint
                End If
                command.Parameters.Add(ReprintParameter)

                command.ExecuteNonQuery()
              End Using
            Finally
              If needClose Then
                connection.Close()
              End If
            End Try
        End Sub

        ''' <summary>
        ''' There are no comments for InsertNewPalletJob in the schema.
        ''' </summary>

        Public Overridable Sub InsertNewPalletJob (ByVal Reprint As Boolean?) 
            Dim connection As EntityConnection = DirectCast(DirectCast(Me, IObjectContextAdapter).ObjectContext.Connection, EntityConnection)
            Dim needClose As Boolean = False
            If (connection.State <> System.Data.ConnectionState.Open) Then
              connection.Open()
              needClose = True
            End If

            Try
              Using command As EntityCommand = New EntityCommand()
                If DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.HasValue Then
                  command.CommandTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.Value
                End If
                command.CommandType = System.Data.CommandType.StoredProcedure
                command.CommandText = "VNDataEntities.InsertNewPalletJob"
                command.Connection = connection
                Dim ReprintParameter As EntityParameter = New EntityParameter("Reprint", System.Data.DbType.Boolean)
				ReprintParameter.Direction = ParameterDirection.Input
                If (Reprint.HasValue) Then
                  ReprintParameter.Value = Reprint
                End If
                command.Parameters.Add(ReprintParameter)

                command.ExecuteNonQuery()
              End Using
            Finally
              If needClose Then
                connection.Close()
              End If
            End Try
        End Sub

        ''' <summary>
        ''' There are no comments for UpdatePalletJobInfo in the schema.
        ''' </summary>

        Public Overridable Sub UpdatePalletJobInfo (ByVal SOId As String) 
            Dim connection As EntityConnection = DirectCast(DirectCast(Me, IObjectContextAdapter).ObjectContext.Connection, EntityConnection)
            Dim needClose As Boolean = False
            If (connection.State <> System.Data.ConnectionState.Open) Then
              connection.Open()
              needClose = True
            End If

            Try
              Using command As EntityCommand = New EntityCommand()
                If DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.HasValue Then
                  command.CommandTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.Value
                End If
                command.CommandType = System.Data.CommandType.StoredProcedure
                command.CommandText = "VNDataEntities.UpdatePalletJobInfo"
                command.Connection = connection
                Dim SOIdParameter As EntityParameter = New EntityParameter("SOId", System.Data.DbType.String)
				SOIdParameter.Direction = ParameterDirection.Input
                If (Not SOId Is Nothing)
                  SOIdParameter.Value = SOId
                End If
                command.Parameters.Add(SOIdParameter)

                command.ExecuteNonQuery()
              End Using
            Finally
              If needClose Then
                connection.Close()
              End If
            End Try
        End Sub

        ''' <summary>
        ''' There are no comments for RefreshSalesForce in the schema.
        ''' </summary>

        Public Overridable Sub RefreshSalesForce () 
            Dim connection As EntityConnection = DirectCast(DirectCast(Me, IObjectContextAdapter).ObjectContext.Connection, EntityConnection)
            Dim needClose As Boolean = False
            If (connection.State <> System.Data.ConnectionState.Open) Then
              connection.Open()
              needClose = True
            End If

            Try
              Using command As EntityCommand = New EntityCommand()
                If DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.HasValue Then
                  command.CommandTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.Value
                End If
                command.CommandType = System.Data.CommandType.StoredProcedure
                command.CommandText = "VNDataEntities.RefreshSalesForce"
                command.Connection = connection

                command.ExecuteNonQuery()
              End Using
            Finally
              If needClose Then
                connection.Close()
              End If
            End Try
        End Sub

        ''' <summary>
        ''' There are no comments for InsertNewCartonJob in the schema.
        ''' </summary>

        Public Overridable Sub InsertNewCartonJob (ByVal Reprint As Boolean?) 
            Dim connection As EntityConnection = DirectCast(DirectCast(Me, IObjectContextAdapter).ObjectContext.Connection, EntityConnection)
            Dim needClose As Boolean = False
            If (connection.State <> System.Data.ConnectionState.Open) Then
              connection.Open()
              needClose = True
            End If

            Try
              Using command As EntityCommand = New EntityCommand()
                If DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.HasValue Then
                  command.CommandTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.Value
                End If
                command.CommandType = System.Data.CommandType.StoredProcedure
                command.CommandText = "VNDataEntities.InsertNewCartonJob"
                command.Connection = connection
                Dim ReprintParameter As EntityParameter = New EntityParameter("Reprint", System.Data.DbType.Boolean)
				ReprintParameter.Direction = ParameterDirection.Input
                If (Reprint.HasValue) Then
                  ReprintParameter.Value = Reprint
                End If
                command.Parameters.Add(ReprintParameter)

                command.ExecuteNonQuery()
              End Using
            Finally
              If needClose Then
                connection.Close()
              End If
            End Try
        End Sub

        ''' <summary>
        ''' There are no comments for InsertNewPalletJobLine in the schema.
        ''' </summary>

        Public Overridable Sub InsertNewPalletJobLine (ByVal Reprint As Boolean?) 
            Dim connection As EntityConnection = DirectCast(DirectCast(Me, IObjectContextAdapter).ObjectContext.Connection, EntityConnection)
            Dim needClose As Boolean = False
            If (connection.State <> System.Data.ConnectionState.Open) Then
              connection.Open()
              needClose = True
            End If

            Try
              Using command As EntityCommand = New EntityCommand()
                If DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.HasValue Then
                  command.CommandTimeout = DirectCast(Me, IObjectContextAdapter).ObjectContext.CommandTimeout.Value
                End If
                command.CommandType = System.Data.CommandType.StoredProcedure
                command.CommandText = "VNDataEntities.InsertNewPalletJobLine"
                command.Connection = connection
                Dim ReprintParameter As EntityParameter = New EntityParameter("Reprint", System.Data.DbType.Boolean)
				ReprintParameter.Direction = ParameterDirection.Input
                If (Reprint.HasValue) Then
                  ReprintParameter.Value = Reprint
                End If
                command.Parameters.Add(ReprintParameter)

                command.ExecuteNonQuery()
              End Using
            Finally
              If needClose Then
                connection.Close()
              End If
            End Try
        End Sub
        
        #End Region
    End Class
End Namespace
