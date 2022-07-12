Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public MustInherit Class HitAndBlowGameTest
    Private sut As New HitAndBlowGame
    Public Class MakeComputerNumberTest : Inherits HitAndBlowGameTest
        Private result As Char()
        <SetUp> Public Sub MakeComputerNumberのセットアップ()
            result = sut.MakeComputerNumber()
        End Sub

        <Test()> Public Sub 数字を返すかテスト()

            Assert.IsTrue(New String(result))

        End Sub

        <Test()> Public Sub 四桁の数字の中に同じ数字を含まないかテスト()

            'result配列の要素の中で重複していない要素だけnotDuplicatNumberに入れる
            Dim notDuplicatNumber As Char() = result.Distinct().ToArray
            Assert.That(notDuplicatNumber.Length, [Is].EqualTo(4))

        End Sub

        <Test()> Public Sub 四桁で返すかテスト()

            Assert.That(result.Count, [Is].EqualTo(4))

        End Sub

    End Class

    Public Class GetHitIndexstTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒットした位置を返すメソッドのテスト()
            Dim playerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})

            Dim resultList As New List(Of Integer)(New Integer() {0, 2, 3})

            Dim result As List(Of Integer) = sut.GetHitIndexs(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(resultList))


        End Sub
    End Class

    Public Class DeleteHitNumberTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒットした数字削除して返すかテスト()
            Dim number As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
            Dim hitNumberIndex As New List(Of Integer)(New Integer() {2, 1})

            Dim resultList As New List(Of Char)(New Char() {"1"c, "4"c})

            Dim result As List(Of Char) = sut.DeleteHitNumber(number, hitNumberIndex)
            Assert.That(result, [Is].EqualTo(resultList))

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

    Public Class CountNumberOfHitTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒット数を返すメソッドのテスト()
            Dim playerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "0"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


            Dim result As Integer = sut.CountNumberOfHit(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(3))

        End Sub
    End Class

End Class
