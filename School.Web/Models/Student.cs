using System;

namespace School.Web.Models
{
    public class Student : Person
    {
        public DateTime? EnrollmentDate { get; set; }
        public int CourseId { get; set; }
        public decimal? Grade { get; set; }
    }
}
