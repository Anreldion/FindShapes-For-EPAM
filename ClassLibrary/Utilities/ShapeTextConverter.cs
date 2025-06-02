using System.Linq;
using System.Text.RegularExpressions;

namespace ShapeLib.Utilities
{
    public static class ShapeTextConverter
    {
        public static string ToJson(string input)
        {
            var output = RemoveWhiteSpace(input);
            output = ReplaceSemicolonsWithCommas(output);
            output = AddCommaBetweenObjects(output);
            output = QuoteTypeValues(output);

            return $"[{output}]";
        }

        private static string RemoveWhiteSpace(string input) => new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        private static string ReplaceSemicolonsWithCommas(string text) => text.Replace(";", ",");

        private static string AddCommaBetweenObjects(string input)
        {
            var objects = Regex.Matches(input, @"\{.*?\}")
                .Cast<Match>().Select(m => m.Value.Trim());

            return string.Join(",", objects);
        }
        private static string QuoteTypeValues(string input) =>
            Regex.Replace(input, @"(?<=""type"":)(trapezoid|circle|rectangle|square|triangle)(?=,|\})", "\"$1\"");
    }
}