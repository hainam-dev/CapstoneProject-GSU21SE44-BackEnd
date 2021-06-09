using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("GuildbookType")]
    public partial class GuildbookType
    {
        public GuildbookType()
        {
            Guidebooks = new HashSet<Guidebook>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(Guidebook.Type))]
        public virtual ICollection<Guidebook> Guidebooks { get; set; }
    }
}
