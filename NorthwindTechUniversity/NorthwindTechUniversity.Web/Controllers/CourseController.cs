using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Data.Repositories;
using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly NorthwindTechContext _context;

        public CourseController(UnitOfWork unitOfWork, NorthwindTechContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Course
        public IActionResult Index()
        {
            var courses = _unitOfWork.Courses.GetAll();
            return View(courses);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "DepartmentId", "Name");
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Courses.Add(course);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error creating course: " + ex.Message);
                }
            }

            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }
    }
}
