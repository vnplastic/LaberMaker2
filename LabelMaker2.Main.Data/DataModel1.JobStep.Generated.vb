﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 8/13/2018 4:45:52 PM
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
    ''' There are no comments for VNDataModel.JobStep in the schema.
    ''' </summary>
    Public partial class TableJobStep 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for JobStepId in the schema.
        ''' </summary>
        Public Overridable Property JobStepId() As Integer
    
        ''' <summary>
        ''' There are no comments for JobTypeId in the schema.
        ''' </summary>
        Public Overridable Property JobTypeId() As Global.System.Nullable(Of Integer)
    
        ''' <summary>
        ''' There are no comments for JobStepName in the schema.
        ''' </summary>
        Public Overridable Property JobStepName() As String
    
        ''' <summary>
        ''' There are no comments for JobStepOrder in the schema.
        ''' </summary>
        Public Overridable Property JobStepOrder() As Integer
    
        ''' <summary>
        ''' There are no comments for LabelCount in the schema.
        ''' </summary>
        Public Overridable Property LabelCount() As Global.System.Nullable(Of Integer)
    
        ''' <summary>
        ''' There are no comments for LabelType in the schema.
        ''' </summary>
        Public Overridable Property LabelType() As Global.System.Nullable(Of Integer)

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for JobType in the schema.
        ''' </summary>
        Public Overridable Property JobType() As TableJobType
    
        ''' <summary>
        ''' There are no comments for CustomerJobSteps in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobSteps() As ICollection(Of TableCustomerJobStep)
    
        ''' <summary>
        ''' There are no comments for VNA057TB07TypeCode in the schema.
        ''' </summary>
        Public Overridable Property VNA057TB07TypeCode() As TableTypeCode

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
