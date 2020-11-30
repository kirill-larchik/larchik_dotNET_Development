using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary
{
    /// <summary>
    /// Class food.
    /// </summary>
    public class Food : Good
    {
        /// <summary>
        /// Inits food.
        /// </summary>
        public Food() { }

        /// <summary>
        /// Inits food with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>

        public Food(string name, double cost, double markup, int count)
            : base(name, cost, markup, count)
        { }
    }
}
