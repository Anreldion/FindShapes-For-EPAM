using System;

namespace ShapeLib.Shapes
{
    public class Circle : Shape
    {
        public override string Name => "circle";

        public double Radius { get; set; }

        public Circle()
        {
        }
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * (Radius * Radius);
        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }
}
