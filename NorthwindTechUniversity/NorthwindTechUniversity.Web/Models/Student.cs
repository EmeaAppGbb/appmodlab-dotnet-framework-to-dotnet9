using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTechUniversity.Web.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int? ProgramId { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
