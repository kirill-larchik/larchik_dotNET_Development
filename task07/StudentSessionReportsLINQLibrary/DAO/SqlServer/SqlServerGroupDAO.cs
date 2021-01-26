using StudentSessionReportsLINQLibrary.DAO.Interfaces;
using StudentSessionReportsLINQLibrary.Data;
using StudentSessionReportsLINQLibrary.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentSessionReportsLINQLibrary.DAO.SqlServer
{
    public class SqlServerGroupDAO : IGroupDAO
    {
        private readonly StudentSessionReportsContext _context;

        private static SqlServerGroupDAO instance;

        private SqlServerGroupDAO(StudentSessionReportsContext context)
        {
            _context = context;
        }

        public static SqlServerGroupDAO GetInstance(StudentSessionReportsContext context)
        {
            if (instance == null)
                instance = new SqlServerGroupDAO(context);
            return instance;
        }

        public bool DeleteGroup(int id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group != null)
            {
                _context.Groups.DeleteOnSubmit(group);
                _context.SubmitChanges();
                return true;
            }

            return false;
        }

        public List<Group> GetAllGroups()
        {
            return _context.Groups.ToList();
        }

        public Group GetGroupById(int id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            return group;
        }

        public bool InsertGroup(Group group)
        {
            if (group != null)
            {
                _context.Groups.InsertOnSubmit(group);
                _context.SubmitChanges();

                return true;
            }

            return false;
        }

        public Group UpdateGroup(Group group)
        {
            var updGroup = _context.Groups.FirstOrDefault(g => g.Id == group.Id);
            if (updGroup != null)
            {
                updGroup.Name = group.Name;
                updGroup.SpecialtyId = group.SpecialtyId;
                _context.SubmitChanges();
            }

            return updGroup;
        }
    }
}
