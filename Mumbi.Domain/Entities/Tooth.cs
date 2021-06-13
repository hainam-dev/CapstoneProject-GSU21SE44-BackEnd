using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Tooth")]
    public partial class Tooth
    {
        public Tooth()
        {
            ToothChildren = new HashSet<ToothChild>();
        }

        [Key]
        public int Id { get; set; }
        public int? ToothNumber { get; set; }
        [StringLength(50)]
        public string ToothName { get; set; }

        [InverseProperty(nameof(ToothChild.Tooth))]
        public virtual ICollection<ToothChild> ToothChildren { get; set; }
    }
}
