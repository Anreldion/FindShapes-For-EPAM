using NUnit.Framework;
using ShapeLib.Shapes;

namespace Find.Tests.Shapes;

[TestFixture]
[TestOf(typeof(Trapezoid))]
public class TrapezoidTest
{

    [Test]
    public void Name_ShouldBeTrapezoid()
    {
        var shape = new Trapezoid(1, 1, 1, 1);
        Assert.That(shape.Name, Is.EqualTo("trapezoid"));
    }

    [Test]
    public void DefaultConstructor_ShouldSetZeroes()
    {
        var shape = new Trapezoid();

        Assert.That(shape.Side_a, Is.EqualTo(0));
        Assert.That(shape.Side_b, Is.EqualTo(0));
        Assert.That(shape.Side_c, Is.EqualTo(0));
        Assert.That(shape.Side_d, Is.EqualTo(0));
        Assert.That(shape.GetPerimeter(), Is.EqualTo(0));
        Assert.That(shape.GetArea(), Is.EqualTo(0)); 
    }

    [TestCase(1, 2, 1, 3, 7)]
    [TestCase(5, 6, 7, 8, 26)]
    [TestCase(10, 10, 10, 10, 40)]
    public void GetPerimeter_ShouldReturnCorrectValue(double a, double b, double c, double d, double expected)
    {
        var shape = new Trapezoid(a, b, c, d);

        Assert.That(shape.GetPerimeter(), Is.EqualTo(expected));
    }

    
    [Test]
    public void GetArea_ShouldReturnExpected_ForKnownValidTrapezoid()
    {
        var shape = new Trapezoid(5, 10, 5, 6);

        var area = shape.GetArea();

        Assert.That(area, Is.EqualTo(36.66).Within(0.01));
    }

    [Test]
    public void GetArea_ShouldReturnZero_WhenImpossibleGeometry()
    {
        var shape = new Trapezoid(1, 1, 1, 1); 

        Assert.That(shape.GetArea(), Is.EqualTo(0));
    }
}