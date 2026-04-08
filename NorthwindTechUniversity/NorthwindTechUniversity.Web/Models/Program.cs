using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTechUniversity.Web.Models
{
    public class Program
    {
        [Key]
        public int ProgramId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int RequiredCredits { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
