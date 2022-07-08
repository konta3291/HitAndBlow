Imports System.Text.RegularExpressions
Public Module Main
    Private computerAnswer As List(Of Char)
    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        computerAnswer = New List(Of Char)(MakeComputerNumber)
        HitAndBlow()
        Console.WriteLine("成功です")
        AskPlayerWantToPlayAgain()
    End Sub

    ''' <summary>
    ''' もう一度ヒット＆ブローを遊ぶか聞きます
    ''' </summary>
    Private Sub AskPlayerWantToPlayAgain()
        Console.WriteLine("もう一度遊びますか")
        Console.WriteLine("遊ぶ場合は：[y]・遊ばない場合は：[n]")
        Dim playerAnswer As String = Console.ReadLine()

        If playerAnswer.Equals("y") Then
            Main()
        ElseIf playerAnswer.Equals("n") Then
            Environment.Exit(0)
        Else
            AskPlayerWantToPlayAgain()
        End If
    End Sub

    ''' <summary>
    ''' 数字の入力を受けとりヒット＆ブローゲームを始めます
    ''' </summary>
    Private Sub HitAndBlow()
        Dim playerNumber As String = GetPlayerNumber()
        ReturnResultOfHitAndBlowGame(playerNumber)
    End Sub

    ''' <summary>
    ''' 数字を受け取りヒット＆ブローの結果を返す
    ''' </summary>
    ''' <param name="playerAnswer"></param>
    Public Sub ReturnResultOfHitAndBlowGame(playerAnswer As String)
        Dim computerNumber As New List(Of Char)(computerAnswer)
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
        Console.WriteLine(result)
        If hit <> 4 Then
            HitAndBlow()
        End If
    End Sub

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

    ''' <summary>
    ''' プレイヤーからヒット＆ブローゲームで遊ぶための四桁の整数を受け取る
    ''' </summary>
    Private Function GetPlayerNumber() As String
        Console.Write("数字を入力してください：")
        Dim playerNumber As String = Console.ReadLine()

        While (Regex.IsMatch(playerNumber, "^[0-9]{1,4}$") AndAlso playerNumber.Length = 4) = False
            Console.WriteLine("受け取った数値は４桁の整数ではありません")
            Console.Write("数字を入力してください：")
            playerNumber = Console.ReadLine()
        End While

        Return playerNumber

    End Function

    ''' <summary>
    ''' コンピュータの数字を四桁ランダムに生成します
    ''' </summary>
    ''' <returns></returns>
    Public Function MakeComputerNumber() As Char()
        Dim random = New System.Random
        '-1はこれから乱数が入るところです。
        Dim randomNumber As Integer() = {random.Next(10), -1, -1, -1}

        Dim i As Integer = 1
        While i < 4

            Dim newNumber As Integer = random.Next(10)
            'randomNumber配列にnewNumberが含まれていなければ中に入る
            If Not (randomNumber.Contains(newNumber)) Then
                randomNumber(i) = newNumber
                i += 1
            End If

        End While
        'randomNumberをStringに変換
        Dim randomNumberString As String = Nothing
        For j As Integer = 0 To 3
            randomNumberString &= randomNumber(j).ToString
        Next

        Dim computerNumber As Char() = randomNumberString.ToCharArray

        Return computerNumber
    End Function

End Module
