﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 8/6/2018 10:50:55 AM
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
    ''' There are no comments for VNDataModel.CustomerJobInfo in the schema.
    ''' </summary>
    Public partial class CustomerJobInfo 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for CustomerJobInfoId in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobInfoId() As Integer
    
        ''' <summary>
        ''' There are no comments for KNDY4CustomerC1 in the schema.
        ''' </summary>
        Public Overridable Property KNDY4CustomerC1() As String
    
        ''' <summary>
        ''' There are no comments for JobTypeId in the schema.
        ''' </summary>
        Public Overridable Property JobTypeId() As Integer
    
        ''' <summary>
        ''' There are no comments for CustomerName in the schema.
        ''' </summary>
        Public Overridable Property CustomerName() As String
    
        ''' <summary>
        ''' There are no comments for CustomerPrintName in the schema.
        ''' </summary>
        Public Overridable Property CustomerPrintName() As String
    
        ''' <summary>
        ''' There are no comments for CustomerShortName in the schema.
        ''' </summary>
        Public Overridable Property CustomerShortName() As String
    
        ''' <summary>
        ''' There are no comments for Serialized in the schema.
        ''' </summary>
        Public Overridable Property Serialized() As Global.System.Nullable(Of Boolean)
    
        ''' <summary>
        ''' There are no comments for LabelPerLine in the schema.
        ''' </summary>
        Public Overridable Property LabelPerLine() As Global.System.Nullable(Of Boolean)
    
        ''' <summary>
        ''' There are no comments for PrinterId in the schema.
        ''' </summary>
        Public Overridable Property PrinterId() As Global.System.Nullable(Of Integer)
    
        ''' <summary>
        ''' There are no comments for NextUniqueLabelNo in the schema.
        ''' </summary>
        Public Overridable Property NextUniqueLabelNo() As Global.System.Nullable(Of Integer) = 0

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for JobType in the schema.
        ''' </summary>
        Public Overridable Property JobType() As JobType
    
        ''' <summary>
        ''' There are no comments for Printer in the schema.
        ''' </summary>
        Public Overridable Property Printer() As Printer

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
