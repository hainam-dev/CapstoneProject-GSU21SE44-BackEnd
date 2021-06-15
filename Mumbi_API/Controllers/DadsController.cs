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
        public async Task<IActionResult> AddDad(CreateDadRequest request)
        {
            return Ok(await _dadService.AddDad(request));
        }

        [HttpGet("GetDadBy/{momId}")]
        public async Task<IActionResult> GetDadByMomId(string momId)
        {
            return Ok(await _dadService.GetDadByMomId(momId));
        }

        [HttpPut("UpdateDad/{Id}")]
        public async Task<IActionResult> UpdateDad(string Id, UpdateDadRequest request)
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
