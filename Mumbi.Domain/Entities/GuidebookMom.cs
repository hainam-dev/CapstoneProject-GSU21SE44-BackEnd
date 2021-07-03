using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("GuidebookMom")]
    public partial class GuidebookMom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string MomId { get; set; }
        [Required]
        [StringLength(50)]
        public string GuidebookId { get; set; }

        [ForeignKey(nameof(GuidebookId))]
        [InverseProperty("GuidebookMoms")]
        public virtual Guidebook Guidebook { get; set; }
        [ForeignKey(nameof(MomId))]
        [InverseProperty(nameof(MomInfo.GuidebookMoms))]
        public virtual MomInfo Mom { get; set; }
    }
}
