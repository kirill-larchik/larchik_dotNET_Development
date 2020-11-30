using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
