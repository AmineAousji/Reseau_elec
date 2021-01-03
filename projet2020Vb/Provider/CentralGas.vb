Public Class CentralGas
    Inherits Provider

    Public Sub New(centralName As String, centralId As Integer)
        MyBase.New(centralName, centralId, 40, 350)
    End Sub

    Public Overrides Function UpdateEnergy() As Double
        MyBase.AmountEnergy += Utils.RandomBtw(500, 1000)
        Return MyBase.AmountEnergy
    End Function


End Class
