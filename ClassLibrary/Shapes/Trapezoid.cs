using System;

namespace ShapeLib.Shapes
{
    public class Trapezoid : Shape
    {
        public override string Name => "trapezoid";

        public double Side_a { get; set; }
        public double Side_b { get; set; }
        public double Side_c { get; set; }
        public double Side_d { get; set; }

        public Trapezoid()
        {
        }

        public Trapezoid(double a, double b, double c, double d)
        {
            Side_a = a;
            Side_b = b;
            Side_c = c;
            Side_d = d;
        }

        /// <summary>
        /// Calculates the area of a trapezoid given the lengths of all four sides.
        ///
        /// The formula is derived using the height of the trapezoid based on side lengths:
        /// <code>
        ///       _______b_______
        ///      /               \ 
        ///   a /                 \ c
        ///    /___________________\
        ///              d
        ///
        /// h = √[ a² - (( (d - b)² + a² - c² ) / (2(d - b)) )² ]
        /// Area = (b + d) / 2 × h
        /// </code>
        ///
        /// If the trapezoid is geometrically invalid (e.g., sides cannot form a closed figure or the expression under the square root is negative),
        /// the method returns <c>0</c>.
        /// </summary>
        /// <returns>The area of the trapezoid in square units. Returns <c>0</c> if the shape is invalid.</returns>
        public override double GetArea()
        {
            var area = (Side_b + Side_d) / 2.0 * Math.Sqrt(Math.Pow(Side_a, 2) - Math.Pow((Math.Pow(Side_d - Side_b, 2) + Math.Pow(Side_a, 2) - Math.Pow(Side_c, 2)) / (2 * (Side_d - Side_b)), 2));
            return double.IsNaN(area) ? 0 : area;
        }

        public override double GetPerimeter() => Side_a + Side_b + Side_c + Side_d;
    }
}
