namespace NorthwindTechUniversity.Web.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalEnrollments { get; set; }
        public int TotalFaculty { get; set; }
        
        public List<Student> RecentStudents { get; set; } = new();
        public List<Enrollment> RecentEnrollments { get; set; } = new();
    }
}
