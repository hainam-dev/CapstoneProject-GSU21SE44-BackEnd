﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("ToothInfo")]
    public partial class ToothInfo
    {
        public ToothInfo()
        {
            ToothChildren = new HashSet<ToothChild>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        public byte Number { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string GrowTime { get; set; }

        public byte Position { get; set; }

        [InverseProperty(nameof(ToothChild.Tooth))]
        public virtual ICollection<ToothChild> ToothChildren { get; set; }
    }
}