using NUnit.Framework;
using ShapeLib.Shapes;

namespace Find.Tests.Shapes;

[TestFixture]
[TestOf(typeof(Rectangle))]
public class RectangleTest
{
    [Test]
    public void Name_ShouldBeRectangle()
    {
        var shape = new Rectangle(1, 1);
        Assert.That(shape.Name, Is.EqualTo("rectangle"));
    }

    [Test]
    public void DefaultConstructor_ShouldSetZeroes()
    {
        var shape = new Rectangle();

        Assert.That(shape.Width, Is.EqualTo(0));
        Assert.That(shape.Height, Is.EqualTo(0));
        Assert.That(shape.GetArea(), Is.EqualTo(0));
        Assert.That(shape.GetPerimeter(), Is.EqualTo(0));
    }

    [TestCase(10, 10, 100)]
    [TestCase(10, 20, 200)]
    [TestCase(10, 30, 300)]
    public void GetArea_ShouldReturnCorrectValue(double width, double height, double expected)
    {
        var shape = new Rectangle(width, height);

        Assert.That(shape.GetArea(), Is.EqualTo(expected));
    }

    [TestCase(10, 10, 40)]
    [TestCase(10, 20, 60)]
    [TestCase(10, 30, 80)]
    public void GetPerimeter_ShouldReturnCorrectValue(double width, double height, double expected)
    {
        var shape = new Rectangle(width, height);
        Assert.That(shape.GetPerimeter(), Is.EqualTo(expected));
    }
}