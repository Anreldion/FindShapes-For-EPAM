using System.Collections.Generic;
using System.Linq;
using ShapeLib.Shapes;
using ShapeLib.Utilities;

namespace ShapeLib.Calculators
{
    /// <summary>
    /// Provides geometric calculations for collections of shapes.
    /// </summary>
    public class ShapeCalculator : IShapeCalculator
    {
        public Shape GetLargestAreaShape(IEnumerable<Shape> list)
        {
            Guard.NotNull(list, nameof(list));
            Guard.NotEmpty(list, nameof(list));

            return list.OrderByDescending(s => s.GetArea()).First();
        }

        public double GetAveragePerimeter(IEnumerable<Shape> list)
        {
            Guard.NotNull(list, nameof(list));
            Guard.NotEmpty(list, nameof(list));

            return list.Average(s => s.GetPerimeter());
        }

        public double GetAreaSum(IEnumerable<Shape> list)
        {
            Guard.NotNull(list, nameof(list));

            return list.Sum(s => s.GetArea());
        }

        public KeyValuePair<string, double> GetShapeWithMaxAveragePerimeter(IEnumerable<Shape> list)
        {
            Guard.NotNull(list, nameof(list));
            Guard.NotEmpty(list, nameof(list));

            return list
                .GroupBy(s => s.Name)
                .Select(g => new KeyValuePair<string, double>(g.Key, g.Average(s => s.GetPerimeter())))
                .OrderByDescending(kvp => kvp.Value)
                .First();
        }
    }
}
