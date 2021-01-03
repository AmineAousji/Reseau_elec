Public Class Company
    Inherits Consumers

    Public Sub New(consumersName As String, consumersId As Integer)
        MyBase.New(consumersName, consumersId)
    End Sub

    Public Overrides Function UpdateEnergyConsummed() As Double
        MyBase.ElectricalQuantityConsumed += 0.041
        Return MyBase.ElectricalQuantityConsumed
    End Function
End Class
