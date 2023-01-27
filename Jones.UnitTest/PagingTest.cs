namespace Jones.UnitTest;

public class PagingTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestPaging()
    {
        var paging = new Paging<string>(null, 2, 10, 26);
        Console.WriteLine($"TotalPages: {paging.TotalPages}");
        Console.WriteLine($"NextPage: {paging.NextPage}");
        Console.WriteLine($"PreviousPage: {paging.PreviousPage}");
        Assert.AreEqual(paging.TotalPages, 3);
        Assert.AreEqual(paging.NextPage, 3);
        Assert.AreEqual(paging.PreviousPage, 1);
            
        paging = new Paging<string>(null, 1, 10, 0);
        Console.WriteLine($"TotalPages: {paging.TotalPages}");
        Console.WriteLine($"NextPage: {paging.NextPage}");
        Console.WriteLine($"PreviousPage: {paging.PreviousPage}");
        Assert.AreEqual(paging.TotalPages, 0);
        Assert.AreEqual(paging.NextPage, null);
        Assert.AreEqual(paging.PreviousPage, null);
    }
}