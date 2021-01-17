using StudentSessionReportsLibrary.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.DAOFactory
{
    /// <summary>
    /// Factory for creating DAO for each object. 
    /// </summary>
    public abstract class DAOFactory
    {
        /// <summary>
        /// Returns DAO object for Group object.
        /// </summary>
        /// <returns></returns>
        public abstract IGroupDAO GetGroupDAO();

        /// <summary>
        /// Returns DAO object for Session object.
        /// </summary>
        public abstract ISessionDAO GetSessionDAO();

        /// <summary>
        /// Returns DAO object for Session result object.
        /// </summary>
        /// <returns></returns>
        public abstract ISessionResultDAO GetSessionResultDAO();

        /// <summary>
        /// Returns DAO object for Student object.
        /// </summary>
        /// <returns></returns>
        public abstract IStudentDAO GetStudentDAO();
    }
}
