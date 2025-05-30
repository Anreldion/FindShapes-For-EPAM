/*using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class ShapeTests
    {

        //*********************************************************************************
        // RECTANGLE CLASS TESTS
        //*********************************************************************************
        [TestMethod]
        public void Rectangle_PerimeterCalculateTest()
        {
            // arrange
            double width = 10;
            double height = 20;
            double expected = 60;

            // act
            var Rectangle = new Rectangle();

            var actual = Rectangle.GetPerimeter();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Rectangle_AreaCalculateTest()
        {
            // arrange
            double width = 10;
            double height = 20;
            double expected = 200;

            // act
            var Rectangle = new Rectangle();

            var actual = Rectangle.GetArea(width, height);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Rectangle_ParceParametersTest()
        {
            // arrange
            var parameters = new string[]
            {
                "\"type\":rectangle",
                "\"width\":10",
                "\"height\":20",
            };
            double expectedPerimeter = 60;

            // act
            var Rectangle = new Rectangle();
            Rectangle.ParseParameters(parameters);

            var actual = Rectangle.Perimeter;
            // assert
            Assert.AreEqual(expectedPerimeter, actual);
        }

        //*********************************************************************************
        // SQUARE CLASS TESTS
        //*********************************************************************************
        [TestMethod]
        public void Square_AreaCalculateTest()
        {
            // arrange
            double side = 10;
            double expected = 100;

            // act
            var Square = new Square();

            var actual = Square.GetArea(side);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Square_PerimeterCalculateTest()
        {
            // arrange
            double side = 10;
            double expected = 40;

            // act
            var Square = new Square();

            var actual = Square.GetPerimeter(side);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Square_ParseParametersTest()
        {
            // arrange
            var parameters = new string[]
            {
                "\"type\":square",
                "\"side\":10",
            };
            double expectedPerimeter = 40;

            // act
            var item = new Square();
            item.ParseParameters(parameters);

            var actual = item.Perimeter;
            // assert
            Assert.AreEqual(expectedPerimeter, actual);
        }
        //*********************************************************************************
        // CIRCLE CLASS TESTS
        //*********************************************************************************
        [TestMethod]
        public void Circle_AreaCalculateTest()
        {
            // arrange
            double radius = 10;
            var expected = (int)(314.15926 * 100.0); //убираем дробную часть

            // act
            var item = new Circle();

            var actual_double = item.AreaCalculate(radius);
            var actual = (int)(actual_double * 100.0); //убираем дробную часть
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Circle_PerimeterCalculateTest()
        {
            // arrange
            double radius = 10;
            var expected = (int)(62.83184 * 100.0); //убираем дробную часть

            // act
            var item = new Circle();

            var actual_double = item.PerimeterCalculate(radius);
            var actual = (int)(actual_double * 100.0); //убираем дробную часть
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Сircle_ParceParametersTest()
        {
            // arrange
            var parameters = new string[]
            {
                "\"type\":circle",
                "\"radius\":10",
            };
            var expectedPerimeter = (int)(62.83184 * 100.0); //убираем дробную часть

            // act
            var item = new Circle();
            item.ParseParameters(parameters);

            var actual_double = item.Perimeter;
            var actual = (int)(actual_double * 100.0); //убираем дробную часть
            // assert
            Assert.AreEqual(expectedPerimeter, actual);
        }
        //*********************************************************************************
        // TRAPEZOID CLASS TESTS
        //*********************************************************************************
        [TestMethod]
        public void Trapezoid_AreaCalculateTest()
        {
            // arrange
            //  __b__
            //a/_____\ c
            //    d
            double sideA = 1;
            double sideB = 2;
            double sideC = 1;
            double sideD = 3;
            var expected = (int)(2.16506 * 100.0);

            // act
            var item = new Trapezoid();
            
            var actual_double = item.GetArea(sideA, sideB, sideC, sideD);
            var actual = (int)(actual_double * 100.0); 
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Trapezoid_PerimeterCalculateTest()
        {
            // arrange
            double sideA = 2;
            double sideB = 3;
            double sideC = 1;
            double sideD = 1;
            double expected = 7;

            // act
            var item = new Trapezoid();

            var actual = item.GetPerimeter(sideA, sideB, sideC, sideD);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Trapezoid_ParseParametersTest()
        {
            // arrange
            var parameters = new string[]
            {
                "\"type\":trapezoid",
                "\"side_a\":2",
                "\"side_b\":3",
                "\"side_c\":1",
                "\"side_d\":1",
            };
            double expectedPerimeter = 7;

            // act
            var item = new Trapezoid();
            item.ParseParameters(parameters);

            var actual = item.Perimeter;
            // assert
            Assert.AreEqual(expectedPerimeter, actual);
        }
        //*********************************************************************************
        // TRIANGLE CLASS TESTS
        //*********************************************************************************
        [TestMethod]
        public void Triangle_AreaCalculateTest()
        {
            // arrange
            double sideA = 2;
            double sideB = 2;
            double sideC = 2;
            var expected = (int)(1.73 * 100.0); //убираем дробную часть

            // act
            var item = new Triangle();

            var actual_double = item.AreaCalculate(sideA, sideB, sideC);
            var actual= (int)(actual_double * 100.0); //убираем дробную часть
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Triangle_PerimeterCalculateTest()
        {
            // arrange
            double sideA = 2;
            double sideB = 2;
            double sideC = 2;
            double expected = 6;

            // act
            var item = new Triangle();

            var actual = item.PerimeterCalculate(sideA, sideB, sideC);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Triangle_ParseParametersTest()
        {
            // arrange
            var parameters = new string[]
            {
                "\"type\":triangle",
                "\"side_a\":2",
                "\"side_b\":2",
                "\"side_c\":2",
            };
            double expectedPerimeter = 6;

            // act
            var item = new Triangle();
            item.ParseParameters(parameters);

            var actual = item.Perimeter;
            // assert
            Assert.AreEqual(expectedPerimeter, actual);
        }
    }
}
*/