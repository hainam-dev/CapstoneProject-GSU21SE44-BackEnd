using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Childrens
{
    public class UpdatePregnancyInfoRequest
    {
        public string Id { get; set; }
        public int PregnancyWeek { get; set; }
        public float MotherWeight { get; set; }
        public float Weight { get; set; }
        public float HeadCircumference { get; set; }
        public float FetalHeartRate { get; set; }
        public float FemurLength { get; set; }
    }
}
