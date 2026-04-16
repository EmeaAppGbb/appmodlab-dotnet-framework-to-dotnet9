using System.ComponentModel.DataAnnotations;

namespace NorthwindTechUniversity.Web.Models.ViewModels
{
    public class EnrollmentViewModel
    {
        public int EnrollmentId { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public string? CourseTitle { get; set; }

        [Required]
        public string Semester { get; set; } = string.Empty;

        public string? Grade { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
    }
}
