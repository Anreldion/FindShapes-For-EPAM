using System;

namespace ShapeLib.Generators
{
    public class ShapeTextGenerator : IShapeTextGenerator
    {
        public string Generate(string shapeType)
        {
            return shapeType switch
            {
                "triangle" => @"{ 
""type"" : triangle;
""side_a"" : 1;
""side_b"" : 1;
""side_c"" : 1;
}",
                "trapezoid"=> @"{
""type"" : trapezoid;
""side_a"" : 1;
""side_b"" : 2;
""side_c"" : 1;
""side_d"" : 3;
}",
                "square" => @"{
""type"" : square;
""side"" : 2;
}",
                "circle"=> @"{
""type"" : circle;
""radius"" : 10;
}",
                "rectangle"=> @"{
""type"" : rectangle;
""width"" : 1;
""height"" : 1;
}",
                _=> throw new ArgumentException("Unknown shape type")
            };
        }
    }
}
