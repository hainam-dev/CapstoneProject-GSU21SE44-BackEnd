using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("UserNotification")]
    public partial class UserNotification
    {
        [Key]
        public int Id { get; set; }
        public int NotificationId { get; set; }
        [Required]
        [StringLength(100)]
        public string UserId { get; set; }

        [ForeignKey(nameof(NotificationId))]
        [InverseProperty("UserNotifications")]
        public virtual Notification Notification { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserNotifications")]
        public virtual User User { get; set; }
    }
}
