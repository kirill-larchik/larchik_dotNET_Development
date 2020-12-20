using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing methods and properties for all rectangles.
    /// </summary>
    public interface IRectangle : IFigure
    {
        /// <summary>
        /// Returns length of figure.
        /// </summary>
        /// <returns></returns>
        int Length { get; set; }

        /// <summary>
        /// Returns width of figure.
        /// </summary>
        int Width { get; set; }
    }
}
