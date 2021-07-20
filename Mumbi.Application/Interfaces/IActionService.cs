using Mumbi.Application.Dtos.Action;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IActionService
    {
        Task<Response<List<ActionResponse>>> GetActionByType(string type);
    }
}
