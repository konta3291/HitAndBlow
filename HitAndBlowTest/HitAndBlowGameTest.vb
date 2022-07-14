Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public MustInherit Class HitAndBlowGameTest
    Private sut As HitAndBlowGame
    <SetUp> Public Overridable Sub Setup()
        sut = New HitAndBlowGame
    End Sub

    Public Class CountNumberOfHitTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒット数を返すメソッドのテスト()
            Dim playerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "0"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


            Dim result As Integer = sut.CountNumberOfHit(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(3))

        End Sub
    End Class

    Public Class CountNumberOfBlowTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ブロー数を返すメソッドのテスト()
            Dim playerNumber As New List(Of Char)(New Char() {"4"c, "3"c, "8"c, "0"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


            Dim result As Integer = sut.CountNumberOfBlow(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(2))

        End Sub
    End Class

End Class
