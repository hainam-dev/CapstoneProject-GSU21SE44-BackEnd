using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IInjectionScheduleService
    {
        Task<Response<string>> AddInjectionSchedule(CreateInjectionScheduleRequest request);
    }
}
