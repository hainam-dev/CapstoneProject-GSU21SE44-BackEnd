using System;

namespace Mumbi.Application.Dtos.Tooths
{
    public class UpsertToothRequest
    {
        public string ToothId { get; set; }
        public string ChildId { get; set; }
        public DateTime GrownDate { get; set; }
        public string Note { get; set; }
        public string ImageURL { get; set; }
        public bool GrownFlag { get; set; }
    }
}