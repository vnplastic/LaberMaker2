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
    ''' There are no comments for VNDataModel.TableType in the schema.
    ''' </summary>
    Public partial class TableType 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for TypeId in the schema.
        ''' </summary>
        Public Overridable Property TypeId() As Integer
    
        ''' <summary>
        ''' There are no comments for TypeName in the schema.
        ''' </summary>
        Public Overridable Property TypeName() As String

        #End Region
        #Region "Navigation Properties"
    
        ''' <summary>
        ''' There are no comments for VNA057TB07TypeCodes in the schema.
        ''' </summary>
        Public Overridable Property VNA057TB07TypeCodes() As ICollection(Of TableTypeCode)

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
