using System;

namespace Mumbi.Application.Dtos.Childrens
{
    public class ChildrenResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public String BirthDay { get; set; }
        public string BloodGroup { get; set; }
        public string RhBloodGroup { get; set; }  
        public int Fingertips { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? HeadCircumference { get; set; }
        public double? HourSleep { get; set; }
        public double? AvgMilk { get; set; }
        public string MomId { get; set; }   
        public string DadId { get; set; }
        public DateTime CalculatedBornDate { get; set; }
        public double? FemurLength { get; set; }
        public double? FetalHeartRate { get; set; }
        public int HeadVortex { get; set; }
        public int? PregnancyWeek { get; set; }
        public string PregnancyType { get; set; }
        public int? MotherMenstrualCycleTime { get; set; }
        public double? MotherWeight { get; set; }
        public bool IsBorn { get; set; }
    }
}
