using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Tooth")]
    public partial class Tooth
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ChildId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public byte? Position { get; set; }
        [Column("ImageURL")]
        public string ImageUrl { get; set; }
        [StringLength(50)]
        public string GrowTime { get; set; }
        public string Note { get; set; }
        public bool GrownFlag { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.Teeth))]
        public virtual ChildInfo Child { get; set; }
    }
}
