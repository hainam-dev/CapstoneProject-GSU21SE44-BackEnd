using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Dads
{
    public class UpdateDadRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phonenumber { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }
    }
}
