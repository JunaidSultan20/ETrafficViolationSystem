using System.ComponentModel;

namespace ETrafficViolationSystem.Common.Enumerators
{
    public enum Roles
    {
        [Description("Admin")]
        Admin = 1,
        [Description("User")]
        User,
        [Description("Officer")]
        Officer,
        [Description("SuperAdmin")]
        SuperAdmin
    }
}