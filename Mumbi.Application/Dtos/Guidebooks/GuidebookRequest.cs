using Mumbi.Application.Parameters;

namespace Mumbi.Application.Dtos.Guidebooks
{
    public class GuidebookRequest : RequestParameter
    {
        public int? TypeId { get; set; }
        public byte? SuitableAge { get; set; }
        public string SearchValue { get; set; }
    }
}