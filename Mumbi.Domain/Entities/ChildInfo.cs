using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Child_Info")]
    public partial class ChildInfo
    {
        public ChildInfo()
        {
            ActionChildren = new HashSet<ActionChild>();
            ChildHistories = new HashSet<ChildHistory>();
            Diaries = new HashSet<Diary>();
            PregnancyActivities = new HashSet<PregnancyActivity>();
            PregnancyInfos = new HashSet<PregnancyInfo>();
            Teeth = new HashSet<Tooth>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Mom_Id")]
        [StringLength(100)]
        public string MomId { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(200)]
        public string Nickname { get; set; }
        [Column("ImageURL")]
        public string ImageUrl { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string EstimatedBornDate { get; set; }
        [StringLength(50)]
        public string Birthday { get; set; }
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
        public byte? HeadVortex { get; set; }
        public bool BornFlag { get; set; }
        public bool DelFlag { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty(nameof(MomInfo.ChildInfos))]
        public virtual MomInfo Mom { get; set; }
        [InverseProperty(nameof(ActionChild.Child))]
        public virtual ICollection<ActionChild> ActionChildren { get; set; }
        [InverseProperty(nameof(ChildHistory.Child))]
        public virtual ICollection<ChildHistory> ChildHistories { get; set; }
        [InverseProperty(nameof(Diary.Child))]
        public virtual ICollection<Diary> Diaries { get; set; }
        [InverseProperty(nameof(PregnancyActivity.Child))]
        public virtual ICollection<PregnancyActivity> PregnancyActivities { get; set; }
        [InverseProperty(nameof(PregnancyInfo.Child))]
        public virtual ICollection<PregnancyInfo> PregnancyInfos { get; set; }
        [InverseProperty(nameof(Tooth.Child))]
        public virtual ICollection<Tooth> Teeth { get; set; }
    }
}
