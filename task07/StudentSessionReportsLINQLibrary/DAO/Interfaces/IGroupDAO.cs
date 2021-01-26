using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;

namespace StudentSessionReportsLINQLibrary.DAO.Interfaces
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
