using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports.Objects
{
    /// <summary>
    /// Describing a average mark reports for each specailty.
    /// </summary>
    public class AverageSpecialtyMarkReport
    {
        public string Specialty { get; set; }
        public double AverageMark { get; set; }
    }
}
