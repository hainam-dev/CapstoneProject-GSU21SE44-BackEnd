using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Childrens
{
    public class UpdateChildHistoryRequest
    {
        public string ChildId { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float HeadCircumference { get; set; }
        public float HourSleep { get; set; }
        public float AvgMilk { get; set; }
        public short WeekOlds { get; set; }
    }
}
