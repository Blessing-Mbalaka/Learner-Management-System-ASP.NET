using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class DocumentWorkflow
    {
        [Key]
        public int WorkflowId { get; set; }

        [StringLength(50)]
        public string? DocumentType { get; set; }

        public int? AssessmentBankId { get; set; }

        public int? AdminUploadId { get; set; }

        public int? AssessmentId { get; set; }

        public int? RandomizedPaperId { get; set; }

        [Required]
        public DocumentWorkflowStatus Status { get; set; }

        public DocumentWorkflowStatus? PreviousStatus { get; set; }

        [Required]
        public int ActionByUserId { get; set; }

        [StringLength(2000)]
        public string? Comments { get; set; }

        [StringLength(2000)]
        public string? Feedback { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ActionDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; }

        [ForeignKey("AssessmentBankId")]
        public AssessmentBank? AssessmentBank { get; set; }

        [ForeignKey("AdminUploadId")]
        public AdminUpload? AdminUpload { get; set; }

        [ForeignKey("AssessmentId")]
        public Assessment? Assessment { get; set; }

        [ForeignKey("RandomizedPaperId")]
        public RandomizedPaper? RandomizedPaper { get; set; }

        [ForeignKey("ActionByUserId")]
        public User? ActionBy { get; set; }
    }
}
