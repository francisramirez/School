using Microsoft.Extensions.Logging;
using School.DAL.Context;
using School.DAL.Entities;
using School.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace School.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext context;
        private readonly ILogger<StudentRepository> logger;
        public StudentRepository(SchoolContext context, ILogger<StudentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(int studentId)
        {
            return context.Students.Any(cd => cd.Id == studentId);
        }
        public Student GetStudent(int studentId)
        {
            return context.Students.Find(studentId);
        }
        public IEnumerable<Student> GetStudnets()
        {
            return context.Students.OrderByDescending(st => st.CreationDate);
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
                Student studentToModify = GetStudent(student.Id);

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
