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
            Dads = new HashSet<Dad>();
            GuidebookMoms = new HashSet<GuidebookMom>();
            InjectionSchedules = new HashSet<InjectionSchedule>();
            NewsMoms = new HashSet<NewsMom>();
        }

        [Key]
        [StringLength(100)]
        public string AccountId { get; set; }
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

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Mom")]
        public virtual Account Account { get; set; }
        [InverseProperty(nameof(Child.Mom))]
        public virtual ICollection<Child> Children { get; set; }
        [InverseProperty(nameof(Dad.Mom))]
        public virtual ICollection<Dad> Dads { get; set; }
        [InverseProperty(nameof(GuidebookMom.Mom))]
        public virtual ICollection<GuidebookMom> GuidebookMoms { get; set; }
        [InverseProperty(nameof(InjectionSchedule.Mom))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
        [InverseProperty(nameof(NewsMom.Mom))]
        public virtual ICollection<NewsMom> NewsMoms { get; set; }
    }
}
