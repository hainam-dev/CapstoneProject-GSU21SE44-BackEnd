using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Wrappers;
using System;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IUserInfoService
    {
        Task<Response<StaffInfoResponse>> GetStaffInfoById(String Id);

        Task<Response<string>> UpdateStaffInfoRequest(UpdateStaffInfoRequest request);
    }
}