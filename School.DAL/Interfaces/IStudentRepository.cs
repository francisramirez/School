﻿using School.DAL.Entities;

namespace School.DAL.Interfaces
{
    public interface IStudentRepository
    {
        void Save(Student student);
        void Update(Student student);
        void Remove(Student student);
        Student GetStudent(int studentId);
        bool Exists(int studentId);

    }
}
