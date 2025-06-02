using System.Collections.Generic;
using System.Text.Json;
using ShapeLib.Shapes;
using ShapeLib.Utilities;

namespace ShapeLib.Parsers
{
    public class ShapeParser : IShapeParser
    {
        public List<Shape> Parse(string input)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new ShapeConverter() },
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
            };
            
            return JsonSerializer.Deserialize<List<Shape>>(ShapeTextConverter.ToJson(input), options);
        }
    }
}
