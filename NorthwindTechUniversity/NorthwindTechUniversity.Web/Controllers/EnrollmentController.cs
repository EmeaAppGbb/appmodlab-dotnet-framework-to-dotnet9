using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Models;
using NorthwindTechUniversity.Web.Models.ViewModels;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly NorthwindTechContext _context;
        private readonly IMapper _mapper;

        public EnrollmentController(NorthwindTechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Enrollment
        public IActionResult Index()
        {
            var enrollments = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            var viewModels = enrollments.Select(e => _mapper.Map<EnrollmentViewModel>(e)).ToList();
            return View(viewModels);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(_context.Students.ToList(), "StudentId", "FullName");
            ViewBag.Courses = new SelectList(_context.Courses.ToList(), "CourseId", "Title");
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EnrollmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

                    var enrollment = _mapper.Map<Enrollment>(model);
                    enrollment.EnrollmentDate = DateTime.Now;
                    
                    _context.Enrollments.Add(enrollment);
                    _context.SaveChanges();
                    
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
    }
}
