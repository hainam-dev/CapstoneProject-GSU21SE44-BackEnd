using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Mom")]
    public partial class Mom
    {
        public Mom()
        {
            Children = new HashSet<Child>();
            InjectionSchedules = new HashSet<InjectionSchedule>();
        }

        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }
        [StringLength(15)]
        public string Phonenumber { get; set; }
        [StringLength(10)]
        public string BloodGroup { get; set; }
        [StringLength(10)]
        public string RhBloodGroup { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public bool? IsSingleMom { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountId { get; set; }

        [InverseProperty("EmailNavigation")]
        public virtual Account Account { get; set; }
        [InverseProperty(nameof(Child.Mom))]
        public virtual ICollection<Child> Children { get; set; }
        [InverseProperty(nameof(InjectionSchedule.Mother))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
    }
}
