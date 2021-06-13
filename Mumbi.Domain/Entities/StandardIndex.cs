using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("StandardIndex")]
    public partial class StandardIndex
    {
        [Key]
        public int Id { get; set; }
        public int Month { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
        public int Gender { get; set; }
        [Required]
        [StringLength(10)]
        public string Unit { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}
