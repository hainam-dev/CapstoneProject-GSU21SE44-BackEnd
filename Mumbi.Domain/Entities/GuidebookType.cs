using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Guidebook_Type")]
    public partial class GuidebookType
    {
        public GuidebookType()
        {
            Guidebooks = new HashSet<Guidebook>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        public bool DelFlag { get; set; }

        [InverseProperty(nameof(Guidebook.GuidebookType))]
        public virtual ICollection<Guidebook> Guidebooks { get; set; }
    }
}
