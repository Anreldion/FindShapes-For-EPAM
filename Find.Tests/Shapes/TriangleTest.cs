using NUnit.Framework;
using ShapeLib.Shapes;

namespace Find.Tests.Shapes;

[TestFixture]
[TestOf(typeof(Triangle))]
public class TriangleTest
{

    [Test]
    public void Name_ShouldBeTriangle()
    {
        var shape = new Triangle(3, 4, 5);
        Assert.That(shape.Name, Is.EqualTo("triangle"));
    }

    [Test]
    public void DefaultConstructor_ShouldSetZeroes()
    {
        var shape = new Triangle();

        Assert.That(shape.Side_a, Is.EqualTo(0));
        Assert.That(shape.Side_b, Is.EqualTo(0));
        Assert.That(shape.Side_c, Is.EqualTo(0));
        Assert.That(shape.GetPerimeter(), Is.EqualTo(0));
        Assert.That(shape.GetArea(), Is.EqualTo(0));
    }

    [TestCase(3, 4, 5, 12)] 
    [TestCase(5, 5, 5, 15)] 
    [TestCase(10, 6, 8, 24)]
    public void GetPerimeter_ShouldReturnCorrectValue(double a, double b, double c, double expected)
    {
        var shape = new Triangle(a, b, c);

        Assert.That(shape.GetPerimeter(), Is.EqualTo(expected));
    }

    [TestCase(3, 4, 5, 6.0)]
    [TestCase(5, 5, 5, 10.825)]  
    [TestCase(10, 6, 8, 24.0)]   
    public void GetArea_ShouldReturnCorrectValue(double a, double b, double c, double expected)
    {
        var shape = new Triangle(a, b, c);

        var actual = shape.GetArea();

        Assert.That(actual, Is.EqualTo(expected).Within(0.01));
    }

    [Test]
    public void GetArea_ShouldReturnZero_WhenTriangleIsInvalid()
    {
        var shape = new Triangle(1, 1, 5); 

        var area = shape.GetArea();

        Assert.That(area, Is.EqualTo(0));
    }
}