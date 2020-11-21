using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsLibrary
{
    /// <summary>
    /// Class describing properties of a water.
    /// </summary>
    public class Water : Ingredient
    {
        /// <summary>
        /// Inits a water.
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="value"></param>
        public Water(double cost, double value)
        {
            Cost = cost;
            Calorie = 0;
            Value = value;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: " + base.ToString();
        }
    }
}
