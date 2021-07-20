using Mumbi.Application.Dtos.ActionChild;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IActionChildService
    {
        Task<Response<string>> UpsertActionChild(UpsertActionChildRequest request);
        Task<Response<ActionChildResponse>> GetActionChildByActionIdAndChildId(int actionId, string childId);
    }
}
