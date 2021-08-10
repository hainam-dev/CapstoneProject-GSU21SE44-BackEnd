using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("DadInfo")]
    public partial class DadInfo
    {
        [Required]
        [StringLength(50)]
        public string Id { get; set; }

        [Key]
        [StringLength(100)]
        public string MomId { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Column("ImageURL")]
        public string ImageUrl { get; set; }

        [StringLength(50)]
        public string Birthday { get; set; }

        [StringLength(10)]
        public string Phonenumber { get; set; }

        [StringLength(10)]
        public string BloodGroup { get; set; }

        [StringLength(10)]
        public string RhBloodGroup { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty(nameof(MomInfo.DadInfo))]
        public virtual MomInfo Mom { get; set; }
    }
}