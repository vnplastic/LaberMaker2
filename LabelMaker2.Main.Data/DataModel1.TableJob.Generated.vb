﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 9/4/2018 1:42:30 PM
'
' Changes to this file may cause incorrect behavior and will be lost if
' the code is regenerated.
'------------------------------------------------------------------------------

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Runtime.Serialization

Namespace VNDataModel

    ''' <summary>
    ''' There are no comments for VNDataModel.TableJob in the schema.
    ''' </summary>
    Public partial class TableJob 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for JobId in the schema.
        ''' </summary>
        Public Overridable Property JobId() As Integer
    
        ''' <summary>
        ''' There are no comments for JobTypeId in the schema.
        ''' </summary>
        Public Overridable Property JobTypeId() As Integer
    
        ''' <summary>
        ''' There are no comments for KNDY4CustomerC1 in the schema.
        ''' </summary>
        Public Overridable Property KNDY4CustomerC1() As String
    
        ''' <summary>
        ''' There are no comments for KNDY4SalesOrderC1 in the schema.
        ''' </summary>
        Public Overridable Property KNDY4SalesOrderC1() As String
    
        ''' <summary>
        ''' There are no comments for Printed in the schema.
        ''' </summary>
        Public Overridable Property Printed() As Boolean
    
        ''' <summary>
        ''' There are no comments for SalesOrderName in the schema.
        ''' </summary>
        Public Overridable Property SalesOrderName() As String
    
        ''' <summary>
        ''' There are no comments for CreatedDate in the schema.
        ''' </summary>
        Public Overridable Property CreatedDate() As Global.System.Nullable(Of System.DateTime)

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for JobType in the schema.
        ''' </summary>
        Public Overridable Property JobType() As TableJobType

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
