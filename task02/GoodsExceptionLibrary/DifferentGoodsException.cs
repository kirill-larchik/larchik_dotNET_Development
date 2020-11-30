using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsExceptionLibrary
{
    public class DifferentGoodsException : Exception
    {
        public DifferentGoodsException()
            : base("It`s different types.") { }
    }
}
