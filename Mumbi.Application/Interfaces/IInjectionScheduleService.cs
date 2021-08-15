using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IInjectionScheduleService
    {
        Task<Response<List<string>>> AddInjectionSchedule(List<CreateInjectionScheduleRequest> request);

        Task<Response<List<InjectionScheduleResponse>>> GetInjectionScheduleByChildId(string childId);
    }
}