using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.InjectionSchedule
{
    public class CreateInjectionScheduleRequest
    {
        public int Id { get; set; }
        public string MomId { get; set; }
        public string InjectedPersonId { get; set; }
        public string VaccineName { get; set; }
        public string Antigen { get; set; }
        public string InjectionDate { get; set; }
        public byte OrderOfInjection { get; set; }
        public string VaccineBatch { get; set; }
        public string VaccinationFacility { get; set; }
        public byte Status { get; set; }
    }
}
