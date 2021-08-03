using Mumbi.Application.Dtos.News;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface INewsService
    {
        Task<Response<string>> AddNews(CreateNewsRequest request);
        Task<Response<List<NewsResponse>>> GetAllNews();
        Task<Response<NewsResponse>> GetNewsById(string Id);
        Task<PagedResponse<List<NewsByTypeIdResponse>>> GetNews(NewsRequest request);
        Task<Response<string>> UpdateNewsRequest(UpdateNewsRequest request);
        Task<Response<string>> DeleteNews(string Id);
    }
}
