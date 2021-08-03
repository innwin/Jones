using Jones.Extensions;
using NUnit.Framework;

namespace Jones.UnitTest.Extensions
{
    public class TExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIsNullable()
        {
            var viewModel = new ViewModel();
            Assert.AreEqual(viewModel.Name.IsNullable(), false);
            Assert.AreEqual(viewModel.ShortName.IsNullable(), true);
            Assert.AreEqual(viewModel.Balance.IsNullable(), false);
            Assert.AreEqual(viewModel.Money.IsNullable(), true);
            Assert.AreEqual(viewModel.IsAdmin.IsNullable(), false);
            Assert.AreEqual(viewModel.IsLock.IsNullable(), true);
        }
    }

    public record ViewModel
    {
        public string Name { get; set; }
        public string? ShortName { get; set; }
        public int Balance { get; set; }
        public int? Money { get; set; }
        public bool IsAdmin { get; set; }
        public bool? IsLock { get; set; }
    }
}