using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("UsersNotification")]
    public partial class UsersNotification
    {
        [Key]
        public int Id { get; set; }
        [Column("Notification_Id")]
        public int NotificationId { get; set; }
        [Required]
        [Column("User_Id")]
        [StringLength(100)]
        public string UserId { get; set; }

        [ForeignKey(nameof(NotificationId))]
        [InverseProperty("UsersNotifications")]
        public virtual Notification Notification { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UsersNotifications")]
        public virtual User User { get; set; }
    }
}
