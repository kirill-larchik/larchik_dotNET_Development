using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.Reports.Objects
{
    public class ExpelledStudent
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
