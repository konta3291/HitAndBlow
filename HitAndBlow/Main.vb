﻿Imports System.Text.RegularExpressions
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
        Dim playerNumber As String = ""

        While Not (Regex.IsMatch(playerNumber, "^[0-9]{1,4}$") AndAlso playerNumber.Length = 4)
            Dim count As Integer
            If 0 < count Then
                Console.WriteLine("受け取った数値は４桁の整数ではありません")
            End If
            Console.Write("数字を入力してください：")
            playerNumber = Console.ReadLine()

            count += 1

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
