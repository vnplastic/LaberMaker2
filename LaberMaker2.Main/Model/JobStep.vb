Imports System.ComponentModel.DataAnnotations.Schema

<Table("VNA057TB03_Job_Step")>
Public Class JobStepDTO

    Public Property JobStepId As Integer
    'Property JobStepId() As Integer
    Public Property JobTypeId() As Integer
    'Public Property JobTypeName As String 'JobType
    <ForeignKey("JobTypeId")>
    Public Property JobType As JobTypeDTO

    Public Property JobStepName() As String
    Public Property JobStepOrder() As Integer

End Class
