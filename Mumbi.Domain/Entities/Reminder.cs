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
        [StringLength(200)]
        public string TypeRemind { get; set; }
        public TimeSpan? Time { get; set; }
        public bool? IsActive { get; set; }
        [StringLength(100)]
        public string Frequency { get; set; }
        [Required]
        [StringLength(100)]
        public string AccountId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Reminders")]
        public virtual Account Account { get; set; }
    }
}
