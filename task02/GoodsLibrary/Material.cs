using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsLibrary
{
    /// <summary>
    /// Class material.
    /// </summary>
    public class Material : Good
    {
        /// <summary>
        /// Inits material.
        /// </summary>
        public Material() { }

        /// <summary>
        /// Inits material with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        public Material(string name, double cost, double markup, int count)
            : base(name, cost, markup, count)
        { }
    }
}
