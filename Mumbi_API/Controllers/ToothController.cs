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
        [HttpGet("GetToothByChildId/{childId}/{toothId}")]
        public async Task<IActionResult> GetToothByChildId(string childId, string toothId)
        {
            return Ok(await _toothService.GetToothByChildId(childId, toothId));

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
