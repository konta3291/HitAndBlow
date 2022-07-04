Public Module Main

    Sub Main()

    End Sub

    ''' <summary>
    ''' 数字を受け取りヒット＆ブローの結果を返す
    ''' </summary>
    ''' <param name="playerAnswer"></param>
    ''' <returns></returns>
    Public Function ReturnResultOfHitAndBlowGame(playerAnswer As Integer) As String
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim playerNumber As New List(Of Char)(playerAnswer.ToString.ToCharArray)
        Dim blow As Integer = 0
        'hitした数字はblowでは比較しないので削除します。hitの位置を記録します
        Dim hitIndexs As New List(Of Integer)

        Dim hit As Integer = CountNumberOfHit(computerNumber, playerNumber)
        For i As Integer = 0 To computerNumber.Count - 1
            If computerNumber(i) = playerNumber(i) Then
                hitIndexs.Add(i)
            End If
        Next

        If hit < 4 Then

            '反転させ数字の大きい方から削除します
            hitIndexs.Reverse()
            For Each hitIndex As Integer In hitIndexs
                computerNumber.RemoveAt(hitIndex)
                playerNumber.RemoveAt(hitIndex)
            Next
            blow = CountNumberOfBlow(computerNumber, playerNumber)

        End If

        Dim result As String = ("Hit:" & hit.ToString & "," & "Blow:" & blow.ToString)
        Return result

    End Function

    ''' <summary>
    ''' 受け取った2つのリストを比較し、数字が同じであればhitに1を足す
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
    ''' computerNumberと同じ数字をplayerNumberが持っていればblowに1を足す
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

End Module
