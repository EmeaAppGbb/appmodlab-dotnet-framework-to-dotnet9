namespace NorthwindTechUniversity.Web.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly NorthwindTechContext _context;
        private StudentRepository? _studentRepository;
        private CourseRepository? _courseRepository;

        public UnitOfWork(NorthwindTechContext context)
        {
            _context = context;
        }

        public StudentRepository Students
        {
            get
            {
                _studentRepository ??= new StudentRepository(_context);
                return _studentRepository;
            }
        }

        public CourseRepository Courses
        {
            get
            {
                _courseRepository ??= new CourseRepository(_context);
                return _courseRepository;
            }
        }

        public void Save()
        {
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
