using System;

namespace NorthwindTechUniversity.Web.Data.Repositories
{
    // Legacy: Unit of Work pattern wrapping EF6 (which already has UoW via DbContext!)
    public class UnitOfWork : IDisposable
    {
        private readonly NorthwindTechContext _context;
        private StudentRepository _studentRepository;
        private CourseRepository _courseRepository;

        public UnitOfWork(NorthwindTechContext context)
        {
            _context = context;
        }

        public StudentRepository Students
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            }
        }

        public CourseRepository Courses
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(_context);
                return _courseRepository;
            }
        }

        public void Save()
        {
            // TODO: make this async
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
