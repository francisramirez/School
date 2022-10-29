

using System;

namespace School.Service.Dtos
{
    public class UpdateCourse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public int UserMod { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
