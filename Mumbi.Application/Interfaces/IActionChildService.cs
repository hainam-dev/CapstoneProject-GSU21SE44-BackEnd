using Mumbi.Application.Dtos.ActionChild;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IActionChildService
    {
        Task<Response<string>> UpsertActionChild(UpsertActionChildRequest request);

        Task<Response<List<ActionChildResponse>>> GetActionChildByChildId(string childId);
    }
}