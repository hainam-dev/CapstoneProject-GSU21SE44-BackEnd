using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.InjectedPerson;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class InjectedPersonController : ControllerBase
    {

        private readonly IInjectedPersonService _injectedPersonService;

        public InjectedPersonController(IInjectedPersonService injectedPersonService)
        {
            _injectedPersonService = injectedPersonService;
        }
        [HttpPost("AddInjectedPerson")]
        public async Task<IActionResult> AddInjectedPerson(List<CreateInjectedPersonRequest> request)
        {
            return Ok(await _injectedPersonService.AddInjectedPerson(request));
        }
    }
}
