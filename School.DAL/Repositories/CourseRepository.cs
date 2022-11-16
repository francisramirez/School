using Microsoft.Extensions.Logging;
using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace School.DAL.Repositories
{
    public class CourseRepository : Core.RepositoryBase<Course>,  ICourseRepository
    {
        private readonly SchoolContext context;

        private readonly ILogger<StudentRepository> logger;
        public CourseRepository(SchoolContext context,
                                 ILogger<StudentRepository> logger)
            :base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public IEnumerable<Course> GetCoursesByDeparmentId(int departmentId) => this.context.Courses.Where(co => co.DepartmentID == departmentId && !co.Deleted);

        public override IEnumerable<Course> GetEntities() => base.GetEntities().Where(cd => !cd.Deleted);
        public override void Save(Course entity)
        {
            if (this.context.Courses.Any(co => co.Title == entity.Title))
                throw new Exceptions.CourseDataException("El curso ya se encuentra registrado.");

            base.Save(entity);
        }
        public override void Save(Course[] entities)
        {
            if (entities.Any())
                base.Save(entities);
            else
                throw new Exceptions.CourseDataException("Los cursos son requeridos.");

            base.Save(entities);

        }

    }

}
