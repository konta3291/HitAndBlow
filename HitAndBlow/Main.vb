Public Module Main

    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        Console.Write("数字を入力してください：")
        Dim playerNumber As String = Console.ReadLine()
        Console.Write(ReturnResultOfHitAndBlowGame(playerNumber))
    End Sub

    ''' <summary>
    ''' 数字を受け取りヒット＆ブローの結果を返す
    ''' </summary>
    ''' <param name="playerAnswer"></param>
    ''' <returns></returns>
    Public Function ReturnResultOfHitAndBlowGame(playerAnswer As String) As String
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim playerNumber As New List(Of Char)(playerAnswer.ToCharArray)
        Dim blow As Integer = 0

        Dim hit As Integer = CountNumberOfHit(computerNumber, playerNumber)

        If hit < 4 Then

            'hitした数字はblowでは比較しないので削除します。hitの位置を記録します
            Dim hitIndexs As New List(Of Integer)(GetHitIndexs(computerNumber, playerNumber))
            '反転させ数字の大きい方を先頭にします
            hitIndexs.Reverse()
            computerNumber = DeleteHitNumber(computerNumber, hitIndexs)
            playerNumber = DeleteHitNumber(playerNumber, hitIndexs)
            blow = CountNumberOfBlow(computerNumber, playerNumber)

        End If

        Dim result = $"Hit:{hit},Blow:{blow}"
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

    ''' <summary>
    ''' 2つのリストを比較し数字が同じだった場所を返す
    ''' </summary>
    ''' <param name="computerNumber"></param>
    ''' <param name="playerNumber"></param>
    ''' <returns></returns>
    Public Function GetHitIndexs(computerNumber As List(Of Char), playerNumber As List(Of Char)) As List(Of Integer)
        Dim hitIndexs As New List(Of Integer)

        For i As Integer = 0 To computerNumber.Count - 1
            If computerNumber(i) = playerNumber(i) Then
                hitIndexs.Add(i)
            End If
        Next
        Return hitIndexs

    End Function

    ''' <summary>
    ''' ヒットだった数字を消したリストを返す
    ''' </summary>
    ''' <param name="number"></param>
    ''' <param name="hitIndexs"></param>
    ''' <returns></returns>
    Public Function DeleteHitNumber(number As List(Of Char), hitIndexs As List(Of Integer)) As List(Of Char)
        Dim returnNumber As New List(Of Char)(number)

        For Each deleteIndex As Integer In hitIndexs
            returnNumber.RemoveAt(deleteIndex)
        Next

        Return returnNumber

    End Function

End Module
