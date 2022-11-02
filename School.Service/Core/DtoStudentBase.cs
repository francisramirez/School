using System;

namespace School.Service.Core
{
    public class DtoStudentBase : DtoAudit
    {
        public DateTime? EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
