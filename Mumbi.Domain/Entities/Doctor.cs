using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Doctor")]
    public partial class Doctor
    {
        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [Required]
        [StringLength(10)]
        public string FullName { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }
        [StringLength(100)]
        public string FromHospital { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Account.Doctor))]
        public virtual Account IdNavigation { get; set; }
    }
}
