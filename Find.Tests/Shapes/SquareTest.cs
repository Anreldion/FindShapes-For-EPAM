using NUnit.Framework;
using ShapeLib.Shapes;

namespace Find.Tests.Shapes;

[TestFixture]
[TestOf(typeof(Square))]
public class SquareTest
{

    [Test]
    public void Name_ShouldBeSquare()
    {
        var shape = new Square(1);
        Assert.That(shape.Name, Is.EqualTo("square"));
    }

    [Test]
    public void DefaultConstructor_ShouldSetZeroes()
    {
        var shape = new Square();

        Assert.That(shape.Side, Is.EqualTo(0));
        Assert.That(shape.GetArea(), Is.EqualTo(0));
        Assert.That(shape.GetPerimeter(), Is.EqualTo(0));
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 4)]
    [TestCase(10, 100)]
    public void GetArea_ShouldReturnCorrectValue(double side, double expected)
    {
        var shape = new Square(side);

        Assert.That(shape.GetArea(), Is.EqualTo(expected));
    }

    [TestCase(0, 0)]
    [TestCase(1, 4)]
    [TestCase(2, 8)]
    [TestCase(10, 40)]
    public void GetPerimeter_ShouldReturnCorrectValue(double side, double expected)
    {
        var shape = new Square(side);

        Assert.That(shape.GetPerimeter(), Is.EqualTo(expected));
    }
}