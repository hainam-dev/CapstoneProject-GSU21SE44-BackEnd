using Microsoft.AspNetCore.Mvc;
using Mumbi.Application.Interfaces;
using System.Threading.Tasks;

namespace Mumbi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : Controller
    {
        private readonly IActionService _actionService;

        public ActionController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet("GetActionBy/{type}")]
        public async Task<IActionResult> GetActionByType(string type)
        {
            return Ok(await _actionService.GetActionByType(type));
        }
    }
}
