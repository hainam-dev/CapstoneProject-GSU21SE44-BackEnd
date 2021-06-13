using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("PregnancyInformation")]
    public partial class PregnancyInformation
    {
        [Key]
        [Column("ChildID")]
        [StringLength(50)]
        public string ChildId { get; set; }
        public double? Weight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CalculatedBornDate { get; set; }
        public double? HeadCircumference { get; set; }
        public double? FemurLength { get; set; }
        public double? FetalHeartRate { get; set; }
        public int? PregnancyWeek { get; set; }
        [StringLength(50)]
        public string PregnancyType { get; set; }
        public int? MotherMenstrualCycleTime { get; set; }
        public double? MotherWeight { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("PregnancyInformation")]
        public virtual Child Child { get; set; }
    }
}
