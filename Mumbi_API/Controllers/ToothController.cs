using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.Tooths;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToothController : ControllerBase
    {
        private readonly IToothService _toothService;

        public ToothController(IToothService toothService)
        {
            _toothService = toothService;
        }
        [HttpGet("GetToothByToothId/{childId}/{toothId}")]
        public async Task<IActionResult> GetToothByToothId(string childId, string toothId)
        {
            return Ok(await _toothService.GetToothByToothId(childId, toothId));

        }
        [HttpGet("GetToothByChildId/{childId}")]
        public async Task<IActionResult> GetToothByChildId(string childId)
        {
            return Ok(await _toothService.GetToothByChildId(childId));

        }
        [HttpPost("UpsertTooth/{toothId}")]
        public async Task<IActionResult> UpsertToothRequest(string toothId,UpsertToothRequest request)
        {
            if (toothId != request.ToothId)
            {
                return BadRequest();
            }
            return Ok(await _toothService.UpsertToothRequest(request));
        }
    }
}
