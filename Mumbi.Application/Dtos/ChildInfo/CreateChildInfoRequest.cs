using System;

namespace Mumbi.Application.Dtos.Childrens
{
    public class CreateChildInfoRequest
    {
        public string MomID { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public string EstimatedBornDate { get; set; }
        public string Birthday { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }
        public byte HeadVortex { get; set; }
        public byte Fingertips { get; set; }
        public int ChildrenStatus { get; set; }
    }
}
