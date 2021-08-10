using Mumbi.Application.Dtos.NewsType;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface INewsTypeService
    {
        Task<Response<string>> AddNewsType(CreateNewsTypeRequest request);

        Task<Response<List<NewsTypeResponse>>> GetAllNewsType();

        Task<Response<NewsTypeResponse>> GetNewsTypeById(int Id);

        Task<Response<string>> UpdateNewsTypeRequest(UpdateNewsTypeRequest request);

        Task<Response<string>> DeleteNewsType(int Id);
    }
}