using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Symptom")]
    public partial class Symptom
    {
        public Symptom()
        {
            SymptomVaccines = new HashSet<SymptomVaccine>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string SymptomName { get; set; }

        [InverseProperty(nameof(SymptomVaccine.Symptom))]
        public virtual ICollection<SymptomVaccine> SymptomVaccines { get; set; }
    }
}
