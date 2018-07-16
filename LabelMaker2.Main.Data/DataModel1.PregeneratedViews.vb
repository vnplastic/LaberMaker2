﻿'------------------------------------------------------------------------------
' This is auto-generated code.
'------------------------------------------------------------------------------
' This code was generated by Devart Entity Developer tool using Entity Framework EntityObject template.
' Code is generated on: 7/13/2018 4:50:26 PM
'
' Changes to this file may cause incorrect behavior and will be lost if
' the code is regenerated.
'------------------------------------------------------------------------------

Imports System.Collections.Generic
Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.Entity.Infrastructure.MappingViews

<assembly: DbMappingViewCacheTypeAttribute(GetType(VNDataModel.VNDataEntities), GetType(EntityMappingGeneratedViews.ViewsForBaseEntitySets69f37237892d43368c968dc5c9e9c4df))>
	
Namespace EntityMappingGeneratedViews

    <System.CodeDom.Compiler.GeneratedCode("Devart Entity Developer", "")> _
	Public Class ViewsForBaseEntitySets69f37237892d43368c968dc5c9e9c4df
	  Inherits DbMappingViewCache
	
		Private Shared cachedViews As Dictionary(Of string, DbMappingView) = Nothing
		Private Shared syncRoot = New object()

		Public Sub New()
		End Sub
		
		Public Overrides ReadOnly Property MappingHashValue As String
		  Get
 		    Return "189e5e4b9413eae2c709eba867f1714bf97dd847e0b3b02b3c79e777f9461f30"
		  End Get
	    End Property

		Public Overrides Function GetView(entitySet As EntitySetBase) As DbMappingView
		
			If (cachedViews Is Nothing) Then
			  SyncLock syncRoot
			    If (cachedViews Is Nothing) Then
			      FillCache()
				End If
			  End SyncLock
			End If

			Dim view As DbMappingView = Nothing
			cachedViews.TryGetValue(entitySet.EntityContainer.Name + "." + entitySet.Name, view)
			Return view
		End Function

		Private Shared Sub FillCache()

			cachedViews = New Dictionary(Of String, DbMappingView)()
			cachedViews.Add("VNDataEntitiesStoreContainer.JobTypes", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing JobTypes" & vbNewLine &
"        [VNDataModel.Store.JobTypes](T1.JobTypes_JobTypeId, T1.JobTypes_JobTypeName, T1.JobTypes_DLLName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobTypeId AS JobTypes_JobTypeId, " & vbNewLine &
"            T.JobTypeName AS JobTypes_JobTypeName, " & vbNewLine &
"            T.DLLName AS JobTypes_DLLName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.JobTypes AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.Jobs", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing Jobs" & vbNewLine &
"        [VNDataModel.Store.Jobs](T1.Jobs_JobId, T1.Jobs_JobTypeId, T1.[Jobs.KNDY4__Customer__c], T1.[Jobs.KNDY4__Sales_Order__c], T1.Jobs_Printed, T1.Jobs_SalesOrderName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobId AS Jobs_JobId, " & vbNewLine &
"            T.JobTypeId AS Jobs_JobTypeId, " & vbNewLine &
"            T.KNDY4CustomerC1 AS [Jobs.KNDY4__Customer__c], " & vbNewLine &
"            T.KNDY4SalesOrderC1 AS [Jobs.KNDY4__Sales_Order__c], " & vbNewLine &
"            T.Printed AS Jobs_Printed, " & vbNewLine &
"            T.SalesOrderName AS Jobs_SalesOrderName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.Jobs AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.JobSteps", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing JobSteps" & vbNewLine &
"        [VNDataModel.Store.JobSteps](T1.JobSteps_JobStepId, T1.JobSteps_JobTypeId, T1.JobSteps_JobStepName, T1.JobSteps_JobStepOrder, T1.JobSteps_LabelCount, T1.JobSteps_LabelType)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobStepId AS JobSteps_JobStepId, " & vbNewLine &
"            T.JobTypeId AS JobSteps_JobTypeId, " & vbNewLine &
"            T.JobStepName AS JobSteps_JobStepName, " & vbNewLine &
"            T.JobStepOrder AS JobSteps_JobStepOrder, " & vbNewLine &
"            T.LabelCount AS JobSteps_LabelCount, " & vbNewLine &
"            T.LabelType AS JobSteps_LabelType, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.JobSteps AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.CustomerJobInfos", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing CustomerJobInfos" & vbNewLine &
"        [VNDataModel.Store.CustomerJobInfos](T1.CustomerJobInfos_CustomerJobInfoId, T1.[CustomerJobInfos.KNDY4__Customer__c], T1.CustomerJobInfos_JobTypeId, T1.CustomerJobInfos_CustomerName, T1.CustomerJobInfos_CustomerShortName, T1.CustomerJobInfos_Serialized, T1.CustomerJobInfos_PrinterId)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.CustomerJobInfoId AS CustomerJobInfos_CustomerJobInfoId, " & vbNewLine &
"            T.KNDY4CustomerC1 AS [CustomerJobInfos.KNDY4__Customer__c], " & vbNewLine &
"            T.JobTypeId AS CustomerJobInfos_JobTypeId, " & vbNewLine &
"            T.CustomerName AS CustomerJobInfos_CustomerName, " & vbNewLine &
"            T.CustomerShortName AS CustomerJobInfos_CustomerShortName, " & vbNewLine &
"            T.Serialized AS CustomerJobInfos_Serialized, " & vbNewLine &
"            T.PrinterId AS CustomerJobInfos_PrinterId, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.CustomerJobInfos AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.CustomerJobSteps", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing CustomerJobSteps" & vbNewLine &
"        [VNDataModel.Store.CustomerJobSteps](T1.CustomerJobSteps_CustomerJobStepsId, T1.CustomerJobSteps_CustomerJobInfoId, T1.CustomerJobSteps_JobStepId, T1.CustomerJobSteps_PrinterCompatibilityID, T1.CustomerJobSteps_LabelSizeId, T1.CustomerJobSteps_SourceTypeId, T1.CustomerJobSteps_DeliveryTypeId, T1.CustomerJobSteps_LabelOrientationId, T1.CustomerJobSteps_LabelCount, T1.CustomerJobSteps_PrinterId, T1.CustomerJobSteps_FormatName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.CustomerJobStepsId AS CustomerJobSteps_CustomerJobStepsId, " & vbNewLine &
"            T.CustomerJobInfoId AS CustomerJobSteps_CustomerJobInfoId, " & vbNewLine &
"            T.JobStepId AS CustomerJobSteps_JobStepId, " & vbNewLine &
"            T.PrinterCompatibilityID AS CustomerJobSteps_PrinterCompatibilityID, " & vbNewLine &
"            T.LabelSizeId AS CustomerJobSteps_LabelSizeId, " & vbNewLine &
"            T.SourceTypeId AS CustomerJobSteps_SourceTypeId, " & vbNewLine &
"            T.DeliveryTypeId AS CustomerJobSteps_DeliveryTypeId, " & vbNewLine &
"            T.LabelOrientationId AS CustomerJobSteps_LabelOrientationId, " & vbNewLine &
"            T.LabelCount AS CustomerJobSteps_LabelCount, " & vbNewLine &
"            T.PrinterId AS CustomerJobSteps_PrinterId, " & vbNewLine &
"            T.FormatName AS CustomerJobSteps_FormatName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.CustomerJobSteps AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057TB06_Types", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057TB06_Types" & vbNewLine &
"        [VNDataModel.Store.VNA057TB06_Types](T1.[VNA057TB06_Types.TypeId], T1.[VNA057TB06_Types.TypeName])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.TypeId AS [VNA057TB06_Types.TypeId], " & vbNewLine &
"            T.TypeName AS [VNA057TB06_Types.TypeName], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.Types AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057TB07_TypeCodes", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057TB07_TypeCodes" & vbNewLine &
"        [VNDataModel.Store.VNA057TB07_TypeCodes](T1.[VNA057TB07_TypeCodes.TypeCodeId], T1.[VNA057TB07_TypeCodes.TypeCodeTypeId], T1.[VNA057TB07_TypeCodes.TypeCode], T1.[VNA057TB07_TypeCodes.TypeCodeName])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.TypeCodeId AS [VNA057TB07_TypeCodes.TypeCodeId], " & vbNewLine &
"            T.TypeCodeTypeId AS [VNA057TB07_TypeCodes.TypeCodeTypeId], " & vbNewLine &
"            T.TypeCode AS [VNA057TB07_TypeCodes.TypeCode], " & vbNewLine &
"            T.TypeCodeName AS [VNA057TB07_TypeCodes.TypeCodeName], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.TypeCodes AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057TB08_Printers", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057TB08_Printers" & vbNewLine &
"        [VNDataModel.Store.VNA057TB08_Printer](T1.[VNA057TB08_Printer.PrinterID], T1.[VNA057TB08_Printer.PrinterName], T1.[VNA057TB08_Printer.AlternatePrinters], T1.[VNA057TB08_Printer.CompatibilityCode], T1.[VNA057TB08_Printer.SupportsSource], T1.[VNA057TB08_Printer.SupportsDelivery], T1.[VNA057TB08_Printer.SupportsSize], T1.[VNA057TB08_Printer.LastSize], T1.[VNA057TB08_Printer.LastSource], T1.[VNA057TB08_Printer.LastDelivery], T1.[VNA057TB08_Printer.Active])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.PrinterID AS [VNA057TB08_Printer.PrinterID], " & vbNewLine &
"            T.PrinterName AS [VNA057TB08_Printer.PrinterName], " & vbNewLine &
"            T.AlternatePrinters AS [VNA057TB08_Printer.AlternatePrinters], " & vbNewLine &
"            T.CompatibilityCode AS [VNA057TB08_Printer.CompatibilityCode], " & vbNewLine &
"            T.SupportsSource AS [VNA057TB08_Printer.SupportsSource], " & vbNewLine &
"            T.SupportsDelivery AS [VNA057TB08_Printer.SupportsDelivery], " & vbNewLine &
"            T.SupportsSize AS [VNA057TB08_Printer.SupportsSize], " & vbNewLine &
"            T.LastSize AS [VNA057TB08_Printer.LastSize], " & vbNewLine &
"            T.LastSource AS [VNA057TB08_Printer.LastSource], " & vbNewLine &
"            T.LastDelivery AS [VNA057TB08_Printer.LastDelivery], " & vbNewLine &
"            T.Active AS [VNA057TB08_Printer.Active], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.Printers AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.JobTypes", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing JobTypes" & vbNewLine &
"        [VNDataModel.JobType](T1.JobType_JobTypeId, T1.JobType_JobTypeName, T1.JobType_DLLName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobTypeId AS JobType_JobTypeId, " & vbNewLine &
"            T.JobTypeName AS JobType_JobTypeName, " & vbNewLine &
"            T.DLLName AS JobType_DLLName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.JobTypes AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.Jobs", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing Jobs" & vbNewLine &
"        [VNDataModel.Job](T1.Job_JobId, T1.Job_JobTypeId, T1.Job_KNDY4CustomerC1, T1.Job_KNDY4SalesOrderC1, T1.Job_Printed, T1.Job_SalesOrderName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobId AS Job_JobId, " & vbNewLine &
"            T.JobTypeId AS Job_JobTypeId, " & vbNewLine &
"            T.KNDY4__Customer__c AS Job_KNDY4CustomerC1, " & vbNewLine &
"            T.KNDY4__Sales_Order__c AS Job_KNDY4SalesOrderC1, " & vbNewLine &
"            T.Printed AS Job_Printed, " & vbNewLine &
"            T.SalesOrderName AS Job_SalesOrderName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.Jobs AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.JobSteps", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing JobSteps" & vbNewLine &
"        [VNDataModel.JobStep](T1.JobStep_JobStepId, T1.JobStep_JobTypeId, T1.JobStep_JobStepName, T1.JobStep_JobStepOrder, T1.JobStep_LabelCount, T1.JobStep_LabelType)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobStepId AS JobStep_JobStepId, " & vbNewLine &
"            T.JobTypeId AS JobStep_JobTypeId, " & vbNewLine &
"            T.JobStepName AS JobStep_JobStepName, " & vbNewLine &
"            T.JobStepOrder AS JobStep_JobStepOrder, " & vbNewLine &
"            T.LabelCount AS JobStep_LabelCount, " & vbNewLine &
"            T.LabelType AS JobStep_LabelType, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.JobSteps AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.CustomerJobInfos", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing CustomerJobInfos" & vbNewLine &
"        [VNDataModel.CustomerJobInfo](T1.CustomerJobInfo_CustomerJobInfoId, T1.CustomerJobInfo_KNDY4CustomerC1, T1.CustomerJobInfo_JobTypeId, T1.CustomerJobInfo_CustomerName, T1.CustomerJobInfo_CustomerShortName, T1.CustomerJobInfo_Serialized, T1.CustomerJobInfo_PrinterId)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.CustomerJobInfoId AS CustomerJobInfo_CustomerJobInfoId, " & vbNewLine &
"            T.KNDY4__Customer__c AS CustomerJobInfo_KNDY4CustomerC1, " & vbNewLine &
"            T.JobTypeId AS CustomerJobInfo_JobTypeId, " & vbNewLine &
"            T.CustomerName AS CustomerJobInfo_CustomerName, " & vbNewLine &
"            T.CustomerShortName AS CustomerJobInfo_CustomerShortName, " & vbNewLine &
"            T.Serialized AS CustomerJobInfo_Serialized, " & vbNewLine &
"            T.PrinterId AS CustomerJobInfo_PrinterId, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.CustomerJobInfos AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.CustomerJobSteps", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing CustomerJobSteps" & vbNewLine &
"        [VNDataModel.CustomerJobStep](T1.CustomerJobStep_CustomerJobStepsId, T1.CustomerJobStep_CustomerJobInfoId, T1.CustomerJobStep_JobStepId, T1.CustomerJobStep_PrinterCompatibilityID, T1.CustomerJobStep_LabelSizeId, T1.CustomerJobStep_SourceTypeId, T1.CustomerJobStep_DeliveryTypeId, T1.CustomerJobStep_LabelOrientationId, T1.CustomerJobStep_LabelCount, T1.CustomerJobStep_PrinterId, T1.CustomerJobStep_FormatName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.CustomerJobStepsId AS CustomerJobStep_CustomerJobStepsId, " & vbNewLine &
"            T.CustomerJobInfoId AS CustomerJobStep_CustomerJobInfoId, " & vbNewLine &
"            T.JobStepId AS CustomerJobStep_JobStepId, " & vbNewLine &
"            T.PrinterCompatibilityID AS CustomerJobStep_PrinterCompatibilityID, " & vbNewLine &
"            T.LabelSizeId AS CustomerJobStep_LabelSizeId, " & vbNewLine &
"            T.SourceTypeId AS CustomerJobStep_SourceTypeId, " & vbNewLine &
"            T.DeliveryTypeId AS CustomerJobStep_DeliveryTypeId, " & vbNewLine &
"            T.LabelOrientationId AS CustomerJobStep_LabelOrientationId, " & vbNewLine &
"            T.LabelCount AS CustomerJobStep_LabelCount, " & vbNewLine &
"            T.PrinterId AS CustomerJobStep_PrinterId, " & vbNewLine &
"            T.FormatName AS CustomerJobStep_FormatName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.CustomerJobSteps AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.Types", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing Types" & vbNewLine &
"        [VNDataModel.Type](T1.Type_TypeId, T1.Type_TypeName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.TypeId AS Type_TypeId, " & vbNewLine &
"            T.TypeName AS Type_TypeName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057TB06_Types AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.TypeCodes", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing TypeCodes" & vbNewLine &
"        [VNDataModel.VNA057TB07TypeCode](T1.VNA057TB07TypeCode_TypeCodeId, T1.VNA057TB07TypeCode_TypeCodeTypeId, T1.VNA057TB07TypeCode_TypeCode, T1.VNA057TB07TypeCode_TypeCodeName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.TypeCodeId AS VNA057TB07TypeCode_TypeCodeId, " & vbNewLine &
"            T.TypeCodeTypeId AS VNA057TB07TypeCode_TypeCodeTypeId, " & vbNewLine &
"            T.TypeCode AS VNA057TB07TypeCode_TypeCode, " & vbNewLine &
"            T.TypeCodeName AS VNA057TB07TypeCode_TypeCodeName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057TB07_TypeCodes AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.Printers", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing Printers" & vbNewLine &
"        [VNDataModel.Printer](T1.Printer_PrinterID, T1.Printer_PrinterName, T1.Printer_AlternatePrinters, T1.Printer_CompatibilityCode, T1.Printer_SupportsSource, T1.Printer_SupportsDelivery, T1.Printer_SupportsSize, T1.Printer_LastSize, T1.Printer_LastSource, T1.Printer_LastDelivery, T1.Printer_Active)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.PrinterID AS Printer_PrinterID, " & vbNewLine &
"            T.PrinterName AS Printer_PrinterName, " & vbNewLine &
"            T.AlternatePrinters AS Printer_AlternatePrinters, " & vbNewLine &
"            T.CompatibilityCode AS Printer_CompatibilityCode, " & vbNewLine &
"            T.SupportsSource AS Printer_SupportsSource, " & vbNewLine &
"            T.SupportsDelivery AS Printer_SupportsDelivery, " & vbNewLine &
"            T.SupportsSize AS Printer_SupportsSize, " & vbNewLine &
"            T.LastSize AS Printer_LastSize, " & vbNewLine &
"            T.LastSource AS Printer_LastSource, " & vbNewLine &
"            T.LastDelivery AS Printer_LastDelivery, " & vbNewLine &
"            T.Active AS Printer_Active, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057TB08_Printers AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.CustomerSoldTos", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing CustomerSoldTos" & vbNewLine &
"        [VNDataModel.Store.CustomerSoldTos](T1.CustomerSoldTos_Id, T1.CustomerSoldTos_Name)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.Id AS CustomerSoldTos_Id, " & vbNewLine &
"            T.Name AS CustomerSoldTos_Name, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.CustomerSoldTos AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.CustomerSoldTos", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing CustomerSoldTos" & vbNewLine &
"        [VNDataModel.CustomerSoldTo](T1.CustomerSoldTo_Id, T1.CustomerSoldTo_Name)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.Id AS CustomerSoldTo_Id, " & vbNewLine &
"            T.Name AS CustomerSoldTo_Name, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.CustomerSoldTos AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057VW01_Job_Not_Printeds", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057VW01_Job_Not_Printeds" & vbNewLine &
"        [VNDataModel.Store.VNA057VW01_Job_Not_Printed](T1.[VNA057VW01_Job_Not_Printed.JobTypeId], T1.[VNA057VW01_Job_Not_Printed.JobId], T1.[VNA057VW01_Job_Not_Printed.KNDY4__Customer__c], T1.[VNA057VW01_Job_Not_Printed.CustomerName], T1.[VNA057VW01_Job_Not_Printed.SalesOrder], T1.[VNA057VW01_Job_Not_Printed.SalesOrderName])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobTypeId AS [VNA057VW01_Job_Not_Printed.JobTypeId], " & vbNewLine &
"            T.JobId AS [VNA057VW01_Job_Not_Printed.JobId], " & vbNewLine &
"            T.KNDY4CustomerC AS [VNA057VW01_Job_Not_Printed.KNDY4__Customer__c], " & vbNewLine &
"            T.CustomerName AS [VNA057VW01_Job_Not_Printed.CustomerName], " & vbNewLine &
"            T.SalesOrder AS [VNA057VW01_Job_Not_Printed.SalesOrder], " & vbNewLine &
"            T.SalesOrderName AS [VNA057VW01_Job_Not_Printed.SalesOrderName], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.ViewJobNotPrinteds AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.ViewJobNotPrinteds", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing ViewJobNotPrinteds" & vbNewLine &
"        [VNDataModel.ViewJobNotPrinted](T1.ViewJobNotPrinted_JobTypeId, T1.ViewJobNotPrinted_JobId, T1.ViewJobNotPrinted_KNDY4CustomerC, T1.ViewJobNotPrinted_CustomerName, T1.ViewJobNotPrinted_SalesOrder, T1.ViewJobNotPrinted_SalesOrderName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobTypeId AS ViewJobNotPrinted_JobTypeId, " & vbNewLine &
"            T.JobId AS ViewJobNotPrinted_JobId, " & vbNewLine &
"            T.KNDY4__Customer__c AS ViewJobNotPrinted_KNDY4CustomerC, " & vbNewLine &
"            T.CustomerName AS ViewJobNotPrinted_CustomerName, " & vbNewLine &
"            T.SalesOrder AS ViewJobNotPrinted_SalesOrder, " & vbNewLine &
"            T.SalesOrderName AS ViewJobNotPrinted_SalesOrderName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057VW01_Job_Not_Printeds AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057VW04_TypesWithNames", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057VW04_TypesWithNames" & vbNewLine &
"        [VNDataModel.Store.VNA057VW04_TypesWithNames](T1.[VNA057VW04_TypesWithNames.TypeCodeId], T1.[VNA057VW04_TypesWithNames.TypeCodeTypeId], T1.[VNA057VW04_TypesWithNames.TypeCode], T1.[VNA057VW04_TypesWithNames.TypeCodeName], T1.[VNA057VW04_TypesWithNames.TypeName])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.TypeCodeId AS [VNA057VW04_TypesWithNames.TypeCodeId], " & vbNewLine &
"            T.TypeCodeTypeId AS [VNA057VW04_TypesWithNames.TypeCodeTypeId], " & vbNewLine &
"            T.TypeCode AS [VNA057VW04_TypesWithNames.TypeCode], " & vbNewLine &
"            T.TypeCodeName AS [VNA057VW04_TypesWithNames.TypeCodeName], " & vbNewLine &
"            T.TypeName AS [VNA057VW04_TypesWithNames.TypeName], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.TypesWithNames AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.TypesWithNames", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing TypesWithNames" & vbNewLine &
"        [VNDataModel.TypesWithName](T1.TypesWithName_TypeCodeId, T1.TypesWithName_TypeCodeTypeId, T1.TypesWithName_TypeCode, T1.TypesWithName_TypeCodeName, T1.TypesWithName_TypeName)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.TypeCodeId AS TypesWithName_TypeCodeId, " & vbNewLine &
"            T.TypeCodeTypeId AS TypesWithName_TypeCodeTypeId, " & vbNewLine &
"            T.TypeCode AS TypesWithName_TypeCode, " & vbNewLine &
"            T.TypeCodeName AS TypesWithName_TypeCodeName, " & vbNewLine &
"            T.TypeName AS TypesWithName_TypeName, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057VW04_TypesWithNames AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057VW05_Pallet_Jobs_Not_Printeds", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057VW05_Pallet_Jobs_Not_Printeds" & vbNewLine &
"        [VNDataModel.Store.VNA057VW05_Pallet_Jobs_Not_Printed](T1.[VNA057VW05_Pallet_Jobs_Not_Printed.JobTypeId], T1.[VNA057VW05_Pallet_Jobs_Not_Printed.JobId], T1.[VNA057VW05_Pallet_Jobs_Not_Printed.KNDY4__Customer__c], T1.[VNA057VW05_Pallet_Jobs_Not_Printed.CustomerName], T1.[VNA057VW05_Pallet_Jobs_Not_Printed.SalesOrder], T1.[VNA057VW05_Pallet_Jobs_Not_Printed.SalesOrderName], T1.[VNA057VW05_Pallet_Jobs_Not_Printed.ShipmentData])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobTypeId AS [VNA057VW05_Pallet_Jobs_Not_Printed.JobTypeId], " & vbNewLine &
"            T.JobId AS [VNA057VW05_Pallet_Jobs_Not_Printed.JobId], " & vbNewLine &
"            T.KNDY4CustomerC AS [VNA057VW05_Pallet_Jobs_Not_Printed.KNDY4__Customer__c], " & vbNewLine &
"            T.CustomerName AS [VNA057VW05_Pallet_Jobs_Not_Printed.CustomerName], " & vbNewLine &
"            T.SalesOrder AS [VNA057VW05_Pallet_Jobs_Not_Printed.SalesOrder], " & vbNewLine &
"            T.SalesOrderName AS [VNA057VW05_Pallet_Jobs_Not_Printed.SalesOrderName], " & vbNewLine &
"            T.ShipmentData AS [VNA057VW05_Pallet_Jobs_Not_Printed.ShipmentData], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.ViewPalletJobsNotPrinteds AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.ViewPalletJobsNotPrinteds", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing ViewPalletJobsNotPrinteds" & vbNewLine &
"        [VNDataModel.ViewPalletJobsNotPrinted](T1.ViewPalletJobsNotPrinted_JobTypeId, T1.ViewPalletJobsNotPrinted_JobId, T1.ViewPalletJobsNotPrinted_KNDY4CustomerC, T1.ViewPalletJobsNotPrinted_CustomerName, T1.ViewPalletJobsNotPrinted_SalesOrder, T1.ViewPalletJobsNotPrinted_SalesOrderName, T1.ViewPalletJobsNotPrinted_ShipmentData)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.JobTypeId AS ViewPalletJobsNotPrinted_JobTypeId, " & vbNewLine &
"            T.JobId AS ViewPalletJobsNotPrinted_JobId, " & vbNewLine &
"            T.KNDY4__Customer__c AS ViewPalletJobsNotPrinted_KNDY4CustomerC, " & vbNewLine &
"            T.CustomerName AS ViewPalletJobsNotPrinted_CustomerName, " & vbNewLine &
"            T.SalesOrder AS ViewPalletJobsNotPrinted_SalesOrder, " & vbNewLine &
"            T.SalesOrderName AS ViewPalletJobsNotPrinted_SalesOrderName, " & vbNewLine &
"            T.ShipmentData AS ViewPalletJobsNotPrinted_ShipmentData, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057VW05_Pallet_Jobs_Not_Printeds AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057VW12_Printers", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057VW12_Printers" & vbNewLine &
"        [VNDataModel.Store.VNA057VW12_Printers](T1.[VNA057VW12_Printers.LabelSizeName], T1.[VNA057VW12_Printers.LabelSizeCode], T1.[VNA057VW12_Printers.PrinterCompatibilityCode], T1.[VNA057VW12_Printers.PrinterCompatibilityName], T1.[VNA057VW12_Printers.SourceTypeCode], T1.[VNA057VW12_Printers.SourceTypeName], T1.[VNA057VW12_Printers.DeliveryTypeCode], T1.[VNA057VW12_Printers.DeliveryTypeName], T1.[VNA057VW12_Printers.PrinterName], T1.[VNA057VW12_Printers.AlternatePrinters], T1.[VNA057VW12_Printers.CompatibilityCode], T1.[VNA057VW12_Printers.PrinterID], T1.[VNA057VW12_Printers.SupportsSource], T1.[VNA057VW12_Printers.SupportsDelivery], T1.[VNA057VW12_Printers.SupportsSize], T1.[VNA057VW12_Printers.LastSize], T1.[VNA057VW12_Printers.LastSource], T1.[VNA057VW12_Printers.LastDelivery], T1.[VNA057VW12_Printers.Active])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.LabelSizeName AS [VNA057VW12_Printers.LabelSizeName], " & vbNewLine &
"            T.LabelSizeCode AS [VNA057VW12_Printers.LabelSizeCode], " & vbNewLine &
"            T.PrinterCompatibilityCode AS [VNA057VW12_Printers.PrinterCompatibilityCode], " & vbNewLine &
"            T.PrinterCompatibilityName AS [VNA057VW12_Printers.PrinterCompatibilityName], " & vbNewLine &
"            T.SourceTypeCode AS [VNA057VW12_Printers.SourceTypeCode], " & vbNewLine &
"            T.SourceTypeName AS [VNA057VW12_Printers.SourceTypeName], " & vbNewLine &
"            T.DeliveryTypeCode AS [VNA057VW12_Printers.DeliveryTypeCode], " & vbNewLine &
"            T.DeliveryTypeName AS [VNA057VW12_Printers.DeliveryTypeName], " & vbNewLine &
"            T.PrinterName AS [VNA057VW12_Printers.PrinterName], " & vbNewLine &
"            T.AlternatePrinters AS [VNA057VW12_Printers.AlternatePrinters], " & vbNewLine &
"            T.CompatibilityCode AS [VNA057VW12_Printers.CompatibilityCode], " & vbNewLine &
"            T.PrinterID AS [VNA057VW12_Printers.PrinterID], " & vbNewLine &
"            T.SupportsSource AS [VNA057VW12_Printers.SupportsSource], " & vbNewLine &
"            T.SupportsDelivery AS [VNA057VW12_Printers.SupportsDelivery], " & vbNewLine &
"            T.SupportsSize AS [VNA057VW12_Printers.SupportsSize], " & vbNewLine &
"            T.LastSize AS [VNA057VW12_Printers.LastSize], " & vbNewLine &
"            T.LastSource AS [VNA057VW12_Printers.LastSource], " & vbNewLine &
"            T.LastDelivery AS [VNA057VW12_Printers.LastDelivery], " & vbNewLine &
"            T.Active AS [VNA057VW12_Printers.Active], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.ViewPrinters AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.ViewPrinters", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing ViewPrinters" & vbNewLine &
"        [VNDataModel.ViewPrinter](T1.ViewPrinter_LabelSizeName, T1.ViewPrinter_LabelSizeCode, T1.ViewPrinter_PrinterCompatibilityCode, T1.ViewPrinter_PrinterCompatibilityName, T1.ViewPrinter_SourceTypeCode, T1.ViewPrinter_SourceTypeName, T1.ViewPrinter_DeliveryTypeCode, T1.ViewPrinter_DeliveryTypeName, T1.ViewPrinter_PrinterName, T1.ViewPrinter_AlternatePrinters, T1.ViewPrinter_CompatibilityCode, T1.ViewPrinter_PrinterID, T1.ViewPrinter_SupportsSource, T1.ViewPrinter_SupportsDelivery, T1.ViewPrinter_SupportsSize, T1.ViewPrinter_LastSize, T1.ViewPrinter_LastSource, T1.ViewPrinter_LastDelivery, T1.ViewPrinter_Active)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.LabelSizeName AS ViewPrinter_LabelSizeName, " & vbNewLine &
"            T.LabelSizeCode AS ViewPrinter_LabelSizeCode, " & vbNewLine &
"            T.PrinterCompatibilityCode AS ViewPrinter_PrinterCompatibilityCode, " & vbNewLine &
"            T.PrinterCompatibilityName AS ViewPrinter_PrinterCompatibilityName, " & vbNewLine &
"            T.SourceTypeCode AS ViewPrinter_SourceTypeCode, " & vbNewLine &
"            T.SourceTypeName AS ViewPrinter_SourceTypeName, " & vbNewLine &
"            T.DeliveryTypeCode AS ViewPrinter_DeliveryTypeCode, " & vbNewLine &
"            T.DeliveryTypeName AS ViewPrinter_DeliveryTypeName, " & vbNewLine &
"            T.PrinterName AS ViewPrinter_PrinterName, " & vbNewLine &
"            T.AlternatePrinters AS ViewPrinter_AlternatePrinters, " & vbNewLine &
"            T.CompatibilityCode AS ViewPrinter_CompatibilityCode, " & vbNewLine &
"            T.PrinterID AS ViewPrinter_PrinterID, " & vbNewLine &
"            T.SupportsSource AS ViewPrinter_SupportsSource, " & vbNewLine &
"            T.SupportsDelivery AS ViewPrinter_SupportsDelivery, " & vbNewLine &
"            T.SupportsSize AS ViewPrinter_SupportsSize, " & vbNewLine &
"            T.LastSize AS ViewPrinter_LastSize, " & vbNewLine &
"            T.LastSource AS ViewPrinter_LastSource, " & vbNewLine &
"            T.LastDelivery AS ViewPrinter_LastDelivery, " & vbNewLine &
"            T.Active AS ViewPrinter_Active, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057VW12_Printers AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntitiesStoreContainer.VNA057VW06_Job_Infos", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing VNA057VW06_Job_Infos" & vbNewLine &
"        [VNDataModel.Store.VNA057VW06_Job_Info](T1.[VNA057VW06_Job_Info.Printed], T1.[VNA057VW06_Job_Info.VN_FCUSCHR1__c], T1.[VNA057VW06_Job_Info.fcusrchr2], T1.[VNA057VW06_Job_Info.fcusrchr3], T1.[VNA057VW06_Job_Info.Pickup_Date__c], T1.[VNA057VW06_Job_Info.DeliveryNum], T1.[VNA057VW06_Job_Info.ShipToCity], T1.[VNA057VW06_Job_Info.ShipToCountry], T1.[VNA057VW06_Job_Info.ShipToState], T1.[VNA057VW06_Job_Info.ShipToStreet], T1.[VNA057VW06_Job_Info.ShipToZip], T1.[VNA057VW06_Job_Info.ShipToCompany], T1.[VNA057VW06_Job_Info.fsono], T1.[VNA057VW06_Job_Info.fcustpono], T1.[VNA057VW06_Job_Info.fshipvia], T1.[VNA057VW06_Job_Info.fshptoaddr], T1.[VNA057VW06_Job_Info.SOStatus], T1.[VNA057VW06_Job_Info.SoldToCustId], T1.[VNA057VW06_Job_Info.SoldToCompany], T1.[VNA057VW06_Job_Info.JobId], T1.[VNA057VW06_Job_Info.SalesOrderName], T1.[VNA057VW06_Job_Info.JobTypeName], T1.[VNA057VW06_Job_Info.Serialized], T1.[VNA057VW06_Job_Info.FormatName], T1.[VNA057VW06_Job_Info.PrinterName], T1.[VNA057VW06_Job_Info.JobStepName], T1.[VNA057VW06_Job_Info.JobStepOrder], T1.[VNA057VW06_Job_Info.CartonLabelCount], T1.[VNA057VW06_Job_Info.CartonCount], T1.[VNA057VW06_Job_Info.PalletCount], T1.[VNA057VW06_Job_Info.PalletLabelCount])" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.Printed AS [VNA057VW06_Job_Info.Printed], " & vbNewLine &
"            T.VNFCUSCHR1C AS [VNA057VW06_Job_Info.VN_FCUSCHR1__c], " & vbNewLine &
"            T.Fcusrchr2 AS [VNA057VW06_Job_Info.fcusrchr2], " & vbNewLine &
"            T.Fcusrchr3 AS [VNA057VW06_Job_Info.fcusrchr3], " & vbNewLine &
"            T.PickupDateC AS [VNA057VW06_Job_Info.Pickup_Date__c], " & vbNewLine &
"            T.DeliveryNum AS [VNA057VW06_Job_Info.DeliveryNum], " & vbNewLine &
"            T.ShipToCity AS [VNA057VW06_Job_Info.ShipToCity], " & vbNewLine &
"            T.ShipToCountry AS [VNA057VW06_Job_Info.ShipToCountry], " & vbNewLine &
"            T.ShipToState AS [VNA057VW06_Job_Info.ShipToState], " & vbNewLine &
"            T.ShipToStreet AS [VNA057VW06_Job_Info.ShipToStreet], " & vbNewLine &
"            T.ShipToZip AS [VNA057VW06_Job_Info.ShipToZip], " & vbNewLine &
"            T.ShipToCompany AS [VNA057VW06_Job_Info.ShipToCompany], " & vbNewLine &
"            T.Fsono AS [VNA057VW06_Job_Info.fsono], " & vbNewLine &
"            T.Fcustpono AS [VNA057VW06_Job_Info.fcustpono], " & vbNewLine &
"            T.Fshipvia AS [VNA057VW06_Job_Info.fshipvia], " & vbNewLine &
"            T.Fshptoaddr AS [VNA057VW06_Job_Info.fshptoaddr], " & vbNewLine &
"            T.SOStatus AS [VNA057VW06_Job_Info.SOStatus], " & vbNewLine &
"            T.SoldToCustId AS [VNA057VW06_Job_Info.SoldToCustId], " & vbNewLine &
"            T.SoldToCompany AS [VNA057VW06_Job_Info.SoldToCompany], " & vbNewLine &
"            T.JobId AS [VNA057VW06_Job_Info.JobId], " & vbNewLine &
"            T.SalesOrderName AS [VNA057VW06_Job_Info.SalesOrderName], " & vbNewLine &
"            T.JobTypeName AS [VNA057VW06_Job_Info.JobTypeName], " & vbNewLine &
"            T.Serialized AS [VNA057VW06_Job_Info.Serialized], " & vbNewLine &
"            T.FormatName AS [VNA057VW06_Job_Info.FormatName], " & vbNewLine &
"            T.PrinterName AS [VNA057VW06_Job_Info.PrinterName], " & vbNewLine &
"            T.JobStepName AS [VNA057VW06_Job_Info.JobStepName], " & vbNewLine &
"            T.JobStepOrder AS [VNA057VW06_Job_Info.JobStepOrder], " & vbNewLine &
"            T.CartonLabelCount AS [VNA057VW06_Job_Info.CartonLabelCount], " & vbNewLine &
"            T.CartonCount AS [VNA057VW06_Job_Info.CartonCount], " & vbNewLine &
"            T.PalletCount AS [VNA057VW06_Job_Info.PalletCount], " & vbNewLine &
"            T.PalletLabelCount AS [VNA057VW06_Job_Info.PalletLabelCount], " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntities.JobInfos AS T" & vbNewLine &
"    ) AS T1"))
			cachedViews.Add("VNDataEntities.JobInfos", new DbMappingView("" & vbNewLine &
"    SELECT VALUE -- Constructing JobInfos" & vbNewLine &
"        [VNDataModel.JobInfo](T1.JobInfo_Printed, T1.JobInfo_VNFCUSCHR1C, T1.JobInfo_Fcusrchr2, T1.JobInfo_Fcusrchr3, T1.JobInfo_PickupDateC, T1.JobInfo_DeliveryNum, T1.JobInfo_ShipToCity, T1.JobInfo_ShipToCountry, T1.JobInfo_ShipToState, T1.JobInfo_ShipToStreet, T1.JobInfo_ShipToZip, T1.JobInfo_ShipToCompany, T1.JobInfo_Fsono, T1.JobInfo_Fcustpono, T1.JobInfo_Fshipvia, T1.JobInfo_Fshptoaddr, T1.JobInfo_SOStatus, T1.JobInfo_SoldToCustId, T1.JobInfo_SoldToCompany, T1.JobInfo_JobId, T1.JobInfo_SalesOrderName, T1.JobInfo_JobTypeName, T1.JobInfo_Serialized, T1.JobInfo_FormatName, T1.JobInfo_PrinterName, T1.JobInfo_JobStepName, T1.JobInfo_JobStepOrder, T1.JobInfo_CartonLabelCount, T1.JobInfo_CartonCount, T1.JobInfo_PalletCount, T1.JobInfo_PalletLabelCount)" & vbNewLine &
"    FROM (" & vbNewLine &
"        SELECT " & vbNewLine &
"            T.Printed AS JobInfo_Printed, " & vbNewLine &
"            T.VN_FCUSCHR1__c AS JobInfo_VNFCUSCHR1C, " & vbNewLine &
"            T.fcusrchr2 AS JobInfo_Fcusrchr2, " & vbNewLine &
"            T.fcusrchr3 AS JobInfo_Fcusrchr3, " & vbNewLine &
"            T.Pickup_Date__c AS JobInfo_PickupDateC, " & vbNewLine &
"            T.DeliveryNum AS JobInfo_DeliveryNum, " & vbNewLine &
"            T.ShipToCity AS JobInfo_ShipToCity, " & vbNewLine &
"            T.ShipToCountry AS JobInfo_ShipToCountry, " & vbNewLine &
"            T.ShipToState AS JobInfo_ShipToState, " & vbNewLine &
"            T.ShipToStreet AS JobInfo_ShipToStreet, " & vbNewLine &
"            T.ShipToZip AS JobInfo_ShipToZip, " & vbNewLine &
"            T.ShipToCompany AS JobInfo_ShipToCompany, " & vbNewLine &
"            T.fsono AS JobInfo_Fsono, " & vbNewLine &
"            T.fcustpono AS JobInfo_Fcustpono, " & vbNewLine &
"            T.fshipvia AS JobInfo_Fshipvia, " & vbNewLine &
"            T.fshptoaddr AS JobInfo_Fshptoaddr, " & vbNewLine &
"            T.SOStatus AS JobInfo_SOStatus, " & vbNewLine &
"            T.SoldToCustId AS JobInfo_SoldToCustId, " & vbNewLine &
"            T.SoldToCompany AS JobInfo_SoldToCompany, " & vbNewLine &
"            T.JobId AS JobInfo_JobId, " & vbNewLine &
"            T.SalesOrderName AS JobInfo_SalesOrderName, " & vbNewLine &
"            T.JobTypeName AS JobInfo_JobTypeName, " & vbNewLine &
"            T.Serialized AS JobInfo_Serialized, " & vbNewLine &
"            T.FormatName AS JobInfo_FormatName, " & vbNewLine &
"            T.PrinterName AS JobInfo_PrinterName, " & vbNewLine &
"            T.JobStepName AS JobInfo_JobStepName, " & vbNewLine &
"            T.JobStepOrder AS JobInfo_JobStepOrder, " & vbNewLine &
"            T.CartonLabelCount AS JobInfo_CartonLabelCount, " & vbNewLine &
"            T.CartonCount AS JobInfo_CartonCount, " & vbNewLine &
"            T.PalletCount AS JobInfo_PalletCount, " & vbNewLine &
"            T.PalletLabelCount AS JobInfo_PalletLabelCount, " & vbNewLine &
"            True AS _from0" & vbNewLine &
"        FROM VNDataEntitiesStoreContainer.VNA057VW06_Job_Infos AS T" & vbNewLine &
"    ) AS T1"))
		End Sub
	End Class
End Namespace
