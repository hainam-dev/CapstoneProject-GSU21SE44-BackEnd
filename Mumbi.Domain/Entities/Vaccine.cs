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
            SymptomVaccines = new HashSet<SymptomVaccine>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string VaccineName { get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseDescription { get; set; }
        [StringLength(50)]
        public string WayToUse { get; set; }
        public int? Month { get; set; }
        [StringLength(200)]
        public string ProductionCountry { get; set; }
        public int? Price { get; set; }
        public bool IsMandatory { get; set; }

        [InverseProperty(nameof(InjectionSchedule.Vaccine))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
        [InverseProperty(nameof(SymptomVaccine.Vaccine))]
        public virtual ICollection<SymptomVaccine> SymptomVaccines { get; set; }
    }
}
