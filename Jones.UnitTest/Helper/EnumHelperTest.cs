using System.Linq;
using Jones.Helper;
using NUnit.Framework;

namespace Jones.UnitTest.Helper
{
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
        
        public enum RoleType
        {
            [System.ComponentModel.Description("系统管理员")]
            Root = 999,
            [System.ComponentModel.Description("管理员")]
            Admin = 99,
            [System.ComponentModel.Description("用户")]
            User = 11
        }
    }
}