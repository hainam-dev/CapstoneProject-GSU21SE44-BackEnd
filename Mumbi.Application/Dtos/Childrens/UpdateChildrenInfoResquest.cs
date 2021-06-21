using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Childrens
{
    public class UpdateChildrenInfoResquest
    {
        public string Id { get; set; }
        public string BirthDay { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float HeadCircumference { get; set; }
        public float HourSleep { get; set; }
        public float AvgMilk { get; set; }
    }
}
