using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("InjectionSchedule")]
    public partial class InjectionSchedule
    {
        [Key]
        public int Id { get; set; }
        public int VaccineId { get; set; }
        [StringLength(15)]
        public string Phonenumber { get; set; }
        [StringLength(50)]
        public string ChildId { get; set; }
        [StringLength(100)]
        public string MomId { get; set; }
        public int? OrderOfInjection { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InjectionDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NextInjectionDate { get; set; }
        public int? Price { get; set; }
        public bool? IsInjection { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("InjectionSchedules")]
        public virtual Child Child { get; set; }
        [ForeignKey(nameof(MomId))]
        [InverseProperty("InjectionSchedules")]
        public virtual Mom Mom { get; set; }
        [ForeignKey(nameof(VaccineId))]
        [InverseProperty("InjectionSchedules")]
        public virtual Vaccine Vaccine { get; set; }
    }
}
