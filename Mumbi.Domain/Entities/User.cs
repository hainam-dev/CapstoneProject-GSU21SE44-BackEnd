using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            UserNotifications = new HashSet<UserNotification>();
        }

        [Key]
        [StringLength(100)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
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

        [InverseProperty(nameof(UserNotification.User))]
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}