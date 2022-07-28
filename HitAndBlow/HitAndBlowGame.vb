Imports System.Text.RegularExpressions
Public Class HitAndBlowGame
    Private ReadOnly timer As New System.Diagnostics.Stopwatch()
    ''' <summary>
    ''' ヒット＆ブローの処理をする
    ''' </summary>
    Public Sub HitAndBlow(numberOfDigits As Integer)
        Dim hit As Integer = 0
        Dim computerAnswer As Char() = MakeComputerNumber(numberOfDigits)
        Dim turnCount As Integer = 0
        timer.Start()
        While hit <> numberOfDigits
            Dim computerNumber As New List(Of Char)(computerAnswer)
            Dim playerAnswer As String = GetPlayerAnswer(numberOfDigits)
            If "giveup".Equals(playerAnswer, StringComparison.OrdinalIgnoreCase) Then
                AbandonTheGame(computerAnswer)
                Exit Sub
            ElseIf "ShowAnswer".Equals(playerAnswer) Then
                ShowAnswer(computerAnswer)
                Continue While
            End If
            Dim playerNumber As New List(Of Char)(playerAnswer.ToCharArray)
            Dim blow As Integer = 0
            turnCount += 1
            hit = CountNumberOfHit(computerNumber, playerNumber)

            If hit = numberOfDigits Then
                timer.Stop()
                Exit While
            End If

            'hitした数字はblowでは比較しないので削除します。hitの位置を記録します
            Dim hitIndexs As New List(Of Integer)(GetHitIndexs(computerNumber, playerNumber))
            '反転させ数字の大きい方を先頭にします
            hitIndexs.Reverse()
            computerNumber = DeleteHitNumber(computerNumber, hitIndexs)
            playerNumber = DeleteHitNumber(playerNumber, hitIndexs)
            blow = CountNumberOfBlow(computerNumber, playerNumber)
            ShowHitAndBlowResult(hit, blow)

        End While
        ShowTheScreenOfGamePassed(turnCount)
    End Sub

    ''' <summary>
    ''' ギブアップしたときの処理
    ''' </summary>
    ''' <param name="answer"></param>
    Private Sub AbandonTheGame(answer As Char())
        Console.WriteLine("ギブアップしました。正解は「" & answer & "」でした。")
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

        For Each number As Char In computerNumber
            If playerNumber.Contains(number) Then
                blow += 1
            End If
        Next

        Return blow

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
    ''' コンピュータの数字を指定桁ランダムに生成します
    ''' </summary>
    ''' <returns></returns>
    Public Function MakeComputerNumber(numberOfDigits As Integer) As Char()
        Dim originArray As Char() = {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c}

        originArray = Shuffle(originArray)

        Dim computerNumber As Char() = New ArraySegment(Of Char)(originArray, 0, numberOfDigits).ToArray()

        Return computerNumber

    End Function

    ''' <summary>
    ''' 配列の中身をシャッフルする
    ''' </summary>
    ''' <param name="originArray"></param>
    ''' <returns></returns>
    Public Function Shuffle(originArray As Char()) As Char()
        Dim returnArray As Char() = originArray
        Dim random As New System.Random()

        For i As Integer = returnArray.Length - 1 To 1 Step -1
            Dim j As Integer = random.Next(i + 1)
            Dim nextINumber As Char = returnArray(j)
            returnArray(j) = returnArray(i)
            returnArray(i) = nextINumber
        Next

        Return returnArray

    End Function

    ''' <summary>
    ''' ヒット＆ブローの結果を表示する
    ''' </summary>
    ''' <param name="hit"></param>
    ''' <param name="blow"></param>
    Private Sub ShowHitAndBlowResult(hit As Integer, blow As Integer)
        Dim result = $"ヒット:{hit}　ブロー:{blow}"
        Console.WriteLine(result)
    End Sub

    ''' <summary>
    ''' 答えを表示する
    ''' </summary>
    Private Sub ShowAnswer(computerAnswer As Char())

        Console.WriteLine(computerAnswer)

    End Sub

    ''' <summary>
    ''' プレイヤーから適切な入力がされるまで数字の入力を求める
    ''' 適切な入力とは、指定桁の整数もしくは、ShowAnswer、giveup
    ''' </summary>
    Private Function GetPlayerAnswer(numberOfDigits As Integer) As String

        While True

            Console.Write("数字を入力してください：")
            Dim playerInput As String = Console.ReadLine()

            If IsPlayerInputIsCorrect(playerInput, numberOfDigits) Then
                Return playerInput
            Else
                Console.WriteLine("入力された数字は" & numberOfDigits & "桁の整数ではありません")
            End If

        End While

    End Function

    ''' <summary>
    ''' ゲームが受け付ける入力かを判断する
    ''' </summary>
    ''' <param name="playerInput"></param>
    ''' <returns></returns>
    Public Function IsPlayerInputIsCorrect(playerInput As String, numberOfDigits As Integer) As Boolean
        Return Regex.IsMatch(playerInput, "^[0-9]{" & numberOfDigits & "}$") OrElse
            "giveup".Equals(playerInput, StringComparison.OrdinalIgnoreCase) OrElse
            "ShowAnswer".Equals(playerInput)
    End Function

    ''' <summary>
    ''' ゲームクリアの画面を表示する
    ''' </summary>
    ''' <param name="turn"></param>
    Private Sub ShowTheScreenOfGamePassed(turn As Integer)
        Console.WriteLine("正解です！ゲームクリア！")
        Console.WriteLine($"正解まで{turn}手、クリアタイム {timer.Elapsed:mm\:ss\.ff}")
    End Sub

End Class
