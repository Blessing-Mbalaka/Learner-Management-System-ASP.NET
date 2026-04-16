using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Learner_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }

        public int? QualificationId { get; set; }

        [StringLength(100)]
        public string? Department { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastLoginDate { get; set; }

        // Navigation properties
        public Qualification? Qualification { get; set; }
    }
}
