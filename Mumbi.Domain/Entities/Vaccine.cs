using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Vaccine")]
    public partial class Vaccine
    {
        public Vaccine()
        {
            InjectionSchedules = new HashSet<InjectionSchedule>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string Disease { get; set; }
        [StringLength(100)]
        public string ProducingCountry { get; set; }
        public int? Price { get; set; }
        public bool Mandatory { get; set; }

        [InverseProperty(nameof(InjectionSchedule.Vaccine))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
    }
}
