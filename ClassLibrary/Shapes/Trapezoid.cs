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

        public override double GetArea()
        {
            //              _______b_______
            //             /               \ 
            //          a /                 \ c
            //           /___________________\
            //                  d
            //               __________________________________________
            // S =  b+d     / a^2     -    ((d-b)^2 + a^2 - c^2  ) ^2
            //       2    _/               (       2(d-b)        )
            //
            var area = (Side_b + Side_d) / 2.0 * Math.Sqrt(Math.Pow(Side_a, 2) - Math.Pow((Math.Pow(Side_d - Side_b, 2) + Math.Pow(Side_a, 2) - Math.Pow(Side_c, 2)) / (2 * (Side_d - Side_b)), 2));
            return double.IsNaN(area) ? 0 : area;
        }

        public override double GetPerimeter() => Side_a + Side_b + Side_c + Side_d;
    }
}
