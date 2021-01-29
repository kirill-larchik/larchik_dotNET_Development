using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Reports.Objects;

namespace StudentSessionReportsLINQLibrary.Reports
{
    public enum AverageTeacherMarkSortState
    {
        TeacherNameAsc,
        TeacherNameDesc,
        AverageMarkAsc,
        AverageMarkDesc
    }

    public class AverageTeacherMarkReportCollection : ReportCollection<int, List<AverageTeacherMarkReport>>
    {
        /// <summary>
        /// Init a session result report collection.
        /// </summary>
        /// <param name="context"></param>
        public AverageTeacherMarkReportCollection(StudentSessionReportsContext context)
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
                                     TeacherName = sr.TeacherFullName,
                                     Mark = sr.Mark
                                 };

            _reports = sessionReports.GroupBy(q => q.Session).ToDictionary(s => s.Key, s => s.GroupBy(g => g.TeacherName).Select(x => new AverageTeacherMarkReport { TeacherName = x.Key, AverageMark = x.Average(m => m.Mark) }).ToList()).OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        /// <summary>
        /// Sorts the session report collection.
        /// </summary>
        /// <param name="sortState"></param>
        public void SortReports(AverageTeacherMarkSortState sortState)
        {
            var keys = _reports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == AverageTeacherMarkSortState.TeacherNameAsc)
                    _reports[key] = _reports[key].OrderBy(q => q.TeacherName).ToList();
                if (sortState == AverageTeacherMarkSortState.TeacherNameDesc)
                    _reports[key] = _reports[key].OrderByDescending(q => q.TeacherName).ToList();
                if (sortState == AverageTeacherMarkSortState.AverageMarkAsc)
                    _reports[key] = _reports[key].OrderBy(q => q.AverageMark).ToList();
                if (sortState == AverageTeacherMarkSortState.AverageMarkDesc)
                    _reports[key] = _reports[key].OrderByDescending(q => q.AverageMark).ToList();
            }
        }
    }
}
