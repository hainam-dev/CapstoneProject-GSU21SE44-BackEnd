using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("ChildHistory")]
    public partial class ChildHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ChildId { get; set; }
        [Required]
        [StringLength(50)]
        public string Date { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? HeadCircumference { get; set; }
        public double? HourSleep { get; set; }
        public double? AvgMilk { get; set; }
        public short? WeekOlds { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.ChildHistories))]
        public virtual ChildInfo Child { get; set; }
    }
}
