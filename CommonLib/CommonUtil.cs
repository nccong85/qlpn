using System;
using System.Globalization;

namespace CommonLib
{
    public static class CommonUtil
    {
        public static DateTime ConvertStringToDateTime(string input, string format)
        {
            return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        }
    }
}
