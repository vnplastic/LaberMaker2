﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 6/18/2018 4:10:53 PM
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
    ''' There are no comments for VNDataModel.JobType in the schema.
    ''' </summary>
    Public partial class JobType 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for JobTypeId in the schema.
        ''' </summary>
        Public Overridable Property JobTypeId() As Integer
    
        ''' <summary>
        ''' There are no comments for JobTypeName in the schema.
        ''' </summary>
        Public Overridable Property JobTypeName() As String
    
        ''' <summary>
        ''' There are no comments for DLLName in the schema.
        ''' </summary>
        Public Overridable Property DLLName() As String

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for VNA057TB03JobSteps in the schema.
        ''' </summary>
        Public Overridable Property VNA057TB03JobSteps() As ICollection(Of JobStep)
    
        ''' <summary>
        ''' There are no comments for VNA057TB04CustomerJobInfos in the schema.
        ''' </summary>
        Public Overridable Property VNA057TB04CustomerJobInfos() As ICollection(Of VNA057TB04CustomerJobInfo)

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
