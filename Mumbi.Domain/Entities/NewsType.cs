using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("NewsType")]
    public partial class NewsType
    {
        public NewsType()
        {
            News = new HashSet<News>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        public bool DelFlag { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<News> News { get; set; }
    }
}
