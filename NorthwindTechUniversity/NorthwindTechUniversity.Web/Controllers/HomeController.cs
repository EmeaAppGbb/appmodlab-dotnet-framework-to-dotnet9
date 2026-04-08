using System.Linq;
using System.Web.Mvc;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Models.ViewModels;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly NorthwindTechContext _context;

        public HomeController(NorthwindTechContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            // Legacy: Synchronous database calls on the UI thread
            var model = new DashboardViewModel
            {
                TotalStudents = _context.Students.Count(),
                TotalCourses = _context.Courses.Count(),
                TotalEnrollments = _context.Enrollments.Count(),
                TotalFaculty = _context.Faculties.Count(),
                RecentStudents = _context.Students.OrderByDescending(s => s.EnrollmentDate).Take(5).ToList(),
                RecentEnrollments = _context.Enrollments.OrderByDescending(e => e.EnrollmentDate).Take(10).ToList()
            };

            return View(model);
        }
    }
}
