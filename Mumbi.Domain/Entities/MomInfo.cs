using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Mom_Info")]
    public partial class MomInfo
    {
        public MomInfo()
        {
            ChildInfos = new HashSet<ChildInfo>();
            GuidebookMoms = new HashSet<GuidebookMom>();
            InjectionSchedules = new HashSet<InjectionSchedule>();
            NewsMoms = new HashSet<NewsMom>();
        }

        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [StringLength(10)]
        public string BloodGroup { get; set; }
        [StringLength(10)]
        public string RhBloodGroup { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        [Required]
        [Column("Dad_Id")]
        [StringLength(50)]
        public string DadId { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.MomInfo))]
        public virtual User IdNavigation { get; set; }
        [InverseProperty("Mom")]
        public virtual DadInfo DadInfo { get; set; }
        [InverseProperty(nameof(ChildInfo.Mom))]
        public virtual ICollection<ChildInfo> ChildInfos { get; set; }
        [InverseProperty(nameof(GuidebookMom.Mom))]
        public virtual ICollection<GuidebookMom> GuidebookMoms { get; set; }
        [InverseProperty(nameof(InjectionSchedule.Mom))]
        public virtual ICollection<InjectionSchedule> InjectionSchedules { get; set; }
        [InverseProperty(nameof(NewsMom.Mom))]
        public virtual ICollection<NewsMom> NewsMoms { get; set; }
    }
}
