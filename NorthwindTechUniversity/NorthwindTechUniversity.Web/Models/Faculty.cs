using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTechUniversity.Web.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

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

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
