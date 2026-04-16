using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }

        [Required]
        public int QualificationId { get; set; }

        public int? AssessmentBankId { get; set; }

        public int? CreatedByUserId { get; set; }

        [Required]
        [StringLength(200)]
        public string AssessmentName { get; set; } = string.Empty;

        [StringLength(50)]
        public string AssessmentType { get; set; } = "Exam";

        [StringLength(1000)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal MaxScore { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PassingScore { get; set; }

        public int WeightPercentage { get; set; }

        public DocumentWorkflowStatus Status { get; set; } = DocumentWorkflowStatus.Draft;

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        [ForeignKey("AssessmentBankId")]
        public AssessmentBank? AssessmentBank { get; set; }

        [ForeignKey("CreatedByUserId")]
        public User? CreatedBy { get; set; }

        public ICollection<Grades>? Grades { get; set; }
        public ICollection<LearnerUpload>? Uploads { get; set; }
        public ICollection<DocumentWorkflow>? WorkflowHistory { get; set; }
    }
}
