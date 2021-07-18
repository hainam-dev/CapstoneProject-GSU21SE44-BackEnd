using Mumbi.Application.Dtos.GuidebookMom;
using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
