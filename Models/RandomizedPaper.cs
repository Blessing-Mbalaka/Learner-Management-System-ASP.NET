using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class RandomizedPaper
    {
        [Key]
        public int RandomizedPaperId { get; set; }

        [Required]
        public int AssessmentBankId { get; set; }

        public int? QualificationId { get; set; }

        public int? UploadedByUserId { get; set; }

        [Required]
        [StringLength(200)]
        public string PaperName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? PaperVersion { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FileType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        [Required]
        public byte[] FileData { get; set; } = Array.Empty<byte>();

        [StringLength(100)]
        public string? RandomizationSeed { get; set; }

        public int? QuestionPoolSize { get; set; }

        public int? QuestionsPerPaper { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public DocumentWorkflowStatus Status { get; set; } = DocumentWorkflowStatus.Draft;

        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? LastModifiedDate { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("AssessmentBankId")]
        public AssessmentBank? AssessmentBank { get; set; }

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        [ForeignKey("UploadedByUserId")]
        public User? UploadedBy { get; set; }

        public ICollection<DocumentWorkflow>? WorkflowHistory { get; set; }
    }
}
