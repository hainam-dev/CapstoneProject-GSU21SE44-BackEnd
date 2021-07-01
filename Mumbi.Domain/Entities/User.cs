using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Reminders = new HashSet<Reminder>();
            Tokens = new HashSet<Token>();
            UsersNotifications = new HashSet<UsersNotification>();
        }

        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("Role_Id")]
        [StringLength(10)]
        public string RoleId { get; set; }
        public bool DelFlag { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual MomInfo MomInfo { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual UserInfo UserInfo { get; set; }
        [InverseProperty(nameof(Reminder.User))]
        public virtual ICollection<Reminder> Reminders { get; set; }
        [InverseProperty(nameof(Token.User))]
        public virtual ICollection<Token> Tokens { get; set; }
        [InverseProperty(nameof(UsersNotification.User))]
        public virtual ICollection<UsersNotification> UsersNotifications { get; set; }
    }
}
