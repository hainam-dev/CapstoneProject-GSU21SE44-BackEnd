using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    public partial class Tooth
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public int? ToothNumber { get; set; }
        [StringLength(50)]
        public string ToothName { get; set; }
        [StringLength(100)]
        public string EstimateGrowTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GrowTime { get; set; }
        public bool IsGrown { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Child.Tooth))]
        public virtual Child IdNavigation { get; set; }
    }
}
