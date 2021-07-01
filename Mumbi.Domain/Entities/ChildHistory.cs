using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Child_History")]
    public partial class ChildHistory
    {
        [Key]
        public int Id { get; set; }
        [Column("Child_Id")]
        public int ChildId { get; set; }
        [Required]
        [StringLength(50)]
        public string Date { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? HeadCircumference { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.ChildHistories))]
        public virtual ChildInfo Child { get; set; }
    }
}
