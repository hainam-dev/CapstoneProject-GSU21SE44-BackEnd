using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IUserInfoService
    {
        Task<Response<StaffInfoResponse>> GetStaffInfoById(String Id);
        Task<Response<string>> UpdateStaffInfoRequest(UpdateStaffInfoRequest request);
    }
}
