namespace Mumbi.Application.Dtos.Moms
{
    public class UpdateMomInfoRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string BirthDay { get; set; }
        public string Phonenumber { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }
    }
}