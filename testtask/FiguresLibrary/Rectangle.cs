using FiguresLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary
{
    /// <summary>
    /// Class describing a rectangle.
    /// </summary>
    public class Rectangle : IRectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }

        /// <summary>
        /// Init the new rectangle object.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public double GetP()
        {
            return 2 * (Length + Width);
        }

        public double GetS()
        {
            return Length * Width;
        }
    }
}
