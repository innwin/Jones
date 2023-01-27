namespace Jones.UnitTest.Extensions;

public class LinqExtensionsTest
{
    [SetUp]
    public void Setup()
    {
    }
        
    [Test]
    public void TestDistinct()
    {
        var distinctList = new[]
        {
            new Distinct(1, 1),
            new Distinct(1, 1),
            new Distinct(1, 2),
        };

        var list = distinctList.Distinct().ToArray();
        Assert.AreEqual(list.Length, 2);
    }
}

public record Distinct
{
    public int A { get; }
        
    public int B { get; }

    public Distinct(int a, int b)
    {
        A = a;
        B = b;
    }
}