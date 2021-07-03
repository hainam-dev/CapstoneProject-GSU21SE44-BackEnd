using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Reminder")]
    public partial class Reminder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserId { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [Column(TypeName = "time(0)")]
        public TimeSpan? Time { get; set; }
        [StringLength(100)]
        public string Frequency { get; set; }
        public bool? EnabledFlag { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Reminders")]
        public virtual User User { get; set; }
    }
}
