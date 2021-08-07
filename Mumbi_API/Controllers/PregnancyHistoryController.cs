using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
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
            if (!string.IsNullOrEmpty(request.Date) && !DateTimeOffset.TryParse(request.Date, out _))
            {
                return BadRequest(new Response<string>("Incorrect date format"));
            }

            return Ok(await _pregnancyHistoryService.GetPregnancyHistoryByChildId(request));
        }

        [HttpPut("UpdatePregnancyHistory")]
        public async Task<IActionResult> UpdatePregnancyHistory([FromQuery] PregnancyHistoryRequest request, [FromBody]UpdatePregnancyHistoryRequest updateRequest)
        {
            if (string.IsNullOrEmpty(request.ChildId) || request.ChildId != updateRequest.ChildId)
            {
                return BadRequest(new Response<string>("ChildId not found"));
            }
            else
            {
                if (!DateTimeOffset.TryParse(request.Date, out _))
                {
                    return BadRequest(new Response<string>("Incorrect date format"));
                }
            }

            return Ok(await _pregnancyHistoryService.UpdatePregnancyHistory(request, updateRequest));
        }
    }
}