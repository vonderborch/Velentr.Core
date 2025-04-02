namespace Velentr.Core.Test;

public class MySharedClassTest
{
    [Test]
    public void TestMyMethod()
    {
        var myClass = new MySharedClass();
        var result = myClass.MyMethod("World");
        Assert.That(result, Is.EqualTo("Hello, World!"));
    }
}
