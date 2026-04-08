using System.Data.Entity;
using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.Data
{
    public class NorthwindTechContext : DbContext
    {
        public NorthwindTechContext() : base("NorthwindTechContext")
        {
            // Legacy: Disable lazy loading for performance (or so we thought in 2015)
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Program> Programs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
