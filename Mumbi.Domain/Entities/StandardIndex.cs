using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("StandardIndex")]
    public partial class StandardIndex
    {
        [Key]
        public int Id { get; set; }

        public short Month { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public byte Gender { get; set; }

        [Required]
        [StringLength(10)]
        public string Unit { get; set; }

        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}