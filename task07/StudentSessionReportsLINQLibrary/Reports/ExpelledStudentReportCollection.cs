using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Reports.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLINQLibrary.Reports
{
    public enum ExpelledStudentSortState
    {
        FullNameAsc,
        FullNameDesc,
        GenderAsc,
        GenderDesc,
        BirthdayAsc,
        BirthdayDesc
    }

    /// <summary>
    /// A expelled student report collection.
    /// </summary>
    public class ExpelledStudentReportCollection : ReportCollection<string, List<ExpelledStudent>>
    {
        /// <summary>
        /// Init a expelled student report collection.
        /// </summary>
        /// <param name="context"></param>
        public ExpelledStudentReportCollection(StudentSessionReportsContext context)
            : base(context)
        { }

        public override void GenerateReports()
        {
            var expelledStudents = from s in _context.Specialties
                                 join g in _context.Groups on s.Id equals g.SpecialtyId
                                 join st in _context.Students on g.Id equals st.GroupId
                                 join se in _context.Sessions on st.Id equals se.StudentId
                                 join sr in _context.SessionResults on se.Id equals sr.SessionId
                                 select new
                                 {
                                     Group = g.Name,
                                     FullName = st.LastName + " " + st.FirstName + " " + st.MiddleName,
                                     Gender = st.Gender,
                                     Birthday = st.Birthday,
                                     Mark = sr.Mark
                                 };

            _reports = expelledStudents.GroupBy(s => s.Group).ToDictionary(s => s.Key, s => s.Where(g => g.Mark < 4).Select(g => new ExpelledStudent { FullName = g.FullName, Gender = g.Gender, Birthday = g.Birthday }).Distinct().ToList()).OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        /// <summary>
        /// Sorts expelled students collection.
        /// </summary>
        /// <param name="sortState"></param>
        public void SortExpelledStudents(ExpelledStudentSortState sortState)
        {
            var keys = _reports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == ExpelledStudentSortState.FullNameAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.FullName).ToList();
                if (sortState == ExpelledStudentSortState.FullNameDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.FullName).ToList();
                if (sortState == ExpelledStudentSortState.GenderAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.Gender).ToList();
                if (sortState == ExpelledStudentSortState.GenderDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.Gender).ToList();
                if (sortState == ExpelledStudentSortState.BirthdayAsc)
                    _reports[key] = _reports[key].OrderBy(g => g.Birthday).ToList();
                if (sortState == ExpelledStudentSortState.BirthdayDesc)
                    _reports[key] = _reports[key].OrderByDescending(g => g.Birthday).ToList();
            }
        }
    }
}
