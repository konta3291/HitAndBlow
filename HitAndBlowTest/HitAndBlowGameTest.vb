Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public MustInherit Class HitAndBlowGameTest
    Private sut As HitAndBlowGame
    <SetUp> Public Overridable Sub Setup()
        sut = New HitAndBlowGame
    End Sub

    Public Class MakeComputerNumberTest : Inherits HitAndBlowGameTest
        Private result As Char()
        <SetUp> Public Overrides Sub Setup()
            MyBase.Setup()
            result = sut.MakeComputerNumber(4)
        End Sub

        <Test()> Public Sub 数字を返すかテスト()

            Assert.IsTrue(IsNumeric(New String(result)))

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

    Public Class DeleteHitNumberTest : Inherits HitAndBlowGameTest
        <Test()> Public Sub ヒットした数字削除して返すかテスト()
            Dim number As New List(Of Char)(New Char() {"1"c, "2"c, "3"c, "4"c})
            Dim hitNumberIndex As New List(Of Integer)(New Integer() {2, 1})

            Dim resultList As New List(Of Char)(New Char() {"1"c, "4"c})

            Dim result As List(Of Char) = sut.DeleteHitNumber(number, hitNumberIndex)
            Assert.That(result, [Is].EqualTo(resultList))

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

    Public Class IsPlayerInputIsCorrectTest : Inherits HitAndBlowGameTest
        <TestCase("0000", 4)>
        <TestCase("00000", 5)>
        Public Sub 指定桁の数字を渡したときはTrue(inputNumber As String, numberOfDigits As Integer)

            Assert.IsTrue(sut.IsPlayerInputIsCorrect(inputNumber, numberOfDigits))

        End Sub

        <TestCase("00000", 4)>
        <TestCase("0000", 5)>
        Public Sub 指定桁ではない桁の数字を渡したときはFalse(inputNumber As String, numberOfDigits As Integer)

            Assert.IsFalse(sut.IsPlayerInputIsCorrect(inputNumber, numberOfDigits))

        End Sub

        <TestCase("", 4)>
        <TestCase("1.56", 4)>
        <TestCase("aaaa", 4)>
        Public Sub 受け付けない文字を渡したときはFalse(inputString As String, numberOfDigits As Integer)

            Assert.IsFalse(sut.IsPlayerInputIsCorrect(inputString, numberOfDigits))

        End Sub

        <Test()> Public Sub ShowAnswerを正しく渡すとTrue()

            Assert.IsTrue(sut.IsPlayerInputIsCorrect("ShowAnswer", 4))

        End Sub

        <TestCase("SHOWANSWER", 4)>
        <TestCase("showanswer", 4)>
        Public Sub ShowAnswerを正しく渡さないときはFalse(inputString As String, numberOfDigits As Integer)

            Assert.IsFalse(sut.IsPlayerInputIsCorrect(inputString, numberOfDigits))

        End Sub

        <TestCase("giveup", 4)>
        <TestCase("GIVEUP", 4)>
        <TestCase("GiVeUP", 4)>
        Public Sub giveupを渡すとTrue(inputString As String, numberOfDigits As Integer)

            Assert.IsTrue(sut.IsPlayerInputIsCorrect(inputString, numberOfDigits))

        End Sub

    End Class

End Class
