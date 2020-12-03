using Jones.Extensions;
using NUnit.Framework;

namespace Jones.UnitTest.Extensions
{
    public class EnumExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetDescription()
        {
            Assert.AreEqual(MyEnum.HaHa.GetDescription(), "哈哈");
            Assert.AreEqual(MyEnum.XiXi.GetDescription(), "嘻嘻");
        }

        [Test]
        public void TestGetEnumDescription()
        {
            Assert.AreEqual(MyEnum.XiXi.GetEnumDescription(), "我的Enum");
        }

        [System.ComponentModel.Description("我的Enum")]
        enum MyEnum
        {
            [System.ComponentModel.Description("哈哈")]
            HaHa,
            [System.ComponentModel.Description("嘻嘻")]
            XiXi
        }
    }
}