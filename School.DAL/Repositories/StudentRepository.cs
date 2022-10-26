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
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext context;
        private readonly ILogger<StudentRepository> logger;
        public StudentRepository(SchoolContext context, 
                                 ILogger<StudentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(Expression<Func<Student, bool>> filter)
        {
            return context.Students.Any(filter);
        }

        public IEnumerable<Student> GetEntities()
        {
            return context.Students.OrderByDescending(st => st.CreationDate);
        }
        public Student GetEntity(int studentId)
        {
            return context.Students.Find(studentId);
        }
        public void Remove(Student student)
        {
            context.Students.Remove(student);
        }
        public void Save(Student student)
        {   
            context.Students.Add(student);
            context.SaveChanges();
        }
        public void Update(Student student)
        {
            try
            {
                Student studentToModify = GetEntity(student.Id);

                studentToModify.FirstName = student.FirstName;
                studentToModify.LastName = student.LastName;
                studentToModify.ModifyDate = student.ModifyDate;
                studentToModify.UserMod = student.UserMod;
                studentToModify.EnrollmentDate = student.EnrollmentDate;
                studentToModify.Id = student.Id;

                context.Students.Update(studentToModify);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error: { ex.Message}", ex.ToString());
            }
        }
    }
}
