using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentSessionReportsLINQLibrary.DAO.SqlServer
{
    public class SqlServerSessionDAO : ISessionDAO
    {
        private readonly StudentSessionReportsContext _context;

        private static SqlServerSessionDAO instance;

        private SqlServerSessionDAO(StudentSessionReportsContext context)
        {
            _context = context;
        }

        public static SqlServerSessionDAO GetInstance(StudentSessionReportsContext context)
        {
            if (instance == null)
                instance = new SqlServerSessionDAO(context);
            return instance;
        }

        public bool DeleteSession(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session != null)
            {
                _context.Sessions.DeleteOnSubmit(session);
                _context.SubmitChanges();
                return true;
            }

            return false;
        }

        public List<Session> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public Session GetSessionById(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            return session;
        }

        public bool InsertSession(Session session)
        {
            if (session != null)
            {
                _context.Sessions.InsertOnSubmit(session);
                _context.SubmitChanges();

                return true;
            }

            return false;
        }

        public Session UpdateSession(Session session)
        {
            var updSession = _context.Sessions.FirstOrDefault(s => s.Id == session.Id);
            if (updSession != null)
            {
                updSession.NumberOfSession = session.NumberOfSession;
                _context.SubmitChanges();
            }

            return updSession;
        }
    }
}
