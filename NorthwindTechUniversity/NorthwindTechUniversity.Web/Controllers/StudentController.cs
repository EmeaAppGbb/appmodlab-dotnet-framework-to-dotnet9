using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using NorthwindTechUniversity.Web.Data;
using NorthwindTechUniversity.Web.Data.Repositories;
using NorthwindTechUniversity.Web.Models;
using NorthwindTechUniversity.Web.Models.ViewModels;

namespace NorthwindTechUniversity.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly NorthwindTechContext _context;

        // Legacy: Mixed use of repository pattern and direct DbContext access
        public StudentController(UnitOfWork unitOfWork, NorthwindTechContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Student
        public ActionResult Index()
        {
            // Legacy: Synchronous repository call
            var students = _unitOfWork.Students.GetAll();
            var viewModels = students.Select(s => Mapper.Map<StudentViewModel>(s)).ToList();
            return View(viewModels);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<StudentViewModel>(student);
            return View(viewModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.Programs = new SelectList(_context.Programs.ToList(), "ProgramId", "Name");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = Mapper.Map<Student>(model);
                    student.EnrollmentDate = DateTime.Now;
                    
                    _unitOfWork.Students.Add(student);
                    _unitOfWork.Save(); // Synchronous save
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Legacy: Poor error handling
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }

            ViewBag.Programs = new SelectList(_context.Programs.ToList(), "ProgramId", "Name", model.ProgramId);
            return View(model);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<StudentViewModel>(student);
            ViewBag.Programs = new SelectList(_context.Programs.ToList(), "ProgramId", "Name", student.ProgramId);
            return View(viewModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = Mapper.Map<Student>(model);
                    _unitOfWork.Students.Update(student);
                    _unitOfWork.Save();
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }

            ViewBag.Programs = new SelectList(_context.Programs.ToList(), "ProgramId", "Name", model.ProgramId);
            return View(model);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<StudentViewModel>(student);
            return View(viewModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var student = _unitOfWork.Students.GetById(id);
                _unitOfWork.Students.Remove(student);
                _unitOfWork.Save();
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // TODO: Log this error properly
                TempData["Error"] = "Unable to delete. " + ex.Message;
                return RedirectToAction("Delete", new { id = id });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
