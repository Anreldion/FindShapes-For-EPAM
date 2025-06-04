using ShapeLib.Shapes;

namespace Find.Tests.Calculators;

public class ShapeStub(string name, double area, double perimeter) : Shape
{
    public override string Name => name;
    public override double GetArea() => area;
    public override double GetPerimeter() => perimeter;
}