using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DAL.Interfaces;
using School.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = this.studentRepository.GetStudnets().ToList().Select(st => new Models.Student()
            {
                PersonID = st.Id,
                FirstName = st.FirstName,
                LastName = st.LastName,
                EnrollmentDate = st.EnrollmentDate
            });

            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student studentModel)
        {
            try
            {
                School.DAL.Entities.Student myStudent = new DAL.Entities.Student()
                {
                    CreationUser= 1,
                    FirstName = studentModel.FirstName,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    LastName = studentModel.LastName,
                    Id = studentModel.PersonID
                };

                studentRepository.Save(myStudent);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {

            var student = studentRepository.GetStudent(id);

            Models.Student Modelstudent = new Models.Student()
            {
                PersonID = student.Id,
                EnrollmentDate = student.EnrollmentDate,
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            return View(Modelstudent);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Student studentModel)
        {
            try
            {
                var myModel = studentModel;

                School.DAL.Entities.Student student = new DAL.Entities.Student()
                {
                    ModifyDate = DateTime.Now,
                    UserMod = 1,
                    FirstName = studentModel.FirstName,
                    EnrollmentDate = studentModel.EnrollmentDate,
                    LastName = studentModel.LastName,
                    Id = studentModel.PersonID
                };

                studentRepository.Update(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
