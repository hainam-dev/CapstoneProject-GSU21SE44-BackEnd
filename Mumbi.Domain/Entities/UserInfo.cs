using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("UserInfo")]
    public partial class UserInfo
    {
        [Key]
        [StringLength(100)]
        public string Id { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Column("ImageURL")]
        public string ImageUrl { get; set; }

        [StringLength(50)]
        public string Birthday { get; set; }

        [StringLength(10)]
        public string Phonenumber { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.UserInfo))]
        public virtual User IdNavigation { get; set; }
    }
}