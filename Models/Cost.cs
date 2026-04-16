using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Cost
    {
        [Key]
        public int CostId { get; set; }

        [Required]
        [StringLength(100)]
        public string CostType { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public ICollection<Qualification_cost>? QualificationCosts { get; set; }
    }
}
