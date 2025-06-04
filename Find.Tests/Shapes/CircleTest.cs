using NUnit.Framework;
using ShapeLib.Shapes;
using System;

namespace Find.Tests.Shapes;

[TestFixture]
[TestOf(typeof(Circle))]
public class CircleTest
{

    [Test]
    public void Name_ShouldBeCircle()
    {
        var shape = new Circle(1);
        Assert.That(shape.Name, Is.EqualTo("circle"));
    }

    [Test]
    public void DefaultConstructor_ShouldSetZeroes()
    {
        var shape = new Circle();

        Assert.That(shape.Radius, Is.EqualTo(0));
        Assert.That(shape.GetArea(), Is.EqualTo(0));
        Assert.That(shape.GetPerimeter(), Is.EqualTo(0));
    }

    [TestCase(0, 0)]
    [TestCase(1, Math.PI)]                 
    [TestCase(2, 4 * Math.PI)]             
    [TestCase(10, 100 * Math.PI)]
    public void GetArea_ShouldReturnCorrectValue(double radius, double expected)
    {
        var shape = new Circle(radius);

        Assert.That(shape.GetArea(), Is.EqualTo(expected).Within(0.001));
    }

    [TestCase(0, 0)]
    [TestCase(1, 2 * Math.PI)]             
    [TestCase(2, 4 * Math.PI)]             
    [TestCase(10, 20 * Math.PI)]
    public void GetPerimeter_ShouldReturnCorrectValue(double radius, double expected)
    {
        var shape = new Circle(radius);

        Assert.That(shape.GetPerimeter(), Is.EqualTo(expected).Within(0.001));
    }
}