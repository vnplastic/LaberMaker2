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
    ''' There are no comments for VNDataModel.ViewJobNotPrinted in the schema.
    ''' </summary>
    Public partial class ViewJobNotPrinted 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for JobTypeId in the schema.
        ''' </summary>
        Public Overridable Property JobTypeId() As Integer
    
        ''' <summary>
        ''' There are no comments for JobId in the schema.
        ''' </summary>
        Public Overridable Property JobId() As Integer
    
        ''' <summary>
        ''' There are no comments for KNDY4CustomerC in the schema.
        ''' </summary>
        Public Overridable Property KNDY4CustomerC() As String
    
        ''' <summary>
        ''' There are no comments for CustomerName in the schema.
        ''' </summary>
        Public Overridable Property CustomerName() As String
    
        ''' <summary>
        ''' There are no comments for SalesOrder in the schema.
        ''' </summary>
        Public Overridable Property SalesOrder() As String
    
        ''' <summary>
        ''' There are no comments for SalesOrderName in the schema.
        ''' </summary>
        Public Overridable Property SalesOrderName() As String
    
        ''' <summary>
        ''' There are no comments for CreatedDate in the schema.
        ''' </summary>
        Public Overridable Property CreatedDate() As Global.System.Nullable(Of System.DateTime)

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
