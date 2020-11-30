using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary
{
    /// <summary>
    /// Class furniture.
    /// </summary>
    public class Furniture : Good 
    {
        /// <summary>
        /// Inits furniture.
        /// </summary>
        public Furniture() { }

        /// <summary>
        /// Inits furniture with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        public Furniture(string name, double cost, double markup, int count)
            : base(name, cost, markup, count)
        { }
    }
}
