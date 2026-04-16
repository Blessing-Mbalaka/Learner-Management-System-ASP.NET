using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public int? QualificationId { get; set; }

        [StringLength(100)]
        public string? Department { get; set; }

        [StringLength(500)]
        public string? Specialization { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? LastLoginDate { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        public ICollection<DocumentWorkflow>? WorkflowActions { get; set; }
    }
}
