using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Staffs
{
    public class UpdateStaffRequest
    {
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string BirthDay { get; set; }
        public string Phonenumber { get; set; }
    }
}
