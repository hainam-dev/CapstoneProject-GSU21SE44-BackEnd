using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Token")]
    public partial class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string AccountId { get; set; }
        [Required]
        public string FcmToken { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Tokens")]
        public virtual Account Account { get; set; }
    }
}
