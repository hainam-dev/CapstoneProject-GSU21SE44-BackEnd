using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Childrens
{
    public class UpdateChildrenHealthResquest
    {
        public string Id { get; set; }
        public string BirthDay { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float HeadCircumference { get; set; }
        public float HourSleep { get; set; }
        public float AvgMilk { get; set; }
        public int PregnancyWeek { get; set; }
        public float MotherWeight { get; set; }
        public float FetalHeartRate { get; set; }
        public float FemurLength { get; set; }
        public int ChildrenStatus { get; set; }
    }
}
