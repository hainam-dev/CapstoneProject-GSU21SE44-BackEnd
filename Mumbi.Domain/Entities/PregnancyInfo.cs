using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Pregnancy_Info")]
    public partial class PregnancyInfo
    {
        [Key]
        public int Id { get; set; }
        [Column("Child_Id")]
        public int ChildId { get; set; }
        [StringLength(50)]
        public string PregnancyWeek { get; set; }
        public double? Weight { get; set; }
        public double? BiparietalDiameter { get; set; }
        public double? FemurLength { get; set; }
        public double? FetalHeartRate { get; set; }
        public double? MotherWeight { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.PregnancyHistories))]
        public virtual ChildInfo Child { get; set; }
    }
}
