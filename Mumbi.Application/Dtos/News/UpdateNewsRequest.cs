namespace Mumbi.Application.Dtos.News
{
    public class UpdateNewsRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
        public string ImageURL { get; set; }
        public short EstimatedFinishTime { get; set; }
        public string LastModifiedBy { get; set; }
        public int TypeId { get; set; }
    }
}