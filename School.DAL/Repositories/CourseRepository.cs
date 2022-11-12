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
        public override IEnumerable<Course> GetEntities()
        {
            return base.GetEntities().Where(cd => !cd.Deleted);
        }

    }

}
