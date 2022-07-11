Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public MustInherit Class HitAndBlowGameTest
    Public Class MakeComputerNumberTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub 数字を返すかテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim result As Char() = hitAndBlowGame.MakeComputerNumber()

            Assert.IsTrue(New String(result))

        End Sub

        <Test()> Public Sub 四桁の数字の中に同じ数字を含まないかテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim result As Char() = hitAndBlowGame.MakeComputerNumber()
            Dim numbersThatAreNotDuplicated As Boolean = True
            Dim notDuplicatNumber As Char() = {result(0), "", "", ""}
            Dim i As Integer = 1
            While i < 4
                Dim newNumber As Char = result(i)

                If Not (notDuplicatNumber.Contains(newNumber)) Then
                    notDuplicatNumber(i) = newNumber
                    i += 1
                Else
                    numbersThatAreNotDuplicated = False
                    Exit While
                End If

            End While
            Assert.IsTrue(numbersThatAreNotDuplicated)

        End Sub

        <Test()> Public Sub 四桁で返すかテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim result As Char() = hitAndBlowGame.MakeComputerNumber()
            Assert.That(result.Count, [Is].EqualTo(4))

        End Sub

    End Class

    Public Class GetHitIndexstTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒットした位置を返すメソッドのテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim playerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})

            Dim resultList As New List(Of Integer)(New Integer() {0, 2, 3})

            Dim result As List(Of Integer) = hitAndBlowGame.GetHitIndexs(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(resultList))


        End Sub
    End Class

    Public Class DeleteHitNumberTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒットした数字削除して返すかテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim number As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
            Dim hitNumberIndex As New List(Of Integer)(New Integer() {2, 1})

            Dim resultList As New List(Of Char)(New Char() {"1"c, "4"c})

            Dim result As List(Of Char) = hitAndBlowGame.DeleteHitNumber(number, hitNumberIndex)
            Assert.That(result, [Is].EqualTo(resultList))

        End Sub
    End Class

    Public Class CountNumberOfBlowTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ブロー数を返すメソッドのテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim playerNumber As New List(Of Char)(New Char() {"4"c, "3"c, "8"c, "0"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


            Dim result As Integer = hitAndBlowGame.CountNumberOfBlow(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(2))

        End Sub
    End Class

    Public Class CountNumberOfHitTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒット数を返すメソッドのテスト()
            Dim hitAndBlowGame As New HitAndBlowGame
            Dim playerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "0"c})
            Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


            Dim result As Integer = hitAndBlowGame.CountNumberOfHit(computerNumber, playerNumber)
            Assert.That(result, [Is].EqualTo(3))

        End Sub
    End Class

End Class
