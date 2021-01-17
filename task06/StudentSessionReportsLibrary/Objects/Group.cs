using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.Objects
{
    /// <summary>
    /// Group of a student.
    /// </summary>
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Group group &&
                   GroupId == group.GroupId &&
                   GroupName == group.GroupName;
        }

        public override int GetHashCode()
        {
            int hashCode = 746186864;
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            return hashCode;
        }
    }
}
