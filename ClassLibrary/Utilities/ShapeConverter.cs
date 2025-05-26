using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShapeLib.Shapes;

namespace ShapeLib.Utilities
{
    public class ShapeConverter : JsonConverter<Shape>
    {
        public override Shape Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var root = jsonDoc.RootElement;
            var type = root.GetProperty("type").GetString()?.ToLowerInvariant();

            return type switch
            {
                "trapezoid" => JsonSerializer.Deserialize<Trapezoid>(root.GetRawText(), options),
                "circle" => JsonSerializer.Deserialize<Circle>(root.GetRawText(), options),
                "rectangle" => JsonSerializer.Deserialize<Rectangle>(root.GetRawText(), options),
                "square" => JsonSerializer.Deserialize<Square>(root.GetRawText(), options),
                "triangle" => JsonSerializer.Deserialize<Triangle>(root.GetRawText(), options),
                _ => throw new NotSupportedException($"Unknown shape type: {type}")
            };
        }

        public override void Write(Utf8JsonWriter writer, Shape value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
