Public MustInherit Class Consumers
    Inherits Entity
    Private ReadOnly ConsumersName As String


    Public ElectricalQuantityConsumed As Double

    Public Sub New(consumersName As String, consumersId As Integer)
        MyBase.New(consumersId)
        Me.ConsumersName = consumersName
    End Sub

    MustOverride Function UpdateEnergyConsummed() As Double

    Protected Function GetConsumersName() As String
        Return ConsumersName
    End Function

End Class