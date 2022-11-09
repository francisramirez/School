using Microsoft.Extensions.Logging;
using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace School.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext context;
       
        private readonly ILogger<StudentRepository> logger;
        public CourseRepository(SchoolContext context,
                                 ILogger<StudentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(int courseId)
        {
            return context.Courses.Any(cd => cd.CourseID == courseId);
        }
        public bool Exists(Expression<Func<Course, bool>> filter)
        {
            return this.context.Courses.Any(filter);
        }
        public IEnumerable<Course> GetEntities()
        {
            return context.Courses.OrderByDescending(st => st.CreationDate);
        }
        public Course GetEntity(int courseId)
        {
            return context.Courses.Find(courseId);
        }
        public void Remove(Course course)
        {
            try
            {
                context.Courses.Remove(course);

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error removiendo el curso {ex.Message}", ex.ToString());
            }
        }
        public void Save(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }
        public void Update(Course course)
        {
            throw new System.NotImplementedException();
        }
    }

}
