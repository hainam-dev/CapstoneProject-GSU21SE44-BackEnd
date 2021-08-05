using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregnancyHistoryController : ControllerBase
    {
        private readonly IPregnancyHistoryService _pregnancyHistoryService;

        public PregnancyHistoryController(IPregnancyHistoryService pregnancyHistoryService)
        {
            _pregnancyHistoryService = pregnancyHistoryService;
        }

        [HttpGet("GetPregnancyHistoryByChildId")]
        public async Task<IActionResult> GetPregnancyHistoryByChildId([FromQuery] PregnancyHistoryRequest request)
        {
            return Ok(await _pregnancyHistoryService.GetPregnancyHistoryByChildId(request));
        }
        [HttpPut("UpdatePregnancyHistory")]
        public async Task<IActionResult> UpdatePregnancyHistory(UpdatePregnancyHistoryRequest request)
        {
            return Ok(await _pregnancyHistoryService.UpdatePregnancyHistory(request));
        }
    }
}
