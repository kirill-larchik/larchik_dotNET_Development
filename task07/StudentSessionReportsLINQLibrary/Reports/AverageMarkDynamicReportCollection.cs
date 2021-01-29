using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSessionReportsLINQLibrary.Reports.Objects;
using StudentSessionReportsLINQLibrary.Data;

namespace StudentSessionReportsLINQLibrary.Reports
{
    public enum AverageMarkDynamicSortState
    {
        SubjectNameAsc,
        SubjectNameDesc
    }

    public class AverageMarkDynamicReportCollection : ReportCollection<int, List<AverageMarkDynamicReport>>
    {
        public AverageMarkDynamicReportCollection(StudentSessionReportsContext context)
            : base(context) { }

        public override void GenerateReports()
        {
            var sessionReports = from s in _context.Specialties
                                 join g in _context.Groups on s.Id equals g.SpecialtyId
                                 join st in _context.Students on g.Id equals st.GroupId
                                 join se in _context.Sessions on st.Id equals se.StudentId
                                 join sr in _context.SessionResults on se.Id equals sr.SessionId
                                 select new
                                 {
                                     Session = se.NumberOfSession,
                                     Year = sr.DateOfPassing.Year,
                                     Subject = sr.SubjectName,
                                     Mark = sr.Mark
                                 };

            var reports = _reports = sessionReports.GroupBy(q => q.Session).OrderBy(q => q.Key).ToDictionary(q => q.Key, q => q.GroupBy(w => w.Subject).Select(w => new AverageMarkDynamicReport { SubjectName = w.Key, MinYear = w.Min(e => e.Year), MaxYear = w.Max(e => e.Year), YearMarkPairs = w.GroupBy(e => e.Year).ToDictionary(e => e.Key, e => e.Average(r => r.Mark)) }).OrderBy(w => w.SubjectName).ToList());
            
        }

        /// <summary>
        /// Sorts the session report collection.
        /// </summary>
        /// <param name="sortState"></param>
        public void SortReports(AverageMarkDynamicSortState sortState)
        {
            var keys = _reports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == AverageMarkDynamicSortState.SubjectNameAsc)
                    _reports[key] = _reports[key].OrderBy(q => q.SubjectName).ToList();
                if (sortState == AverageMarkDynamicSortState.SubjectNameDesc)
                    _reports[key] = _reports[key].OrderByDescending(q => q.SubjectName).ToList();
            }
        }
    }
}
