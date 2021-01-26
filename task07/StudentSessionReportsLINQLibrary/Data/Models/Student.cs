using System;
using System.Data.Linq.Mapping;

namespace StudentSessionReportsLINQLibrary.Data.Models
{
    /// <summary>
    /// A studennt of concrete group.
    /// </summary>
    [Table(Name = "Students")]
    public class Student
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "LastName")]
        public string LastName { get; set; }

        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [Column(Name = "Gender")]
        public string Gender { get; set; }

        [Column(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Column(Name = "GroupId")]
        public int GroupId { get; set; }
    }
}
