Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public MustInherit Class MainTest
    Public Class IsNumbersAreCorrectForGameTest : Inherits MainTest
        <Test()> Public Sub 四桁の数字を渡したときはTrue()

            Assert.IsTrue(Main.IsNumbersAreCorrectForGame("0000"))

        End Sub

        <Test()> Public Sub 四桁ではない五桁の数字を渡したときはFalse()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame("00000"))

        End Sub

        <Test()> Public Sub 四桁の数字ではない空文字を渡したときはFalse()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame(""))

        End Sub

        <Test()> Public Sub 数字以外の文字を含むときはFalse()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame("1.56"))

        End Sub

        <Test()> Public Sub 数字以外の文字を渡したときはFalse()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame("aaaa"))

        End Sub

    End Class

End Class