using System.Data.Linq.Mapping;

namespace StudentSessionReportsLINQLibrary.Data.Models
{
    /// <summary>
    /// Session of a student
    /// </summary>
    [Table(Name = "Sessions")]
    public class Session
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "NumberOfSession")]
        public int NumberOfSession { get; set; }

        [Column(Name = "StudentId")]
        public int StudentId { get; set; }
    }
}
