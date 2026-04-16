using System.ComponentModel.DataAnnotations;

namespace Learner_Management_System.Models
{
    public class Learners
    {
        [Key]
        public int LearnerId { get; set; }

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
        public string? Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Grades>? Grades { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<LearnerUpload>? Uploads { get; set; }
    }
}
