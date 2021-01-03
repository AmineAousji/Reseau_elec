Public Class Lines

    Public ReadOnly LineId As Integer
    Public ReadOnly Transmitter As Entity
    Public ReadOnly Receiver As Entity
    Public ReadOnly MaximumPower As Integer

    Public Sub New(lineId As Integer, transmitter As Entity, receiver As Entity, maximumPower As Integer)
        Me.LineId = lineId
        Me.Transmitter = transmitter
        Me.Receiver = receiver
        Me.MaximumPower = maximumPower
    End Sub

End Class
