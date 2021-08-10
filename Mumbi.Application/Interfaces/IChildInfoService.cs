using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IChildInfoService
    {
        Task<Response<List<ChildInfoResponse>>> GetAllChildInfo();

        Task<Response<ChildInfoResponse>> GetChildInfoById(string id);

        Task<Response<List<ChildInfoResponse>>> GetChildInfoByMomId(string momId);

        Task<Response<string>> AddChildInfo(CreateChildInfoRequest request);

        Task<Response<string>> UpdateChildInfo(UpdateChildInfoRequest request);

        Task<Response<string>> DeleteChildInfo(string id);
    }
}