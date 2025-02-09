using System.Text.RegularExpressions;

namespace Mbzuh.Assessment.BookService.Application.Common.Extensions;

public static class StringExtensions
{
    public static string SanitizeSpaces(this string str)
    {
        return string.IsNullOrEmpty(str) ? str : Regex.Replace(str, @"\s+", " ").Trim();
    }
}
