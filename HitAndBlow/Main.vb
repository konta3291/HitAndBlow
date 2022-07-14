Module Main

    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        Dim hitAndBlowGame As New HitAndBlowGame
        Console.Write("数字を入力してください：")
        Dim playerAswer As String = Console.ReadLine()
        Console.WriteLine(hitAndBlowGame.HitAndBlow(playerAswer))
    End Sub

End Module
