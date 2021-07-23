namespace ETrafficViolationSystem.Common.Helpers
{
    public static class HelperMethods
    {
        public static string NullOrEmptyCheck(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return null;
            return value;
        }

        public static int NullCheckInteger(int? number)
        {
            if (number.HasValue)
                return number.Value;
            return -1;
        }

        public static double NullCheckDouble(double? number)
        {
            if (number.HasValue)
                return number.Value;
            return -1;
        }

        public static decimal NullCheckDecimal(decimal? number)
        {
            if (number.HasValue)
                return number.Value;
            return -1;
        }

        public static short NullCheckShort(short? number)
        {
            if (number.HasValue)
                return number.Value;
            return -1;
        }
    }
}