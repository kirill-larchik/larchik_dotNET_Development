using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentSessionReportsLINQLibrary.DAO.SqlServer
{
    public class SqlServerSessionResultDAO : ISessionResultDAO
    {
        private readonly StudentSessionReportsContext _context;

        private static SqlServerSessionResultDAO instance;

        private SqlServerSessionResultDAO(StudentSessionReportsContext context)
        {
            _context = context;
        }

        public static SqlServerSessionResultDAO GetInstance(StudentSessionReportsContext context)
        {
            if (instance == null)
                instance = new SqlServerSessionResultDAO(context);
            return instance;
        }

        public bool DeleteSessionResult(int id)
        {
            var sessionResult = _context.SessionResults.FirstOrDefault(s => s.Id == id);
            if (sessionResult != null)
            {
                _context.SessionResults.DeleteOnSubmit(sessionResult);
                _context.SubmitChanges();
                return true;
            }

            return false;
        }

        public List<SessionResult> GetAllSessionResults()
        {
            return _context.SessionResults.ToList();
        }

        public SessionResult GetSessionResultById(int id)
        {
            var sessionResult = _context.SessionResults.FirstOrDefault(s => s.Id == id);
            return sessionResult;
        }

        public bool InsertSessionResult(SessionResult sessionResult)
        {
            if (sessionResult != null)
            {
                _context.SessionResults.InsertOnSubmit(sessionResult);
                _context.SubmitChanges();

                return true;
            }

            return false;
        }

        public SessionResult UpdateSessionResult(SessionResult sessionResult)
        {
            var updSessionResult = _context.SessionResults.FirstOrDefault(s => s.Id == sessionResult.Id);
            if (updSessionResult != null)
            {
                updSessionResult.SubjectName = sessionResult.SubjectName;
                updSessionResult.SubjectCheckType = sessionResult.SubjectCheckType;
                updSessionResult.DateOfPassing = sessionResult.DateOfPassing;
                updSessionResult.TeacherFullName = sessionResult.TeacherFullName;
                updSessionResult.Mark = sessionResult.Mark;

                _context.SubmitChanges();
            }

            return updSessionResult;
        }
    }
}
