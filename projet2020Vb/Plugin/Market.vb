Public Class Market
    Implements IMarket

    Private BuyingPrice As Double = 0

    Private SellingPrice As Double = 0

    Public Sub EditBuyingPrice(value As Integer)
        BuyingPrice = value
    End Sub

    Public Sub EditSellingPrice(value As Integer)
        SellingPrice = value
    End Sub

    Public Function BuyingPriceFunc() As Double Implements IMarket.BuyingPriceFunc
        Return BuyingPrice
    End Function

    Public Function SellingPriceFunc() As Double Implements IMarket.SellingPriceFunc
        Return SellingPrice
    End Function

End Class