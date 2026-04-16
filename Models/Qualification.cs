using System.ComponentModel.DataAnnotations;

namespace Learner_Management_System.Models
{
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }

        [Required]
        [StringLength(200)]
        public string QualificationName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? QualificationCode { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public int DurationInHours { get; set; }

        [StringLength(50)]
        public string? Level { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Qualification_cost>? QualificationCosts { get; set; }
        public ICollection<ClassSession>? ClassSessions { get; set; }
        public ICollection<Assessment>? Assessments { get; set; }
        public ICollection<Admin>? Admins { get; set; }
        public ICollection<AdminUpload>? AdminUploads { get; set; }
        public ICollection<AssessmentBank>? AssessmentBanks { get; set; }
        public ICollection<RandomizedPaper>? RandomizedPapers { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
