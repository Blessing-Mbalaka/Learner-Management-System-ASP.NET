using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Grades
    {
        [Key]
        public int GradeId { get; set; }

        [Required]
        public int LearnerId { get; set; }

        [Required]
        public int AssessmentId { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Score { get; set; }

        [StringLength(10)]
        public string? LetterGrade { get; set; }

        [StringLength(500)]
        public string? Comments { get; set; }

        [DataType(DataType.Date)]
        public DateTime GradeDate { get; set; } = DateTime.Now;

        [ForeignKey("LearnerId")]
        public Learners? Learner { get; set; }

        [ForeignKey("AssessmentId")]
        public Assessment? Assessment { get; set; }
    }
}
