Imports System.Text.RegularExpressions
Public Module Main

    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        Do
            Dim hitAndBlowGame As New HitAndBlowGame
            hitAndBlowGame.HitAndBlow(GetNumberOfChallengeDigits)
        Loop While AskPlayerWantToPlayAgain()
    End Sub

    ''' <summary>
    ''' ヒット＆ブローゲームを何桁で遊ぶか取得する
    ''' </summary>
    ''' <returns></returns>
    Private Function GetNumberOfChallengeDigits() As Integer

        While True

            Console.Write("挑戦する桁数を入力してください(3～10):")
            Dim numberOfDigits As String = Console.ReadLine()
            If Regex.IsMatch(numberOfDigits, "^[0-9]{1,2}$") AndAlso 2 < Integer.Parse(numberOfDigits) AndAlso Integer.Parse(numberOfDigits) < 11 Then
                Return Integer.Parse(numberOfDigits)
            Else
                Console.WriteLine("入力された数字は3～10の整数ではありません")
            End If

        End While

    End Function

    ''' <summary>
    ''' もう一度ヒット＆ブローを遊ぶか聞きます
    ''' </summary>
    Private Function AskPlayerWantToPlayAgain() As Boolean
        Dim playerAnswer As String

        While Not ("Y".Equals(playerAnswer) OrElse "N".Equals(playerAnswer))
            Console.Write("もう一度プレイしますか？（Y/N）:")
            playerAnswer = Console.ReadLine().ToUpper
        End While
        Return playerAnswer.Equals("Y")
    End Function

End Module
