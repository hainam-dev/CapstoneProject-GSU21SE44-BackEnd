using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadsController : ControllerBase
    {
        private readonly IDadService _dadService;

        public DadsController(IDadService dadService)
        {
            _dadService = dadService;
        }

        [HttpPost("AddDad")]
        public async Task<IActionResult> Add(CreateDadRequest request)
        {
            return Ok(await _dadService.AddDad(request));
        }

        [HttpPut("UpdateDad/{Id}")]
        public async Task<IActionResult> UpdateMom(string Id, UpdateDadRequest request)
        {
            if (Id != request.Id)
            {
                return BadRequest();
            }

            return Ok(await _dadService.UpdateDadRequest(request));
        }

        [HttpPut("DeleteDad/{Id}")]
        public async Task<IActionResult> DeleteDad(string Id)
        {
            return Ok(await _dadService.DeleteDad(Id));
        }
    }
}
