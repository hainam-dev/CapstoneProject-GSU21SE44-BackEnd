using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Wrappers;
using System;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IDadInfoService
    {
        Task<Response<string>> AddDadInfo(CreateDadInfoRequest request);

        Task<Response<DadInfoResponse>> GetDadInfoByMomId(String momId);

        Task<Response<string>> UpdateDadInfoRequest(UpdateDadInfoRequest request);

        Task<Response<string>> DeleteDadInfo(string Id);
    }
}