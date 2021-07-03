using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Action")]
    public partial class Action
    {
        public Action()
        {
            ActionChildren = new HashSet<ActionChild>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
        public byte Month { get; set; }

        [InverseProperty(nameof(ActionChild.Action))]
        public virtual ICollection<ActionChild> ActionChildren { get; set; }
    }
}
