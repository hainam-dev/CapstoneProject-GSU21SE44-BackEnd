namespace Mumbi.Application.Dtos.Staffs
{
    public class UpdateStaffInfoRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string BirthDay { get; set; }
        public string Phonenumber { get; set; }
    }
}