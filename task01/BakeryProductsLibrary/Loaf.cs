using IngredientsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryProductsLibrary
{
    /// <summary>
    /// Class describing properties of a loaf.
    /// </summary>
    public class Loaf : IBakeryProduct
    {
        private Ingredient[] _ingredients;

        /// <summary>
        /// Returns the loaf name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Returns the markup of the loaf category.
        /// </summary>
        public double Markup { get; private set; }

        /// <summary>
        /// Inits a loaf with product name and given inredients.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ingredients"></param>
        public Loaf(string name, params Ingredient[] ingredients)
        {
            Name = name;
            _ingredients = ingredients;

            Markup = 100;
        }

        /// <summary>
        /// Returns the loaf calorie.
        /// </summary>
        /// <returns></returns>
        public double GetCalorie()
        {
            double calorie = 0;
            for (int i = 0; i < _ingredients.Length; i++)
                calorie += _ingredients[i].Calorie;
            return calorie;
        }

        /// <summary>
        /// Returns the loaf cost.
        /// </summary>
        /// <returns></returns>
        public double GetCost()
        {
            double cost = 0;
            for (int i = 0; i < _ingredients.Length; i++)
                cost += _ingredients[i].Cost;
            return cost;
        }

        public Ingredient[] GetIngredients()
        {
            return _ingredients;
        }

        public override bool Equals(object obj)
        {
            return obj is Loaf loaf &&
                   EqualityComparer<Ingredient[]>.Default.Equals(_ingredients, loaf._ingredients) &&
                   Name == loaf.Name &&
                   Markup == loaf.Markup;
        }

        public override int GetHashCode()
        {
            int hashCode = -1335647283;
            hashCode = hashCode * -1521134295 + EqualityComparer<Ingredient[]>.Default.GetHashCode(_ingredients);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Markup.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            string str = $"{this.GetType().Name} '{Name}:'\n";
            for (int i = 0; i < _ingredients.Length; i++)
                str += _ingredients[i].ToString() + "\n";
            return str;
        }
    }
}
