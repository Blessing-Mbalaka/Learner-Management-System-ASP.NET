using System.ComponentModel.DataAnnotations;

namespace Learner_Management_System.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

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

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(500)]
        public string? Specialization { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public ICollection<ClassSession>? ClassSessions { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
