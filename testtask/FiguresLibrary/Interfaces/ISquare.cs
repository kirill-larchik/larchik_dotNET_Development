using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing properties of a square.
    /// </summary>
    public interface ISquare : IFigure
    {
        /// <summary>
        /// the side of the square.
        /// </summary>
        int Side { get; set; }
    }
}
