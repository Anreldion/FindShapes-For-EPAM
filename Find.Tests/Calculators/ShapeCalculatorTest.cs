using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapeLib.Calculators;
using ShapeLib.Shapes;

namespace Find.Tests.Calculators;

[TestFixture]
[TestOf(typeof(ShapeCalculator))]
public class ShapeCalculatorTest
{
    private ShapeCalculator _calculator;
    [SetUp]
    public void SetUp()
    {
        _calculator = new ShapeCalculator();
    }

    [Test]
    public void GetLargestAreaShape_ShouldReturnShapeWithMaxArea()
    {
        var shapes = new List<Shape>
        {
            new ShapeStub("a", 10, 20),
            new ShapeStub("b", 25, 40),
            new ShapeStub("c", 15, 30)
        };

        var result = _calculator.GetLargestAreaShape(shapes);

        Assert.That(result.GetArea(), Is.EqualTo(25));
    }

    [Test]
    public void GetAveragePerimeter_ShouldReturnCorrectAverage()
    {
        var shapes = new List<Shape>
        {
            new ShapeStub("x", 1, 10),
            new ShapeStub("y", 2, 20),
            new ShapeStub("z", 3, 30)
        };

        var result = _calculator.GetAveragePerimeter(shapes);

        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void GetAreaSum_ShouldReturnTotalArea()
    {
        var shapes = new List<Shape>
        {
            new ShapeStub("x", 5, 10),
            new ShapeStub("y", 15, 20)
        };

        var result = _calculator.GetAreaSum(shapes);

        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void GetShapeWithMaxAveragePerimeter_ShouldReturnCorrectType()
    {
        var shapes = new List<Shape>
        {
            new ShapeStub("circle", 100, 10),
            new ShapeStub("circle", 200, 20),
            new ShapeStub("square", 400, 40),
            new ShapeStub("square", 500, 60)
        };

        var result = _calculator.GetShapeWithMaxAveragePerimeter(shapes);

        Assert.That(result.Key, Is.EqualTo("square"));
        Assert.That(result.Value, Is.EqualTo(50));
    }
    [Test]
    public void AllMethods_ShouldThrowArgumentNullException_WhenInputIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _calculator.GetLargestAreaShape(null));
        Assert.Throws<ArgumentNullException>(() => _calculator.GetAveragePerimeter(null));
        Assert.Throws<ArgumentNullException>(() => _calculator.GetAreaSum(null));
        Assert.Throws<ArgumentNullException>(() => _calculator.GetShapeWithMaxAveragePerimeter(null));
    }

    [Test]
    public void MethodsThatRequireElements_ShouldThrowInvalidOperationException_WhenEmpty()
    {
        var empty = new List<Shape>();

        Assert.Throws<InvalidOperationException>(() => _calculator.GetLargestAreaShape(empty));
        Assert.Throws<InvalidOperationException>(() => _calculator.GetAveragePerimeter(empty));
        Assert.Throws<InvalidOperationException>(() => _calculator.GetShapeWithMaxAveragePerimeter(empty));
    }
}