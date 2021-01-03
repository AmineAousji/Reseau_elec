''' <summary>Market Simulation</summary>
Public Interface IMarket
    ' Properties
    ''' <summary>Le prix d'achat d'électicité</summary>
    Function BuyingPriceFunc() As Double
    ''' <summary>Le prix de vente d'électricité</summary>
    Function SellingPriceFunc() As Double
End Interface
