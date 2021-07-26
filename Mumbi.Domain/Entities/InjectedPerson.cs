using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("InjectedPerson")]
    public partial class InjectedPerson
    {
        public InjectedPerson()
        {
            InjectionSchedules = new HashSet<InjectionSchedule>();
        }

        [Key]
        public double Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Birthday { get; set; }
        public byte? Gender { get; set; }
        [StringLength(20)]
        public string EthnicGroup { get; set; }
        [StringLength(10)]
        public string Phonenumber { get; set; }
        [StringLength(12)]
        public string IdentityCardNumber { get; set; }
        [StringLength(250)]
        public string HomeAddress { get; set; }
        [StringLength(250)]
        public string TemporaryAddress { get; set; }

        [InverseProperty(nameof(InjectionSchedule.InjectedPerson))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
    }
}
