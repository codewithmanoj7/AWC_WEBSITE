using System.Globalization;

namespace AWC.UI.Services.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToLongDateIndianString(this DateTime date)
        {
            CultureInfo inCulture = new("en-IN");
            return date.ToString("f", inCulture);
        }
    }
}
