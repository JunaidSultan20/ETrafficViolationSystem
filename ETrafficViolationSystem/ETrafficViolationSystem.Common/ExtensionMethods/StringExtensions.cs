using System;

namespace ETrafficViolationSystem.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            if (value is null or " " or "")
                return true;
            return false;
        }
    }
}