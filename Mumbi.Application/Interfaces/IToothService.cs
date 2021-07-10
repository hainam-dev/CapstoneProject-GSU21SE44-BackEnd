using Mumbi.Application.Dtos.Tooths;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IToothService
    {
        Task<Response<ToothResponse>> GetToothByChildId(string childId,string toothId);
        Task<Response<string>> UpsertToothRequest(UpsertToothRequest request);
    }
}
