using Find.Services.Interfaces;
using Find.ViewModels;
using Moq;
using NUnit.Framework;
using ShapeLib.Calculators;
using ShapeLib.Generators;
using ShapeLib.Parsers;

namespace Find.Tests.ViewModels;

[TestFixture]
[TestOf(typeof(MainWindowViewModel))]
public class MainWindowViewModelTest
{
    private MainWindowViewModel _vm;
    private Mock<IShapeTextGenerator> _mockShapeTextGenerator;
    private Mock<IFileDialogService> _mockFileDialogService;
    private Mock<IShapeCalculator> _mockShapeCalculator;
    private Mock<IFileService> _mockFileService;
    private Mock<IShapeParser> _mockShapeParser;
    private Mock<IWindowService> _mockWindowService;
    private Mock<IDialogService> _mockDialogService;
    private Mock<IAppCloser> _mockAppCloser;
    private Mock<IFolderService> _mockFolderService;

    [SetUp]
    public void SetUp()
    {
        _mockShapeTextGenerator = new Mock<IShapeTextGenerator>();
        _mockFileDialogService = new Mock<IFileDialogService>();
        _mockShapeCalculator = new Mock<IShapeCalculator>();
        _mockFileService = new Mock<IFileService>();
        _mockShapeParser = new Mock<IShapeParser>();
        _mockWindowService = new Mock<IWindowService>();
        _mockDialogService = new Mock<IDialogService>();
        _mockAppCloser = new Mock<IAppCloser>();
        _mockFolderService = new Mock<IFolderService>();
        _mockFolderService.Setup(f => f.CreateFolderInBaseDirectory(It.IsAny<string>()))
            .Returns("C:\\fakefolder");
        _vm = new MainWindowViewModel(
            _mockShapeCalculator.Object,
            _mockShapeParser.Object,
            _mockShapeTextGenerator.Object,
            _mockFileDialogService.Object,
            _mockFileService.Object,
            _mockFolderService.Object,
            _mockWindowService.Object,
            _mockDialogService.Object,
            _mockAppCloser.Object
        );
    }

    [TestCase("rectangle", "rectangle shape")]
    [TestCase("circle", "circle shape")]
    [TestCase("square", "square shape")]
    [TestCase("trapezoid", "trapezoid shape")]
    [TestCase("triangle", "triangle shape")]
    public void AddShapeCommand_ShouldAppendGeneratedText(string shapeType, string expectedText)
    {
        // Arrange
        _mockShapeTextGenerator.Setup(g => g.Generate(shapeType)).Returns(expectedText);

        // Act
        switch (shapeType)
        {
            case "rectangle": _vm.AddRectangleCommand.Execute(null); break;
            case "circle": _vm.AddCircleCommand.Execute(null); break;
            case "square": _vm.AddSquareCommand.Execute(null); break;
            case "trapezoid": _vm.AddTrapezoidCommand.Execute(null); break;
            case "triangle": _vm.AddTriangleCommand.Execute(null); break;
        }

        // Assert
        Assert.That(_vm.PlainText.Trim(), Is.EqualTo(expectedText));
    }

    [Test]
    public void CloseApp_ShouldCallAppCloser_WhenNoUnsavedChanges()
    {
        _vm.HasUnsavedChanges = false;

        _vm.CloseAppCommand.Execute(null);

        _mockAppCloser.Verify(a => a.Close(), Times.Once);
    }

    [Test]
    public void Clear_ShouldBeCleared()
    {
        _vm.PlainText = "some shapes";
        _vm.AveragePerimeter = "123";
        _vm.AverageArea = "456";
        _vm.LargestAreaShape = "circle (999)";
        _vm.ShapeWithMaxAveragePerimeter = "square (888)";

        _vm.ClearCommand.Execute(null);

        Assert.That(_vm.PlainText, Is.Empty);
        Assert.That(_vm.AveragePerimeter, Is.EqualTo("0"));
        Assert.That(_vm.AverageArea, Is.EqualTo("0"));
        Assert.That(_vm.LargestAreaShape, Is.EqualTo("0"));
        Assert.That(_vm.ShapeWithMaxAveragePerimeter, Is.EqualTo("0"));

    }
}