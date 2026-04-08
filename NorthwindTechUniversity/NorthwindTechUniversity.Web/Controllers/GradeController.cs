using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly NorthwindTechContext _context;

        public GradeController(NorthwindTechContext context)
        {
            _context = context;
        }

        // GET: Grade/Entry
        public ActionResult Entry(int enrollmentId)
        {
            var enrollment = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefault(e => e.EnrollmentId == enrollmentId);

            if (enrollment == null)
            {
                return HttpNotFound();
            }

            return View(enrollment);
        }

        // POST: Grade/Entry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entry(int enrollmentId, string grade)
        {
            try
            {
                var enrollment = _context.Enrollments.Find(enrollmentId);
                if (enrollment != null)
                {
                    enrollment.Grade = grade;
                    _context.SaveChanges();
                    TempData["Success"] = "Grade saved successfully.";
                }
                
                return RedirectToAction("Index", "Enrollment");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error saving grade: " + ex.Message;
                return RedirectToAction("Entry", new { enrollmentId = enrollmentId });
            }
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
