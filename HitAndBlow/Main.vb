Imports System.Text.RegularExpressions
Public Module Main

    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        Dim hitAndBlowGame As New HitAndBlowGame
        hitAndBlowGame.HitAndBlow()
        Console.WriteLine("正解です！ゲームクリア！")
    End Sub

    ''' <summary>
    ''' プレイヤーからヒット＆ブローゲームで遊ぶための四桁の整数を受け取る
    ''' </summary>
    Public Function GetPlayerNumber() As String

        While True

            Console.Write("数字を入力してください：")
            Dim playerNumber As String = Console.ReadLine()
            If IsNumbersAreCorrectForGame(playerNumber) Then
                Return playerNumber
            Else
                Console.WriteLine("受け取った数値は４桁の整数ではありません")
            End If

        End While

    End Function

    ''' <summary>
    ''' 受け取った数字がヒット＆ブローのゲームに使用することのできる数字か判断する
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    Public Function IsNumbersAreCorrectForGame(number As String) As Boolean
        Return Regex.IsMatch(number, "^[0-9]{1,4}$") AndAlso number.Length = 4
    End Function

    ''' <summary>
    ''' ヒット＆ブローの結果を表示する
    ''' </summary>
    ''' <param name="hit"></param>
    ''' <param name="blow"></param>
    Public Sub ShowHitAndBlowResult(hit As Integer, blow As Integer)
        Dim result = $"ヒット:{hit}　ブロー:{blow}"
        Console.WriteLine(result)
    End Sub

End Module
