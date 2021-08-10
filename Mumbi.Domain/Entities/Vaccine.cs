using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Mumbi.Domain.Entities
{
    [Table("Vaccine")]
    public partial class Vaccine
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Antigen { get; set; }

        public byte? Month { get; set; }

        [StringLength(100)]
        public string ProducingCountry { get; set; }

        public int? Price { get; set; }
        public byte? OrderOfInjection { get; set; }
        public byte? TotalNumberOfInjections { get; set; }
        public bool? RequiredFlag { get; set; }
    }
}