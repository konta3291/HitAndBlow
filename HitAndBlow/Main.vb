Imports System.Text.RegularExpressions
Public Module Main

    Sub Main()
        Dim isPlayerWantsToPlay As Boolean = True
        While isPlayerWantsToPlay = True
            Console.WriteLine("ヒット＆ブロー")
            Dim hitAndBlowGame As New HitAndBlowGame
            hitAndBlowGame.HitAndBlow()
            Console.WriteLine("成功です")
            isPlayerWantsToPlay = AskPlayerWantToPlayAgain()
        End While
    End Sub

    ''' <summary>
    ''' もう一度ヒット＆ブローを遊ぶか聞きます
    ''' </summary>
    Private Function AskPlayerWantToPlayAgain() As Boolean
        Dim playerAnswer As String

        While Not ("Y".Equals(playerAnswer) OrElse "N".Equals(playerAnswer))
            Console.WriteLine("もう一度プレイしますか？（Y/N）")
            playerAnswer = Console.ReadLine()
        End While
        Return playerAnswer.Equals("Y")
    End Function

    ''' <summary>
    ''' プレイヤーからヒット＆ブローゲームで遊ぶための四桁の整数を受け取る
    ''' </summary>
    Public Function GetPlayerNumber() As String

        While True

            Console.Write("数字を入力してください：")
            Dim playerNumber As String = Console.ReadLine()
            If Regex.IsMatch(playerNumber, "^[0-9]{1,4}$") AndAlso playerNumber.Length = 4 Then
                Return playerNumber
            Else
                Console.WriteLine("受け取った数値は４桁の整数ではありません")
            End If

        End While

    End Function

    ''' <summary>
    ''' ヒット＆ブローの結果を表示する
    ''' </summary>
    ''' <param name="hit"></param>
    ''' <param name="blow"></param>
    Public Sub ShowHitAndBlowResult(hit As Integer, blow As Integer)
        Dim result = $"Hit:{hit},Blow:{blow}"
        Console.WriteLine(result)
    End Sub

End Module
