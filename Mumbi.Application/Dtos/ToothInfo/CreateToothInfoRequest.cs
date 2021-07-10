using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.ToothInfo
{
    public class CreateToothInfoRequest
    {
        public byte Position { get; set; }
        public string Name { get; set; }
        public string GrowTime { get; set; }
    }
}
