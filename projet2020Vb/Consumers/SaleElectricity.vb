Public Class SaleElectricity
    Inherits Consumers

    Private ReadOnly MarketPrice As Market

    Public Sub New(consumersName As String, consumersId As Integer, marketPrice As Market)
        MyBase.New(consumersName, consumersId)
        Me.MarketPrice = marketPrice
    End Sub

    Public Overrides Function UpdateEnergyConsummed() As Double
        MyBase.ElectricalQuantityConsumed += 10
        Return MyBase.ElectricalQuantityConsumed
    End Function
End Class


