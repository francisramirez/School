using System;

namespace School.Service.Dtos
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ModifyUser { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
