Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public Class MainTest

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドが数字を返すかテスト()

        Dim result As Char() = Main.MakeComputerNumber()
        Dim resultInteger = Integer.Parse(New String(result))

        Assert.AreEqual(result, result)

    End Sub

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドが４桁で返すかテスト()

        Dim result As Char() = Main.MakeComputerNumber()
        Assert.AreEqual(4, result.Count)

    End Sub

    <Test()> Public Sub ヒットした位置を返すメソッドのテスト()
        Dim playerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})

        Dim resultList As New List(Of Integer)(New Integer() {0, 2, 3})

        Dim result As List(Of Integer) = Main.GetHitIndexs(computerNumber, playerNumber)
        Assert.AreEqual(resultList, result)

    End Sub

    <Test()> Public Sub ヒットした数字削除して返すかテスト()
        Dim number As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim hitNumberIndex As New List(Of Integer)(New Integer() {2, 1})

        Dim resultList As New List(Of Char)(New Char() {"1"c, "4"c})

        Dim result As List(Of Char) = Main.DeleteHitNumber(number, hitNumberIndex)
        Assert.AreEqual(resultList, result)

    End Sub

    <Test()> Public Sub ブロー数を返すメソッドのテスト()
        Dim playerNumber As New List(Of Char)(New Char() {"4"c, "3"c, "8"c, "0"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


        Dim result As Integer = Main.CountNumberOfBlow(computerNumber, playerNumber)
        Assert.AreEqual(2, result)

    End Sub

    <Test()> Public Sub ヒット数を返すメソッドのテスト()
        Dim playerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "0"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


        Dim result As Integer = Main.CountNumberOfBlow(computerNumber, playerNumber)
        Assert.AreEqual(3, result)

    End Sub

End Class
