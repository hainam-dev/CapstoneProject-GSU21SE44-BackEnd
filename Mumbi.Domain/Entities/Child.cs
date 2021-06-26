using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Child")]
    public partial class Child
    {
        public Child()
        {
            ActionChildren = new HashSet<ActionChild>();
            Diaries = new HashSet<Diary>();
            InjectionSchedules = new HashSet<InjectionSchedule>();
            PregnancyActivities = new HashSet<PregnancyActivity>();
            ToothChildren = new HashSet<ToothChild>();
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(200)]
        public string Nickname { get; set; }
        public string Image { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Birthday { get; set; }
        [StringLength(10)]
        public string BloodGroup { get; set; }
        [StringLength(10)]
        public string RhBloodGroup { get; set; }
        public int? Fingertips { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? HeadCircumference { get; set; }
        public double? HourSleep { get; set; }
        public double? AvgMilk { get; set; }
        [Required]
        [StringLength(100)]
        public string MomId { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsBorn { get; set; }
        public int? HeadVortex { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty("Children")]
        public virtual Mom Mom { get; set; }
        [InverseProperty("Child")]
        public virtual PregnancyInformation PregnancyInformation { get; set; }
        [InverseProperty(nameof(ActionChild.Child))]
        public virtual ICollection<ActionChild> ActionChildren { get; set; }
        [InverseProperty(nameof(Diary.Child))]
        public virtual ICollection<Diary> Diaries { get; set; }
        [InverseProperty(nameof(InjectionSchedule.Child))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
        [InverseProperty(nameof(PregnancyActivity.Child))]
        public virtual ICollection<PregnancyActivity> PregnancyActivities { get; set; }
        [InverseProperty(nameof(ToothChild.Child))]
        public virtual ICollection<ToothChild> ToothChildren { get; set; }
    }
}
