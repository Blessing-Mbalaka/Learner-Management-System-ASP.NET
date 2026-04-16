using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learner_Management_System.Models
{
    public class Qualification_cost
    {
        [Key]
        public int QualificationCostId { get; set; }

        [Required]
        public int QualificationId { get; set; }

        [Required]
        public int CostId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("QualificationId")]
        public Qualification? Qualification { get; set; }

        [ForeignKey("CostId")]
        public Cost? Cost { get; set; }
    }
}
