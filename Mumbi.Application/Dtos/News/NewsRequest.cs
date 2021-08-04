using Mumbi.Application.Parameters;

namespace Mumbi.Application.Dtos.News
{
    public class NewsRequest : RequestParameter
    {
        public int? TypeId { get; set; }
        public string SearchValue { get; set; }
    }
}