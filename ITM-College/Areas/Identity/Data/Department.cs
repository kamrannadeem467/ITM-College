using System.ComponentModel.DataAnnotations;

namespace ITM_College.Areas.Identity.Data
{
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(100)]
        public string? HOD { get; set; }   // Head of Department

        [EmailAddress]
        public string? ContactEmail { get; set; }

        [StringLength(15)]
        public string? ContactPhone { get; set; }
    }
}
