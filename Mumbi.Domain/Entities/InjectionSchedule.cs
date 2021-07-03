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
        [StringLength(50)]
        public string ChildId { get; set; }
        [StringLength(100)]
        public string MomId { get; set; }
        public int VaccineId { get; set; }
        [StringLength(10)]
        public string Phonenumber { get; set; }
        public byte? OrderOfInjection { get; set; }
        [StringLength(50)]
        public string InjectionDate { get; set; }
        [StringLength(50)]
        public string NextInjectionDate { get; set; }
        public int? Price { get; set; }
        public byte Status { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty(nameof(MomInfo.InjectionSchedules))]
        public virtual MomInfo Mom { get; set; }
        [ForeignKey(nameof(VaccineId))]
        [InverseProperty("InjectionSchedules")]
        public virtual Vaccine Vaccine { get; set; }
    }
}
