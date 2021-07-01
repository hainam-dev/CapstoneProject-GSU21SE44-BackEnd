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
        [Column("ImageURL")]
        public string ImageUrl { get; set; }
        public short? EstimatedFinishTime { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [StringLength(100)]
        public string LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedTime { get; set; }
        [Column("GuidebookType_Id")]
        public int? GuidebookTypeId { get; set; }
        public bool DelFlag { get; set; }

        [ForeignKey(nameof(GuidebookTypeId))]
        [InverseProperty("Guidebooks")]
        public virtual GuidebookType GuidebookType { get; set; }
        [InverseProperty(nameof(GuidebookMom.Guidebook))]
        public virtual ICollection<GuidebookMom> GuidebookMoms { get; set; }
    }
}
