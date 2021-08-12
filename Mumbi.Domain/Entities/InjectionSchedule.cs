using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("InjectionSchedule")]
    public partial class InjectionSchedule
    {
        [Key]
        public double Id { get; set; }

        [StringLength(100)]
        public string MomId { get; set; }

        [StringLength(50)]
        public string ChildId { get; set; }

        public double? InjectedPersonId { get; set; }

        [StringLength(100)]
        public string VaccineName { get; set; }

        [StringLength(50)]
        public string Antigen { get; set; }

        [StringLength(50)]
        public string InjectionDate { get; set; }

        public byte? OrderOfInjection { get; set; }

        [StringLength(30)]
        public string VaccineBatch { get; set; }

        [StringLength(100)]
        public string VaccinationFacility { get; set; }

        public byte Status { get; set; }

        [ForeignKey(nameof(InjectedPersonId))]
        [InverseProperty("InjectionSchedules")]
        public virtual InjectedPerson InjectedPerson { get; set; }

        [ForeignKey(nameof(MomId))]
        [InverseProperty(nameof(MomInfo.InjectionSchedules))]
        public virtual MomInfo Mom { get; set; }
    }
}