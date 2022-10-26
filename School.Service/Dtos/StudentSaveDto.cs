using System;

namespace School.Service.Dtos
{
    public class StudentSaveDto
    {
        public DateTime? EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
