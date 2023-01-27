namespace Jones.UnitTest.Types;

public enum RoleType
{
    [System.ComponentModel.Description("系统管理员")]
    Root = 999,
    [System.ComponentModel.Description("管理员")]
    Admin = 99,
    [System.ComponentModel.Description("用户")]
    User = 11
}