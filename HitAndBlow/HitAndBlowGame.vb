Public Class HitAndBlowGame

    ''' <summary>
    ''' 受け取った2つのリストを比較し、位置と数字が同じものがいくつあったかカウントしその値を返す
    ''' </summary>
    ''' <param name="computerNumber"></param>
    ''' <param name="playerNumber"></param>
    ''' <returns></returns>
    Public Function CountNumberOfHit(computerNumber As List(Of Char), playerNumber As List(Of Char)) As Integer
        Dim hit As Integer = 0

        For i As Integer = 0 To computerNumber.Count - 1
            If computerNumber(i) = playerNumber(i) Then
                hit += 1
            End If
        Next

        Return hit

    End Function

    ''' <summary>
    ''' 受け取った2つのリストを比較し、数字が同じものがいくつあったかカウントしその値を返す
    ''' </summary>
    ''' <param name="computerNumber"></param>
    ''' <param name="playerNumber"></param>
    ''' <returns></returns>
    Public Function CountNumberOfBlow(computerNumber As List(Of Char), playerNumber As List(Of Char)) As Integer
        Dim blow As Integer = 0
        Dim playerNumberForComparison As New List(Of Char)(playerNumber)

        For i As Integer = 0 To computerNumber.Count - 1
            For j As Integer = 0 To playerNumberForComparison.Count - 1
                If computerNumber(i) = playerNumberForComparison(j) Then
                    blow += 1
                    playerNumberForComparison.RemoveAt(j)
                    Exit For
                End If
            Next
        Next

        Return blow

    End Function

End Class
