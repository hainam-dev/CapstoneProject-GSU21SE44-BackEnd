namespace Mumbi.Application.Dtos.Activity
{
    public class ActivityByTypeIdResponse
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string MediaFileURL { get; set; }
        public int TypeId { get; set; }
        public byte SuitableAge { get; set; }
        public bool DelFlag { get; set; }
    }
}