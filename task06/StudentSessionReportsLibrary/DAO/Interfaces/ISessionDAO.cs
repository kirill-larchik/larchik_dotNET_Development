using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.Interfaces
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
