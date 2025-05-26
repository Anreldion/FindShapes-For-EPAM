namespace ShapeLib.Shapes
{
    public abstract class Shape
    {
        public abstract string Name { get; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
