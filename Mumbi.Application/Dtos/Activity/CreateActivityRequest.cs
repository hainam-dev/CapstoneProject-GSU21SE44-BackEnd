using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Activity
{
    public class CreateActivityRequest
    {
        public string ActivityName { get; set; }
        public string MediaFileURL { get; set; }
        public int TypeId { get; set; }
        public byte SuitableAge { get; set; }
    }
}
