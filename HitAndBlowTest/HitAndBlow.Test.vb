Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public Class HitAndBlowTest

    <Test()> Public Sub ヒット4ブロー0の時()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame("1234")
        Assert.AreEqual("Hit:4,Blow:0", result)

    End Sub

    <Test()> Public Sub ヒット2ブロー2の時()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame("1324")
        Assert.AreEqual("Hit:2,Blow:2", result)

    End Sub

    <Test()> Public Sub ヒットもブローも0の時()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame("5678")
        Assert.AreEqual("Hit:0,Blow:0", result)

    End Sub

    <Test()> Public Sub ヒット0のブロー4()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame("4321")
        Assert.AreEqual("Hit:0,Blow:4", result)

    End Sub

    <Test()> Public Sub 五桁目以上はエラーと返す()

        Assert.That(Sub() Main.ReturnResultOfHitAndBlowGame("12345"), Throws.TypeOf(Of ArgumentException)().And.Message.EqualTo("受け取った数値は４桁の整数ではありません"))

    End Sub

    <Test()> Public Sub 三桁以下はエラーと返す()

        Assert.That(Sub() Main.ReturnResultOfHitAndBlowGame("123"), Throws.TypeOf(Of ArgumentException)().And.Message.EqualTo("受け取った数値は４桁の整数ではありません"))

    End Sub

    <Test()> Public Sub 負の値はエラーと返す()

        Assert.That(Sub() Main.ReturnResultOfHitAndBlowGame("-123"), Throws.TypeOf(Of ArgumentException)().And.Message.EqualTo("受け取った数値は４桁の整数ではありません"))

    End Sub

    <Test()> Public Sub 小数点はエラーと返す()

        Assert.That(Sub() Main.ReturnResultOfHitAndBlowGame("1.538"), Throws.TypeOf(Of ArgumentException)().And.Message.EqualTo("受け取った数値は４桁の整数ではありません"))

    End Sub

    <Test()> Public Sub 空はエラーと返す()

        Assert.That(Sub() Main.ReturnResultOfHitAndBlowGame(""), Throws.TypeOf(Of ArgumentException)().And.Message.EqualTo("受け取った数値は４桁の整数ではありません"))

    End Sub

    <Test()> Public Sub 文字を含む場合はエラーと返す()

        Assert.That(Sub() Main.ReturnResultOfHitAndBlowGame("12a4"), Throws.TypeOf(Of ArgumentException)().And.Message.EqualTo("受け取った数値は４桁の整数ではありません"))

    End Sub

End Class
