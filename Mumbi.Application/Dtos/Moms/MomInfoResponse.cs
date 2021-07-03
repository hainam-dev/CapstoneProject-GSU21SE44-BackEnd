using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Moms
{
    public class MomInfoResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public String Birthday { get; set; }
        public string Phonenumber { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string Dad_Id { get; set; }
    }
}
