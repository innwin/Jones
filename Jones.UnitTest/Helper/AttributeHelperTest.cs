using System.ComponentModel.DataAnnotations;
using Jones.Helper;

namespace Jones.UnitTest.Helper;

public class AttributeHelperTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestGetDisplayName()
    {
        Console.WriteLine(AttributeHelper.GetDisplayName<MyClass>(p => p.HaHa));
        Assert.AreEqual(AttributeHelper.GetDisplayName<MyClass>(p => p.HaHa), "哈哈哈哈哈哈");
    }
        

    [System.ComponentModel.Description("我的Enum")]
    record MyClass
    {
        [System.ComponentModel.Description("哈哈")]
        [Display(Name = "哈哈哈哈哈哈")]
        public int HaHa { get; set; }

        [System.ComponentModel.Description("嘻嘻")]
        public string XiXi;
            
        [Required]
        public string Name { get; set; }
            
        public string? ShortName { get; set; }
    }
}