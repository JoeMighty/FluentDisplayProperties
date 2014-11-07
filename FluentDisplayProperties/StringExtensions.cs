using System.Text.RegularExpressions;

namespace FluentDisplayProperties
{
    public static class StringExtensions
    {
        public static string ToSeparatedWords(this string value)
        {
            return value != null ? Regex.Replace(value, "([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 ").Trim() : null;
        }
    }
}