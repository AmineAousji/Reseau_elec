Public Class CentralNuclear
    Inherits Provider

    Public Sub New(centralName As String, centralId As Integer)
        MyBase.New(centralName, centralId, 55, 6)
    End Sub

    Public Overrides Function UpdateEnergy() As Double
        MyBase.AmountEnergy += 690
        Return MyBase.AmountEnergy
    End Function


End Class
