using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;

namespace StudentSessionReportsLINQLibrary.DAO.Interfaces
{
    public interface ISessionDAO
    {
        List<Session> GetAllSessions();
        Session GetSessionById(int id);
        Session UpdateSession(Session session);
        bool DeleteSession(int id);
        bool InsertSession(Session session);
    }
}
