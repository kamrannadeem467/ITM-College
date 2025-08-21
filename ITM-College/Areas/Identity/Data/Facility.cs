using System.ComponentModel.DataAnnotations;

namespace ITM_College.Areas.Identity.Data
{
    public class Facility
    {
        public Guid FacilityId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
