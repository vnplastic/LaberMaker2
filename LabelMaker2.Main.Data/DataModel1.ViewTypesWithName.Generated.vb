﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 8/24/2018 3:30:53 PM
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
    ''' There are no comments for VNDataModel.ViewTypesWithName in the schema.
    ''' </summary>
    Public partial class ViewTypesWithName 

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
    
        ''' <summary>
        ''' There are no comments for TypeName in the schema.
        ''' </summary>
        Public Overridable Property TypeName() As String

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
