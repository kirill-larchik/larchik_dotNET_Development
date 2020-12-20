﻿using FiguresLibrary.Interfaces;
using SheetsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.PaperFigures
{
    /// <summary>
    /// A Paper circle
    /// </summary>
    public class PaperCircle : PaperSheet, ICircle
    {
        public int Diameter { get ; set; }
        public int Radius { get; set; }

        /// <summary>
        /// Inits a new paper circle.
        /// </summary>
        /// <param name="radius"></param>
        public PaperCircle(int radius)
        {
            Radius = radius;
            Diameter = 2 * radius;
        }

        public double GetP()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetS()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Returns a paper circle from another.
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="figure"></param>
        public PaperCircle(int radius, IFigure figure)
        {
            if (GetType() != figure.GetType())
                throw new Exception("Нельзя вырезать из фигуры другого материала.");

            Radius = radius;
            Diameter = 2 * Radius;

            if (figure.GetS() < GetS())
                throw new Exception("Заданная фигура больше предыдущей.");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Фигура: круг, материал: бумага, ");
            stringBuilder.Append("площадь: ");
            stringBuilder.Append(GetS());
            stringBuilder.Append("периметр: ");
            stringBuilder.Append(GetP());
            stringBuilder.Append(";\n");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is PaperCircle circle &&
                   base.Equals(obj) &&
                   color == circle.color &&
                   GetColor == circle.GetColor &&
                   IsDrawn == circle.IsDrawn &&
                   Diameter == circle.Diameter &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            int hashCode = 363865032;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + color.GetHashCode();
            hashCode = hashCode * -1521134295 + GetColor.GetHashCode();
            hashCode = hashCode * -1521134295 + IsDrawn.GetHashCode();
            hashCode = hashCode * -1521134295 + Diameter.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }
    }
}
