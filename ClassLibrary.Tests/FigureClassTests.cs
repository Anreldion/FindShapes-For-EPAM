using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class FigureClassTests
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
            RectangleClass Rectangle = new RectangleClass();

            double actual = Rectangle.PerimeterCalculate(width, height);
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
            RectangleClass Rectangle = new RectangleClass();

            double actual = Rectangle.AreaCalculate(width, height);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Rectangle_ParceParametersTest()
        {
            // arrange
            string[] parameters = new string[]
            {
                "\"type\":rectangle",
                "\"width\":10",
                "\"height\":20",
            };
            double expectedPerimeter = 60;

            // act
            RectangleClass Rectangle = new RectangleClass();
            Rectangle.ParceParameters(parameters);

            double actual = Rectangle.PerimeterGet();
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
            SquareClass Square = new SquareClass();

            double actual = Square.AreaCalculate(side);
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
            SquareClass Square = new SquareClass();

            double actual = Square.PerimeterCalculate(side);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Square_ParceParametersTest()
        {
            // arrange
            string[] parameters = new string[]
            {
                "\"type\":square",
                "\"side\":10",
            };
            double expectedPerimeter = 40;

            // act
            SquareClass item = new SquareClass();
            item.ParceParameters(parameters);

            double actual = item.PerimeterGet();
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
            int expected = (int)(314.15926 * 100.0); //убираем дробную часть

            // act
            СircleClass item = new СircleClass();

            double actual_double = item.AreaCalculate(radius);
            int actual = (int)(actual_double * 100.0); //убираем дробную часть
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Circle_PerimeterCalculateTest()
        {
            // arrange
            double radius = 10;
            int expected = (int)(62.83184 * 100.0); //убираем дробную часть

            // act
            СircleClass item = new СircleClass();

            double actual_double = item.PerimeterCalculate(radius);
            int actual = (int)(actual_double * 100.0); //убираем дробную часть
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Сircle_ParceParametersTest()
        {
            // arrange
            string[] parameters = new string[]
            {
                "\"type\":circle",
                "\"radius\":10",
            };
            int expectedPerimeter = (int)(62.83184 * 100.0); //убираем дробную часть

            // act
            СircleClass item = new СircleClass();
            item.ParceParameters(parameters);

            double actual_double = item.PerimeterGet();
            int actual = (int)(actual_double * 100.0); //убираем дробную часть
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
            int expected = (int)(2.16506 * 100.0); //убираем дробную часть

            // act
            TrapezoidClass item = new TrapezoidClass();
            
            double actual_double = item.AreaCalculate(sideA, sideB, sideC, sideD);
            int actual = (int)(actual_double * 100.0); //убираем дробную часть
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
            TrapezoidClass item = new TrapezoidClass();

            double actual = item.PerimeterCalculate(sideA, sideB, sideC, sideD);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Trapezoid_ParceParametersTest()
        {
            // arrange
            string[] parameters = new string[]
            {
                "\"type\":trapezoid",
                "\"side_a\":2",
                "\"side_b\":3",
                "\"side_c\":1",
                "\"side_d\":1",
            };
            double expectedPerimeter = 7;

            // act
            TrapezoidClass item = new TrapezoidClass();
            item.ParceParameters(parameters);

            double actual = item.PerimeterGet();
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
            int expected = (int)(1.73 * 100.0); //убираем дробную часть

            // act
            TriangleClass item = new TriangleClass();

            double actual_double = item.AreaCalculate(sideA, sideB, sideC);
            int actual= (int)(actual_double * 100.0); //убираем дробную часть
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
            TriangleClass item = new TriangleClass();

            double actual = item.PerimeterCalculate(sideA, sideB, sideC);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Triangle_ParceParametersTest()
        {
            // arrange
            string[] parameters = new string[]
            {
                "\"type\":triangle",
                "\"side_a\":2",
                "\"side_b\":2",
                "\"side_c\":2",
            };
            double expectedPerimeter = 6;

            // act
            TriangleClass item = new TriangleClass();
            item.ParceParameters(parameters);

            double actual = item.PerimeterGet();
            // assert
            Assert.AreEqual(expectedPerimeter, actual);
        }
    }
}
