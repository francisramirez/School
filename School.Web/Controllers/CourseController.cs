using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Service.Contracts;
using System.Collections.Generic;
using School.Service.Models;
using System.Linq;
namespace School.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var result = _courseService.GetAll();

            List<Models.CourseList> courseLists = new List<Models.CourseList>();

            if (result.Success)
            {
                // Cargamos la lista //
                courseLists = ((List<CourseModel>)result.Data).Select(co => new Models.CourseList()
                {
                    Credits = co.Credits,
                    Department = co.Department,
                    DepartmentId = co.DepartmentId,
                    Id = co.Id,
                    Name = co.Title
                }).ToList(); ;
            }
            else
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(courseLists);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
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

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
