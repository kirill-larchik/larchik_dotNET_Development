using System;
using System.Collections.Generic;

namespace StudentLibrary
{
    /// <summary>
    /// A test mark.
    /// </summary>
    public enum Mark
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }

    /// <summary>
    /// Class describing a result of the student test.
    /// </summary>
    public class StudentTest : IComparable<StudentTest>
    {
        /// <summary>
        /// Full name of Student,
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Name of the test.
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Date of conducting the test.
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Mark of the test.
        /// </summary>
        public Mark TestMark { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StudentTest() { }

        /// <summary>
        /// Inits a result test of a student.
        /// </summary>
        /// <param name="fio">The student full name.</param>
        /// <param name="testName">The test name.</param>
        /// <param name="testDate">The test conducting date.</param>
        /// <param name="testMark">The test mark.</param>
        public StudentTest(string fio, string testName, DateTime testDate, Mark testMark)
        {
            FIO = fio;
            TestName = testName;
            TestDate = testDate;
            TestMark = testMark;
        }

        public int CompareTo(StudentTest other)
        {
            return this.GetHashCode().CompareTo(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return obj is StudentTest test &&
                   FIO == test.FIO &&
                   TestName == test.TestName &&
                   TestDate == test.TestDate &&
                   TestMark == test.TestMark;
        }

        public override int GetHashCode()
        {
            int hashCode = 159815148;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FIO);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + TestDate.GetHashCode();
            hashCode = hashCode * -1521134295 + TestMark.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Name: {FIO}, TestName: {TestName}, Date: {TestDate.ToString("d")}, Mark: {(int)TestMark};\n";
        }
    }
}
