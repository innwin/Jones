using System;
using NUnit.Framework;

namespace Jones.UnitTest
{
    public class PagingTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPaging()
        {
            var paging = new Paging<string>(null, 2, 10, 21);
            Console.WriteLine($"TotalPages: {paging.TotalPages}");
            Console.WriteLine($"NextPage: {paging.NextPage}");
            Console.WriteLine($"PreviousPage: {paging.PreviousPage}");
            Assert.AreEqual(paging.TotalPages, 3);
            Assert.AreEqual(paging.NextPage, 3);
            Assert.AreEqual(paging.PreviousPage, 1);
        }
    }
}