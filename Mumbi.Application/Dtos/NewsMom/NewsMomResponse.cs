using Mumbi.Application.Dtos.News;

namespace Mumbi.Application.Dtos.NewsMom
{
    public class NewsMomResponse
    {
        public int Id { get; set; }
        public NewsResponse NewsData { get; set; }
    }
}