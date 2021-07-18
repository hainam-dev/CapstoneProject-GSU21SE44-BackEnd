using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.PregnancyHistory
{
    public class UpdatePregnancyHistoryRequest
    {
        public string ChildId { get; set; }
        public string Date { get; set; }
        public string PregnancyWeek { get; set; }
        public float Weight { get; set; }
        public float BiparietalDiameter { get; set; }
        public double HeadCircumference { get; set; }
        public float FemurLength { get; set; }
        public float FetalHeartRate { get; set; }
        public float MotherWeight { get; set; }

    }
}
