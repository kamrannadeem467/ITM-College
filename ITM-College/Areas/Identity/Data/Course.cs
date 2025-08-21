using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITM_College.Areas.Identity.Data
{
    public class Course
    {
        public Guid CourseID { get; set; }   // Primary Key

        [Required]
        [MaxLength(200)]
        public string CourseName { get; set; }

        public string Description { get; set; }

        [Range(1, 10)]
        public int Credits { get; set; }    // Example: 3 Credit Hours

        [MaxLength(50)]
        public string Duration { get; set; } // Example: "4 Years"

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        // Foreign Key to Department
       
        public Department Department { get; set; }
    }
}
