namespace Mumbi.Application.Dtos.StandardIndex
{
    public class StandardIndexResponse
    {
        public int Id { get; set; }
        public short Month { get; set; }
        public string Type { get; set; }
        public byte Gender { get; set; }
        public string Unit { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}