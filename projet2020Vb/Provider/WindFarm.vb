Public Class WindFarm
    Inherits Provider

    Private ReadOnly Weather As Weather

    Public Sub New(centralName As String, centralId As Integer, weather As Weather)
        MyBase.New(centralName, centralId, 90, 3)
        Me.Weather = weather
    End Sub

    Public Overrides Function UpdateEnergy() As Double
        AmountEnergy += Weather.WindForceFunc * 50
        Return AmountEnergy
    End Function


End Class
