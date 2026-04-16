using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public int LearnerId { get; set; }

        [Required]
        public int QualificationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Status { get; set; } = "Active";

        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? FinalGrade { get; set; }

        [ForeignKey("LearnerId")]
        public Learners? Learner { get; set; }

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }
    }
}
