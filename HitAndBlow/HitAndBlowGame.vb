﻿Public Class HitAndBlowGame

    ''' <summary>
    ''' ヒット＆ブローの処理をする
    ''' </summary>
    Public Sub HitAndBlow(computerAnswer As List(Of Char))
        Dim hit As Integer = 0

        While hit <> 4
            Dim computerNumber As New List(Of Char)(computerAnswer)
            Dim playerNumber As New List(Of Char)(Main.GetPlayerNumber.ToCharArray)
            Dim blow As Integer = 0

            hit = CountNumberOfHit(computerNumber, playerNumber)

            If hit < 4 Then

                'hitした数字はblowでは比較しないので削除します。hitの位置を記録します
                Dim hitIndexs As New List(Of Integer)(GetHitIndexs(computerNumber, playerNumber))
                '反転させ数字の大きい方を先頭にします
                hitIndexs.Reverse()
                computerNumber = DeleteHitNumber(computerNumber, hitIndexs)
                playerNumber = DeleteHitNumber(playerNumber, hitIndexs)
                blow = CountNumberOfBlow(computerNumber, playerNumber)

            End If

            Main.ShowHitAndBlowResult(hit, blow)

        End While

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
    ''' コンピュータの数字を四桁ランダムに生成します
    ''' </summary>
    ''' <returns></returns>
    Public Function MakeComputerNumber() As Char()
        Dim random = New System.Random
        Const RANDOM_NUMBER_WILL_BE_ENTERED As Integer = -1
        Dim randomNumber As Integer() = {random.Next(10), RANDOM_NUMBER_WILL_BE_ENTERED,
            RANDOM_NUMBER_WILL_BE_ENTERED, RANDOM_NUMBER_WILL_BE_ENTERED}

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

End Class
