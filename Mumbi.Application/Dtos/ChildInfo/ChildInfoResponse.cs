using System;

namespace Mumbi.Application.Dtos.Childrens
{
    public class ChildInfoResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public string EstimatedBornDate { get; set; }
        public String Birthday { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }  
        public int Fingertips { get; set; }
        public int HeadVortex { get; set; }
        public string MomId { get; set; }   
        public bool BornFlag { get; set; }
    }
}
