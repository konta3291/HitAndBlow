Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public MustInherit Class MainTest
    Public Class IsNumbersAreCorrectForGameTest : Inherits MainTest
        <Test()> Public Sub 四桁の数字を渡したときのテスト()

            Assert.IsTrue(Main.IsNumbersAreCorrectForGame("0000"))

        End Sub

        <Test()> Public Sub 五桁の数字を渡したときのテスト()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame("00000"))

        End Sub

        <Test()> Public Sub 空文字を渡したときのテスト()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame(""))

        End Sub

        <Test()> Public Sub 数字以外の文字を含むときのテスト()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame("1.56"))

        End Sub

        <Test()> Public Sub 数字以外の文字を渡したときのテスト()

            Assert.IsFalse(Main.IsNumbersAreCorrectForGame("aaaa"))

        End Sub

    End Class

End Class
