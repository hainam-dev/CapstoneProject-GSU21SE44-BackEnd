using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Activity")]
    public partial class Activity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string ActivityName { get; set; }

        [Column("MediaFileURL")]
        public string MediaFileUrl { get; set; }

        public int TypeId { get; set; }
        public byte? SuitableAge { get; set; }
        public bool DelFlag { get; set; }

        [ForeignKey(nameof(TypeId))]
        [InverseProperty(nameof(ActivityType.Activities))]
        public virtual ActivityType Type { get; set; }
    }
}