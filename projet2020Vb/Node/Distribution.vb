Public Class Distribution
    Inherits Entity

    Public ReceiverLines As Lines
    Public OutputLines As New List(Of Lines)

    Public Sub New(nodeId As Integer)
        MyBase.New(nodeId)
    End Sub


End Class
