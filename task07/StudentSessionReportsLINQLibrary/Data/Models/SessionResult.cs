using System;
using System.Data.Linq.Mapping;

namespace StudentSessionReportsLINQLibrary.Data.Models
{
    /// <summary>
    /// Session results of a student for concrete session.
    /// </summary>
    [Table(Name = "SessionResults")]
    public class SessionResult
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "SessionId")]
        public int SessionId { get; set; }

        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        [Column(Name = "SubjectCheckType")]
        public string SubjectCheckType { get; set; }

        [Column(Name = "TeacherFullName")]
        public string TeacherFullName { get; set; }

        [Column(Name = "DateOfPassing")]
        public DateTime DateOfPassing { get; set; }

        [Column(Name = "Mark")]
        public int Mark { get; set; }
    }
}
