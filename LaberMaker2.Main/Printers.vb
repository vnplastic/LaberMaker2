Imports LabelMaker2.Main.Data
Imports LabelMaker2.Main.Data.VNDataModel

Module Printers
    Public Function LookupPrinterByName(ByVal pPrinterName As System.String) As System.UInt32
        Dim conn As String = Globals.GetEFConnectionString
        Dim ctx = New VNDataEntities(conn)
        Dim Result As System.UInt32

        Dim erc As Long

        Result = 0
        erc = QEnum.QueueConsumerErrorCodes.OK
        Dim printer As ViewPrinter = ctx.ViewPrinters.Where(Function(c) c.PrinterName = pPrinterName).FirstOrDefault


        Result = printer.PrinterName

        Return Result
    End Function

    Public Function LookupPrinterById(ByVal pPrinterId As System.UInt32) As System.String
        Dim conn As String = Globals.GetEFConnectionString
        Dim ctx = New VNDataEntities(conn)
        Dim Result As System.String

        Dim SqlConnection As New ADODB.Connection
        Dim SqlProc As New ADODB.Command
        Dim ResultSet As New ADODB.Recordset
        Dim erc As Long

        Result = 0
        erc = QEnum.QueueConsumerErrorCodes.OK
        Dim printer As ViewPrinter = ctx.ViewPrinters.Where(Function(c) c.PrinterID = pPrinterId).FirstOrDefault
        Result = printer.PrinterName
        Return Result
    End Function
End Module
