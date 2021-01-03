Public Class Weather
    Implements IWeather

    Private SunshineLevel As Integer

    Private WindForce As Integer

    Private Temperature As String

    Public Sub EditSunshineLevel(value As Integer)
        SunshineLevel = value
    End Sub

    Public Sub EditWindForce(value As Integer)
        WindForce = value
    End Sub

    Public Sub EditTemperature(value As Integer)
        Temperature = value
    End Sub

    Public Function SunshineLevelFunc() As Integer Implements IWeather.SunshineLevelFunc
        Return SunshineLevel
    End Function

    Public Function WindForceFunc() As Double Implements IWeather.WindForceFunc
        Return WindForce
    End Function

    Public Function TemperatureFunc() As String Implements IWeather.TemperatureFunc
        Return Temperature
    End Function
End Class
