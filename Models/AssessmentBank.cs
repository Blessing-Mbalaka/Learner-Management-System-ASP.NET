using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class AssessmentBank
    {
        [Key]
        public int AssessmentBankId { get; set; }

        [Required]
        public int QualificationId { get; set; }

        public int? CreatedByUserId { get; set; }

        public int? AssessorDeveloperId { get; set; }

        [Required]
        [StringLength(200)]
        public string BankName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Version { get; set; }

        public DocumentWorkflowStatus Status { get; set; } = DocumentWorkflowStatus.Draft;

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? LastModifiedDate { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        [ForeignKey("CreatedByUserId")]
        public User? CreatedBy { get; set; }

        [ForeignKey("AssessorDeveloperId")]
        public User? AssessorDeveloper { get; set; }

        public ICollection<Assessment>? Assessments { get; set; }
        public ICollection<RandomizedPaper>? RandomizedPapers { get; set; }
        public ICollection<DocumentWorkflow>? WorkflowHistory { get; set; }
    }
}
