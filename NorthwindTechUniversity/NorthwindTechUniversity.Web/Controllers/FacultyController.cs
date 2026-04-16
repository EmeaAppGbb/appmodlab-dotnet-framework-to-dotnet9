using Microsoft.AspNetCore.Mvc;
using NorthwindTechUniversity.Web.Data;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class FacultyController : Controller
    {
        private readonly NorthwindTechContext _context;

        public FacultyController(NorthwindTechContext context)
        {
            _context = context;
        }

        // GET: Faculty
        public IActionResult Index()
        {
            var faculty = _context.Faculties.ToList();
            return View(faculty);
        }
    }
}
