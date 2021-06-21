using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Moms
{
    public class UpdateMomRequest
    {
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string BirthDay { get; set; }
        public string Phonenumber { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
    }
}
