using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Reports.Objects;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports
{
    public enum SummaryMarkSortState
    {
        GroupAsc,
        GroupDesc,
        MinAsc,
        MinDesc,
        MaxAsc,
        MaxDesc,
        AverageAsc,
        AverageDesc
    }

    /// <summary>
    /// A summary mark report collection. 
    /// </summary>
    public class SummaryMarkReportCollection : ReportCollection<int, List<SummaryMark>>
    {
        /// <summary>
        /// Init a summary mark report collection.
        /// </summary>
        /// <param name="context"></param>
        public SummaryMarkReportCollection(StudentSessionReportsContext context)
            : base(context) { }

        public override void GenerateReports()
        {
            var summaryMarks = from s in _context.Specialties
                               join g in _context.Groups on s.Id equals g.SpecialtyId
                               join st in _context.Students on g.Id equals st.GroupId
                               join se in _context.Sessions on st.Id equals se.StudentId
                               join sr in _context.SessionResults on se.Id equals sr.SessionId
                               select new
                               {
                                   SessionNumber = se.NumberOfSession,
                                   Group = g.Name,
                                   Mark = sr.Mark
                               };

            _reports = summaryMarks.GroupBy(q => q.SessionNumber).ToDictionary(q => q.Key, q => q.GroupBy(w => w.Group).Select(w => new SummaryMark { Group = w.Key, MinimalMark = w.Min(e => e.Mark), MaximumMark = w.Max(e => e.Mark), AverageMark = w.Average(e => e.Mark) }).ToList()).OrderBy(q => q.Key).ToDictionary(q => q.Key, q => q.Value);
        }

        /// <summary>
        /// Sorts the summary marks collection.
        /// </summary>
        /// <param name="sortState"></param>
        public void SortSummaryMarks(SummaryMarkSortState sortState)
        {
            var keys = _reports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == SummaryMarkSortState.GroupAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.Group).ToList();
                if (sortState == SummaryMarkSortState.GroupDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.Group).ToList();
                if (sortState == SummaryMarkSortState.MinAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.MinimalMark).ToList();
                if (sortState == SummaryMarkSortState.MinDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.MinimalMark).ToList();
                if (sortState == SummaryMarkSortState.MaxAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.MaximumMark).ToList();
                if (sortState == SummaryMarkSortState.MaxDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.MaximumMark).ToList();
                if (sortState == SummaryMarkSortState.AverageAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.AverageMark).ToList();
                if (sortState == SummaryMarkSortState.AverageDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.AverageMark).ToList();
            }
        }
    }
}
