using System;
using System.ComponentModel.DataAnnotations;

namespace NorthwindTechUniversity.Web.Models.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Program")]
        public int? ProgramId { get; set; }

        public string ProgramName { get; set; }
    }
}
