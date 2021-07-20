using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.ActionChild;
using Mumbi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionChildController : Controller
    {
        private readonly IActionChildService _actionChildService;

        public ActionChildController(IActionChildService actionChildService)
        {
            _actionChildService = actionChildService;
        }
        [HttpGet("GetActionChildBy/{childId}/{actionId}")]
        public async Task<IActionResult> GetActionChildByActionIdAndChildId(string childId, int actionId)
        {
            return Ok(await _actionChildService.GetActionChildByActionIdAndChildId(actionId, childId));

        }
        [HttpPost("UpsertActionChild/{childId}")]
        public async Task<IActionResult> UpsertActionChild(string childId, UpsertActionChildRequest request)
        {
            if (childId != request.ChildId)
            {
                return BadRequest();
            }
            return Ok(await _actionChildService.UpsertActionChild(request));
        }
    }
}
