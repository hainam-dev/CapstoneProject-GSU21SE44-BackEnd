using Mumbi.Application.Dtos.Tooths;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IToothService
    {
        Task<Response<ToothResponse>> GetToothByToothId(string childId, string toothId);

        Task<Response<List<ToothResponse>>> GetToothByChildId(string childId);

        Task<Response<string>> UpsertToothRequest(UpsertToothRequest request);
    }
}