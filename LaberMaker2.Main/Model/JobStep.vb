Imports System.ComponentModel.DataAnnotations.Schema

<Table("VNA057TB03_Job_Step")>
Public Class JobStep

    Public Property JobStepId As Integer
    'Property JobStepId() As Integer
    Public Property JobTypeId() As Integer
    Public Property JobTypeName As String 'JobType

    Public Property JobStepName() As String
    Public Property JobStepOrder() As Integer

End Class
