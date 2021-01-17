﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.Reports.Objects
{
    public class SummaryMark
    {
        public string Group { get; set; }
        public int MinimalMark { get; set; }
        public int MaximumMark { get; set; }
        public double AverageMark { get; set; }
    }
}
