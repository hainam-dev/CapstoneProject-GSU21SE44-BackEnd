using Mumbi.Application.Dtos.News;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface INewsService
    {
        Task<Response<string>> AddNews(CreateNewsRequest request);
        Task<Response<List<NewsResponse>>> GetAllNews();
        Task<Response<NewsResponse>> GetNewsById(string Id);
        Task<Response<List<NewsByTypeIdResponse>>> GetNewsByTypeId(int typeId);
        Task<Response<string>> UpdateNewsRequest(UpdateNewsRequest request);
        Task<Response<string>> DeleteNews(string Id);
    }
}
