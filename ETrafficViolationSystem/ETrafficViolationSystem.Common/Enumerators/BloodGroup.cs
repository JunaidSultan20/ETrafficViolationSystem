using System.ComponentModel;

namespace ETrafficViolationSystem.Common.Enumerators
{
    public enum BloodGroup
    {
        [Description("A+")]
        APositive = 1,

        [Description("A-")]
        ANegative,

        [Description("B+")]
        BPositive,

        [Description("B-")]
        BNegative,

        [Description("O+")]
        OPositive,

        [Description("O-")]
        ONegative,

        [Description("AB+")]
        ABPositive,

        [Description("AB-")]
        ABNegative
    }
}