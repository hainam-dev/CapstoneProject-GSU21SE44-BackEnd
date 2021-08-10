using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("GuidebookType")]
    public partial class GuidebookType
    {
        public GuidebookType()
        {
            Guidebooks = new HashSet<Guidebook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

        public bool DelFlag { get; set; }

        [InverseProperty(nameof(Guidebook.Type))]
        public virtual ICollection<Guidebook> Guidebooks { get; set; }
    }
}