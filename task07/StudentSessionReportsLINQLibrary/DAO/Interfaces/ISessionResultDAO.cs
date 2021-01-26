using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;

namespace StudentSessionReportsLINQLibrary.DAO.Interfaces
{
    public interface ISessionResultDAO
    {
        List<SessionResult> GetAllSessionResults();
        SessionResult GetSessionResultById(int id);
        SessionResult UpdateSessionResult(SessionResult sessionResult);
        bool DeleteSessionResult(int id);
        bool InsertSessionResult(SessionResult sessionResult);
    }
}
