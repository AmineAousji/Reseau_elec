Public Class Concentration
    Inherits Entity

    Public ReceiverLines As New List(Of Lines)
    Public OutputLines As Lines

    Public Sub New(nodeId As Integer)
        MyBase.New(nodeId)
    End Sub

End Class
