namespace Mumbi.Application.Dtos.ToothInfo
{
    public class CreateToothInfoRequest
    {
        public byte Position { get; set; }
        public byte Number { get; set; }
        public string Name { get; set; }
        public string GrowTime { get; set; }
    }
}