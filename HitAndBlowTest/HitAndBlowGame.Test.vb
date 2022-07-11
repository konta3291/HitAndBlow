Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public Class HitAndBlowGameTest

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドが数字を返すかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim result As Char() = HitAndBlowGame.MakeComputerNumber()

        Assert.That(True, [Is].EqualTo(IsNumeric(New String(result))))

    End Sub

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドの返す四桁の数字の中に同じ数字を含まないかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim result As Char() = HitAndBlowGame.MakeComputerNumber()
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
        Assert.That(True, [Is].EqualTo(numbersThatAreNotDuplicated))

    End Sub

    <Test()> Public Sub コンピュータの４桁の数字を作るメソッドが４桁で返すかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim result As Char() = HitAndBlowGame.MakeComputerNumber()
        Assert.That(4, [Is].EqualTo(result.Count))

    End Sub

    <Test()> Public Sub ヒットした位置を返すメソッドのテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim playerNumber As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})

        Dim resultList As New List(Of Integer)(New Integer() {0, 2, 3})

        Dim result As List(Of Integer) = HitAndBlowGame.GetHitIndexs(computerNumber, playerNumber)
        Assert.That(resultList, [Is].EqualTo(result))


    End Sub

    <Test()> Public Sub ヒットした数字削除して返すかテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim number As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
        Dim hitNumberIndex As New List(Of Integer)(New Integer() {2, 1})

        Dim resultList As New List(Of Char)(New Char() {"1"c, "4"c})

        Dim result As List(Of Char) = HitAndBlowGame.DeleteHitNumber(number, hitNumberIndex)
        Assert.That(resultList, [Is].EqualTo(result))

    End Sub

    <Test()> Public Sub ブロー数を返すメソッドのテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim playerNumber As New List(Of Char)(New Char() {"4"c, "3"c, "8"c, "0"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


        Dim result As Integer = HitAndBlowGame.CountNumberOfBlow(computerNumber, playerNumber)
        Assert.That(2, [Is].EqualTo(result))

    End Sub

    <Test()> Public Sub ヒット数を返すメソッドのテスト()
        Dim HitAndBlowGame As New HitAndBlowGame
        Dim playerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "0"c})
        Dim computerNumber As New List(Of Char)(New Char() {"1"c, "5"c, "3"c, "4"c})


        Dim result As Integer = HitAndBlowGame.CountNumberOfBlow(computerNumber, playerNumber)
        Assert.That(3, [Is].EqualTo(result))

    End Sub
End Class
