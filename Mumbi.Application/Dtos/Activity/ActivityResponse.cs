namespace Mumbi.Application.Dtos.Activity
{
    public class ActivityResponse
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string MediaFileURL { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public byte SuitableAge { get; set; }
        public bool DelFlag { get; set; }
    }
}