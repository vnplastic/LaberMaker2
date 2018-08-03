
Imports System.Windows.Forms
Imports LabelMaker2.Infrastructure


Public Class LabelProperties : Implements ILabelProperties

    Public Property JobTypeId As Integer Implements ILabelProperties.JobTypeId
    Public Property FormPrint As UserControl Implements ILabelProperties.FormPrint
    Public Property DBConnString As String Implements ILabelProperties.DBConnString

    Public Function CanPrintJob() As Boolean Implements ILabelProperties.CanPrintJob
        Return True
    End Function

    Public Sub New(connString As String)
        JobTypeId = 3
        DBConnString = connString
        Vars.ConnString = DBConnString
        Vars.JobTypeID = JobTypeId
        FormPrint = New FormJobs()

    End Sub


End Class