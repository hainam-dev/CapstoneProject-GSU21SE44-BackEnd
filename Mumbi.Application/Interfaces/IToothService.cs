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
        Task<Response<ToothResponse>> GetToothByToothId(string childId,string toothId);
        Task<Response<List<ToothResponse>>> GetToothByChildId(string childId);
        Task<Response<string>> UpsertToothRequest(UpsertToothRequest request);
    }
}
