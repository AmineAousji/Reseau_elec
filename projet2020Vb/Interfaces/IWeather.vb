''' <summary>Weather Simulation</summary>
Public Interface IWeather
    ' Properties
    ''' <summary>Le niveau d'ensoleillement</summary>
    Function SunshineLevelFunc() As Integer
    ''' <summary>La force du vent</summary>
    Function WindForceFunc() As Double
    ''' <summary>La température à un point donné</summary>
    Function TemperatureFunc() As String
End Interface
