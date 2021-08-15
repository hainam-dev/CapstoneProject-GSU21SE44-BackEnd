using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IMomInfoService
    {
        Task<PagedResponse<List<MomInfoResponse>>> GetListMomInfo(MomInfoRequest request);

        Task<Response<MomInfoResponse>> GetMomInfoById(string Id);

        Task<Response<string>> UpdateMomInfoRequest(UpdateMomInfoRequest request);

        Task<Response<string>> DeleteMomInfo(string Id);
    }
}