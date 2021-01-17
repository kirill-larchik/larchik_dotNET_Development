using StudentSessionReportsLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSessionReportsLibrary.DAO.Interfaces
{
    public interface IGroupDAO
    {
        List<Group> GetAllGroups();
        Group GetGroupById(int id);
        Group UpdateGroup(Group group);
        bool DeleteGroup(int id);
        bool InsertGroup(Group group);
    }
}
