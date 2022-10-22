namespace School.DAL.Entities
{
    public class Course : Core.BaseEntity
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}