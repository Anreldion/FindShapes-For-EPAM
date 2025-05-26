namespace ShapeLib.Shapes
{
    public class Square : Shape
    {
        public override string Name => "square";

        public double Side { get; set; }

        public Square()
        {
        }

        public Square(double side)
        {
            Side = side;
        }
        
        public override double GetArea()
        {
            var area = Side * Side;
            return area;
        }

        public override double GetPerimeter()
        {
            var perimeter = Side * 4;
            return perimeter;
        }
    }
}
