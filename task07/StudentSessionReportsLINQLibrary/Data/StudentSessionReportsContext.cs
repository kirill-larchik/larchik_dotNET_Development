using StudentSessionReportsLINQLibrary.Data.Models;
using System.Data.Linq;

namespace StudentSessionReportsLINQLibrary.Data
{
    /// <summary>
    /// A DataContext for student session reports.
    /// </summary>
    public class StudentSessionReportsContext : DataContext
    {
        /// <summary>
        /// Inint a data context with connection string.
        /// </summary>
        /// <param name="connection"></param>
        public StudentSessionReportsContext(string connection)
            : base(connection)
        {  }

        /// <summary>
        /// Returns "Specialties" table.
        /// </summary>
        public Table<Specialty> Specialties { get { return this.GetTable<Specialty>(); } }

        /// <summary>
        /// Returns "Groups" table.
        /// </summary>
        public Table<Group> Groups { get { return this.GetTable<Group>(); } }

        /// <summary>
        /// Returns "Students" table.
        /// </summary>
        public Table<Student> Students { get { return this.GetTable<Student>(); } }

        /// <summary>
        /// Returns "Sessions" table.
        /// </summary>
        public Table<Session> Sessions { get { return this.GetTable<Session>(); } }

        /// <summary>
        /// Returns "SessionResults" table.
        /// </summary>
        public Table<SessionResult> SessionResults { get { return this.GetTable<SessionResult>(); } }
    }
}
