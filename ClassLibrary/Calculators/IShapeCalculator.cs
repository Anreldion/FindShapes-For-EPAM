using System.Collections.Generic;
using ShapeLib.Shapes;

namespace ShapeLib.Calculators
{
    public interface IShapeCalculator
    {
        Shape GetLargestAreaShape(IEnumerable<Shape> list);
        double GetAveragePerimeter(IEnumerable<Shape> list);
        double GetAreaSum(IEnumerable<Shape> list);
        KeyValuePair<string, double> GetShapeWithMaxAveragePerimeter(IEnumerable<Shape> list);
    }
}
