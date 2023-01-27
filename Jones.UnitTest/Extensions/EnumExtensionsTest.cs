using Jones.Extensions;
using Jones.UnitTest.Types;

namespace Jones.UnitTest.Extensions;

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

    [Test]
    public void TestToRoleString()
    {
        var roleString = new[] {RoleType.Root, RoleType.Admin}.ToRoleString();
            
        Assert.AreEqual(roleString, "Root,Admin");
    }
}