
using System;

namespace School.Service.Dtos
{
    public class SaveCourseDto
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
