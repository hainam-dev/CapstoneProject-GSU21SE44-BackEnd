using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Diary")]
    public partial class Diary
    {
        [Key]
        public int Id { get; set; }
        public string ChildId { get; set; }
        [Column("ImageURL")]
        public string ImageUrl { get; set; }
        [Required]
        public string DiaryContent { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [StringLength(200)]
        public string LastModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedTime { get; set; }
        public bool ApprovedFlag { get; set; }
        public bool PublicFlag { get; set; }
        public bool DelFlag { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.Diaries))]
        public virtual ChildInfo Child { get; set; }
    }
}
