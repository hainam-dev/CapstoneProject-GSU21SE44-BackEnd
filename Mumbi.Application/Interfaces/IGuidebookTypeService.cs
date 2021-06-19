using Mumbi.Application.Dtos.GuidebookTypes;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IGuidebookTypeService
    {
        Task<Response<string>> AddGuidebookType(CreateGuidebookTypeRequest request);
        Task<Response<List<GuidebookTypeResponse>>> GetAllGuidebookType();
        Task<Response<GuidebookTypeResponse>> GetGuidebookTypeById(int Id);
        Task<Response<string>> UpdateGuidebookTypeRequest(UpdateGuidebookTypeRequest request);
        Task<Response<string>> DeleteGuidebookType(int Id);
    }
}
