using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.Objects
{
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// A studennt of concrete group.
    /// </summary>
    public class Student : Group
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   base.Equals(obj) &&
                   GroupId == student.GroupId &&
                   GroupName == student.GroupName &&
                   StudentId == student.StudentId &&
                   LastName == student.LastName &&
                   FirstName == student.FirstName &&
                   MiddleName == student.MiddleName &&
                   Gender == student.Gender &&
                   Birthday == student.Birthday;
        }

        public override int GetHashCode()
        {
            int hashCode = 1926721806;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiddleName);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}
