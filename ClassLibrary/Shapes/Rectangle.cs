namespace ShapeLib.Shapes
{
    public class Rectangle : Shape
    {
        public override string Name => "rectangle";
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;

        public override double GetPerimeter() => 2 * (Width + Height);
    }
}
