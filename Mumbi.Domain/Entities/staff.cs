using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Staff")]
    public partial class staff
    {
        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Account.staff))]
        public virtual Account IdNavigation { get; set; }
    }
}
