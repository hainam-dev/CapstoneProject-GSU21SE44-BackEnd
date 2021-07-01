using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Notification")]
    public partial class Notification
    {
        public Notification()
        {
            UsersNotifications = new HashSet<UsersNotification>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string NotificationContent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedTime { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }

        [InverseProperty(nameof(UsersNotification.Notification))]
        public virtual ICollection<UsersNotification> UsersNotifications { get; set; }
    }
}
