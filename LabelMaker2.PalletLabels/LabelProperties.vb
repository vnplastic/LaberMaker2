Imports System.Windows.Forms
Imports LaberMaker2.Main

Public Class LabelProperties : Implements ILabelProperties

    Public Property JobTypeId As Integer Implements ILabelProperties.JobTypeId
    Public Property FormPrint As UserControl Implements ILabelProperties.FormPrint

    Public Sub New()
        JobTypeId = 2
        FormPrint = New FormJobs()
    End Sub


End Class