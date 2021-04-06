using System;
using Jones.Extensions;
using NUnit.Framework;

namespace Jones.UnitTest.Extensions
{
    public class AttributeExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void TestGetDescription()
        {
            var myClass = new MyClass();
            Console.WriteLine(myClass.GetDescription(p => p.HaHa));
            Console.WriteLine(myClass.GetDisplay(p => p.HaHa)?.Name);
            Assert.AreEqual(myClass.GetAttribute<System.ComponentModel.DescriptionAttribute, MyClass>(p => p.HaHa)?.Description, "哈哈");
            Console.WriteLine(myClass.GetFieldDescription(p => p.XiXi));
            Assert.AreEqual(myClass.GetFieldAttribute<System.ComponentModel.DescriptionAttribute, MyClass>(p => p.XiXi)?.Description, "嘻嘻");
        }
        

        [System.ComponentModel.Description("我的Enum")]
        record MyClass
        {
            [System.ComponentModel.Description("哈哈")]
            [System.ComponentModel.DataAnnotations.Display(Name = "哈哈哈哈哈哈")]
            public string HaHa { get; set; }

            [System.ComponentModel.Description("嘻嘻")]
            public string XiXi;
        }
    }
}