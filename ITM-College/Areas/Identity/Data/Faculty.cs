using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITM_College.Areas.Identity.Data
{
    public class Faculty
    {
        public Guid FacultyId { get; set; }

        [Required]
        [StringLength(150)]
        public string FacultyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Designation { get; set; }  // e.g., Professor, Lecturer

        public string Description { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Qualification { get; set; }

        public string ImageUrl { get; set; }

        public string Achievements { get; set; }

        public string SocialLink { get; set; }



        // Foreign Key
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }  // Navigation Property
    }
}
