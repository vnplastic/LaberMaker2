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
    ''' There are no comments for VNDataModel.TableTypeCode in the schema.
    ''' </summary>
    Public partial class TableTypeCode 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for TypeCodeId in the schema.
        ''' </summary>
        Public Overridable Property TypeCodeId() As Integer
    
        ''' <summary>
        ''' There are no comments for TypeCodeTypeId in the schema.
        ''' </summary>
        Public Overridable Property TypeCodeTypeId() As Integer
    
        ''' <summary>
        ''' There are no comments for TypeCode in the schema.
        ''' </summary>
        Public Overridable Property TypeCode() As String
    
        ''' <summary>
        ''' There are no comments for TypeCodeName in the schema.
        ''' </summary>
        Public Overridable Property TypeCodeName() As String

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for VNA057TB06Type in the schema.
        ''' </summary>
        Public Overridable Property VNA057TB06Type() As TableType
    
        ''' <summary>
        ''' There are no comments for JobSteps in the schema.
        ''' </summary>
        Public Overridable Property JobSteps() As ICollection(Of TableJobStep)
    
        ''' <summary>
        ''' There are no comments for CustomerJobSteps_PrinterCompatibilityID in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobSteps_PrinterCompatibilityID() As ICollection(Of TableCustomerJobStep)
    
        ''' <summary>
        ''' There are no comments for CustomerJobSteps_LabelSizeId in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobSteps_LabelSizeId() As ICollection(Of TableCustomerJobStep)
    
        ''' <summary>
        ''' There are no comments for CustomerJobSteps_SourceTypeId in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobSteps_SourceTypeId() As ICollection(Of TableCustomerJobStep)
    
        ''' <summary>
        ''' There are no comments for CustomerJobSteps_DeliveryTypeId in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobSteps_DeliveryTypeId() As ICollection(Of TableCustomerJobStep)
    
        ''' <summary>
        ''' There are no comments for CustomerJobSteps_LabelOrientationId in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobSteps_LabelOrientationId() As ICollection(Of TableCustomerJobStep)

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
