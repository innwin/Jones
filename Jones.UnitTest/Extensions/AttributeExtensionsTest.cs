using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Jones.Extensions;
using NUnit.Framework;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

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
            Assert.AreEqual(myClass.GetAttribute<DescriptionAttribute, MyClass>(p => p.HaHa, false)?.Description, "哈哈");
            Console.WriteLine(myClass.GetFieldDescription(p => p.XiXi));
            Assert.AreEqual(myClass.GetFieldAttribute<DescriptionAttribute, MyClass>(p => p.XiXi, false)?.Description, "嘻嘻");

            Expression<Func<dynamic?>> haha = () => myClass.HaHa;
            Expression<Func<dynamic?>> hehe = () => myClass.HeHe;
            Expression<Func<dynamic?>> xixi = () => myClass.XiXi;
            Console.WriteLine(haha.GetDisplayName());
            Console.WriteLine(haha.GetDisplayName());
            Console.WriteLine(hehe.GetDisplayName());
            Assert.AreEqual(haha.GetAttribute<DescriptionAttribute>(false)?.Description, "哈哈");
            Console.WriteLine(xixi.GetFieldDescription());
            Assert.AreEqual(xixi.GetFieldAttribute<DescriptionAttribute>(false)?.Description, "嘻嘻");
        }

        [Test]
        public void TestIsHasRequiredAttribute()
        {
            var myClass = new MyClass();
            Console.WriteLine(myClass.IsHasRequiredAttribute(p => p.Name));
            Assert.AreEqual(myClass.IsHasRequiredAttribute(p => p.Name), true);
            Console.WriteLine(myClass.IsHasRequiredAttribute(p => p.ShortName));
            Assert.AreEqual(myClass.IsHasRequiredAttribute(p => p.ShortName), false);
        }
        

        [Description("我的Enum")]
        record MyClass
        {
            [Description("哈哈")]
            [Display(Name = "哈哈哈哈哈哈")]
            public int HaHa { get; set; }

            [Description("嘻嘻")]
            public string XiXi;
            
            [Required]
            public string Name { get; set; }
            
            public string? ShortName { get; set; }
        }
        

        [Description("我的Enum")]
        record MyClass2 : MyClass
        {
            [Description("呵呵")]
            [Display(Name = "呵呵呵呵呵呵")]
            public string HeHe { get; set; } = "hehehe";
        }
    }
}