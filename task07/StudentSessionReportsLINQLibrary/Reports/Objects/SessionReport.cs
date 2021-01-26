using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports.Objects
{
    /// <summary>
    /// Describing a session report of student with average mark.
    /// </summary>
    public class SessionReport
    {
        public string FullName { get; set; }
        public string Group { get; set; }
        public double AverageMark { get; set; }
    }
}
