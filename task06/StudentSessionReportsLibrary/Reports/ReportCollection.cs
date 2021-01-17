using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSessionReportsLibrary.Reports.Objects;
using StudentSessionReportsLibrary.Objects;

namespace StudentSessionReportsLibrary.Reports
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

    public enum SessionResultSortState
    {
        FullNameAsc,
        FullNameDesc,
        GroupAsc,
        GroupDesc,
        AverageMarkAsc,
        AverageMarkDesc
    }

    public enum ExpelledStudentSortState
    {
        FullNameAsc,
        FullNameDesc,
        GenderAsc,
        GenderDesc,
        BirthdayAsc,
        BirthdayDesc
    }


    public class ReportCollection
    {
        private Dictionary<int, List<SummaryMark>> _summaryMarks;
        private Dictionary<int, List<SessionReport>> _sessionReports;
        private Dictionary<string, List<ExpelledStudent>> _expelledStudents;

        public Dictionary<int, List<SessionReport>> GetSessionReports { get { return _sessionReports; } }
        public Dictionary<int, List<SummaryMark>> GetSummaryMark { get { return _summaryMarks; } }
        public Dictionary<string, List<ExpelledStudent>> GetExpelledStudents { get { return _expelledStudents; } }

        public ReportCollection(List<SessionResult> sessionResults)
        {
            SetSessionReports(sessionResults);
            SetSummaryMarks(sessionResults);
            SetExpelledStudents(sessionResults);
        }

        public void SetSessionReports(List<SessionResult> sessionResults)
        {
            _sessionReports = sessionResults.GroupBy(s => s.NumberOfSession).ToDictionary(s => s.Key, s => s.GroupBy(g => new { FullName = g.LastName + " " + g.FirstName + " " + g.MiddleName, Group = g.GroupName }).Select(x => new SessionReport { FullName = x.Key.FullName, Group = x.Key.Group, AverageMark = x.Average(m => m.Mark) }).ToList()).OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        public void SetSummaryMarks(List<SessionResult> sessionResults)
        {
            _summaryMarks = sessionResults.GroupBy(s => s.NumberOfSession).ToDictionary(s => s.Key, s => s.GroupBy(g => g.GroupName).Select(g => new SummaryMark { Group = g.Key, MinimalMark = g.Min(q => q.Mark), MaximumMark = g.Max(m => m.Mark), AverageMark = g.Average(e => e.Mark) }).ToList()).OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        public void SetExpelledStudents(List<SessionResult> sessionResults)
        {
            _expelledStudents = sessionResults.GroupBy(s => s.GroupName).ToDictionary(s => s.Key, s => s.Where(g => g.Mark < 4).Select(g => new ExpelledStudent { FullName = g.LastName + " " + g.FirstName + " " + g.MiddleName, Gender = g.Gender, Birthday = g.Birthday } ).Distinct().ToList()).OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
        }

        public void SortSessionReports(SessionResultSortState sortState)
        {
            var keys = _sessionReports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == SessionResultSortState.GroupAsc)
                    _sessionReports[key] = _sessionReports[key].OrderBy(q => q.Group).ToList();
                if (sortState == SessionResultSortState.GroupDesc)
                    _sessionReports[key] = _sessionReports[key].OrderByDescending(q => q.Group).ToList();
                if (sortState == SessionResultSortState.FullNameAsc)
                    _sessionReports[key] = _sessionReports[key].OrderBy(q => q.FullName).ToList();
                if (sortState == SessionResultSortState.FullNameDesc)
                    _sessionReports[key] = _sessionReports[key].OrderByDescending(q => q.FullName).ToList();
                if (sortState == SessionResultSortState.AverageMarkAsc)
                    _sessionReports[key] = _sessionReports[key].OrderBy(q => q.AverageMark).ToList();
                if (sortState == SessionResultSortState.AverageMarkDesc)
                    _sessionReports[key] = _sessionReports[key].OrderByDescending(q => q.AverageMark).ToList();
            }
        }

        public void SortSummaryMarks(SummaryMarkSortState sortState)
        {
            var keys = _sessionReports.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == SummaryMarkSortState.GroupAsc)
                    _summaryMarks[key] = _summaryMarks[key].OrderBy(g => g.Group).ToList();
                if (sortState == SummaryMarkSortState.GroupDesc)
                    _summaryMarks[key] = _summaryMarks[key].OrderByDescending(g => g.Group).ToList();
                if (sortState == SummaryMarkSortState.MinAsc)
                    _summaryMarks[key] = _summaryMarks[key].OrderBy(g => g.MinimalMark).ToList();
                if (sortState == SummaryMarkSortState.MinDesc)
                    _summaryMarks[key] = _summaryMarks[key].OrderByDescending(g => g.MinimalMark).ToList();
                if (sortState == SummaryMarkSortState.MaxAsc)
                    _summaryMarks[key] = _summaryMarks[key].OrderBy(g => g.MaximumMark).ToList();
                if (sortState == SummaryMarkSortState.MaxDesc)
                    _summaryMarks[key] = _summaryMarks[key].OrderByDescending(g => g.MaximumMark).ToList();
                if (sortState == SummaryMarkSortState.AverageAsc)
                    _summaryMarks[key] = _summaryMarks[key].OrderBy(g => g.AverageMark).ToList();
                if (sortState == SummaryMarkSortState.AverageDesc)
                    _summaryMarks[key] = _summaryMarks[key].OrderByDescending(g => g.AverageMark).ToList();
            }
        }

        public void SortExpelledStudents(ExpelledStudentSortState sortState)
        {
            var keys = _expelledStudents.Keys.ToArray();
            foreach (var key in keys)
            {
                if (sortState == ExpelledStudentSortState.FullNameAsc)
                    _expelledStudents[key] = _expelledStudents[key].OrderBy(g => g.FullName).ToList();
                if (sortState == ExpelledStudentSortState.FullNameDesc)
                    _expelledStudents[key] = _expelledStudents[key].OrderByDescending(g => g.FullName).ToList();
                if (sortState == ExpelledStudentSortState.GenderAsc)
                    _expelledStudents[key] = _expelledStudents[key].OrderBy(g => g.Gender).ToList();
                if (sortState == ExpelledStudentSortState.GenderDesc)
                    _expelledStudents[key] = _expelledStudents[key].OrderByDescending(g => g.Gender).ToList();
                if (sortState == ExpelledStudentSortState.BirthdayAsc)
                    _expelledStudents[key] = _expelledStudents[key].OrderBy(g => g.Birthday).ToList();
                if (sortState == ExpelledStudentSortState.BirthdayDesc)
                    _expelledStudents[key] = _expelledStudents[key].OrderByDescending(g => g.Birthday).ToList();
            }
        }
    }
}
