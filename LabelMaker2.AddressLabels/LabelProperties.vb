
Imports System.Windows.Forms
Imports LaberMaker2.Main

Public Class LabelProperties : Implements ILabelProperties

    Public Property JobTypeId As Integer Implements ILabelProperties.JobTypeId
    Public Property FormPrint As UserControl Implements ILabelProperties.FormPrint
    Public Property DBConnString As String Implements ILabelProperties.DBConnString

    Public Sub New(connString As String)
        JobTypeId = 3
        DBConnString = connString
        Vars.DBConnString = DBConnString
        Vars.JobTypeID = JobTypeId
        FormPrint = New FormJobs()

    End Sub


End Class