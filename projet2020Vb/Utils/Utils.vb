Public Class Utils
    Private Shared RandomNumber As New Random
    Public Shared Function RandomBtw(minValue As Integer, maxValueExclude As Integer) As Integer
        Randomize()
        Return RandomNumber.Next(minValue, maxValueExclude)
    End Function
End Class
