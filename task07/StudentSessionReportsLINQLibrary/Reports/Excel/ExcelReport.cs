using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports.Excel
{
    /// <summary>
    /// A class describing methods for save reports to file. 
    /// </summary>
    public abstract class ExcelReport<T>
    {
        /// <summary>
        /// A file path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Init a excel object for save reports to file.
        /// </summary>
        /// <param name="filePath"></param>
        public ExcelReport(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Saves reports to file.
        /// </summary>
        /// <param name="reports"></param>
        public abstract void SaveToFile(T reports);
    }
}
