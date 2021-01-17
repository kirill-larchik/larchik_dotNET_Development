using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.Objects
{
    /// <summary>
    /// Session of a student
    /// </summary>
    public class Session : Student
    {
        public int SessionId { get; set; }
        public int NumberOfSession { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Session session &&
                   base.Equals(obj) &&
                   GroupId == session.GroupId &&
                   GroupName == session.GroupName &&
                   StudentId == session.StudentId &&
                   LastName == session.LastName &&
                   FirstName == session.FirstName &&
                   MiddleName == session.MiddleName &&
                   Gender == session.Gender &&
                   Birthday == session.Birthday &&
                   SessionId == session.SessionId &&
                   NumberOfSession == session.NumberOfSession;
        }

        public override int GetHashCode()
        {
            int hashCode = -2058001861;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiddleName);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionId.GetHashCode();
            hashCode = hashCode * -1521134295 + NumberOfSession.GetHashCode();
            return hashCode;
        }
    }
}
