using Mumbi.Application.Dtos.InjectedPerson;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IInjectedPersonService
    {
        Task<Response<List<string>>> AddInjectedPerson(List<CreateInjectedPersonRequest> request);
    }
}
