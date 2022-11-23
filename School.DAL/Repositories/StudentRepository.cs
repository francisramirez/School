using Microsoft.Extensions.Logging;
using School.DAL.Context;
using School.DAL.Core;
using School.DAL.Entities;
using School.DAL.Interfaces;
using System;

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
        public override void Update(Student entity)
        {
            try
            {
                Student studentToUpdate = base.GetEntity(entity.Id); // Se busca el estudiante a actualizar //

                studentToUpdate.FirstName = entity.FirstName;
                studentToUpdate.LastName = entity.LastName;
                studentToUpdate.EnrollmentDate = entity.EnrollmentDate;
                studentToUpdate.ModifyDate = System.DateTime.Now;
                studentToUpdate.UserMod = entity.UserMod;
                studentToUpdate.Id = entity.Id;

                this.context.Students.Update(studentToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error actualizando el estudiante {ex.Message}",ex.ToString());
                throw ex;
            }
        }

    }
}
