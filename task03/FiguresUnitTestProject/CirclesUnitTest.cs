using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorsLibrary;
using FiguresLibrary.PaperFigures;
using FiguresLibrary.FilmFigures;

namespace FiguresUnitTestProject
{
    [TestClass]
    public class CirclesUnitTest
    {
        [TestMethod]
        public void GetP_PaperCircle()
        {
            int radius = 10;
            double expected = 2 * Math.PI * radius;

            PaperCircle rectangle = new PaperCircle(radius);
            double actual = rectangle.GetP();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetP_FilmCircle()
        {
            int radius = 15;
            double expected = 2 * Math.PI * radius;

            FilmCircle rectangle = new FilmCircle(radius);
            double actual = rectangle.GetP();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_PaperCircle()
        {
            int radius = 10;    
            double expected = Math.PI * radius * radius;

            PaperCircle rectangle = new PaperCircle(radius);
            double actual = rectangle.GetS();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_FilmCircle()
        {
            int radius = 15;
            double expected = Math.PI * radius * radius;

            FilmCircle rectangle = new FilmCircle(radius);
            double actual = rectangle.GetS();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeColor_PaperCircle()
        {
            int radius = 10;
            Color expected = Color.Purple;

            PaperCircle rectangle = new PaperCircle(radius);
            rectangle.ChangeColor(Color.Purple);
            Color actual = rectangle.GetColor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Цвет листа пленки нельзя менять.")]
        public void ChangeColor_FilmCircle_GetException()
        {
            int radius = 15;

            FilmCircle rectangle = new FilmCircle(radius);
            rectangle.ChangeColor(Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Лист бумаги можно красить только один раз.")]
        public void ChangeColor_PaperCircle_GetException()
        {
            int radius = 10;

            PaperCircle rectangle = new PaperCircle(radius);
            rectangle.ChangeColor(Color.Purple);
            rectangle.ChangeColor(Color.Black);
        }

        [TestMethod]
        public void CutFigure_FilmCircle()
        {
            int radius = 15;
            FilmCircle circle = new FilmCircle(16);

            FilmCircle actual = new FilmCircle(radius, circle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Заданная фигура больше предыдущей.")]
        public void CutFigure_FilmCircle_GetException()
        {
            int radius = 15;
            FilmCircle circle = new FilmCircle(14);

            FilmCircle actual = new FilmCircle(radius, circle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Нельзя вырезать из фигуры другого материала.")]
        public void CutFigure_FilmCircleFromPaper_GetException()
        {
            int radius = 15;
            PaperCircle circle = new PaperCircle(16);

            FilmCircle actual = new FilmCircle(radius, circle);
        }
    }
}
