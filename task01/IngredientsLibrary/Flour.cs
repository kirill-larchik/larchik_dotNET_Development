using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsLibrary
{
    /// <summary>
    /// Class describing properties of a flour.
    /// </summary>
    public class Flour : Ingredient
    {
        /// <summary>
        /// Inits a flour.
        /// </summary>
        /// <param name="calorie"></param>
        /// <param name="cost"></param>
        /// <param name="value"></param>
        public Flour(double calorie, double cost, double value)
        {
            Calorie = calorie;
            Cost = cost;
            Value = value;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: " + base.ToString();
        }
    }
}
