using Jones.Helper;
using Jones.UnitTest.Types;

namespace Jones.UnitTest.Helper;

public class EnumHelperTest
{
    [SetUp]
    public void Setup()
    {
    }
        
    [Test]
    public void TestEnumToArray()
    {
        var roleTypes = EnumHelper.ToEnumerable<RoleType>().ToArray();
        Assert.AreEqual(roleTypes[0], RoleType.User);
        Assert.AreEqual(roleTypes[1], RoleType.Admin);
        Assert.AreEqual(roleTypes[2], RoleType.Root);
    }

    [Test]
    public void TestToRoleString()
    {
        var roleString = EnumHelper.ToRoleString(RoleType.Root, RoleType.Admin);
        Assert.AreEqual(roleString, "Root,Admin");
    }
}