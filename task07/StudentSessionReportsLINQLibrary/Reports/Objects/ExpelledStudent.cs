using System;

namespace StudentSessionReportsLINQLibrary.Reports.Objects
{
    /// <summary>
    /// A expelled student.
    /// </summary>
    public class ExpelledStudent
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
