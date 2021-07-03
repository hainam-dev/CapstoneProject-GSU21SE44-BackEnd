using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("NewsMom")]
    public partial class NewsMom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string MomId { get; set; }
        [Required]
        [StringLength(50)]
        public string NewsId { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty(nameof(MomInfo.NewsMoms))]
        public virtual MomInfo Mom { get; set; }
        [ForeignKey(nameof(NewsId))]
        [InverseProperty("NewsMoms")]
        public virtual News News { get; set; }
    }
}
