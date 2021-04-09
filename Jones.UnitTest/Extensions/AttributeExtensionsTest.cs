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
            var myClass = new MyClass2();
            Console.WriteLine(myClass.GetDescription(p => p.HaHa));
            Console.WriteLine(myClass.GetDisplayName(p => p.HaHa));
            Console.WriteLine(myClass.GetDisplayName(p => p.HeHe));
            Assert.AreEqual(myClass.GetAttribute<System.ComponentModel.DescriptionAttribute, MyClass>(p => p.HaHa)?.Description, "哈哈");
            Console.WriteLine(myClass.GetFieldDescription(p => p.XiXi));
            Assert.AreEqual(myClass.GetFieldAttribute<System.ComponentModel.DescriptionAttribute, MyClass>(p => p.XiXi)?.Description, "嘻嘻");
        }
        

        [System.ComponentModel.Description("我的Enum")]
        record MyClass
        {
            [System.ComponentModel.Description("哈哈")]
            [System.ComponentModel.DataAnnotations.Display(Name = "哈哈哈哈哈哈")]
            public int HaHa { get; set; }

            [System.ComponentModel.Description("嘻嘻")]
            public string XiXi;
        }
        

        [System.ComponentModel.Description("我的Enum")]
        record MyClass2 : MyClass
        {
            [System.ComponentModel.Description("呵呵")]
            [System.ComponentModel.DataAnnotations.Display(Name = "呵呵呵呵呵呵")]
            public string HeHe { get; set; } = "hehehe";
        }
    }
}