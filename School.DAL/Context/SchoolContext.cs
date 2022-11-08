using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;

namespace School.DAL.Context
{

    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {

        }
        #region "Entities"
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion

    }
}
