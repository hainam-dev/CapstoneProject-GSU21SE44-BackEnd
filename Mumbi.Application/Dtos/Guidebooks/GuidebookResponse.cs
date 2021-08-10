namespace Mumbi.Application.Dtos.Guidebooks
{
    public class GuidebookResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string GuidebookContent { get; set; }
        public string ImageURL { get; set; }
        public short EstimatedFinishTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedTime { get; set; }
        public byte SuitableAge { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
    }
}