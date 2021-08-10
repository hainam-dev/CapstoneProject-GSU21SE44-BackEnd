using Mumbi.Application.Dtos.GuidebookMom;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IGuidebookMomService
    {
        Task<Response<string>> AddGuidebookMom(CreateGuidebookMomRequest request);

        Task<Response<List<GuidebookMomResponse>>> GetGuidebookMomByMomId(string momId);

        Task<Response<string>> DeleteGuidebookMom(int Id);
    }
}