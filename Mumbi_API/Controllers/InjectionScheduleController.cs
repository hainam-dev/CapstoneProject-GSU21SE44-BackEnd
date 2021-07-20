using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionScheduleController : ControllerBase
    {

        private readonly IInjectionScheduleService _injectionScheduleService;

        public InjectionScheduleController(IInjectionScheduleService injectionScheduleService)
        {
            _injectionScheduleService = injectionScheduleService;
        }
        [HttpPost("AddInjectionSchedule")]

        public async Task<IActionResult> AddInjectionSchedule(List<CreateInjectionScheduleRequest> request)
        {
            return Ok(await _injectionScheduleService.AddInjectionSchedule(request));
        }
    }
}
