using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Interfaces
{
    /// <summary>
    /// Interface describing properties of a circle.
    /// </summary>
    public interface ICircle : IFigure
    {
        /// <summary>
        /// The radius of the circle.
        /// </summary>
        int Radius { get; set; }
    }
}
