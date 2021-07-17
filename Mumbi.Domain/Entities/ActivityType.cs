using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("ActivityType")]
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public bool? DelFlag { get; set; }

        [InverseProperty(nameof(Activity.Type))]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
