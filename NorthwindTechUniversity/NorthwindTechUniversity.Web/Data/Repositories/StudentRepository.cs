using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.Data.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly NorthwindTechContext _context;

        public StudentRepository(NorthwindTechContext context)
        {
            _context = context;
        }

        // Legacy: All synchronous calls (no async/await)
        public IEnumerable<Student> GetAll()
        {
            // TODO: make this async
            return _context.Students
                .Include(s => s.Program)
                .ToList();
        }

        public Student GetById(int id)
        {
            // TODO: make this async
            return _context.Students
                .Include(s => s.Program)
                .FirstOrDefault(s => s.StudentId == id);
        }

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return _context.Students
                .Include(s => s.Program)
                .Where(predicate)
                .ToList();
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
        }

        public void Update(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(Student entity)
        {
            _context.Students.Remove(entity);
        }
    }
}
