using Mumbi.Application.Parameters;

namespace Mumbi.Application.Dtos.Activity
{
    public class ActivityRequest : RequestParameter
    {
        public int? TypeId { get; set; }
        public byte? SuitableAge { get; set; }
        public string SearchValue { get; set; }
    }
}
