Public MustInherit Class Provider
    Inherits Entity
    Private ReadOnly CentralName As String
    Private ReadOnly ProductionCost As Double 'euros/MWh
    Private ReadOnly RateCarbonDioxide As Double 'g/KWh

    Public AmountEnergy As Double


    Public Sub New(centralName As String, centralId As Integer, productionCost As Double, rateCarbonDioxide As Double)
        MyBase.New(centralId)
        Me.CentralName = centralName
        Me.ProductionCost = productionCost
        Me.RateCarbonDioxide = rateCarbonDioxide
    End Sub

    Public Function GetRateCarbonDioxide() As Double
        Return AmountEnergy * RateCarbonDioxide
    End Function

    MustOverride Function UpdateEnergy() As Double

    Overridable Function GetProductionCost() As Double
        Return AmountEnergy * ProductionCost
    End Function

    Protected Function GetCentralName() As String
        Return CentralName
    End Function

End Class
