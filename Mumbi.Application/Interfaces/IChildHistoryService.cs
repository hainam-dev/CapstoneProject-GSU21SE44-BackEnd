using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IChildHistoryService
    {
        Task<Response<ChildHistoryResponse>> GetChildHistoryByChildId(ChildHistoryRequest request);
        Task<Response<string>> UpdateChildHistory(UpdateChildHistoryRequest request);
    }
}
