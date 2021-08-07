using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IPregnancyHistoryService
    {
        Task<Response<List<PregnancyHistoryResponse>>> GetPregnancyHistoryByChildId(PregnancyHistoryRequest request);

        Task<Response<string>> UpdatePregnancyHistory(PregnancyHistoryRequest request, UpdatePregnancyHistoryRequest updateRequest);
    }
}