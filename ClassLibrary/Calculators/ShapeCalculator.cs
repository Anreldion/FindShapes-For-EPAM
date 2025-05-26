using System;
using System.Collections.Generic;
using System.Linq;
using ShapeLib.Shapes;

namespace ShapeLib.Calculators
{
    public class ShapeCalculator : IShapeCalculator
    {
        public Shape GetLargestAreaShape(IEnumerable<Shape> list)
        {
            var shape = list.FirstOrDefault();
            if (shape == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in list)
            {
                if (shape.GetPerimeter() < item.GetPerimeter())
                {
                    shape = item;
                }
            }
            return shape;
        }

        public double GetAveragePerimeter(IEnumerable<Shape> list)
        {
            double perimeter = 0;
            foreach (var item in list)
            {
                perimeter += item.GetPerimeter();
            }
            return perimeter / list.Count();
        }

        public double GetAreaSum(IEnumerable<Shape> list)
        {
            double area = 0;
            foreach (var item in list)
            {
                area += item.GetArea();
            }
            return area;
        }

        public KeyValuePair<string, double> GetShapeWithMaxAveragePerimeter(IEnumerable<Shape> list)
        {
            var shapes = new Dictionary<string, double>();
            foreach (var item in list)
            {
                if (shapes.ContainsKey(item.Name))
                {
                    shapes[item.Name] += item.GetPerimeter();
                }
                else
                {
                    shapes.Add(item.Name, item.GetPerimeter());
                }
            }

            return shapes.Aggregate((l, r) => l.Value > r.Value ? l : r);
        }
    }
}
