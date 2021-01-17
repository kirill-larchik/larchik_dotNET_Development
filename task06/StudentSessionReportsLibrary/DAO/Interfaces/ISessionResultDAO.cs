using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.Interfaces
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
