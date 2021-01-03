Public Class PurchaseElectricity
    Inherits Provider

    Private ReadOnly MarketPrice As Market

    Public Sub New(centralName As String, centralId As Integer, marketPrice As Market)
        MyBase.New(centralName, centralId, 10, 5)
        Me.MarketPrice = marketPrice
    End Sub

    Public Overrides Function UpdateEnergy() As Double
        AmountEnergy += Utils.RandomBtw(50, 101)
        Return AmountEnergy
    End Function

    Public Overrides Function GetProductionCost() As Double
        Return MarketPrice.BuyingPriceFunc() * AmountEnergy
    End Function


End Class

