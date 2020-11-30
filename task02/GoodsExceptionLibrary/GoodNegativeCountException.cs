using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsExceptionLibrary
{
    public class GoodNegativeCountException : Exception
    {
        public GoodNegativeCountException()
            : base("Count is not be negative.") { }
    }
}
