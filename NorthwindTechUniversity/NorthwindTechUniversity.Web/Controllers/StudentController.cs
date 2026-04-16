using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IMapper _mapper;

        public StudentController(UnitOfWork unitOfWork, NorthwindTechContext context, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
        }

        // GET: Student
        public IActionResult Index()
        {
            var students = _unitOfWork.Students.GetAll();
            var viewModels = students.Select(s => _mapper.Map<StudentViewModel>(s)).ToList();
            return View(viewModels);
        }

        // GET: Student/Details/5
        public IActionResult Details(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<StudentViewModel>(student);
            return View(viewModel);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewBag.Programs = new SelectList(_context.Programs.ToList(), "ProgramId", "Name");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = _mapper.Map<Student>(model);
                    student.EnrollmentDate = DateTime.Now;
                    
                    _unitOfWork.Students.Add(student);
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

        // GET: Student/Edit/5
        public IActionResult Edit(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<StudentViewModel>(student);
            ViewBag.Programs = new SelectList(_context.Programs.ToList(), "ProgramId", "Name", student.ProgramId);
            return View(viewModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = _mapper.Map<Student>(model);
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
        public IActionResult Delete(int id)
        {
            var student = _unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<StudentViewModel>(student);
            return View(viewModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var student = _unitOfWork.Students.GetById(id);
                if (student != null)
                {
                    _unitOfWork.Students.Remove(student);
                    _unitOfWork.Save();
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Unable to delete. " + ex.Message;
                return RedirectToAction("Delete", new { id = id });
            }
        }
    }
}
