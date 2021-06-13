using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("ToothChild")]
    public partial class ToothChild
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ChildId { get; set; }
        public int ToothId { get; set; }
        [StringLength(100)]
        public string EstimateGrowTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GrowTime { get; set; }
        public bool IsGrown { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("ToothChildren")]
        public virtual Child Child { get; set; }
        [ForeignKey(nameof(ToothId))]
        [InverseProperty("ToothChildren")]
        public virtual Tooth Tooth { get; set; }
    }
}
