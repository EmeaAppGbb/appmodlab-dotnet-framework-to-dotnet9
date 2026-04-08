using System.Linq;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            // Legacy: Direct LINQ queries in controller (no service layer)
            var faculty = _context.Faculties.ToList();
            return View(faculty);
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
