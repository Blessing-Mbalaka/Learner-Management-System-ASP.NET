using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public int LearnerId { get; set; }

        [Required]
        public int ClassSessionId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Present";

        [DataType(DataType.DateTime)]
        public DateTime AttendanceDate { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string? Notes { get; set; }

        [ForeignKey("LearnerId")]
        public Learners? Learner { get; set; }

        [ForeignKey("ClassSessionId")]
        public ClassSession? ClassSession { get; set; }
    }
}
