using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IChildrenService
    {
        Task<Response<List<ChildrenResponse>>> GetAllChildren();
        Task<Response<ChildrenResponse>> GetChildrenById(string id);
        Task<Response<string>> AddChildren(CreateChildrenRequest request);
        Task<Response<string>> UpdateChildrenInformation(UpdateChildrenInfoResquest request);
        Task<Response<string>> UpdatePregnancyInformation(UpdatePregnancyInfoRequest request);
        Task<Response<string>> DeleteChildren(string id);
    }
}
