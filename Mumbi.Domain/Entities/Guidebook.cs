using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Guidebook")]
    public partial class Guidebook
    {
        public Guidebook()
        {
            GuidebookMoms = new HashSet<GuidebookMom>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        public string GuidebookContent { get; set; }
        public string Image { get; set; }
        [StringLength(10)]
        public string EstimateFinishTime { get; set; }
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedTime { get; set; }
        public int? TypeId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(GuildbookType.Guidebooks))]
        public virtual GuildbookType Type { get; set; }
        [InverseProperty(nameof(GuidebookMom.Guidebook))]
        public virtual ICollection<GuidebookMom> GuidebookMoms { get; set; }
    }
}
