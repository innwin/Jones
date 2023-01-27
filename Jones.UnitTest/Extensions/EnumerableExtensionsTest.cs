using Jones.Extensions;

namespace Jones.UnitTest.Extensions;

[TestFixture]
public class EnumerableExtensionsTest
{
    [Test]
    public void TestToString()
    {
        var intString = new [] { 1, 2}.ToString(",");
        Console.WriteLine(intString);
        Assert.AreEqual(intString, "1,2");
        var stringString = new [] { "1", "2"}.ToString(",");
        Console.WriteLine(stringString);
        Assert.AreEqual(stringString, "1,2");
    }
}