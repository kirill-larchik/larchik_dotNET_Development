using StudentSessionReportsLINQLibrary.Reports.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSessionReportsLINQLibrary.Data;

namespace StudentSessionReportsLINQLibrary.Reports
{
    public enum SessionResultSortState
    {
        FullNameAsc,
        FullNameDesc,
        GroupAsc,
        GroupDesc,
        AverageMarkAsc,
        AverageMarkDesc
    }

    /// <summary>
    /// A session result report collection. 
    /// </summary>
    public class SessionResultReportCollection : ReportCollection<int, List<SessionReport>>
    {
        /// <summary>
        /// Init a session result report collection.
        /// </summary>
        /// <param name="context"></param>
        public SessionResultReportCollection(StudentSessionReportsContext context)
            : base(context)
        { }

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
                                     FullName = st.LastName + " " + st.FirstName + " " + st.MiddleName,
                                     Group = g.Name,
                                     Mark = sr.Mark
                                 };

            _reports = sessionReports.GroupBy(q => q.Session).ToDictionary(s => s.Key, s => s.GroupBy(g => new { FullName = g.FullName, Group = g.Group }).Select(x => new SessionReport { FullName = x.Key.FullName, Group = x.Key.Group, AverageMark = x.Average(m => m.Mark) }).ToList()).OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        /// <summary>
        /// Sorts the session report collection.
        /// </summary>
        /// <param name="sortState"></param>
        public void SortSessionReports(SessionResultSortState sortState)
        {
            var keys = _reports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == SessionResultSortState.GroupAsc)
                    _reports[key] = _reports[key].OrderBy(q => q.Group).ToList();
                if (sortState == SessionResultSortState.GroupDesc)
                    _reports[key] = _reports[key].OrderByDescending(q => q.Group).ToList();
                if (sortState == SessionResultSortState.FullNameAsc)
                    _reports[key] = _reports[key].OrderBy(q => q.FullName).ToList();
                if (sortState == SessionResultSortState.FullNameDesc)
                    _reports[key] = _reports[key].OrderByDescending(q => q.FullName).ToList();
                if (sortState == SessionResultSortState.AverageMarkAsc)
                    _reports[key] = _reports[key].OrderBy(q => q.AverageMark).ToList();
                if (sortState == SessionResultSortState.AverageMarkDesc)
                    _reports[key] = _reports[key].OrderByDescending(q => q.AverageMark).ToList();
            }
        }
    }
}
