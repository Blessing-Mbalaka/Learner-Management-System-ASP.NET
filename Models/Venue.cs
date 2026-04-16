using System.ComponentModel.DataAnnotations;

namespace Learner_Management_System.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required]
        [StringLength(200)]
        public string VenueName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        public int Capacity { get; set; }

        [StringLength(500)]
        public string? Facilities { get; set; }

        public bool IsAvailable { get; set; } = true;

        public ICollection<ClassSession>? ClassSessions { get; set; }
    }
}
