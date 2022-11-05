using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Service.Contracts;
using School.Web.Models;
using System.Collections.Generic;
using School.Web.Extentions;
namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = ((List<Service.Models.StudentModel>)_studentService.Gets().Data)
                                                                              .ConvertStudentModelToModel();

            ///var students = StudentExtentions.GetStudents(mystudents);


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
                Service.Dtos.StudentSaveDto saveStudnetDto = new Service.Dtos.StudentSaveDto()
                {
                    UserId = 1,
                    AuditDate = System.DateTime.Now,
                    EnrollmentDate = studentModel.EnrollmentDate.Value,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName
                };

                _studentService.SaveStudent(saveStudnetDto);

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

           var student =(Service.Models.StudentModel)_studentService.GetById(id).Data;

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
        public ActionResult Edit(Student studentModel)
        {
            try
            {
                var myModel = studentModel;

                Service.Dtos.StudentUpdateDto studentUpdate = new Service.Dtos.StudentUpdateDto()
                {
                    Id = studentModel.PersonID,
                    AuditDate = System.DateTime.Now,
                    EnrollmentDate = studentModel.EnrollmentDate.Value,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    UserId = 1
                };

                _studentService.UpdateStudent(studentUpdate);
              
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
