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
        public int Month { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        [StringLength(20)]
        public string ActionType { get; set; }

        [InverseProperty(nameof(ActionChild.Action))]
        public virtual ICollection<ActionChild> ActionChildren { get; set; }
    }
}
