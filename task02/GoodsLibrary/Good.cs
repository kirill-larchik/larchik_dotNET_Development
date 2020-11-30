using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsExceptionLibrary;

namespace GoodsLibrary
{
    /// <summary>
    /// Class good.
    /// </summary>
    public abstract class Good
    {
        /// <summary>
        /// Name of a good.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of a good. 
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Cost of a markup. 
        /// </summary>
        public double Markup { get; set; }

        /// <summary>
        /// Count of a good. 
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Inits a good.
        /// </summary>
        public Good() { }

        /// <summary>
        /// Inits a good with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        public Good(string name, double cost, double markup, int count)
        {
            Name = name;
            Cost = cost;
            Markup = markup;
            Count = count;
        }

        /// <summary>
        /// Returns unit cost.
        /// </summary>
        /// <returns></returns>
        public double GetUnitCost()
        {
            return Cost + Markup;
        }

        /// <summary>
        /// Returns total cost.
        /// </summary>
        /// <returns></returns>
        public double GetTotalCost()
        {
            return (Cost + Markup) * Count;
        }

        /// <summary>
        /// Operation plus for goods.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Good operator +(Good left, Good right)
        {
            if (left.GetType() == right.GetType() && left.Name == right.Name)
            {
                double cost = (left.Cost * left.Count + right.Cost * right.Count) / (left.Count + right.Count);
                double markup = (left.Markup * left.Count + right.Markup * right.Count) / (left.Count + right.Count);
                int count = left.Count + right.Count;

                return GetGood(left.GetType().Name, left.Name, cost, markup, count);
            }
            else
                throw new DifferentGoodsException();
        }

        /// <summary>
        /// Decrease count of good by number.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Good operator -(Good left, int right)
        {
            if (left.Count > right)
            {
                int count = left.Count - right;
                return GetGood(left.GetType().Name, left.Name, left.Cost, left.Markup, count);
            }
            else
                throw new GoodNegativeCountException();
        }

        /// <summary>
        /// Returns good by type name.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        /// <returns></returns>

        public static Good GetGood(string typeName, string name, double cost, double markup, int count)
        {
            switch (typeName)
            {
                case nameof(Food):
                    return new Food(name, cost, markup, count);
                case nameof(Furniture):
                    return new Furniture(name, cost, markup, count);
                case nameof(Material):
                    return new Material(name, cost, markup, count);
                default:
                    return null;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Good good &&
                   Name == good.Name &&
                   Cost == good.Cost &&
                   Markup == good.Markup &&
                   Count == good.Count;
        }

        public override int GetHashCode()
        {
            int hashCode = 651863063;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Cost.GetHashCode();
            hashCode = hashCode * -1521134295 + Markup.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: name={Name},cost={Cost},markup={Markup},count={Count},";
        }
    }
}
