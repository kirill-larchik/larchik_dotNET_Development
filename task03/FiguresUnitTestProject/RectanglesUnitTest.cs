using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLibrary;
using FiguresLibrary.PaperFigures;
using FiguresLibrary.FilmFigures;
using ColorsLibrary;

namespace FiguresUnitTestProject
{
    [TestClass]
    public class RectanglesUnitTest
    {
        [TestMethod]
        public void GetP_PaperRectangle()
        {
            int length = 10;
            int width = 10;
            double expected = 40;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            double actual = rectangle.GetP();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetP_FlimRectangle()
        {
            int length = 15;
            int width = 24;
            double expected = 78;

            FilmRectangle rectangle = new FilmRectangle(length, width);
            double actual = rectangle.GetP();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_PaperRectangle()
        {
            int length = 10;
            int width = 10;
            double expected = 100;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            double actual = rectangle.GetS();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_FlimRectangle()
        {
            int length = 15;
            int width = 24;
            double expected = 360;

            FilmRectangle rectangle = new FilmRectangle(length, width);
            double actual = rectangle.GetS();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeColor_PaperRectangle()
        {
            int length = 10;
            int width = 10;
            Color expected = Color.Purple;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            rectangle.ChangeColor(Color.Purple);
            Color actual = rectangle.GetColor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Цвет листа пленки нельзя менять.")]
        public void ChangeColor_FlimRectangle_GetException()
        {
            int length = 15;
            int width = 24;

            FilmRectangle rectangle = new FilmRectangle(length, width);
            rectangle.ChangeColor(Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Лист бумаги можно красить только один раз.")]
        public void ChangeColor_PaperRectangle_GetException()
        {
            int length = 10;
            int width = 10;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            rectangle.ChangeColor(Color.Purple);
            rectangle.ChangeColor(Color.Black);
        }

        [TestMethod]
        public void CutFigure_FlimRectangle()
        {
            int length = 15;
            int width = 24;
            FilmRectangle rectangle = new FilmRectangle(20, 25);
            FilmRectangle expected = new FilmRectangle(15, 24);

            FilmRectangle actual = new FilmRectangle(length, width, rectangle);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Заданная фигура больше предыдущей.")]
        public void CutFigure_FlimRectangle_GetException()
        {
            int length = 15;
            int width = 24;
            FilmRectangle rectangle = new FilmRectangle(10, 10);

            FilmRectangle actual = new FilmRectangle(length, width, rectangle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Нельзя вырезать из фигуры другого материала.")]
        public void CutFigure_FlimRectangleFromPaper_GetException()
        {
            int length = 15;
            int width = 24;
            PaperRectangle rectangle = new PaperRectangle(10, 10);

            FilmRectangle actual = new FilmRectangle(length, width, rectangle);
        }
    }
}
