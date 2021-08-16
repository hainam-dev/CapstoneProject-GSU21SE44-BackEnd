using System;

namespace Mumbi.Application.Dtos.Guidebooks
{
    public class GuidebookByTypeIdResponse
    {
        public string Title { get; set; }
        public string GuidebookContent { get; set; }
        public string ImageURL { get; set; }
        public short EstimatedFinishTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public byte? SuitableAge { get; set; }
        public int TypeId { get; set; }
    }
}