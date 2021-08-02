using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Dtos.ActionChild;
using Mumbi.Application.Interfaces;
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

        [HttpGet("GetActionChildBy/{childId}")]
        public async Task<IActionResult> GetActionChildByChildId(string childId)
        {
            return Ok(await _actionChildService.GetActionChildByChildId(childId));
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
