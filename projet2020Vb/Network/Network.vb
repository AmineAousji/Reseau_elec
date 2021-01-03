Public Class Network
    Private LinesNetwork As New List(Of Lines)
    Private EntitiesNetwork As New List(Of Entity)


    Public Sub AddEntityNetwork(entity As Entity)
        EntitiesNetwork.Add(entity)
    End Sub

    Public Sub AddLineNetwork(LineId As Integer, entityTransmitterId As Integer, entityReceiverId As Integer, maximumPower As Integer)
        Dim entityTransmitter As Entity = EntitiesNetwork.Item(GetIndexEntityById(entityTransmitterId))
        Dim entityReceiver As Entity = EntitiesNetwork.Item(GetIndexEntityById(entityReceiverId))
        Dim myLines As New Lines(LineId, entityTransmitter, entityReceiver, maximumPower)
        LinesNetwork.Add(myLines)

        If TypeOf entityTransmitter Is Concentration Then
            Dim entity As Concentration = DirectCast(entityTransmitter, Concentration)
            entity.OutputLines = myLines
        ElseIf TypeOf entityTransmitter Is Distribution Then
            Dim entity As Distribution = DirectCast(entityTransmitter, Distribution)
            entity.OutputLines.Add(myLines)

        End If

        If TypeOf entityReceiver Is Concentration Then
            Dim entity As Concentration = DirectCast(entityReceiver, Concentration)
            entity.ReceiverLines.Add(myLines)
        ElseIf TypeOf entityReceiver Is Distribution Then
            Dim entity As Distribution = DirectCast(entityReceiver, Distribution)
            entity.ReceiverLines = myLines

        End If
    End Sub

    Public Sub UpdateEnergy()
        For i As Integer = 0 To EntitiesNetwork.Count - 1
            Dim myItem As Entity = EntitiesNetwork.Item(i)
            If TypeOf myItem Is Provider Then
                Dim entity As Provider = DirectCast(myItem, Provider)
                entity.UpdateEnergy()
            ElseIf TypeOf myItem Is Consumers Then
                Dim entity As Consumers = DirectCast(myItem, Consumers)
                entity.UpdateEnergyConsummed()
            End If
        Next
    End Sub

    Public Function GetGeneralMessage() As String
        Dim sumOfProductionCost As Double
        Dim sumOfCarbonDioxyde As Double
        Dim sumOfEnergy As Double
        Dim sumOfEnergyConsum As Double
        For i As Integer = 0 To EntitiesNetwork.Count - 1
            Dim myItem As Entity = EntitiesNetwork.Item(i)
            If TypeOf myItem Is Provider Then
                Dim entity As Provider = DirectCast(myItem, Provider)
                sumOfEnergy = entity.AmountEnergy
                sumOfProductionCost += entity.GetProductionCost()
                sumOfCarbonDioxyde += entity.GetRateCarbonDioxide()
            ElseIf TypeOf myItem Is Consumers Then
                Dim entity As Consumers = DirectCast(myItem, Consumers)
                sumOfEnergyConsum = entity.ElectricalQuantityConsumed
            End If
        Next

        Return $"Energie total de {sumOfEnergy}MW pour un cout de {sumOfProductionCost}€ et une production de {sumOfCarbonDioxyde}g de CO2 avec un total de {sumOfEnergyConsum} MW consommé."
    End Function

    'Public Function GetLineMessage() As String
    '    Dim message As String = ""

    '    For i As Integer = 0 To LinesNetwork.Count - 1
    '        Dim myItem As Lines = LinesNetwork.Item(i)
    '        Dim getEnergyTotal As Double = GetTotalEnergyOnTheCurrentLine(myItem, 0)
    '        message = message & $"Line {myItem.LineId} Status : {CBool(getEnergyTotal <= myItem.MaximumPower).ToString} CurrentPower : {getEnergyTotal} LINK: [{myItem.Transmitter.Id} {myItem.Receiver.Id}]" & Environment.NewLine
    '    Next

    '    Return message
    'End Function

    'Private BlacklistIdReceiver As New List(Of Integer)
    'Private BlacklistIdTransmitter As New List(Of Integer)
    'Private Function GetTotalEnergyOnTheCurrentLine(line As Lines, energytotalOnTheLine As Integer)

    '    If TypeOf line.Transmitter Is Provider And BlacklistIdReceiver.Contains(line.LineId) Then
    '        Dim entity As Provider = DirectCast(line.Transmitter, Provider)
    '        BlacklistIdTransmitter.Add(entity.Id)
    '        energytotalOnTheLine += entity.AmountEnergy
    '    ElseIf TypeOf line.Transmitter Is Concentration Then
    '        Dim entity As Concentration = DirectCast(line.Transmitter, Concentration)
    '        BlacklistIdTransmitter.Add(entity.Id)
    '        For i As Integer = 0 To entity.ReceiverLines.Count - 1
    '            energytotalOnTheLine += GetTotalEnergyOnTheCurrentLine(entity.ReceiverLines(i), energytotalOnTheLine)
    '        Next

    '    ElseIf TypeOf line.Transmitter Is Distribution Then
    '        Dim entity As Distribution = DirectCast(line.Transmitter, Distribution)
    '        BlacklistIdTransmitter.Add(entity.Id)
    '        energytotalOnTheLine += GetTotalEnergyOnTheCurrentLine(entity.ReceiverLines, energytotalOnTheLine)
    '    End If

    '    If TypeOf line.Receiver Is Consumers Then
    '        Dim entity As Consumers = DirectCast(line.Receiver, Consumers)
    '        BlacklistIdReceiver.Add(entity.Id)
    '        energytotalOnTheLine -= entity.ElectricalQuantityConsumed

    '    ElseIf TypeOf line.Receiver Is Concentration Then
    '        Dim entity As Concentration = DirectCast(line.Receiver, Concentration)
    '        BlacklistIdReceiver.Add(entity.Id)
    '        energytotalOnTheLine -= GetTotalEnergyOnTheCurrentLine(entity.OutputLines, energytotalOnTheLine)
    '    ElseIf TypeOf line.Receiver Is Distribution Then
    '        Dim entity As Distribution = DirectCast(line.Receiver, Distribution)
    '        BlacklistIdReceiver.Add(entity.Id)
    '        For i As Integer = 0 To entity.OutputLines.Count - 1
    '            energytotalOnTheLine -= GetTotalEnergyOnTheCurrentLine(entity.OutputLines(i), energytotalOnTheLine)
    '        Next

    '    End If

    '    Return energytotalOnTheLine

    'End Function

    Public Sub RemoveLineNetwork(idLine As Integer)
        Dim myIndex As Integer = GetIndexLineById(idLine)
        If myIndex <> -1 Then
            LinesNetwork.RemoveAt(myIndex)
        End If
    End Sub

    Public Sub RemoveEntityNetwork(idEntity As Integer)
        Dim myIndex As Integer = GetIndexEntityById(idEntity)
        If myIndex <> -1 Then
            EntitiesNetwork.RemoveAt(myIndex)
        End If
    End Sub

    Private Function GetIndexEntityById(idEntity As Integer)
        For i As Integer = 0 To EntitiesNetwork.Count - 1
            If EntitiesNetwork(i).Id = idEntity Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Function GetIndexLineById(idLine As Integer)
        For i As Integer = 0 To LinesNetwork.Count - 1
            If LinesNetwork(i).LineId = idLine Then
                Return i
            End If
        Next
        Return -1
    End Function


End Class
