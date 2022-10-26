using System;

namespace School.Service.Dtos
{
    public class StudentRemoveDto
    {
        public int Id { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
