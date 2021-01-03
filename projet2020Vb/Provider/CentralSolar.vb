Public Class CentralSolar
    Inherits Provider

    Private ReadOnly Weather As Weather

    Public Sub New(centralName As String, centralId As Integer, weather As Weather)
        MyBase.New(centralName, centralId, 300, 60)
        Me.Weather = weather
    End Sub

    Public Overrides Function UpdateEnergy() As Double
        Return Utils.RandomBtw(10, 20)
    End Function

End Class
