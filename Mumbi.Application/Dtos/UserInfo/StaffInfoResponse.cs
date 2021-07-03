using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Staffs
{
    public class StaffInfoResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string Birthday { get; set; }
        public string Phonenumber { get; set; }
    }
}
