using System;

namespace Mumbi.Application.Dtos.News
{
    public class NewsByTypeIdResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
        public string ImageURL { get; set; }
        public short EstimatedFinishTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public int TypeId { get; set; }
        public string Type{ get; set; }
    }
}