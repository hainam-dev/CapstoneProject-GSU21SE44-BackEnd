using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IStaffService
    {
        Task<Response<StaffResponse>> GetStaffByAccountId(String accountId);
        Task<Response<string>> UpdateStaffRequest(UpdateStaffRequest request);
    }
}
