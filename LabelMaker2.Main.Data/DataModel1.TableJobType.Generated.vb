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
    ''' There are no comments for VNDataModel.TableJobType in the schema.
    ''' </summary>
    Public partial class TableJobType 

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
    
        ''' <summary>
        ''' There are no comments for Active in the schema.
        ''' </summary>
        Public Overridable Property Active() As Global.System.Nullable(Of Boolean)

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for JobSteps in the schema.
        ''' </summary>
        Public Overridable Property JobSteps() As ICollection(Of TableJobStep)
    
        ''' <summary>
        ''' There are no comments for CustomerJobInfos in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobInfos() As ICollection(Of TableCustomerJobInfo)

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace