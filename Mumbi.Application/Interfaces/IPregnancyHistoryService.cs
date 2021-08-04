using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IPregnancyHistoryService
    {
        Task<Response<PregnancyHistoryResponse>> GetPregnancyHistoryByChildId(PregnancyHistoryRequest request);
        Task<Response<string>> UpdatePregnancyHistory(UpdatePregnancyHistoryRequest request);
    }
}
