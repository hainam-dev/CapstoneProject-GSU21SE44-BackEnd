using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("ActionChild")]
    public partial class ActionChild
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ChildId { get; set; }

        public int ActionId { get; set; }
        public bool CheckedFlag { get; set; }

        [ForeignKey(nameof(ActionId))]
        [InverseProperty("ActionChildren")]
        public virtual Action Action { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty(nameof(ChildInfo.ActionChildren))]
        public virtual ChildInfo Child { get; set; }
    }
}