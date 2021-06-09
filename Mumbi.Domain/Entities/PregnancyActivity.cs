using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("PregnancyActivity")]
    public partial class PregnancyActivity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(16)]
        public string ActivityName { get; set; }
        public string MediaFile { get; set; }
        [Required]
        [StringLength(30)]
        public string IsDone { get; set; }
        public int? TypeId { get; set; }
        [StringLength(50)]
        public string ChildId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("PregnancyActivities")]
        public virtual Child Child { get; set; }
        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(PregnancyActivityType.PregnancyActivities))]
        public virtual PregnancyActivityType Type { get; set; }
    }
}
