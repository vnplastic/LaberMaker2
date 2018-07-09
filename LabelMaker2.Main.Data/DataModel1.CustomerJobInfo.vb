Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Runtime.Serialization

Namespace VNDataModel

    Partial Public Class CustomerJobInfo
        Public ReadOnly Property JobTypeName() As String
            Get
                Return JobType.JobTypeName
            End Get
        End Property
        Public ReadOnly Property PrinterName() As String
            Get
                Return Printer.PrinterName
            End Get
        End Property
    End Class
End Namespace
