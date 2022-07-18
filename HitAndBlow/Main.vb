Public Module Main

    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        Do
            Dim hitAndBlowGame As New HitAndBlowGame
            hitAndBlowGame.HitAndBlow()
            Console.WriteLine("正解です！ゲームクリア！")
        Loop While AskPlayerWantToPlayAgain()
    End Sub

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
