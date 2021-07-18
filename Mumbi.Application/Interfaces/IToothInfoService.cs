using Mumbi.Application.Dtos.ToothInfo;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IToothInfoService
    {
        Task<Response<string>> AddToothInfo(CreateToothInfoRequest request);
        Task<Response<ToothInfoResponse>> GetToothInfoByPosition(byte position);
    }
}
