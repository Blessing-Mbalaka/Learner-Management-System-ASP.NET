using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        public int LearnerId { get; set; }

        public int? TeacherId { get; set; }

        public int? ClassSessionId { get; set; }

        [Required]
        [StringLength(2000)]
        public string FeedbackText { get; set; } = string.Empty;

        [Range(1, 5)]
        public int? Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime FeedbackDate { get; set; } = DateTime.Now;

        [ForeignKey("LearnerId")]
        public Learners? Learner { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }

        [ForeignKey("ClassSessionId")]
        public ClassSession? ClassSession { get; set; }
    }
}
