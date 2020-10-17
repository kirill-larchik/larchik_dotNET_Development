using FiguresLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary
{
    /// <summary>
    /// Class describing a circle.
    /// </summary>
    public class Circle : ICircle
    {
        public int Radius { get; set; }

        /// <summary>
        /// Init the new circle object.
        /// </summary>
        /// <param name="radius"></param>
        public Circle(int radius)
        {
            Radius = radius;
        }

        public double GetP()
        {
            return 2 * Math.PI * Radius; 
        }

        public double GetS()
        {
            return Math.PI * Radius * Radius;
        }

        public override bool Equals(object obj)
        {
            return obj is Circle circle &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            return 598075851 + Radius.GetHashCode();
        }
    }
}
