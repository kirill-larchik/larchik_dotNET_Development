using StudentSessionReportsLibrary.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.DAOFactory
{
    public abstract class DAOFactory
    {
        public abstract IGroupDAO GetGroupDAO();
        public abstract ISessionDAO GetSessionDAO();
        public abstract ISessionResultDAO GetSessionResultDAO();
        public abstract IStudentDAO GetStudentDAO();
    }
}
