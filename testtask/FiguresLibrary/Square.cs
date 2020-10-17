using FiguresLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary
{
    /// <summary>
    /// Class describing a square.
    /// </summary>
    public class Square : ISquare
    {
        public int Side { get; set; }

        /// <summary>
        /// Init the new square object.
        /// </summary>
        /// <param name="side"></param>
        public Square(int side)
        {
            Side = side;
        }

        public double GetP()
        {
            return 4 * Side;
        }

        public double GetS()
        {
            return Side * Side;
        }
    }
}
