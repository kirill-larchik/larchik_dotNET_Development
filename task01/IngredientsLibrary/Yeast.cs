using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsLibrary
{
    /// <summary>
    /// Class describing properties of a yeast.
    /// </summary>
    public class Yeast : Ingredient
    {
        /// <summary>
        /// Inits a yeast.
        /// </summary>
        /// <param name="calorie"></param>
        /// <param name="cost"></param>
        public Yeast(double calorie, double cost, double value)
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
