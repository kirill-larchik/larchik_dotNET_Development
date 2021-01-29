using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports.Objects
{
    /// <summary>
    /// Describing a dynamic report of student with average mark.
    /// </summary>
    public class AverageMarkDynamicReport
    {
        public string SubjectName { get; set; }
        public Dictionary<int, double> YearMarkPairs { get; set; }

        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }
}
