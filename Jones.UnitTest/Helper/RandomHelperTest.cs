using System;
using Jones.Helper;
using NUnit.Framework;

namespace Jones.UnitTest.Helper;

public class RandomHelperTest
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void TestRandomItemsWithWeight()
    {
        var random = RandomHelper.Random(new float[]{ 1, 2, 3 });
        Console.WriteLine($"random：{random}");
    }
}