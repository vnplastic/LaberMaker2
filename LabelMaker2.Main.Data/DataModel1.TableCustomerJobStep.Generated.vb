﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 2022/06/29 2:44:18 PM
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

    Public Partial Class TableCustomerJobStep 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        Public Overridable Property CustomerJobStepsId() As Integer
    
        Public Overridable Property CustomerJobInfoId() As Integer
    
        Public Overridable Property JobStepId() As Integer
    
        Public Overridable Property PrinterCompatibilityID() As Integer?
    
        Public Overridable Property LabelSizeId() As Integer?
    
        Public Overridable Property SourceTypeId() As Integer?
    
        Public Overridable Property DeliveryTypeId() As Integer?
    
        Public Overridable Property LabelOrientationId() As Integer?
    
        Public Overridable Property LabelCount() As Integer?
    
        Public Overridable Property PrinterId() As Integer?
    
        Public Overridable Property FormatName() As String
    
        Public Overridable Property DateCreated() As Global.System.DateTime?

        #End Region
        #Region "Navigation Properties"
    
        Public Overridable Property JobStep() As TableJobStep
    
        Public Overridable Property VNA057TB07TypeCode_PrinterCompatibilityID() As TableTypeCode
    
        Public Overridable Property VNA057TB07TypeCode_LabelSizeId() As TableTypeCode
    
        Public Overridable Property VNA057TB07TypeCode_SourceTypeId() As TableTypeCode
    
        Public Overridable Property VNA057TB07TypeCode_DeliveryTypeId() As TableTypeCode
    
        Public Overridable Property VNA057TB07TypeCode_LabelOrientationId() As TableTypeCode

        #End Region

        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
