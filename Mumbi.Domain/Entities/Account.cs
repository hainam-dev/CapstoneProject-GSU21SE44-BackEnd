using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            Reminders = new HashSet<Reminder>();
            Tokens = new HashSet<Token>();
        }

        [Key]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string RoleId { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(Email))]
        [InverseProperty(nameof(Mom.Account))]
        public virtual Mom EmailNavigation { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Accounts")]
        public virtual Role Role { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Dad Dad { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Doctor Doctor { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual staff staff { get; set; }
        [InverseProperty(nameof(Reminder.Account))]
        public virtual ICollection<Reminder> Reminders { get; set; }
        [InverseProperty(nameof(Token.Account))]
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
