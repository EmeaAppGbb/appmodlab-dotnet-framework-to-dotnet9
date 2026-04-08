using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTechUniversity.Web.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        public int? HeadFacultyId { get; set; }

        [ForeignKey("HeadFacultyId")]
        public virtual Faculty HeadFaculty { get; set; }
    }
}
