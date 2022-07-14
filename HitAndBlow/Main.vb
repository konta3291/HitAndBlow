Module Main

    Sub Main()
        Console.WriteLine("ヒット＆ブロー")
        Dim hitAndBlowGame As New HitAndBlowGame
        Dim playerAswer As String = "1234"
        Console.WriteLine(hitAndBlowGame.HitAndBlow(playerAswer))
    End Sub

End Module
