using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class FiguresUT
    {
        [DataTestMethod]
        [DataRow(2, 4, 12)]
        [DataRow(3, 9, 24)]
        [DataRow(12, 13, 50)]
        [DataRow(4, 5, 18)]
        [DataRow(5, 1, 12)]
        public void Rectangle_GetP(int length, int width, int expected)
        {
            Rectangle rectangle = new Rectangle(length, width);
            double actual = rectangle.GetP();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, 4, 8)]
        [DataRow(3, 9, 27)]
        [DataRow(12, 13, 156)]
        [DataRow(4, 5, 20)]
        [DataRow(5, 1, 5)]
        public void Rectangle_GetS(int length, int width, int expected)
        {
            Rectangle rectangle = new Rectangle(length, width);
            double actual = rectangle.GetS();

            Assert.AreEqual(expected, actual);
        }
        
        [DataTestMethod]
        [DataRow(2, 12.5663706143591724)]
        [DataRow(3, 18.8495559215387586)]
        [DataRow(4, 25.1327412287183448)]
        public void Circle_GetP(int radius, double expected)
        {
            Circle circle = new Circle(radius);
            double actual = circle.GetP();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, 12.5663706143591724)]
        [DataRow(3, 28.2743338823081379)]
        [DataRow(4, 50.2654824574366896)]
        public void Circle_GetS(int radius, double expected)
        {
            Circle circle = new Circle(radius);
            double actual = circle.GetS();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, 8)]
        [DataRow(3, 12)]
        [DataRow(12, 48)]
        [DataRow(4, 16)]
        [DataRow(5, 20)]
        public void Square_GetP(int side, int expected)
        {
            Square square = new Square(side);
            double actual = square.GetP();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, 4)]
        [DataRow(3, 9)]
        [DataRow(12, 144)]
        [DataRow(4, 16)]
        [DataRow(5, 25)]
        public void Square_GetS(int side, int expected)
        {
            Square square = new Square(side);
            double actual = square.GetS();

            Assert.AreEqual(expected, actual);
        }
    }
}
