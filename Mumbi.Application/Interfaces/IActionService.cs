using Mumbi.Application.Dtos.Action;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IActionService
    {
        Task<Response<List<ActionResponse>>> GetActionByType(string type);
    }
}