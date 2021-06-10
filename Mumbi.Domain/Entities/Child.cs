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
        }

        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(10)]
        public string Nickname { get; set; }
        public string Image { get; set; }
        public int? Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDay { get; set; }
        [StringLength(10)]
        public string BloodGroup { get; set; }
        [StringLength(10)]
        public string RhBloodGroup { get; set; }
        [StringLength(10)]
        public string Fingertips { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? HeadCircumference { get; set; }
        public double? HourSleep { get; set; }
        public double? AvgMilk { get; set; }
        [StringLength(100)]
        public string MomId { get; set; }
        [StringLength(100)]
        public string DadId { get; set; }

        [ForeignKey(nameof(DadId))]
        [InverseProperty("Children")]
        public virtual Dad Dad { get; set; }
        [ForeignKey(nameof(MomId))]
        [InverseProperty("Children")]
        public virtual Mom Mom { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual PregnancyInformation PregnancyInformation { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Tooth Tooth { get; set; }
        [InverseProperty(nameof(ActionChild.Child))]
        public virtual ICollection<ActionChild> ActionChildren { get; set; }
        [InverseProperty(nameof(Diary.Child))]
        public virtual ICollection<Diary> Diaries { get; set; }
        [InverseProperty(nameof(InjectionSchedule.Children))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
        [InverseProperty(nameof(PregnancyActivity.Child))]
        public virtual ICollection<PregnancyActivity> PregnancyActivities { get; set; }
    }
}
