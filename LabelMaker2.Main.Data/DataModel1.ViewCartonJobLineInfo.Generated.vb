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

    Public Partial Class ViewCartonJobLineInfo 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        Public Overridable Property LineNo() As Decimal?
    
        Public Overridable Property LineCartonCount() As Decimal?
    
        Public Overridable Property CustomerStockNumber() As String
    
        Public Overridable Property VNDesc() As String
    
        Public Overridable Property VNFCUSCHR1C() As String
    
        Public Overridable Property Fcusrchr2() As String
    
        Public Overridable Property Fcusrchr3() As String
    
        Public Overridable Property PickupDateC() As Global.System.DateTime?
    
        Public Overridable Property DeliveryNum() As String
    
        Public Overridable Property ShipToCity() As String
    
        Public Overridable Property ShipToCountry() As String
    
        Public Overridable Property ShipToState() As String
    
        Public Overridable Property ShipToStreet() As String
    
        Public Overridable Property ShipToZip() As String
    
        Public Overridable Property ShipToCompany() As String
    
        Public Overridable Property Fsono() As String
    
        Public Overridable Property Fcustpono() As String
    
        Public Overridable Property Fshipvia() As String
    
        Public Overridable Property Fshptoaddr() As String
    
        Public Overridable Property SOStatus() As String
    
        Public Overridable Property SoldToCustId() As String
    
        Public Overridable Property SoldToCompany() As String
    
        Public Overridable Property JobId() As Integer?
    
        Public Overridable Property SalesOrderName() As String
    
        Public Overridable Property JobTypeName() As String
    
        Public Overridable Property Serialized() As Boolean?
    
        Public Overridable Property FormatName() As String
    
        Public Overridable Property PrinterName() As String
    
        Public Overridable Property JobStepOrder() As Integer
    
        Public Overridable Property CartonLabelCount() As Decimal?
    
        Public Overridable Property CartonCount() As Decimal?
    
        Public Overridable Property JobStepName() As String
    
        Public Overridable Property CustomerPrintName() As String
    
        Public Overridable Property LabelCount() As Integer?
    
        Public Overridable Property LabelPerLine() As Boolean?
    
        Public Overridable Property NextUniqueLabelNo() As Integer?
    
        Public Overridable Property CustomerJobInfoId() As Integer
    
        Public Overridable Property SOId() As String
    
        Public Overridable Property Printed() As Boolean?
    
        Public Overridable Property UPCCOde() As String
    
        Public Overridable Property ProductName() As String
    
        Public Overridable Property ItemColor() As String
    
        Public Overridable Property SourceCountry() As String
    
        Public Overridable Property CaseQty() As Integer?
    
        Public Overridable Property UCCCode() As String
    
        Public Overridable Property CasesPerPallet() As Decimal?

        #End Region

        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
