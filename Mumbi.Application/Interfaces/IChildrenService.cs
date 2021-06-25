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
        Task<Response<List<ChildrenResponse>>> GetChildrenByMomId(string momId);
        Task<Response<string>> AddChildren(CreateChildrenRequest request);
        Task<Response<string>> UpdateChildrenHealth(UpdateChildrenHealthResquest request);
        Task<Response<string>> UpdateChildrenInformation(UpdateChildrenInformationRequest request);
        Task<Response<string>> DeleteChildren(string id);
    }
}
