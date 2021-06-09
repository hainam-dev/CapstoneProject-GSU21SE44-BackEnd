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
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string VaccineName { get; set; }
        [Required]
        [StringLength(200)]
        public string DiseaseName { get; set; }
        [StringLength(200)]
        public string ProductionCountry { get; set; }
        public int Price { get; set; }

        [InverseProperty(nameof(InjectionSchedule.Vaccine))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
    }
}
