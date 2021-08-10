using Mumbi.Application.Dtos.InjectedPerson;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IInjectedPersonService
    {
        Task<Response<List<string>>> AddInjectedPerson(List<CreateInjectedPersonRequest> request);
    }
}