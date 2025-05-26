using System.Collections.Generic;
using ShapeLib.Shapes;

namespace ShapeLib.Parsers
{
    public interface IShapeParser
    {
        List<Shape> Parse(string input);
    }
}
