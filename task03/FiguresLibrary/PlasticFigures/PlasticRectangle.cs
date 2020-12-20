using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLibrary.Interfaces;
using SheetsLibrary;

namespace FiguresLibrary.PlasticFigures
{
    /// <summary>
    /// A plastic rectangle.
    /// </summary>
    public class PlasticRectangle : PlasticSheet, IRectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }

        /// <summary>
        /// Inits a new plastic rectangle.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        public PlasticRectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public double GetP()
        {
            return (Length + Width) * 2;
        }

        public double GetS()
        {
            return Length * Width;
        }

        /// <summary>
        ///  Returns a plastic rectangle from another.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="figure"></param>
        public PlasticRectangle(int length, int width, IFigure figure)
        {
            if (GetType() != figure.GetType())
                throw new Exception("Нельзя вырезать из фигуры другого материала.");

            Length = length;
            Width = width;

            if (figure.GetS() < GetS())
                throw new Exception("Заданная фигура больше предыдущей.");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Фигура: прямоугольник, материал: бумага, ");
            stringBuilder.Append("площадь: ");
            stringBuilder.Append(GetS());
            stringBuilder.Append("периметр: ");
            stringBuilder.Append(GetP());
            stringBuilder.Append(";\n");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is PlasticRectangle rectangle &&
                   base.Equals(obj) &&
                   color == rectangle.color &&
                   GetColor == rectangle.GetColor &&
                   IsDrawn == rectangle.IsDrawn &&
                   Length == rectangle.Length &&
                   Width == rectangle.Width;
        }

        public override int GetHashCode()
        {
            int hashCode = 1466145095;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + color.GetHashCode();
            hashCode = hashCode * -1521134295 + GetColor.GetHashCode();
            hashCode = hashCode * -1521134295 + IsDrawn.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            return hashCode;
        }
    }
}
