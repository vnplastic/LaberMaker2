Imports System.Windows.Forms
Imports LabelMaker2.Infrastructure
Imports LabelMaker2.Main.Data.VNDataModel


Public Class LabelProperties : Implements ILabelProperties

    Public Property JobTypeId As Integer Implements ILabelProperties.JobTypeId
    Public Property FormPrint As UserControl Implements ILabelProperties.FormPrint
    Public Property DBConnString As String Implements ILabelProperties.DBConnString
    Private ctx As New VNDataEntities

    Public Function CanPrintJob() As Boolean Implements ILabelProperties.CanPrintJob

        Return True
    End Function

    Public Sub New(connString As String)
        Me.JobTypeId = 2
        DBConnString = connString
        Vars.ConnString = DBConnString
        Vars.JobTypeID = JobTypeId
        FormPrint = New FormJobs()
        Vars.Caller = Me




    End Sub


End Class