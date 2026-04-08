using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Models;
using NorthwindTechUniversity.Web.Models.ViewModels;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly NorthwindTechContext _context;

        public EnrollmentController(NorthwindTechContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public ActionResult Index()
        {
            // Legacy: N+1 query problem - eager loading not optimized
            var enrollments = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            var viewModels = enrollments.Select(e => Mapper.Map<EnrollmentViewModel>(e)).ToList();
            return View(viewModels);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            ViewBag.Students = new SelectList(_context.Students.ToList(), "StudentId", "FullName");
            ViewBag.Courses = new SelectList(_context.Courses.ToList(), "CourseId", "Title");
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Legacy: Manual validation instead of business logic layer
                    var existingEnrollment = _context.Enrollments
                        .FirstOrDefault(e => e.StudentId == model.StudentId && 
                                           e.CourseId == model.CourseId && 
                                           e.Semester == model.Semester);

                    if (existingEnrollment != null)
                    {
                        ModelState.AddModelError("", "Student is already enrolled in this course for this semester.");
                        ViewBag.Students = new SelectList(_context.Students.ToList(), "StudentId", "FullName", model.StudentId);
                        ViewBag.Courses = new SelectList(_context.Courses.ToList(), "CourseId", "Title", model.CourseId);
                        return View(model);
                    }

                    var enrollment = Mapper.Map<Enrollment>(model);
                    enrollment.EnrollmentDate = DateTime.Now;
                    
                    _context.Enrollments.Add(enrollment);
                    _context.SaveChanges(); // Direct DbContext usage (inconsistent with other controllers)
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error creating enrollment: " + ex.Message);
                }
            }

            ViewBag.Students = new SelectList(_context.Students.ToList(), "StudentId", "FullName", model.StudentId);
            ViewBag.Courses = new SelectList(_context.Courses.ToList(), "CourseId", "Title", model.CourseId);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
