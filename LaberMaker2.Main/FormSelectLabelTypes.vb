Public Class FormSelectLabelTypes
    Property LabelTypes As List(Of String)
    Property SelectedLabelTypes As New List(Of String)
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        For Ix = 1 To lstLabelType.Items.Count
            If lstLabelType.GetItemChecked(Ix - 1) = True Then
                SelectedLabelTypes.Add(lstLabelType.Items(Ix - 1))
            End If
        Next
    End Sub

    Private Sub FormSelectLabelTypes_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each item In LabelTypes
            lstLabelType.Items.Add(item)
        Next

    End Sub
End Class