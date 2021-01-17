using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.Objects
{
    public enum SubjectCheckType
    {
        Exam,
        Test
    }

    /// <summary>
    /// Session results of a student for concrete session.
    /// </summary>
    public class SessionResult : Session
    { 
        public int SessionResultId { get; set; }
        public string SubjectName { get; set; }
        public SubjectCheckType SubjectCheckType { get; set; }
        public DateTime DateOfPassing { get; set; }
        public int Mark { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SessionResult result &&
                   base.Equals(obj) &&
                   GroupId == result.GroupId &&
                   GroupName == result.GroupName &&
                   StudentId == result.StudentId &&
                   LastName == result.LastName &&
                   FirstName == result.FirstName &&
                   MiddleName == result.MiddleName &&
                   Gender == result.Gender &&
                   Birthday == result.Birthday &&
                   SessionId == result.SessionId &&
                   NumberOfSession == result.NumberOfSession &&
                   SessionResultId == result.SessionResultId &&
                   SubjectName == result.SubjectName &&
                   SubjectCheckType == result.SubjectCheckType &&
                   DateOfPassing == result.DateOfPassing &&
                   Mark == result.Mark;
        }

        public override int GetHashCode()
        {
            int hashCode = -38841698;
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
            hashCode = hashCode * -1521134295 + SessionResultId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubjectName);
            hashCode = hashCode * -1521134295 + SubjectCheckType.GetHashCode();
            hashCode = hashCode * -1521134295 + DateOfPassing.GetHashCode();
            hashCode = hashCode * -1521134295 + Mark.GetHashCode();
            return hashCode;
        }
    }
}
