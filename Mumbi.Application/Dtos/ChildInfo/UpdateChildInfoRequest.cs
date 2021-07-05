using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Childrens
{
    public class UpdateChildInfoRequest
    {
        public string Id { get; set; }
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
