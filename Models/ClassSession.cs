using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class ClassSession
    {
        [Key]
        public int ClassSessionId { get; set; }

        [Required]
        public int QualificationId { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        [StringLength(200)]
        public string SessionName { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        public int MaxCapacity { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsCancelled { get; set; } = false;

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }

        [ForeignKey("VenueId")]
        public Venue? Venue { get; set; }

        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
