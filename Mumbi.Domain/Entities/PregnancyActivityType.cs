using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("PregnancyActivity_Type")]
    public partial class PregnancyActivityType
    {
        public PregnancyActivityType()
        {
            PregnancyActivities = new HashSet<PregnancyActivity>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(10)]
        public string SuitableAge { get; set; }
        public bool? DelFlag { get; set; }

        [InverseProperty(nameof(PregnancyActivity.Type))]
        public virtual ICollection<PregnancyActivity> PregnancyActivities { get; set; }
    }
}
