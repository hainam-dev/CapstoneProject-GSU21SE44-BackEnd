using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("SymptomVaccine")]
    public partial class SymptomVaccine
    {
        [Key]
        public int Id { get; set; }
        public int VaccineId { get; set; }
        public int SymptomId { get; set; }
        public int IsEffected { get; set; }

        [ForeignKey(nameof(SymptomId))]
        [InverseProperty("SymptomVaccines")]
        public virtual Symptom Symptom { get; set; }
        [ForeignKey(nameof(VaccineId))]
        [InverseProperty("SymptomVaccines")]
        public virtual Vaccine Vaccine { get; set; }
    }
}
