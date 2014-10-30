using System.Text.RegularExpressions;

namespace FluentDisplayProperties
{
    public static class StringExtensions
    {
        public static string ToSeparatedWords(this string value)
        {
            return value != null ? Regex.Replace(value, "([A-Z][a-z]?)", " $1").Trim() : null;
        }
    }
}