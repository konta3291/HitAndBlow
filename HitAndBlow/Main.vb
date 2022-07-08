Imports System.Text.RegularExpressions
Public Module Main

    Sub Main()
        Dim play As Boolean = True
        While play = True
            Console.WriteLine("ヒット＆ブロー")
            Dim HitAndBlowGame As New HitAndBlowGame
            HitAndBlowGame.HitAndBlow()
            Console.WriteLine("成功です")
            play = AskPlayerWantToPlayAgain()
        End While
    End Sub

    ''' <summary>
    ''' もう一度ヒット＆ブローを遊ぶか聞きます
    ''' </summary>
    Private Function AskPlayerWantToPlayAgain() As Boolean
        Dim playerAnswer As String = ""

        While (playerAnswer.Equals("y") OrElse playerAnswer.Equals("n")) = False
            Console.WriteLine("もう一度プレイしますか？（Y/N）")
            playerAnswer = Console.ReadLine()
        End While

        If playerAnswer.Equals("y") Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' プレイヤーからヒット＆ブローゲームで遊ぶための四桁の整数を受け取る
    ''' </summary>
    Public Function GetPlayerNumber() As String
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
    ''' ヒット＆ブローの結果を表示する
    ''' </summary>
    ''' <param name="hit"></param>
    ''' <param name="blow"></param>
    Public Sub ShowHitAndBlowResult(hit As Integer, blow As Integer)
        Dim result = $"Hit:{hit},Blow:{blow}"
        Console.WriteLine(result)
    End Sub

End Module
