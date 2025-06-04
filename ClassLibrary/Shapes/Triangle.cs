using System;

namespace ShapeLib.Shapes
{
    public class Triangle : Shape
    {
        public override string Name => "triangle";

        public double Side_a { get; set; }
        public double Side_b { get; set; }
        public double Side_c { get; set; }

        public Triangle()
        {
        }
        public Triangle(double sideA, double sideB, double sideC)
        {
            Side_a = sideA;
            Side_b = sideB;
            Side_c = sideC;
        }

        public override double GetArea()
        {
            var semiPerimeter = (Side_a + Side_b + Side_c) / 2;
            var result = Math.Sqrt(semiPerimeter * (semiPerimeter - Side_a) * (semiPerimeter - Side_b) * (semiPerimeter - Side_c));
            return double.IsNaN(result) ? 0 : result;
        }

        public override double GetPerimeter() => Side_a + Side_b + Side_c;
    }
}
