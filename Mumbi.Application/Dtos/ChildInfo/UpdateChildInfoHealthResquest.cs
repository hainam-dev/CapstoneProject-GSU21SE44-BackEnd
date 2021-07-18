using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Childrens
{
    public class UpdateChildInfoHealthResquest
    {
        public string Id { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float HeadCircumference { get; set; }
        public float HourSleep { get; set; }
        public float AvgMilk { get; set; }
        public string PregnancyWeek { get; set; }
        public short WeekOlds { get; set; }
        public float BiparietalDiameter { get; set; }
        public float FemurLength { get; set; }
        public float FetalHeartRate { get; set; }
        public float MotherWeight { get; set; }
    }
}
