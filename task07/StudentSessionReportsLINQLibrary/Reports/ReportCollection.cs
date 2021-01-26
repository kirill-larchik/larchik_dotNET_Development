using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSessionReportsLINQLibrary.Data;

namespace StudentSessionReportsLINQLibrary.Reports
{
    /// <summary>
    /// A report collectiom.
    /// </summary>
    /// <typeparam name="TKey">A sheet.</typeparam>
    /// <typeparam name="TValue">Records.</typeparam>
    public abstract class ReportCollection<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> _reports;
        protected readonly StudentSessionReportsContext _context;

        /// <summary>
        /// Returns reports.
        /// </summary>
        public Dictionary<TKey, TValue> GetReports { get { return _reports; } }

        /// <summary>
        /// Inits a report collection.
        /// </summary>
        /// <param name="context"></param>
        public ReportCollection(StudentSessionReportsContext context)
        {
            _context = context;
            GenerateReports();
        }

        /// <summary>
        /// Generates a new report collection.
        /// </summary>
        public abstract void GenerateReports();
    }
}
