using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("PregnancyHistory")]
    public partial class PregnancyHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ChildId { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        public short? PregnancyWeek { get; set; }
        public double? Weight { get; set; }
        public double? BiparietalDiameter { get; set; }
        public double? HeadCircumference { get; set; }
        public double? FemurLength { get; set; }
        public double? FetalHeartRate { get; set; }
        public double? MotherWeight { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.PregnancyHistories))]
        public virtual ChildInfo Child { get; set; }
    }
}