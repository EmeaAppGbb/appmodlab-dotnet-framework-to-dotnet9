using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.Data.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly NorthwindTechContext _context;

        public CourseRepository(NorthwindTechContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Department)
                .ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses
                .Include(c => c.Department)
                .FirstOrDefault(c => c.CourseId == id);
        }

        public IEnumerable<Course> Find(Expression<Func<Course, bool>> predicate)
        {
            return _context.Courses
                .Include(c => c.Department)
                .Where(predicate)
                .ToList();
        }

        public void Add(Course entity)
        {
            _context.Courses.Add(entity);
        }

        public void Update(Course entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(Course entity)
        {
            _context.Courses.Remove(entity);
        }
    }
}
