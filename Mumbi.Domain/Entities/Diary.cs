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
        public string Image { get; set; }
        [Required]
        public string DiaryContent { get; set; }
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedTime { get; set; }
        public bool IsPublic { get; set; }
        [Required]
        [StringLength(50)]
        public string ChildId { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsApproved { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("Diaries")]
        public virtual Child Child { get; set; }
    }
}
