using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IGuidebookService
    {
        Task<Response<string>> AddGuidebook(CreateGuidebookRequest request);
        Task<PagedResponse<List<GuidebookByTypeIdResponse>>> GetGuidebook(GuidebookRequest request);
        Task<Response<List<GuidebookResponse>>> GetAllGuidebook();
        Task<Response<GuidebookResponse>> GetGuidebookById(string Id);
        Task<Response<List<GuidebookByTypeIdResponse>>> GetGuidebookByTypeId(int typeId);
        Task<Response<string>> UpdateGuidebookRequest(UpdateGuidebookRequest request);
        Task<Response<string>> DeleteGuidebook(string Id);
    }
}
