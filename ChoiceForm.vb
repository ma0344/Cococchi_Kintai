Imports System.ComponentModel

Public Class ChoiceForm
    'Public value As DDClass
    Public va As DDClass
    Public ret As WorkType
    Public ReadOnly Property SelectType As Integer
        Get
            Return ret
        End Get
    End Property

    Private Sub FstBtn_Click(sender As Object, e As EventArgs) Handles FstBtn.Click
        ret = WorkType.Nikkin
        Me.DialogResult = WorkType.Nikkin
        Me.Close()
    End Sub

    Private Sub SecBtn_Click(sender As Object, e As EventArgs) Handles SecBtn.Click
        ret = WorkType.Yakin
        Me.DialogResult = WorkType.Yakin
        Me.Close()
    End Sub

    Private Sub CanButton_Click(sender As Object, e As EventArgs) Handles CanButton.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    'Private Sub ChoiceForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    '    Me.DialogResult = DialogResult.No
    'End Sub
End Class