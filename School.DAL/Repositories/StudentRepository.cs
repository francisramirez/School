using Microsoft.Extensions.Logging;
using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Interfaces;
    

namespace School.DAL.Repositories
{
    public class StudentRepository : Core.RepositoryBase<Student>, IStudentRepository
    {
        private readonly SchoolContext context;
        private readonly ILogger<StudentRepository> logger;
        public StudentRepository(SchoolContext context, 
                                 ILogger<StudentRepository> logger)
            : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    
    }
}
