using Microsoft.Extensions.Logging;
using School.DAL.Context;
using School.DAL.Core;
using School.DAL.Entities;
using School.DAL.Interfaces;
    

namespace School.DAL.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly SchoolContext context;
        private readonly ILogger<StudentRepository> logger;
        private readonly IUnitOfWork unitOfWork;

        public StudentRepository(SchoolContext context, 
                                 ILogger<StudentRepository> logger, IUnitOfWork unitOfWork)
            : base(new DbFactory.DbFactory(context))
        {
            this.context = context;
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }
        public override void Save(Student entity)
        {
            base.Save(entity);
            this.unitOfWork.SaveChanges();

        }

    }
}
