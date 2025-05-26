using System.Linq;

namespace ShapeLib.Utilities
{
    public static class ShapeTextConverter
    {
        public static string ToJson(string input)
        {
            var output = RemoveWhiteSpace(input);
            output = AddCommaInTheEnd(output);
            output = ReplaceCommaToSemicolon(output);
            output = TypeToQuotations(output);
            output = AddSquareBrackets(output);
            output = RemoveLastComma(output);
            return output;
        }

        private static string AddSquareBrackets(string text) => $"[{text}]";

        private static string TypeToQuotations(string text) => text.Replace("trapezoid", "\"trapezoid\"")
            .Replace("circle", "\"circle\"")
            .Replace("rectangle", "\"rectangle\"")
            .Replace("square", "\"square\"")
            .Replace("triangle", "\"triangle\"");

        private static string ReplaceCommaToSemicolon(string text) => text.Replace(";", ",");

        private static string RemoveWhiteSpace(string input) => new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());

        private static string AddCommaInTheEnd(string input) => input.Replace(";}", "},");

        private static string RemoveLastComma(string input) => input.Replace("},]", "}]");

    }
}