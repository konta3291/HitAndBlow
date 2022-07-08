Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public Class HitAndBlowGameTest

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドが数字を返すかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim result As Char() = HitAndBlowGame.MakeComputerNumber()
        Dim resultInteger = Integer.Parse(New String(result))

        Assert.AreEqual(result, result)

    End Sub

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドが４桁で返すかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim result As Char() = HitAndBlowGame.MakeComputerNumber()
        Assert.AreEqual(4, result.Count)

    End Sub

    <Test()> Public Sub ヒットした位置を返すメソッドのテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim playerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})

        Dim resultList As New List(Of Integer)(New Integer() {0, 2, 3})

        Dim result As List(Of Integer) = HitAndBlowGame.GetHitIndexs(computerNumber, playerNumber)
        Assert.AreEqual(resultList, result)

    End Sub

    <Test()> Public Sub ヒットした数字削除して返すかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim number As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim hitNumberIndex As New List(Of Integer)(New Integer() {2, 1})

        Dim resultList As New List(Of Char)(New Char() {"1"c, "4"c})

        Dim result As List(Of Char) = HitAndBlowGame.DeleteHitNumber(number, hitNumberIndex)
        Assert.AreEqual(resultList, result)

    End Sub

    <Test()> Public Sub ブロー数を返すメソッドのテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim playerNumber As New List(Of Char)(New Char() {"4"c, "3"c, "8"c, "0"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


        Dim result As Integer = HitAndBlowGame.CountNumberOfBlow(computerNumber, playerNumber)
        Assert.AreEqual(2, result)

    End Sub

    <Test()> Public Sub ヒット数を返すメソッドのテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim playerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "0"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


        Dim result As Integer = HitAndBlowGame.CountNumberOfBlow(computerNumber, playerNumber)
        Assert.AreEqual(3, result)

    End Sub
End Class
