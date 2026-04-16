using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public int QualificationId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? Department { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        public ICollection<AdminUpload>? Uploads { get; set; }
    }
}
