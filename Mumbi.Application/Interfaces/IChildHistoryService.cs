using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IChildHistoryService
    {
        Task<Response<List<ChildHistoryResponse>>> GetChildHistoryByChildId(ChildHistoryRequest request);

        Task<Response<string>> UpdateChildHistory(ChildHistoryRequest request, UpdateChildHistoryRequest uodateRequest);
    }
}