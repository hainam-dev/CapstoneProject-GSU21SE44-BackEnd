using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildHistoryController : ControllerBase
    {
        private readonly IChildHistoryService _childHistoryService;

        public ChildHistoryController(IChildHistoryService childHistoryService)
        {
            _childHistoryService = childHistoryService;
        }

        [HttpGet("GetChildHistoryByChildId")]
        public async Task<IActionResult> GetChildHistoryByChildId([FromQuery] ChildHistoryRequest request)
        {
            if (!string.IsNullOrEmpty(request.Date) 
                && !DateTimeOffset.TryParseExact(request.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return BadRequest(new Response<string>("Incorrect date format"));
            }

            return Ok(await _childHistoryService.GetChildHistoryByChildId(request));
        }

        [HttpPut("UpdateChildHistory")]
        public async Task<IActionResult> UpdateChildHistory([FromQuery] ChildHistoryRequest request, [FromBody] UpdateChildHistoryRequest updateRequest)
        {
            if (string.IsNullOrEmpty(request.ChildId) || request.ChildId != updateRequest.ChildId)
            {
                return BadRequest(new Response<string>("ChildId not found"));
            }
            else
            {
                if (!DateTimeOffset.TryParseExact(request.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return BadRequest(new Response<string>("Incorrect date format"));
                }
            }

            return Ok(await _childHistoryService.UpdateChildHistory(request, updateRequest));
        }
    }
}