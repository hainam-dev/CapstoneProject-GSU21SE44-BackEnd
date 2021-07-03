using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Dads
{
    public class CreateDadInfoRequest
    {
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public DateTime Birthday { get; set; }
        public string Phonenumber { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }
        public string MomId { get; set; }

    }
}
