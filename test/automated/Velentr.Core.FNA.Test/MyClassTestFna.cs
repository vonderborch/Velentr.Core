namespace Velentr.Core.Test;

public class MyClassTestFna
{
    [Test]
    public void TestMyMethod()
    {
        var myClass = new MySharedClass();
        var result = myClass.MyMethod("FNA");
        Assert.That(result, Is.EqualTo("Hello, FNA!"));
    }
}
