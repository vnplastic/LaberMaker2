﻿'------------------------------------------------------------------------------
' This is auto-generated code. 
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
' Code is generated on: 8/3/2018 12:55:55 PM
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
    ''' There are no comments for VNDataModel.CartonJobLineInfo in the schema.
    ''' </summary>
    Public partial class CartonJobLineInfo 

        Public Sub New()
            OnCreated()
        End Sub

        #Region "Primitive Properties"
    
        ''' <summary>
        ''' There are no comments for Printed in the schema.
        ''' </summary>
        Public Overridable Property Printed() As Global.System.Nullable(Of Boolean)
    
        ''' <summary>
        ''' There are no comments for VNFCUSCHR1C in the schema.
        ''' </summary>
        Public Overridable Property VNFCUSCHR1C() As String
    
        ''' <summary>
        ''' There are no comments for Fcusrchr2 in the schema.
        ''' </summary>
        Public Overridable Property Fcusrchr2() As String
    
        ''' <summary>
        ''' There are no comments for Fcusrchr3 in the schema.
        ''' </summary>
        Public Overridable Property Fcusrchr3() As String
    
        ''' <summary>
        ''' There are no comments for PickupDateC in the schema.
        ''' </summary>
        Public Overridable Property PickupDateC() As Global.System.Nullable(Of System.DateTime)
    
        ''' <summary>
        ''' There are no comments for DeliveryNum in the schema.
        ''' </summary>
        Public Overridable Property DeliveryNum() As String
    
        ''' <summary>
        ''' There are no comments for ShipToCity in the schema.
        ''' </summary>
        Public Overridable Property ShipToCity() As String
    
        ''' <summary>
        ''' There are no comments for ShipToCountry in the schema.
        ''' </summary>
        Public Overridable Property ShipToCountry() As String
    
        ''' <summary>
        ''' There are no comments for ShipToState in the schema.
        ''' </summary>
        Public Overridable Property ShipToState() As String
    
        ''' <summary>
        ''' There are no comments for ShipToStreet in the schema.
        ''' </summary>
        Public Overridable Property ShipToStreet() As String
    
        ''' <summary>
        ''' There are no comments for ShipToZip in the schema.
        ''' </summary>
        Public Overridable Property ShipToZip() As String
    
        ''' <summary>
        ''' There are no comments for ShipToCompany in the schema.
        ''' </summary>
        Public Overridable Property ShipToCompany() As String
    
        ''' <summary>
        ''' There are no comments for Fsono in the schema.
        ''' </summary>
        Public Overridable Property Fsono() As String
    
        ''' <summary>
        ''' There are no comments for Fcustpono in the schema.
        ''' </summary>
        Public Overridable Property Fcustpono() As String
    
        ''' <summary>
        ''' There are no comments for Fshipvia in the schema.
        ''' </summary>
        Public Overridable Property Fshipvia() As String
    
        ''' <summary>
        ''' There are no comments for Fshptoaddr in the schema.
        ''' </summary>
        Public Overridable Property Fshptoaddr() As String
    
        ''' <summary>
        ''' There are no comments for SOStatus in the schema.
        ''' </summary>
        Public Overridable Property SOStatus() As String
    
        ''' <summary>
        ''' There are no comments for SoldToCustId in the schema.
        ''' </summary>
        Public Overridable Property SoldToCustId() As String
    
        ''' <summary>
        ''' There are no comments for SoldToCompany in the schema.
        ''' </summary>
        Public Overridable Property SoldToCompany() As String
    
        ''' <summary>
        ''' There are no comments for JobId in the schema.
        ''' </summary>
        Public Overridable Property JobId() As Global.System.Nullable(Of Integer)
    
        ''' <summary>
        ''' There are no comments for SalesOrderName in the schema.
        ''' </summary>
        Public Overridable Property SalesOrderName() As String
    
        ''' <summary>
        ''' There are no comments for JobTypeName in the schema.
        ''' </summary>
        Public Overridable Property JobTypeName() As String
    
        ''' <summary>
        ''' There are no comments for Serialized in the schema.
        ''' </summary>
        Public Overridable Property Serialized() As Global.System.Nullable(Of Boolean)
    
        ''' <summary>
        ''' There are no comments for FormatName in the schema.
        ''' </summary>
        Public Overridable Property FormatName() As String
    
        ''' <summary>
        ''' There are no comments for PrinterName in the schema.
        ''' </summary>
        Public Overridable Property PrinterName() As String
    
        ''' <summary>
        ''' There are no comments for JobStepName in the schema.
        ''' </summary>
        Public Overridable Property JobStepName() As String
    
        ''' <summary>
        ''' There are no comments for JobStepOrder in the schema.
        ''' </summary>
        Public Overridable Property JobStepOrder() As Integer
    
        ''' <summary>
        ''' There are no comments for CartonLabelCount in the schema.
        ''' </summary>
        Public Overridable Property CartonLabelCount() As Global.System.Nullable(Of Decimal)
    
        ''' <summary>
        ''' There are no comments for CartonCount in the schema.
        ''' </summary>
        Public Overridable Property CartonCount() As Global.System.Nullable(Of Decimal)
    
        ''' <summary>
        ''' There are no comments for PalletCount in the schema.
        ''' </summary>
        Public Overridable Property PalletCount() As Global.System.Nullable(Of Decimal)
    
        ''' <summary>
        ''' There are no comments for PalletLabelCount in the schema.
        ''' </summary>
        Public Overridable Property PalletLabelCount() As Global.System.Nullable(Of Decimal)
    
        ''' <summary>
        ''' There are no comments for CustomerPrintName in the schema.
        ''' </summary>
        Public Overridable Property CustomerPrintName() As String
    
        ''' <summary>
        ''' There are no comments for LabelCount in the schema.
        ''' </summary>
        Public Overridable Property LabelCount() As Global.System.Nullable(Of Integer)
    
        ''' <summary>
        ''' There are no comments for LabelPerLine in the schema.
        ''' </summary>
        Public Overridable Property LabelPerLine() As Global.System.Nullable(Of Boolean)
    
        ''' <summary>
        ''' There are no comments for LineNo in the schema.
        ''' </summary>
        Public Overridable Property LineNo() As Global.System.Nullable(Of Decimal)
    
        ''' <summary>
        ''' There are no comments for LineCartonCount in the schema.
        ''' </summary>
        Public Overridable Property LineCartonCount() As Global.System.Nullable(Of Decimal)
    
        ''' <summary>
        ''' There are no comments for NextUniqueLabelNo in the schema.
        ''' </summary>
        Public Overridable Property NextUniqueLabelNo() As Global.System.Nullable(Of Integer)
    
        ''' <summary>
        ''' There are no comments for CustomerJobInfoId in the schema.
        ''' </summary>
        Public Overridable Property CustomerJobInfoId() As Integer
    
        ''' <summary>
        ''' There are no comments for SOId in the schema.
        ''' </summary>
        Public Overridable Property SOId() As String
    
        ''' <summary>
        ''' There are no comments for CustomerStockNumber in the schema.
        ''' </summary>
        Public Overridable Property CustomerStockNumber() As String
    
        ''' <summary>
        ''' There are no comments for VNDesc in the schema.
        ''' </summary>
        Public Overridable Property VNDesc() As String
    
        ''' <summary>
        ''' There are no comments for UPCCOde in the schema.
        ''' </summary>
        Public Overridable Property UPCCOde() As String
    
        ''' <summary>
        ''' There are no comments for ProductName in the schema.
        ''' </summary>
        Public Overridable Property ProductName() As String
    
        ''' <summary>
        ''' There are no comments for ItemColor in the schema.
        ''' </summary>
        Public Overridable Property ItemColor() As String
    
        ''' <summary>
        ''' There are no comments for SourceCountry in the schema.
        ''' </summary>
        Public Overridable Property SourceCountry() As String
    
        ''' <summary>
        ''' There are no comments for CaseQty in the schema.
        ''' </summary>
        Public Overridable Property CaseQty() As Global.System.Nullable(Of Decimal)

        #End Region
    
        #Region "Extensibility Method Definitions"
        Partial Private Sub OnCreated()
        End Sub
        #End Region
    End Class

End Namespace
