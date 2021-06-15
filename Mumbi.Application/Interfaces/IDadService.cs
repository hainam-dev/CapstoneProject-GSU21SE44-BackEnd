using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IDadService
    {
        Task<Response<string>> AddDad(CreateDadRequest request);
        Task<Response<DadResponse>> GetDadByMomId(String momId);
        Task<Response<string>> UpdateDadRequest(UpdateDadRequest request);
        Task<Response<string>> DeleteDad(string id);
    }
}
