namespace Mumbi.Application.Dtos.Diaries
{
    public class DiaryResponse
    {
        public int Id { get; set; }
        public string ChildId { get; set; }
        public string ImageURL { get; set; }
        public string DiaryContent { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedTime { get; set; }
        public bool PublicFlag { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}