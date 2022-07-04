Imports HitAndBlow
Imports NUnit.Framework
<TestFixture> Public Class HitAndBlowTest

    <Test()> Public Sub ヒット4ブロー0の時()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame(1234)
        Assert.AreEqual("Hit:4,Blow:0", result)

    End Sub

    <Test()> Public Sub ヒット2ブロー2の時()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame(1324)
        Assert.AreEqual("Hit:2,Blow:2", result)

    End Sub

    <Test()> Public Sub ヒットもブローも0の時()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame(5678)
        Assert.AreEqual("Hit:0,Blow:0", result)

    End Sub

    <Test()> Public Sub ヒット0のブロー4()

        Dim result As String = Main.ReturnResultOfHitAndBlowGame(4321)
        Assert.AreEqual("Hit:0,Blow:4", result)

    End Sub

End Class
