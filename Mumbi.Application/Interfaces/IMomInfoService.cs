using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IMomInfoService
    {
        Task<Response<List<MomInfoResponse>>> GetAllMomInfo();
        Task<Response<MomInfoResponse>> GetMomInfoById(String Id);
        Task<Response<string>> UpdateMomInfoRequest(UpdateMomInfoRequest request);
        Task<Response<string>> DeleteMomInfo(string Id);
    }
}
