using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IMomService
    {
        Task<Response<List<MomResponse>>> GetAllMom();
        Task<Response<MomResponse>> GetMomById(String accountId);
        Task<Response<string>> UpdateMomRequest(UpdateMomRequest request);
        Task<Response<string>> DeleteMom(string accountId);
    }
}
