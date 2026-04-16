using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class LearnerUpload
    {
        [Key]
        public int UploadId { get; set; }

        [Required]
        public int LearnerId { get; set; }

        public int? AssessmentId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FileType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        [Required]
        [StringLength(50)]
        public string UploadCategory { get; set; } = "General";

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public byte[] FileData { get; set; } = Array.Empty<byte>();

        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;

        [StringLength(500)]
        public string? ReviewComments { get; set; }

        [ForeignKey("LearnerId")]
        public Learners? Learner { get; set; }

        [ForeignKey("AssessmentId")]
        public Assessment? Assessment { get; set; }
    }
}
