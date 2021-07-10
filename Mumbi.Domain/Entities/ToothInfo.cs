using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("ToothInfo")]
    public partial class ToothInfo
    {
        public ToothInfo()
        {
            Teeth = new HashSet<Tooth>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public byte Position { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string GrowTime { get; set; }
        public byte Index { get; set; }

        [InverseProperty(nameof(Tooth.ToothNavigation))]
        public virtual ICollection<Tooth> Teeth { get; set; }
    }
}
