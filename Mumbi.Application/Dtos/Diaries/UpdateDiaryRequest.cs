using System;

namespace Mumbi.Application.Dtos.Diaries
{
    public class UpdateDiaryRequest
    {
        public int Id { get; set; }
        public string ChildId { get; set; }
        public string ImageURL { get; set; }
        public string DiaryContent { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public DateTime PublicDate { get; set; }
        public bool PublicFlag { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}