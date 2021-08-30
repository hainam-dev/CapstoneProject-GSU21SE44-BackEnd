namespace Mumbi.Application.Dtos.InjectionSchedule
{
    public class CreateInjectionScheduleRequest
    {
        public double InjectionScheduleId { get; set; }
        public string MomId { get; set; }
        public string ChildId { get; set; }
        public double? InjectedPersonId { get; set; }
        public string VaccineName { get; set; }
        public string Antigen { get; set; }
        public string InjectionDate { get; set; }
        public byte? OrderOfInjection { get; set; }
        public string VaccineBatch { get; set; }
        public string VaccinationFacility { get; set; }
        public byte Status { get; set; }
    }
}