using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Dad")]
    public partial class Dad
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }
        [StringLength(15)]
        public string Phonenumber { get; set; }
        [StringLength(10)]
        public string BloodGroup { get; set; }
        [StringLength(10)]
        public string RhBloodGroup { get; set; }
        [Required]
        [StringLength(100)]
        public string MomId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty("Dads")]
        public virtual Mom Mom { get; set; }
    }
}
