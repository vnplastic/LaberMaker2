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
Imports System.Runtime.Serialization

Namespace VNDataModel

    ''' <summary>
    ''' There are no comments for VNDataModel.TablePrinter in the schema.
    ''' </summary>
    Public partial class TablePrinter 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for PrinterID in the schema.
        ''' </summary>
        Public Overridable Property PrinterID() As Integer
    
        ''' <summary>
        ''' There are no comments for PrinterName in the schema.
        ''' </summary>
        Public Overridable Property PrinterName() As String
    
        ''' <summary>
        ''' There are no comments for AlternatePrinters in the schema.
        ''' </summary>
        Public Overridable Property AlternatePrinters() As String
    
        ''' <summary>
        ''' There are no comments for CompatibilityCode in the schema.
        ''' </summary>
        Public Overridable Property CompatibilityCode() As Integer
    
        ''' <summary>
        ''' There are no comments for SupportsSource in the schema.
        ''' </summary>
        Public Overridable Property SupportsSource() As Integer
    
        ''' <summary>
        ''' There are no comments for SupportsDelivery in the schema.
        ''' </summary>
        Public Overridable Property SupportsDelivery() As Integer
    
        ''' <summary>
        ''' There are no comments for SupportsSize in the schema.
        ''' </summary>
        Public Overridable Property SupportsSize() As Integer
    
        ''' <summary>
        ''' There are no comments for LastSize in the schema.
        ''' </summary>
        Public Overridable Property LastSize() As Integer?
    
        ''' <summary>
        ''' There are no comments for LastSource in the schema.
        ''' </summary>
        Public Overridable Property LastSource() As Integer?
    
        ''' <summary>
        ''' There are no comments for LastDelivery in the schema.
        ''' </summary>
        Public Overridable Property LastDelivery() As Integer?
    
        ''' <summary>
        ''' There are no comments for Active in the schema.
        ''' </summary>
        Public Overridable Property Active() As Boolean

        #End Region
        #Region "Navigation Properties"
    
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
