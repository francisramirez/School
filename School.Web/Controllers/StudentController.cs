using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            IEnumerable<Student> students = new List<Student>()
            {
                new Student 
                {  
                    CourseId = 1, 
                    Discriminator = "S", 
                    EnrollmentDate = DateTime.Now, 
                    FirstName ="Jose", 
                    LastName ="Perez", 
                    Grade = 80
                },
                new Student {     
                    CourseId = 2,
                    Discriminator = "P",
                    EnrollmentDate = DateTime.Now,
                    FirstName ="Juan", 
                    LastName ="De Leon", 
                    Grade = 80
              },
            };

            List<Student> studentsList = new List<Student>();

            


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
        public ActionResult Create(Student student)
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
