using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class AdminUpload
    {
        [Key]
        public int UploadId { get; set; }

        [Required]
        public int AdminId { get; set; }

        public int? QualificationId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FileType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        [Required]
        [StringLength(50)]
        public string UploadCategory { get; set; } = "CourseContent";

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public byte[] FileData { get; set; } = Array.Empty<byte>();

        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        public bool IsPublished { get; set; } = false;

        public DocumentWorkflowStatus Status { get; set; } = DocumentWorkflowStatus.Draft;

        public int? UploadedByUserId { get; set; }

        [ForeignKey("AdminId")]
        public Admin? Admin { get; set; }

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        [ForeignKey("UploadedByUserId")]
        public User? UploadedBy { get; set; }

        public ICollection<DocumentWorkflow>? WorkflowHistory { get; set; }
    }
}
